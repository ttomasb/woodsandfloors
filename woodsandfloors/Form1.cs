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
using System.Text.RegularExpressions;
using RecentEntriesLib;

namespace woodsandfloors
{
    public partial class Form1 : Form
    {
        
        RecentEntries folderPathEntries;

        public Form1()
        {
            InitializeComponent();
            folderPathEntries = new RecentEntries(sourceFolderPathComboBox.Name);

            var recentEntriesList = folderPathEntries.GetEntires().ToList();
            if (recentEntriesList.Count > 0)
            {
                sourceFolderPathComboBox.DataSource = recentEntriesList;
                sourceFolderPathComboBox.SelectedIndex = 0;
            }
        }

        private void selectSourceFolderButton_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.SelectedPath = sourceFolderPathComboBox.Text;
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    sourceFolderPathComboBox.Text = folderDialog.SelectedPath;
                }
            }
        }

        string CreateInsertPhotoSqlLine(string directory, string file, int sequence)
        {
            string photoCategory = new DirectoryInfo(directory).Name;
            string photoName = new DirectoryInfo(file).Name;
            string title = photoCategory;
            string ordinal = Regex.Match(photoName, @"\d+").Value; ;
            string insertQuery = string.Format("INSERT INTO `gallery`( `Name`, `Title`, `Category`, `sequence`) VALUES ('{0}','{1}','{2}',{3});", photoName, title, photoCategory, ordinal);
            return insertQuery;
        }

        string CreateInsertProductSqlLine(string directory, string file, int sequence)
        {
            string category = new DirectoryInfo(directory).Name;
            string name = new DirectoryInfo(file).Name;
            string cat = category;
            string[] data = name.Split('-');
            string color = data[1];
            string title = data[0] + "-" + data[1];
            string insertQuery = string.Format(
                @"INSERT INTO `products`
                (`product_code`, `title`, `price`, `category`, `description`, `short_description`, `thickness`, `width`, `shade`, `species`, `color`, `photo`, `detail1`, `detail2`, `detail3`, `detail4`, `detail5`) 
                VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}');",
                data[0],
                title,
                "0",
                "Ecowood",
                "",
                "SYMMETRICALLY BALANCED 3-LAYER OAK FLOORING",
                "0",
                "0",
                "shade from db",
                "species form db",
                color,
                name,
                "2 x OAK STRUCTURE",
                "Top layer: 4.0 mm European Oak (Quercus robur)",
                "Middle layer: 6.5 mm High Quality water resistant birch plywood",
                "Base layer: 4.0 mm Finger-jointed Oak",
                "");

            return insertQuery;
        }
        void BuildScript(string RootFolderDirectiory, string insertObjects)
        {

            foreach (string directoryFolder in Directory.GetDirectories(RootFolderDirectiory))
            {

                if (!directoryFolder.Contains("thumbnails"))
                {
                    int ordinal = 1;
                    foreach (string file in Directory.GetFiles(directoryFolder, "*.JPG"))
                    {
                        switch (insertObjects)
                        {
                            case "Products":
                                AddProductInsertLineToScript(directoryFolder, ordinal, file);
                                break;
                            case "Photos":
                                AddPhotoInsertLineToScript(directoryFolder, ordinal, file);
                                break;
                        }
                        ordinal++;
                    }
                }
                BuildScript(directoryFolder, insertObjects);
            }
        }

        private void AddPhotoInsertLineToScript(string directoryFolder, int ordinal, string file)
        {
            if (resultScriptRichTextBox.Text != "") resultScriptRichTextBox.Text += Environment.NewLine;
            resultScriptRichTextBox.Text += CreateInsertPhotoSqlLine(directoryFolder, file, ordinal);
        }

        private void AddProductInsertLineToScript(string directoryFolder, int ordinal, string file)
        {
            if (resultScriptRichTextBox.Text != "") resultScriptRichTextBox.Text += Environment.NewLine;
            resultScriptRichTextBox.Text += CreateInsertProductSqlLine(directoryFolder, file, ordinal);
        }



        private void CreateInsertPhotosButton_Click(object sender, EventArgs e)
        {
            try
            {
                BuildScript(sourceFolderPathComboBox.Text, "Photos");
                UpdateLastEntries();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateInsertProductsButton_Click(object sender, EventArgs e)
        {
            try
            {
                BuildScript(sourceFolderPathComboBox.Text, "Products");
                UpdateLastEntries();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateLastEntries()
        {
            folderPathEntries.AddAndSaveEntry(sourceFolderPathComboBox.Text);
            sourceFolderPathComboBox.DataSource = folderPathEntries.GetEntires().ToList();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            try
            {
                resultScriptRichTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
