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

namespace SPZlab1
{
    public partial class ViewPersonnelTable : Form
    {
        SqlConnection sqlConnection;
        public ViewPersonnelTable()
        {
            InitializeComponent();
        }

        private async void ViewPersonnelTable_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Алексей\source\repos\SPZlab1\SPZlab1\ZooDatabase.mdf; Integrated Security = True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [People]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]) + "  " + Convert.ToString(sqlReader["Login"]) + "  " + Convert.ToString(sqlReader["Password"]) + " " + Convert.ToString(sqlReader["FIO"]) + "  " + Convert.ToString(sqlReader["Position"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private void ViewPersonnelTable_FormClosing(object sender, FormClosingEventArgs e)//при завершени роботы с окном просмотра обрывать соединение с БД
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }
    }
}
