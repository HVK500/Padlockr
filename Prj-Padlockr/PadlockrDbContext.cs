using System;
using System.Data;
using System.Data.SQLite;

namespace Padlockr
{
    public interface IPadlockrDbContext
    {
        void ChangePass(string newPass);
        void InitializeDb(string dbDir, string pass);
        void InsertData(string s1, string s2, string s3, string s4, string s5);
        void UpdateData(string oldAccName, string s1, string s2, string s3, string s4);
        void DeleteData(string accName);
        bool PassCheck(string pass);
        bool PassCheck();
        void SetConnectionStrings(string dbDir, string pass);
        DataTable GetDataTable(string query);
        bool AccountExists(string name);
    }

    public class PadlockrDbContext : IPadlockrDbContext
    {
        private readonly ISqliteWrapper _db;

        public PadlockrDbContext(ISqliteWrapper dbClass)
        {
            _db = dbClass;
        }

        // Change password of current DB
        public void ChangePass(string newPass)
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

        // Controls the creation and initialization of a new DB and table
        public void InitializeDb(string dbDir, string pass)
        {
            _db.SetConnectionStrings(dbDir, pass);

            // Create the DB file itself
            SQLiteConnection.CreateFile(dbDir);

            // Sets the DB connect string
            _db.SetInsecureConnection(false);

            // Set the Database password
            _db.SetPassword(pass);

            // Open a secure connection to the DB
            _db.OpenDbConnection();

            // Create the default PDB Table
            try
            {
                // todo: move command into resource, or place better inline
                // Execute query against DB
                _db.RunCommand(
                    "CREATE TABLE PDB (ACC_NAME nvarchar(255) PRIMARY KEY NOT NULL, USER_NAME nvarchar(255) NOT NULL, PASS nvarchar(255) NOT NULL, LINK nvarchar(255), NOTES ntext);");
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

        // Insert new data into DB
        public void InsertData(string s1, string s2, string s3, string s4, string s5)
        {
            try
            {
                _db.OpenDbConnection();

                // todo: move command into resource, or place better in-line
                // Execute query against DB
                _db.RunCommand("INSERT INTO PDB (ACC_NAME, USER_NAME, PASS, LINK, NOTES) VALUES('" + s1 + "', '" + s2 +
                               "', '" + s3 + "', '" + s4 + "', '" + s5 + "');");
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            finally
            {
                _db.CloseDbConnection();
            }
        }

        // Update data in DB
        public void UpdateData(string oldAccName, string s1, string s2, string s3, string s4)
        {
            try
            {
                _db.OpenDbConnection();

                // todo: move command into resource, or place better in-line
                // Execute query against DB
                _db.RunCommand("UPDATE PDB SET USER_NAME = '" + s1 + "', PASS = '" + s2 + "', LINK = '" + s3 +
                               "', NOTES = '" + s4 + "' WHERE ACC_NAME = '" + oldAccName + "';");
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

        // Delete data in DB
        public void DeleteData(string accName)
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

        // Checking given password against the DB connection
        public bool PassCheck(string pass)
        {
            return _db.PassCheck(pass);
        }

        public bool PassCheck()
        {
            return _db.PassCheck();
        }

        // Allowing the setting of DB connection strings
        public void SetConnectionStrings(string dbDir, string pass)
        {
            _db.SetConnectionStrings(dbDir, pass);
        }

        // Returns a DataTable for the given query
        public DataTable GetDataTable(string query)
        {
            return _db.GetDataTable(query);
        }

        public bool AccountExists(string name)
        {
            var dt = GetDataTable("SELECT ACC_NAME FROM PDB WHERE ACC_NAME = '" + name + "';");
            return dt.Rows.Count > 0;
        }
    }
}
