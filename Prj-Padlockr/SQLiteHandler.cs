using System;
using System.Data;
using System.Data.SQLite;

namespace Prj_Padlockr
{
    public class TempDbClass
    {
        // todo: drop locker - possibly not required
        // Locker object makes sure the working thread is locked on the task needed
        public readonly object Locker = new object();
        // Connection object
        private SQLiteConnection _conn;
        // Sqlite connection string
        private string _dbConn;
        // Unlocking Sqlite connection
        private string _dbUnlock;

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

        // todo: rename to something like set connection strings
        // Controls the storing of connection strings
        public void DbUnlock(string dbDir, string pass)
        {
            _dbUnlock = "Data Source=" + dbDir + ";Version=3;Password=" + pass + ";";
            _dbConn = "Data Source=" + dbDir + ";Version=3;";
        }

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
                catch (Exception ex)
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

        public void OpenDbConnection()
        {
            // Sets connection info ready for connection
            _conn = new SQLiteConnection(_dbConn);
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

    public class SqLiteHandler
    {
        private readonly TempDbClass _db;

        public SqLiteHandler(TempDbClass dbClass)
        {
            _db = dbClass;
        }

        // Change password of current DB
        public void ChangePass(string newPass)
        {
            lock (_db.Locker)
            {
                try
                {
                    _db.OpenDbConnection();
                    _db.ChangePass(newPass);
                }
                catch (Exception ex)
                {
                    // todo: handle this better
                    throw new Exception();
                }
                finally
                {
                    _db.CloseDbConnection();
                }
            }
        }

        // Controls the creation and initialization of a new DB and table
        public void InitializeDb(string dbDir, string pass)
        {
            // Sets the DB connect string
            _db.DbUnlock(dbDir, pass);

            // Create the DB file itself
            SQLiteConnection.CreateFile(dbDir);

            lock (_db.Locker)
            {
                _db.OpenDbConnection();

                // Set the Database password
                _db.SetPassword(pass);

                // Create the default PDB Table
                try
                {
                    // todo: move command into resource, or place better inline
                    // Execute query against DB
                    _db.RunCommand("CREATE TABLE PDB (ACC_NAME nvarchar(255) PRIMARY KEY NOT NULL, USER_NAME nvarchar(255) NOT NULL, PASS nvarchar(255) NOT NULL, LINK nvarchar(255), NOTES ntext);");
                }
                catch (Exception ex)
                {
                    // todo: log this ex
                    throw new Exception();
                }
                finally
                {
                    // Close connection
                    _db.CloseDbConnection();
                }
            }
        }

        // Insert new data into DB
        public void InsertData(string s1, string s2, string s3, string s4, string s5)
        {
            lock (_db.Locker)
            {
                try
                {
                    _db.OpenDbConnection();

                    // todo: move command into resource, or place better in-line
                    // Execute query against DB
                    _db.RunCommand("INSERT INTO PDB (ACC_NAME, USER_NAME, PASS, LINK, NOTES) VALUES('" + s1 + "', '" + s2 + "', '" + s3 + "', '" + s4 + "', '" + s5 + "');");
                }
                catch
                {
                    throw new Exception();
                }
                finally
                {
                    _db.CloseDbConnection();
                }
            }
        }

        // Update data in DB
        public void UpdateData(string oldAccName, string s1, string s2, string s3, string s4)
        {
            lock (_db.Locker)
            {
                try
                {
                    _db.OpenDbConnection();

                    // todo: move command into resource, or place better in-line
                    // Execute query against DB
                    _db.RunCommand("UPDATE PDB SET USER_NAME = '" + s1 + "', PASS = '" + s2 + "', LINK = '" + s3 + "', NOTES = '" + s4 + "' WHERE ACC_NAME = '" + oldAccName + "';");
                }
                catch
                {
                    throw new Exception();
                }
                finally
                {
                    // Close connection
                    _db.CloseDbConnection();
                }
            }
        }

        // Delete data in DB
        public void DeleteData(string accName)
        {
            lock (_db.Locker)
            {
                try
                {
                    _db.OpenDbConnection();

                    // todo: move command into resource, or place better in-line
                    // Execute query against DB
                    _db.RunCommand("DELETE FROM PDB WHERE ACC_NAME = '" + accName + "';");
                }
                catch
                {
                    throw new Exception();
                }
                finally
                {
                    // Close connection
                    _db.CloseDbConnection();
                }
            }
        }
    }
}
