using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using System.Collections;

namespace Dentistry.General
{
    class NewMedCard
    {
        private string[] text;
        private FolderBrowserDialog folderBrowserDialog1;
        private OpenFileDialog openFileDialog1;

        public NewMedCard() { }
        public NewMedCard(string[] str)
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
                for (int i = 0; i < keys.Length; i++)
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
    class EditMedCard // Not Ready
    {
        ArrayList DateList = new ArrayList();
        ArrayList InfoList = new ArrayList();

        private string[] text;
        private OpenFileDialog openFileDialog1;

        public EditMedCard() { }
        public EditMedCard(string[] str)
        {
            text = str;
        }

        public void SaveToWordFile()
        {
            try
            {
                rewriteInfo(@Properties.Settings.Default.NewMedCardFile);
            }
            catch
            {
                string message = "Виникли проблеми при спробі зберегти інформацію у вже існуючий файл. Бажаєте вказати шлях?";
                string caption = "Проблема при редагуванні.";
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
                        Properties.Settings.Default.ExistMedCardFile = sFileName;
                        if (Properties.Settings.Default.ExistMedCardFile != null)
                        {
                            MessageBox.Show("Успішно збережено!");
                            rewriteInfo(@Properties.Settings.Default.ExistMedCardFile);
                        }
                    }
                }
            }
        }

        private void rewriteInfo(string way)
        {
            var wordApp = new Word.Application();
            wordApp.Visible = false;

            var wordDocument = wordApp.Documents.Open(way);

            string[] keys = { "{name}", "{dateOfBirthday}", "{phoneNumber}", "{address}", "{dateOfCreating}", "{s}", "{diagnosis}",
            "{complaint}","{doneDiseases}","{currentDiseas}","{survayData","{bite}","{mouthState}","{xReyDate}","{colorVita}",
            "{dateOfLessons}","{controlDate}","{survayPlan}","{treatmentPlan}"};

            int a = 1;
            int i = 0;
            int b = 2;
            while (i < DateList.Count)
            {
                var date = (string)DateList[i];
                var description = (string)InfoList[i];

                ReplaceWordStub("{date1}", date, wordDocument);
                ReplaceWordStub("{description1}", description, wordDocument);
                do
                {
                    replaceDateWord("{date" + a + "}", "{date" + b + "}", wordDocument);
                    replaceDateWord("{description" + a + "}", "{description" + b + "}", wordDocument);
                    a++;
                    b++;
                } while (a <= 24 && b <= 23);
                i++;
            }

            // Передача та запис інформації в Word файл
            for (int g = 0; g < keys.Length; g++)
            {
                ReplaceWordStub(keys[g], text[g], wordDocument);
            }



            wordDocument.SaveAs(@Properties.Settings.Default.Name + "\\" + text[0] + ".docx");
            MessageBox.Show("Успішно експортовано!!!");

            wordApp.ActiveDocument.Close();
            wordApp.Quit();
        }
        private void replaceDateWord(string stubToReplace, string replaceDate, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: replaceDate, ReplaceWith: stubToReplace);
        }
        private void ReplaceWordStub(string stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }

    }
}
