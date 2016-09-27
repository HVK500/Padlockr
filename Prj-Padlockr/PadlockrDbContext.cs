using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Padlockr.Models;

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

        // todo: move into a service...
        List<string> GetAccounts();
        List<string> GetAccounts(string filter);
        PasswordEntry GetPasswordEntry(string accountName);
        void AddPasswordEntry(PasswordEntry entry);
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

        // todo: look at dropping in the not so near future
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


        // todo: move into a Padlockr service
        public List<string> GetAccounts()
        {
            var accounts = new List<string>();

            var accDataTable = GetDataTable("SELECT ACC_NAME FROM PDB;");

            if (accDataTable.Rows.Count == 0)
                return accounts;

            // Cycle through the items in the give DataTable
            accounts.AddRange(from DataRow dr in accDataTable.Rows select dr["ACC_NAME"].ToString());

            return accounts;
        }

        public List<string> GetAccounts(string filter)
        {
            var accounts = new List<string>();

            var query = "SELECT ACC_NAME FROM PDB WHERE ACC_NAME LIKE '%" + filter + "%';";
            var accDataTable = GetDataTable(query);

            if (accDataTable.Rows.Count == 0)
                return accounts;

            // Cycle through the items in the give DataTable
            accounts.AddRange(from DataRow dr in accDataTable.Rows select dr["ACC_NAME"].ToString());

            return accounts;
        }

        public PasswordEntry GetPasswordEntry(string accountName)
        {
            var query = "SELECT ACC_NAME, USER_NAME, PASS, LINK, NOTES FROM PDB WHERE ACC_NAME = '" + accountName + "';";
            var dt = GetDataTable(query);

            if (dt.Rows.Count == 0)
                return null;

            var dr = dt.Rows[dt.Rows.Count - 1];

            var entry = new PasswordEntry
            {
                AccountName = dr["ACC_NAME"].ToString(),
                Link = dr["LINK"].ToString(),
                Notes = dr["NOTES"].ToString(),
                Password = dr["PASS"].ToString(),
                Username = dr["USER_NAME"].ToString()
            };

            return entry;
        }

        public void AddPasswordEntry(PasswordEntry entry)
        {
            // Generate the insert command
            var cmd = $"INSERT INTO PDB (ACC_NAME, USER_NAME, PASS, LINK, NOTES) " +
                      $"VALUES " +
                      $"('{ApoCleansing(entry.AccountName)}', '{ApoCleansing(entry.Username)}', " +
                      $"'{ApoCleansing(entry.Password)}', '{ApoCleansing(entry.Link)}', " +
                      $"'{ApoCleansing(entry.Notes)}');";

            try
            {
                _db.OpenDbConnection();
                _db.RunCommand(cmd);
            }
            catch (Exception ex)
            {
                // todo: [error] handle this better
                throw new Exception();
            }
            finally
            {
                _db.CloseDbConnection();
            }
        }


        // Helper methods
        private static string ApoCleansing(string pass)
        {
            // Gets stores the password in the p
            var p = pass;
            // Counts the number of apostrophe's there are in the pass string
            var c = p.Split('\'').Length - 1;

            if (c == 0)
                return p;

            // New list to convert to an array to cycle through
            var pos = new List<int>();
            var temp = 0;

            // Assembles the list of the index postions of the apostrophe's
            for (var i = 0; i <= c - 1; i++)
            {
                pos.Add(p.IndexOf('\'', temp));
                temp = p.IndexOf('\'', temp) + 1;
            }

            // Converts the list to an array
            var n = pos.ToArray();

            // Cycle through the array and double up the apostrophe's - because SQLite uses the second apostrophe as an escape symbol
            for (var i = 0; i <= n.Length - 1; i++)
            {
                if (i != 0)
                {
                    // Apostrophe doubling up logic for all apostrophe's not in index 0
                    p = p.Insert(n[i] + i, "'");
                }
                else
                {
                    // Initial doubling at index 0
                    p = p.Insert(n[0], "'");
                }
            }

            // Return the resulting password
            return p;
        }
    }
}
