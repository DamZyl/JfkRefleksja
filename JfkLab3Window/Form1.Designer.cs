namespace JfkLab3Window
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openButton = new System.Windows.Forms.Button();
            this.catalogTree = new System.Windows.Forms.TreeView();
            this.description = new System.Windows.Forms.Label();
            this.argumentText = new System.Windows.Forms.TextBox();
            this.argument = new System.Windows.Forms.Label();
            this.resultText = new System.Windows.Forms.TextBox();
            this.result = new System.Windows.Forms.Label();
            this.executeButton = new System.Windows.Forms.Button();
            this.descriptionText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(13, 13);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "Otwórz";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // catalogTree
            // 
            this.catalogTree.Location = new System.Drawing.Point(12, 42);
            this.catalogTree.Name = "catalogTree";
            this.catalogTree.Size = new System.Drawing.Size(450, 293);
            this.catalogTree.TabIndex = 1;
            this.catalogTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.CatalogTree_AfterSelect);
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Location = new System.Drawing.Point(514, 42);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(31, 13);
            this.description.TabIndex = 3;
            this.description.Text = "Opis:";
            // 
            // argumentText
            // 
            this.argumentText.Location = new System.Drawing.Point(124, 344);
            this.argumentText.Name = "argumentText";
            this.argumentText.Size = new System.Drawing.Size(257, 20);
            this.argumentText.TabIndex = 4;
            // 
            // argument
            // 
            this.argument.AutoSize = true;
            this.argument.Location = new System.Drawing.Point(13, 344);
            this.argument.Name = "argument";
            this.argument.Size = new System.Drawing.Size(55, 13);
            this.argument.TabIndex = 6;
            this.argument.Text = "Argument:";
            // 
            // resultText
            // 
            this.resultText.Location = new System.Drawing.Point(124, 377);
            this.resultText.Name = "resultText";
            this.resultText.Size = new System.Drawing.Size(257, 20);
            this.resultText.TabIndex = 7;
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(13, 377);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(40, 13);
            this.result.TabIndex = 8;
            this.result.Text = "Wynik:";
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(387, 342);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(75, 23);
            this.executeButton.TabIndex = 9;
            this.executeButton.Text = "Wykonaj";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // descriptionText
            // 
            this.descriptionText.Location = new System.Drawing.Point(517, 59);
            this.descriptionText.Multiline = true;
            this.descriptionText.Name = "descriptionText";
            this.descriptionText.Size = new System.Drawing.Size(258, 306);
            this.descriptionText.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.descriptionText);
            this.Controls.Add(this.executeButton);
            this.Controls.Add(this.result);
            this.Controls.Add(this.resultText);
            this.Controls.Add(this.argument);
            this.Controls.Add(this.argumentText);
            this.Controls.Add(this.description);
            this.Controls.Add(this.catalogTree);
            this.Controls.Add(this.openButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.TreeView catalogTree;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.TextBox argumentText;
        private System.Windows.Forms.Label argument;
        private System.Windows.Forms.TextBox resultText;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.TextBox descriptionText;
    }
}

