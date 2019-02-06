using JfkLab3Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace JfkLab3Window
{
    public partial class Form1 : Form
    {
        private Assembly assembly;

        public Form1()
        {
            InitializeComponent();
        }

        private static void AddModule(Module module, TreeNode parent)
        {
            var newNode = new TreeNode(module.Name) { Tag = module };
            parent.Nodes.Add(newNode);

            foreach (var type in module.GetTypes())
            {
                if (typeof(IMyMethod).IsAssignableFrom(type))
                {
                    AddType(type, newNode);
                }
            }
        }

        private static void AddType(Type type, TreeNode parent)
        {
            var newNode = new TreeNode(type.Name) { Tag = type };
            var memberTypeNode = new TreeNode();
            TreeNode memberNode;

            memberTypeNode = new TreeNode("Methods");

            foreach (var method in type.GetMethods())
            {
                var count = method.GetParameters().Length;
                var stringBuilder = new StringBuilder(method.Name).Append('(');

                foreach (var param in method.GetParameters())
                {
                    stringBuilder.Append(param.ParameterType);

                    if (param.Position < count - 1)
                    {
                        stringBuilder.Append(", ");
                    }
                }

                stringBuilder.Append(')');
                memberNode = new TreeNode(stringBuilder.ToString()) { Tag = method };
                memberTypeNode.Nodes.Add(memberNode);
            }

            newNode.Nodes.Add(memberTypeNode);
            parent.Nodes.Add(newNode);
        }

        private void PopulateTree()
        {
            var newNode = new TreeNode(assembly.GetName().Name) { Tag = assembly };
            catalogTree.Nodes.Add(newNode);

            foreach (var module in assembly.GetModules())
            {
                AddModule(module, newNode);
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            catalogTree.Nodes.Clear();
            descriptionText.Text = string.Empty;

            string[] files = null;

            using (var catalog = new FolderBrowserDialog())
            {
                DialogResult result = catalog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    files = Directory.GetFiles(catalog.SelectedPath);
                }
            }

            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file.EndsWith("dll") || file.EndsWith("exe"))
                    {
                        assembly = Assembly.LoadFrom(file);
                        PopulateTree();
                    }
                }
            }
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            if (catalogTree.SelectedNode?.Tag is MethodInfo)
            {
                MethodInfo interfaceMethod = (MethodInfo)catalogTree.SelectedNode.Tag;
                var selectedType = catalogTree.SelectedNode.Parent.Parent.Tag as Type;
               
                if (typeof(double).IsAssignableFrom(interfaceMethod.ReturnType))
                {
                    if (double.TryParse(argumentText.Text, out double x))
                    {
                        if (!(Activator.CreateInstance(selectedType) is IMyMethod myMethod))
                        {
                            throw new InvalidOperationException();
                        }

                        double result = myMethod.Method(x);

                        if (result == -1)
                        {
                            informationText.Text = "Metoda jest nadpisaną metodą interfejsu IMyMethodInterface, ale podany został zły parametr wejściowy. Proszę postępować zgodnie z opisem metody !!!";
                            resultText.Text = String.Empty;
                        }

                        else
                        {
                            informationText.Text = "Metoda jest nadpisaną metodą interfejsu IMyMethodInterface";
                            resultText.Text = result.ToString();
                        }
                    }

                    else
                    {
                        informationText.Text = "Podany został nieodpowiedni typ parametru !!!";
                        resultText.Text = String.Empty;
                    }
                }

                else
                {

                    informationText.Text = "Metoda nie jest nadpisaną metodą interfejsu IMyMethodInterface, wybierz metodę Method !!!";
                    resultText.Text = String.Empty;
                }
            }
        }

        private void CatalogTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (catalogTree.SelectedNode?.Tag is MethodInfo selectedMethod)
            {
                informationText.Text = String.Empty;
                resultText.Text = String.Empty;

                if (selectedMethod.GetCustomAttribute<DescriptionAttribute>(true) != null)
                {
                    descriptionText.Text = selectedMethod.GetCustomAttribute<DescriptionAttribute>().Description;
                }

                else
                {
                    descriptionText.Text = "Metoda nie implementuje interfejsu IMyMethods";
                }
            }

            else
            {
                descriptionText.Text = string.Empty;
            }
        }
    }
}
