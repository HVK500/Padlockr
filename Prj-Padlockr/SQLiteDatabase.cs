using System;
using System.Data;
using System.Data.SQLite;

namespace Prj_Padlockr
{
    public class SQLiteDatabase
    {

        string dbConn;

        //TODO: Could possibly merge this in to the InitializeDB method
        public void DBConnect(string dbDir)
        {
            dbConn = "Data Source=" + dbDir + ";Version=3;";
        }

        public void InitializeDB(string pass)
        {
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
                cmd.CommandText = "CREATE TABLE PDB (ROWID int NOT NULL PRIMARY KEY, ACC_NAME varchar(255) NOT NULL, USER_NAME varchar(255) NOT NULL, PASS nvarchar(255) NOT NULL, LINK nvarchar(255) NULL)";
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

        //TODO: Possibly change this methods return type / Learn how to handle DataTables
        public DataTable GetDataTable(string query, string pass)
        {
            //TODO: Add a condition here to check if the password is correct
            SQLiteConnection conn = new SQLiteConnection(dbConn + "Password=" + pass + ";");
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
            SQLiteConnection conn = new SQLiteConnection(dbConn);
            conn.Open();

            try
            {
                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = "INSERT INTO PDB VALUES(" + s1 + ", " + s2 + ", " + s3 + ", " + s4 + ")";
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
