using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstWinFormApp
{
    public partial class Form1 : Form
    {
        List<Button> list;
        public Form1()
        {
            list = new List<Button>();
            InitializeComponent();
            //CreateNewButton();
        }

        //void CreateNewButton()
        //{
        //    // 2. Init component
        //    btNewButton = new Button();
        //    // 3. Design component
        //    btNewButton.Text = "New Button";
        //    btNewButton.Size = new Size(btClickMe.Size.Width, btClickMe.Size.Height);
        //    btNewButton.Location = 
        //        new Point(btClickMe.Location.X, btClickMe.Location.Y + btClickMe.Size.Height + 20);
        //    btNewButton.Click += new EventHandler(btNewButton_Click);
        //    // 4. Add component to Control
        //    this.Controls.Add(btNewButton);
        //}

        //private void btClickMe_Click(object sender, EventArgs e)
        //{
        //    Button button = (Button)sender;
        //    MessageBox.Show($"Just click a {button.Text}");
        //}

        //private void btNewButton_Click(object sender, EventArgs e)
        //{
        //    Button button = (Button)sender;
        //    MessageBox.Show($"Just click a {button.Text}" );
        //}

        private void btAdd_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            // init value check form width
            int formHeight = this.ClientSize.Height;

            // 1. Define/init new btn
            Button button = new Button();
            // 2. Design new button
            button.Text = "New Button Added";
            button.Size = new Size(btAdd.Size.Width, btAdd.Size.Height);

            if(list.Count == 0)
            {
                button.Location =
                    new Point(btAdd.Location.X,
                        btAdd.Location.Y + btAdd.Size.Height + 10);
            }
            else
            {
                // check previous btn localtion
                Button previousBtn = this.list[list.Count - 1];
                if(previousBtn.Location.Y + 10 > formHeight)
                {
                    button.Location =
                        new Point(btAdd.Location.X + previousBtn.Width + 20,
                            btAdd.Location.Y + btAdd.Size.Height + 10);
                }
                else
                {
                    button.Location =
                        new Point(previousBtn.Location.X,
                            previousBtn.Location.Y + previousBtn.Size.Height + 10);
                }
            }

            list.Add(button);
            myTextBox.Text = $"{list.Count} button added into form";
            this.Controls.Add(button);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
