using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Padlockr
{
    public interface ISqliteWrapper
    {
        bool PassCheck();
        bool PassCheck(string pass);
        void ConnCommand(SQLiteConnection conn, string query);
        void RunCommand(string query);
        void SetConnectionStrings(string dbDir, string pass);
        DataTable GetDataTable(string query);
        void OpenDbConnection();
        void SetInsecureConnection(bool open = true);
        void CloseDbConnection();
        void ChangePass(string newPass);
        void SetPassword(string pass);
    }

    public class SqliteWrapper : ISqliteWrapper
    {
        private SQLiteConnection _conn;
        private string _dbUnlock;

        // Check if password unlocks the DB
        public bool PassCheck()
        {
            // Password check result output variable
            bool pc;

            try
            {
                _conn = new SQLiteConnection(_dbUnlock);


                // Open connection
                _conn.Open();

                // Execute query against DB
                ConnCommand(_conn, "SELECT * FROM PDB ORDER BY ACC_NAME ASC LIMIT 1;");

                // Result true
                pc = true;
            }
            catch
            {
                // Result false
                pc = false;
            }
            finally
            {
                // Close connection
                _conn.Close();
            }

            // Returns whether pass is correct of not
            return pc;
        }

        public bool PassCheck(string pass)
        {
            // Password check result output variable
            bool pc;

            try
            {
                _conn = new SQLiteConnection(_dbUnlock);

                // Open connection
                _conn.Open();

                // Execute query against DB
                ConnCommand(_conn, "SELECT * FROM PDB ORDER BY ACC_NAME ASC LIMIT 1;");

                // Result true
                pc = true;
            }
            catch
            {
                // Result false
                pc = false;
            }
            finally
            {
                // Close connection
                _conn.Close();
            }

            // Returns whether pass is correct of not
            return pc;
        }

        // SQLite Command executor
        public void ConnCommand(SQLiteConnection conn, string query)
        {
            using (var c = conn.CreateCommand())
            {
                // Insert command text
                c.CommandText = query;

                // Execute command
                c.ExecuteNonQuery();
            }
        }

        public void RunCommand(string query)
        {
            using (var c = _conn.CreateCommand())
            {
                // Insert command text
                c.CommandText = query;

                // Execute command
                c.ExecuteNonQuery();
            }
        }

        // Controls the storing of connection strings
        public void SetConnectionStrings(string dbDir, string pass)
        {
            _dbUnlock = "Data Source=" + dbDir + ";Version=3;Password=" + pass + ";";
        }

        // Gets all the data rows from the database table PDB
        public DataTable GetDataTable(string query)
        {
            var dt = new DataTable();

            try
            {
                OpenDbConnection();

                using (var c = _conn.CreateCommand())
                {
                    c.CommandText = query;
                    var reader = c.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            finally
            {
                CloseDbConnection();
            }

            return dt;
        }

        public void OpenDbConnection()
        {
            // Sets connection info ready for connection
            _conn = new SQLiteConnection(_dbUnlock);

            if(_conn.State != ConnectionState.Open)
                _conn.Open();
        }

        public void SetInsecureConnection(bool open = true)
        {
            var insecureConString = _dbUnlock
                .Split(new[] {"Password="}, StringSplitOptions.None)
                .First();

            // Sets connection info ready for connection
            _conn = new SQLiteConnection(insecureConString);

            if (open && _conn.State != ConnectionState.Open)
                _conn.Open();
        }

        public void CloseDbConnection()
        {
            if (_conn.State == ConnectionState.Closed)
                return;

            _conn.Close();
        }

        public void ChangePass(string newPass)
        {
            _conn.ChangePassword(newPass);
        }

        public void SetPassword(string pass)
        {
            _conn.SetPassword(pass);
        }
    }
}