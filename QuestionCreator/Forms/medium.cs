using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using QuestionCreator.Forms;
using WebApplication.Models.Medium;

namespace QuestionCreator.Forms
{
    public partial class Medium : Form
    {
        public Medium()
        {
            InitializeComponent();
            FormClosed += Form_Closed;

            richTextBox1.TextChanged += TextBox_TextChanged;
            richTextBox2.TextChanged += TextBox_TextChanged;
            richTextBox2.TextChanged += richTextBox2_TextChanged;

            Text = $"Работа с вопросами для среднего теста ver.{Application.ProductVersion}";
            label4.Text = "";
            ToolStripMenuItem openImage = new ToolStripMenuItem("Открыть изображение");
            ToolStripMenuItem cleanImage = new ToolStripMenuItem("Очистить");

            openImage.Click += openImage_Click;
            cleanImage.Click += cleanImage_Click;

            contextMenuStrip1.Items.AddRange(new[] { openImage, cleanImage });
            pictureBox1.ContextMenuStrip = contextMenuStrip1;
        }

        Image image;
        bool opened = false;
        string image_location;
        string pictureName;
        List<string> possible_answers;
        public void openImage_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = openFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = image;
                image_location = openFileDialog1.FileName;

                pictureName = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);

                label1.Text = pictureName;
                label1.Visible = true;
                opened = true;
            }
        }

        private void cleanImage_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            opened = false;
            label1.Visible = false;
        }

        private void saveJson()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Файлы в формате JSON(.json)|*.json";
            sfd.FileName = pictureName;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string filename = sfd.FileName;

                MediumQuestionViewModel json = new MediumQuestionViewModel
                {
                    Question = richTextBox1.Text,
                    PossibleAnswers = possible_answers,
                    Thumbnail = ($"data:image/jpeg; base64,{Convert.ToBase64String(File.ReadAllBytes(image_location))}")
                };
                MessageBox.Show(filename);
                File.WriteAllText(filename, JsonConvert.SerializeObject(json, Formatting.Indented));
                Close();
                Medium medium = new Medium();
                medium.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (opened) {
            saveJson();
            } else
            {
                MessageBox.Show("Вы картиночку забыли");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms[0];
            form.Show();
            Close();
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            Form form = Application.OpenForms[0];
            form.Show();
            Controls.Clear();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "" & richTextBox2.Text != "")
            {
                button1.Enabled = true;
            } else
            {
                button1.Enabled = false;
            }
        }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            possible_answers = richTextBox2.Text.Split(';').ToList();
            label4.Text = $"Количество возможных ответов: {possible_answers.Count}";
        }
    }
}
