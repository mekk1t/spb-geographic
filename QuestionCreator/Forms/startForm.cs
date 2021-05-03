using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestionCreator.Forms
{
    public partial class startForm : Form
    {
        public startForm()
        {
            InitializeComponent();

            Text = $"{Application.ProductName} ver.{Application.ProductVersion}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Easy easy = new Easy();
            easy.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Medium medium = new Medium();
            medium.Show();
            this.Hide();
        }
    }
}
