
namespace FirstWinFormApp
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
            this.myTextBox = new System.Windows.Forms.TextBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // myTextBox
            // 
            this.myTextBox.Location = new System.Drawing.Point(453, 51);
            this.myTextBox.Name = "myTextBox";
            this.myTextBox.Size = new System.Drawing.Size(354, 20);
            this.myTextBox.TabIndex = 0;
            this.myTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btAdd
            // 
            this.btAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdd.Location = new System.Drawing.Point(27, 51);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(118, 34);
            this.btAdd.TabIndex = 1;
            this.btAdd.Text = "Add Button";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(btAdd_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1010, 580);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.myTextBox);
            this.Name = "Form1";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1; //1. defined component
        private System.Windows.Forms.TextBox myTextBox;
        private System.Windows.Forms.Button btAdd;
    }
}

