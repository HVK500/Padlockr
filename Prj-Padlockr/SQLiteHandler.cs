using System;
using System.Data;
using System.Data.SQLite;

namespace Prj_Padlockr
{
    public class SQLiteHandler
    {
        // Locker object makes sure the working thead is locked on the task needed
        private static object locker = new object();
        // Connection object
        private SQLiteConnection conn;

        // Sqlite connection string
        private string dbConn;
        // Unlocking Sqlite connection
        private string dbUnlock;

        // Controls the storing of connection strings
        public void DBUnlock(string dbDir, string pass)
        {
            dbUnlock = "Data Source=" + dbDir + ";Version=3;Password=" + pass + ";";
            dbConn = "Data Source=" + dbDir + ";Version=3;";
        }

        // SQLite Command executor
        private void connCommand(SQLiteConnection conn, string query)
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
        public bool passCheck()
        {
            // Password check result output variable
            bool pc;

            lock (locker)
            {
                conn = new SQLiteConnection(dbUnlock);
                try
                {
                    // Open connection
                    conn.Open();

                    // Execute query against DB
                    connCommand(conn, "SELECT * FROM PDB ORDER BY ACC_NAME ASC LIMIT 1;");

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
                    conn.Close();
                }
            }

            // Returns whether pass is correct of not
            return pc;
        }
        // Check if specific password unlocks the DB as parameter
        public bool passCheck(string pass)
        {
            // Password check result output variable
            bool pc;

            lock (locker)
            {
                conn = new SQLiteConnection(dbConn + "Password=" + pass + ";");
                try
                {
                    // Open connection
                    conn.Open();

                    // Execute query against DB
                    connCommand(conn, "SELECT * FROM PDB ORDER BY ACC_NAME ASC LIMIT 1;");

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
                    conn.Close();
                }
            }

            // Returns whether pass is correct of not
            return pc;
        }

        // Controls the creation and initialization of a new DB and table
        public void InitializeDB(string dbDir, string pass)
        {
            // Sets the DB connect string
            DBUnlock(dbDir, pass);

            // Create the DB file itself
            SQLiteConnection.CreateFile(dbDir);

            lock (locker)
            {
                // Sets connection info ready for connection
                conn = new SQLiteConnection(dbConn);

                // Set the Database password
                conn.SetPassword(pass);

                // Create the default PDB Table
                try
                {
                    // Opens the DB
                    conn.Open();

                    // Execute query against DB
                    connCommand(conn, "CREATE TABLE PDB (ACC_NAME nvarchar(255) PRIMARY KEY NOT NULL, USER_NAME nvarchar(255) NOT NULL, PASS nvarchar(255) NOT NULL, LINK nvarchar(255));");
                }
                catch
                {
                    throw new Exception();
                }
                finally
                {
                    // Close connection
                    conn.Close();
                }
            }
        }

        // Change password of current DB
        internal void ChangePass(string newPass)
        {
            lock (locker)
            {
                // Sets connection info ready for connection
                conn = new SQLiteConnection(dbUnlock);

                try
                {
                    // Open connection
                    conn.Open();

                    // Change master password
                    conn.ChangePassword(newPass);
                }
                catch
                {
                    throw new Exception();
                }
                finally
                {
                    // Close connection
                    conn.Close();
                }
            }
        }

        // Gets all the data rows from the database table PDB
        public DataTable GetDataTable(string query)
        {
            DataTable dt = new DataTable();

            lock (locker)
            {
                // Sets connection info ready for connection
                conn = new SQLiteConnection(dbUnlock);

                try
                {
                    // Open connection
                    conn.Open();

                    using (var c = conn.CreateCommand())
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
                    conn.Close();
                }
            }
            
            return dt;
        }

        // Insert new data into DB
        public void InsertData(string s1, string s2, string s3, string s4)
        {
            lock (locker)
            {
                // Sets connection info ready for connection
                conn = new SQLiteConnection(dbUnlock);

                try
                {
                    // Open connection
                    conn.Open();

                    // Execute query against DB
                    connCommand(conn, "INSERT INTO PDB (ACC_NAME, USER_NAME, PASS, LINK) VALUES('" + s1 + "', '" + s2 + "', '" + s3 + "', '" + s4 + "');");
                }
                catch
                {
                    throw new Exception();
                }
                finally
                {
                    // Close connection
                    conn.Close();
                }
            }
        }

        // Update data in DB
        public void UpdateData(string oldAccName, string s1, string s2, string s3)
        {
            lock (locker)
            {
                // Sets connection info ready for connection
                conn = new SQLiteConnection(dbUnlock);

                try
                {
                    // Open connection
                    conn.Open();

                    // Execute query against DB
                    connCommand(conn, "UPDATE PDB SET USER_NAME = '" + s1 + "', PASS = '" + s2 + "', LINK = '" + s3 + "' WHERE ACC_NAME = '" + oldAccName + "';");
                }
                catch
                {
                    throw new Exception();
                }
                finally
                {
                    // Close connection
                    conn.Close();
                }
            }
        }

        // Delete data in DB
        public void DeleteData(string accName)
        {
            lock (locker)
            {
                // Sets connection info ready for connection
                conn = new SQLiteConnection(dbUnlock);

                try
                {
                    // Open connection
                    conn.Open();

                    // Execute query against DB
                    connCommand(conn, "DELETE FROM PDB WHERE ACC_NAME = '" + accName + "';");
                }
                catch
                {
                    throw new Exception();
                }
                finally
                {
                    // Close connection
                    conn.Close();
                }
            }
        }
    }
}
