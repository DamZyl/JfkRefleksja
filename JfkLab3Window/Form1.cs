using JfkLab3Interface;
using System;
using System.IO;
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
                AddType(type, newNode);
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
                foreach(var file in files)
                { 
                    if(file.EndsWith("dll") || file.EndsWith("exe"))
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
                var selectedType = catalogTree.SelectedNode.Parent.Parent.Tag as Type;

                if (!(Activator.CreateInstance(selectedType) is IMyMethods myMethods))
                {
                    throw new InvalidOperationException();
                }

                MethodInfo method = catalogTree.SelectedNode.Tag as MethodInfo;

                object[] argument = new object[1];
                argument[0] = argumentText.Text as object;
                
                try
                {
                    object result = method.Invoke(myMethods, argument);
                    resultText.Text = result.ToString();
                }

                catch (Exception exp)
                {
                    MessageBox.Show("Błąd: " + exp.ToString());
                }
            }
        }

        private void CatalogTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (catalogTree.SelectedNode?.Tag is MethodInfo selectedMethod)
            {
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
