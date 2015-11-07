using System;
using System.Data;
using System.Data.SQLite;

namespace Prj_Padlockr
{
    public class SQLiteDatabase
    {
        // Global vars
        string dbConn;
        string dbUnlock;

        public void DBUnlock(string dbDir, string pass)
        {
            dbUnlock = "Data Source=" + dbDir + ";Version=3;Password=" + pass + ";";
            dbConn = "Data Source=" + dbDir + ";Version=3;";
        }

        // Check if password unlocks the DB
        public bool passCheck()
        {
            bool pc;
            SQLiteConnection conn = new SQLiteConnection(dbUnlock);
            try
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = "SELECT * FROM PDB ORDER BY ACC_NAME ASC LIMIT 1;";
                cmd.ExecuteNonQuery();

                pc = true;
            }
            catch (Exception)
            {
                pc = false;
            }
            finally
            {
                conn.Close();
            }

            return pc;
            
        }
        // Check if password unlocks the DB - with parameter
        public bool passCheck(string pass)
        {
            bool pc;
            SQLiteConnection conn = new SQLiteConnection(dbConn + "Password=" + pass + ";");
            try
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = "SELECT * FROM PDB ORDER BY ROWID ASC LIMIT 1;";
                cmd.ExecuteNonQuery();

                pc = true;
            }
            catch (Exception)
            {
                pc = false;
            }
            finally
            {
                conn.Close();
            }

            return pc;

        }

        public void InitializeDB(string dbDir, string pass)
        {
            //TODO: Optimise!
            // Sets the DB connect string
            dbConn = "Data Source=" + dbDir + ";Version=3;";
            // Sets the DB Unlock reference
            dbUnlock = "Data Source=" + dbDir + ";Version=3;Password=" + pass + ";";
            // Connect to new DB
            SQLiteConnection conn = new SQLiteConnection(dbConn);
            // Set the Database password
            conn.SetPassword(pass);
            // Opens the DB
            conn.Open();

            // Create the default PDB Table
            try
            {
                // Create the PDB table in DB
                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = "CREATE TABLE PDB (ACC_NAME nvarchar(255) PRIMARY KEY NOT NULL, USER_NAME nvarchar(255) NOT NULL, PASS nvarchar(255) NOT NULL, LINK nvarchar(255));";
                cmd.ExecuteNonQuery();
            }
            catch (Exception f)
            {
                throw new Exception(f.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Change password of current DB
        public void ChangePass(string newPass)
        {
            SQLiteConnection conn = new SQLiteConnection(dbUnlock);
            conn.Open();
            conn.ChangePassword(newPass);
        }

        // Gets all the data rows from the database table PDB
        public DataTable GetDataTable(string query)
        {
            SQLiteConnection conn = new SQLiteConnection(dbUnlock);
            conn.Open();

            DataTable dt = new DataTable();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = query;
                SQLiteDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();

            }
            catch (Exception f)
            {
                throw new Exception(f.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public void InsertData(string s1, string s2, string s3, string s4)
        {
            SQLiteConnection conn = new SQLiteConnection(dbUnlock);
            conn.Open();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = "INSERT INTO PDB (ACC_NAME, USER_NAME, PASS, LINK) VALUES('" + s1 + "', '" +  s2 + "', '" + s3 + "', '" + s4 + "');";
                cmd.ExecuteNonQuery();
            }
            catch (Exception f)
            {
                throw new Exception(f.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateData(string oldAccName, string s1, string s2, string s3)
        {
            SQLiteConnection conn = new SQLiteConnection(dbUnlock);
            conn.Open();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = "UPDATE PDB SET USER_NAME = '" + s1 + "', PASS = '" + s2 + "', LINK = '" + s3 + "' WHERE ACC_NAME = '" + oldAccName + "';";
                cmd.ExecuteNonQuery();
            }
            catch (Exception f)
            {
                throw new Exception(f.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void DeleteData(string accName)
        {
            SQLiteConnection conn = new SQLiteConnection(dbUnlock);
            conn.Open();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = "DELETE FROM PDB WHERE ACC_NAME = '" + accName + "';";
                cmd.ExecuteNonQuery();
            }
            catch (Exception f)
            {
                throw new Exception(f.Message);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
