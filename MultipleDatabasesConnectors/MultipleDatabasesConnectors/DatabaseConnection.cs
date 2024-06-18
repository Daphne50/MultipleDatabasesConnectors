using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace MultipleDatabasesConnectors
{

    public abstract class DatabaseConnection
    {
            
        protected IDbConnection connection;

        public abstract void Connect();

        public abstract DataTable GetTables();

        public abstract DataTable GetTableData(string tableName);
    }

    public class SQLiteConnection : DatabaseConnection
    {
        public override void Connect()
        {
            connection = new SQLiteConnection("Data Source=your_database.db;Version=3;");
            connection.Open();
        }

        public override DataTable GetTables()
        {
            DataTable schema = connection.GetSchema("Tables");
            return schema;
        }

        public override DataTable GetTableData(string tableName)
        {
            string query = $"SELECT * FROM {tableName}";
            IDbCommand command = connection.CreateCommand();
            command.CommandText = query;
            IDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            reader.Close();
            return dataTable;
        }
    }

    public class AccessConnection : DatabaseConnection
    {
        public override void Connect()
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=your_database.accdb;");
            connection.Open();
        }

        public override DataTable GetTables()
        {
            DataTable schema = connection.GetSchema("Tables");
            return schema;
        }

        public override DataTable GetTableData(string tableName)
        {
            string query = $"SELECT * FROM {tableName}";
            IDbCommand command = connection.CreateCommand();
            command.CommandText = query;
            IDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            reader.Close();
            return dataTable;
        }
    }

    public class MySQLConnection : DatabaseConnection
    {
        public override void Connect()
        {
            connection = new MySqlConnection("Server=localhost;Database=forum;Uid=root;Pwd=;");
            connection.Open();
        }

        public override DataTable GetTables()
        {
            DataTable schema = connection.GetSchema("Tables");
            return schema;
        }

        public override DataTable GetTableData(string tableName)
        {
            string query = $"SELECT * FROM {tableName}";
            IDbCommand command = connection.CreateCommand();
            command.CommandText = query;
            IDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            reader.Close();
            return dataTable;
        }
    }
}