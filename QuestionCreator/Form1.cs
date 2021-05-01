﻿using System;
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
using QuestionCreator.Models;

namespace QuestionCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = $"Работа с вопросами для легкого теста ver.{Application.ProductVersion}";

            ToolStripMenuItem fileItem = new ToolStripMenuItem("Файл");
            fileItem.DropDownItems.Add("Открыть json");
            fileItem.DropDownItems.Add(new ToolStripMenuItem("Сохранить json"));

            fileItem.DropDownItemClicked += FileItem_Click;
            menuStrip1.Items.Add(fileItem);

            ToolStripMenuItem openImage = new ToolStripMenuItem("Открыть изображение");
            ToolStripMenuItem cleanImage = new ToolStripMenuItem("Очистить");

            openImage.Click += openImage_Click;
            cleanImage.Click += cleanImage_Click;

            contextMenuStrip1.Items.AddRange(new[] { openImage, cleanImage });

            pictureBox1.ContextMenuStrip = contextMenuStrip1;

        }

        Image image;
        Boolean opened = false;
        string answer = "test";
        string image_location = "";
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
                opened = true;
                image_location = openFileDialog1.FileName;
            }
        }

        private void cleanImage_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void saveJson()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = ".json|*.json";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string filename = sfd.FileName;

                EasyQuestionViewModel json = new EasyQuestionViewModel
                {
                    ImageBase64 = ($"data:image/jpeg; base64,{Convert.ToBase64String(File.ReadAllBytes(image_location))}"),
                    Options = new string[]
                    {
                        textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text
                    },
                    CorrectAnswer = answer,
                    SelectedAnswer = "0"
                };
                MessageBox.Show(filename);
                File.WriteAllText(filename, JsonConvert.SerializeObject(json, Formatting.Indented));
                Application.Restart();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveJson();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "" & textBox4.Text != "")
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
    }
}