using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;

namespace Dentistry.General
{
    class General
    { 
        private string[] text;
        private FolderBrowserDialog folderBrowserDialog1;
        private OpenFileDialog openFileDialog1;

        public General() { }
        public General(string[] str)
        {
            text = str;
        }
        public void SaveToWordFile()
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            openFileDialog1 = new OpenFileDialog();

            //Стрінговий масив ключів з Word файла 
            string[] keys = { "{name}", "{dateOfBirthday}", "{phoneNumber}", "{address}", "{dateOfCreating}", "{s}", "{diagnosis}",
            "{complaint}","{doneDiseases}","{currentDiseas}","{survayData","{bite}","{mouthState}","{xReyDate}","{colorVita}",
            "{dateOfLessons}","{controlDate}","{survayPlan}","{treatmentPlan}"};

            var wordApp = new Word.Application();
            wordApp.Visible = false;

            try
            {
                var wordDocument = wordApp.Documents.Open(@Properties.Settings.Default.NewMedCardFile);

                // Передача та запис інформації в Word файл
                for(int i = 0; i < keys.Length;i++)
                {
                    ReplaceWordStub(keys[i], text[i], wordDocument);
                }

                string path = null;
                using (var dialog = new FolderBrowserDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        path = dialog.SelectedPath;
                        Properties.Settings.Default.Name = path;
                        Properties.Settings.Default.Save();
                        wordDocument.SaveAs(@path + "\\" + text[0] + ".docx");
                        MessageBox.Show("Успішно експортовано!!!");
                    }
                }

                wordApp.ActiveDocument.Close();
                wordApp.Quit();
            }
            catch
            {
                string message = "Хибний шлях до екземпляру. Бажаєте задати новий шлях?";
                string caption = "Проблема встановлення зв'язку.";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    
                    openFileDialog1.Filter = ".docx file (*.docx)|*.docx";
                    openFileDialog1.FilterIndex = 1;
                    openFileDialog1.Multiselect = false;

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string sFileName = openFileDialog1.FileName;
                        Properties.Settings.Default.NewMedCardFile = sFileName;
                        Properties.Settings.Default.Save();
                        if (Properties.Settings.Default.NewMedCardFile != null)
                        {
                            MessageBox.Show("Шлях до екземпляру успішно збережений! Повторіть спробу зберегти вашу інформацію.");
                        }
                    }
                }
            }
        }
        private void ReplaceWordStub(string stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }

    }
}
