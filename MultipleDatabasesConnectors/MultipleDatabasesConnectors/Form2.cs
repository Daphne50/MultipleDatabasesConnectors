using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultipleDatabasesConnectors
{
    public partial class Form2 : Form
    {
        private DatabaseConnection dbConnection;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }


        private void SQLiteButton_Click(object sender, EventArgs e)
        {
            dbConnection = new SQLiteConnection();
            dbConnection.Connect();
            ListTables();
        }

        private void AccessButton_Click(object sender, EventArgs e)
        {
            dbConnection = new AccessConnection();
            dbConnection.Connect();
            ListTables();
        }

        private void MySQLButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("asdasda");
            dbConnection = new MySQLConnection();
            dbConnection.Connect();
            ListTables();
        }

        private void ListTables()
        {
            listBox2.Items.Clear();
            DataTable tables = dbConnection.GetTables();
            foreach (DataRow row in tables.Rows)
            {
                listBox2.Items.Add(row["TABLE_NAME"].ToString());
            }
        }

        private void listBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTableName = listBox2.SelectedItem.ToString();
            DisplayTableData(selectedTableName);
        }

        private void DisplayTableData(string tableName)
        {
            DataTable tableData = dbConnection.GetTableData(tableName);
            dataGridView1.DataSource = tableData;
        }
    }
}



        
