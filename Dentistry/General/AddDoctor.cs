using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dentistry.General
{
    public partial class AddDoctor : Form
    {
        SqlConnection testCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GoogleDrive InSoP\Stomatology\Stomatology\DataStomatology.mdf;Integrated Security=True;Connect Timeout=30");
        public AddDoctor()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            saveToDataBase();
        }
        private void saveToDataBase()
        {
            try
            {
                if (txtName.Text.Length == 0 || txtAddress.Text.Length == 0 || txtPhoneNumber.Text.Length == 0)
                    throw new Exception("Не всі поля заповнені!");
                else
                {

                    testCon.Open();
                    SqlCommand cmd = testCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"INSERT INTO Doctor ( Name, Adress, Number) " +
                        $"values ( N'{txtName.Text}',  N'{txtAddress.Text}',  N'{txtPhoneNumber.Text}')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Додано нового Лікаря.");
                    testCon.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                testCon.Close();

            }
        }
    }
}
