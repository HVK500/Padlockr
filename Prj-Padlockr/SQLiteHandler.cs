using System;
using System.Data;
using System.Data.SQLite;

namespace Prj_Padlockr
{
    public class SqLiteHandler
    {
        // Locker object makes sure the working thead is locked on the task needed
        private static readonly object Locker = new object();
        // Connection object
        private SQLiteConnection _conn;

        // Sqlite connection string
        private string _dbConn;
        // Unlocking Sqlite connection
        private string _dbUnlock;

        // Controls the storing of connection strings
        public void DbUnlock(string dbDir, string pass)
        {
            _dbUnlock = "Data Source=" + dbDir + ";Version=3;Password=" + pass + ";";
            _dbConn = "Data Source=" + dbDir + ";Version=3;";
        }

        // SQLite Command executor
        private static void ConnCommand(SQLiteConnection conn, string query)
        {
            using (var c = conn.CreateCommand())
            {
                // Insert command text
                c.CommandText = query;

                // Execute command
                c.ExecuteNonQuery();
            }
        }

        // Check if password unlocks the DB
        public bool PassCheck()
        {
            // Password check result output variable
            bool pc;

            lock (Locker)
            {
                _conn = new SQLiteConnection(_dbUnlock);
                try
                {
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
            }

            // Returns whether pass is correct of not
            return pc;
        }
        // Check if specific password unlocks the DB as parameter
        public bool PassCheck(string pass)
        {
            // Password check result output variable
            bool pc;

            lock (Locker)
            {
                _conn = new SQLiteConnection(_dbConn + "Password=" + pass + ";");
                try
                {
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
            }

            // Returns whether pass is correct of not
            return pc;
        }

        // Controls the creation and initialization of a new DB and table
        public void InitializeDb(string dbDir, string pass)
        {
            // Sets the DB connect string
            DbUnlock(dbDir, pass);

            // Create the DB file itself
            SQLiteConnection.CreateFile(dbDir);

            lock (Locker)
            {
                // Sets connection info ready for connection
                _conn = new SQLiteConnection(_dbConn);

                // Set the Database password
                _conn.SetPassword(pass);

                // Create the default PDB Table
                try
                {
                    // Opens the DB
                    _conn.Open();

                    // Execute query against DB
                    ConnCommand(_conn, "CREATE TABLE PDB (ACC_NAME nvarchar(255) PRIMARY KEY NOT NULL, USER_NAME nvarchar(255) NOT NULL, PASS nvarchar(255) NOT NULL, LINK nvarchar(255), NOTES ntext);");
                }
                catch
                {
                    throw new Exception();
                }
                finally
                {
                    // Close connection
                    _conn.Close();
                }
            }
        }

        // Change password of current DB
        internal void ChangePass(string newPass)
        {
            lock (Locker)
            {
                // Sets connection info ready for connection
                _conn = new SQLiteConnection(_dbUnlock);

                try
                {
                    // Open connection
                    _conn.Open();

                    // Change master password
                    _conn.ChangePassword(newPass);
                }
                catch
                {
                    throw new Exception();
                }
                finally
                {
                    // Close connection
                    _conn.Close();
                }
            }
        }

        // Gets all the data rows from the database table PDB
        public DataTable GetDataTable(string query)
        {
            DataTable dt = new DataTable();

            lock (Locker)
            {
                // Sets connection info ready for connection
                _conn = new SQLiteConnection(_dbUnlock);

                try
                {
                    // Open connection
                    _conn.Open();

                    using (var c = _conn.CreateCommand())
                    {
                        c.CommandText = query;
                        SQLiteDataReader reader = c.ExecuteReader();
                        dt.Load(reader);
                        reader.Close();
                    }
                }
                catch
                {
                    throw new Exception();
                }
                finally
                {
                    // Close connection
                    _conn.Close();
                }
            }
            
            return dt;
        }

        // Insert new data into DB
        public void InsertData(string s1, string s2, string s3, string s4, string s5)
        {
            lock (Locker)
            {
                // Sets connection info ready for connection
                _conn = new SQLiteConnection(_dbUnlock);

                try
                {
                    // Open connection
                    _conn.Open();

                    // Execute query against DB
                    ConnCommand(_conn, "INSERT INTO PDB (ACC_NAME, USER_NAME, PASS, LINK, NOTES) VALUES('" + s1 + "', '" + s2 + "', '" + s3 + "', '" + s4 + "', '" + s5 + "');");
                }
                catch
                {
                    throw new Exception();
                }
                finally
                {
                    // Close connection
                    _conn.Close();
                }
            }
        }

        // Update data in DB
        public void UpdateData(string oldAccName, string s1, string s2, string s3, string s4)
        {
            lock (Locker)
            {
                // Sets connection info ready for connection
                _conn = new SQLiteConnection(_dbUnlock);

                try
                {
                    // Open connection
                    _conn.Open();

                    // Execute query against DB
                    ConnCommand(_conn, "UPDATE PDB SET USER_NAME = '" + s1 + "', PASS = '" + s2 + "', LINK = '" + s3 + "', NOTES = '" + s4 + "' WHERE ACC_NAME = '" + oldAccName + "';");
                }
                catch
                {
                    throw new Exception();
                }
                finally
                {
                    // Close connection
                    _conn.Close();
                }
            }
        }

        // Delete data in DB
        public void DeleteData(string accName)
        {
            lock (Locker)
            {
                // Sets connection info ready for connection
                _conn = new SQLiteConnection(_dbUnlock);

                try
                {
                    // Open connection
                    _conn.Open();

                    // Execute query against DB
                    ConnCommand(_conn, "DELETE FROM PDB WHERE ACC_NAME = '" + accName + "';");
                }
                catch
                {
                    throw new Exception();
                }
                finally
                {
                    // Close connection
                    _conn.Close();
                }
            }
        }
    }
}
