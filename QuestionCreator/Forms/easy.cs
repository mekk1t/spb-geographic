using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using QuestionCreator.Forms;
using WebApplication.Models.Easy;

namespace QuestionCreator
{
    public partial class Easy : Form
    {
        public Easy()
        {
            InitializeComponent();
            FormClosed += Form_Closed;
            Text = $"Работа с вопросами для легкого теста ver.{Application.ProductVersion}";

            //ToolStripMenuItem fileItem = new ToolStripMenuItem("Файл");
            //fileItem.DropDownItems.Add("Открыть json");
            //fileItem.DropDownItems.Add(new ToolStripMenuItem("Сохранить json"));

            //fileItem.DropDownItemClicked += FileItem_Click;
            //menuStrip1.Items.Add(fileItem);

            ToolStripMenuItem openImage = new ToolStripMenuItem("Открыть изображение");
            ToolStripMenuItem cleanImage = new ToolStripMenuItem("Очистить");

            openImage.Click += openImage_Click;
            cleanImage.Click += cleanImage_Click;

            contextMenuStrip1.Items.AddRange(new[] { openImage, cleanImage });

            pictureBox1.ContextMenuStrip = contextMenuStrip1;

        }

        Image image;
        string answer;
        string image_location;
        string pictureName;
        private void FileItem_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            string action = e.ClickedItem.Text;
            switch (action)
            {
                case "Сохранить json":
                    saveJson();
                    break;
            }
        }

        public void openImage_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = openFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = image;
                image_location = openFileDialog1.FileName;

                pictureName = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);

                label3.Text = pictureName;
                label3.Visible = true;
            }
        }

        private void cleanImage_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void saveJson()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Файлы в формате JSON(.json)|*.json";
            sfd.FileName = pictureName;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string filename = sfd.FileName;

                EasyQuestionViewModel json = new EasyQuestionViewModel
                {
                    Question = richTextBox1.Text,
                    Options = new string[]
                    {
                        textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text
                    },
                    CorrectAnswer = answer,
                    SelectedAnswer = "0",
                    ImageBase64 = ($"data:image/jpeg; base64,{Convert.ToBase64String(File.ReadAllBytes(image_location))}")
                };
                MessageBox.Show(filename);
                File.WriteAllText(filename, JsonConvert.SerializeObject(json, Formatting.Indented));
                Close();
                Easy easy = new Easy();
                easy.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveJson();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "" & textBox4.Text != "" & richTextBox1.Text != "")
            {
                button1.Enabled = true;
            }
        }

        void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == null)
            {
                return;
            }
            if (rb.Checked)
            {
                string action = rb.Text;
                switch (action)
                {
                    case "1":
                        answer = textBox1.Text;
                        break;
                    case "2":
                        answer = textBox2.Text;
                        break;
                    case "3":
                        answer = textBox3.Text;
                        break;
                    case "4":
                        answer = textBox4.Text;
                        break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms[0];
            form.Show();
            Close();
        }

        private void Form_Closed( object sender, FormClosedEventArgs e)
        {
            Form form = Application.OpenForms[0];
            form.Show();
            Controls.Clear();
        }
    }
}
