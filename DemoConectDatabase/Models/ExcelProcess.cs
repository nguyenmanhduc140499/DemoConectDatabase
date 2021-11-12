using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DemoConectDatabase.Models
{
    public class ExcelProcess
    {
        public static DataTable ReadDataFromExcelFile(string filepath, bool removeRow0)
        {
            string connectionString = "";
            string fileExtention = filepath.Substring(filepath.Length - 4).ToLower();
            if (fileExtention.IndexOf("xlsx") < 0)
            {
                connectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + filepath + "; Extended Properties = Excel 8.0";
            }
            else { connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + filepath + "; Extended Properties = \"Excel 12.0 Xml; HDR=NO\""; }

            //Tao chuoi ket noi
            OleDbConnection oledbConn = new OleDbConnection(connectionString);
            DataTable data = null;
            try
            {
                // mo ket noi
                oledbConn.Open();
                // Taoj doi tuong vaf query data tu sheet co ten "Sheet1"
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn);

                // Tao doi tuong Adapter de thuc thi viec query lay du lieu tu excel
                OleDbDataAdapter oleDataAdap = new OleDbDataAdapter();
                oleDataAdap.SelectCommand = cmd;
                // Tao doi tuong Dataset de nhan du lieu 
                DataSet ds = new DataSet();
                // Do du lieu tu excel vao DataSet
                oleDataAdap.Fill(ds);
                data = ds.Tables[0];
                if (removeRow0 == true)
                {
                    data.Rows.RemoveAt(0);
                }
            }
            catch
            {
            }
            finally
            {
                // dong chuoi ket noi
                oledbConn.Close();
            }
            return data;
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LaptringquanlyDBcontext"].ConnectionString);
        private void OverWriteFastData (int? StudentID)
        {
            // Tạo table chứa dữ liệu
            DataTable dt = new DataTable();
            // Mapping cá column trong datatable và các column trong CSDl
            SqlBulkCopy bulkCopy = new SqlBulkCopy(con);
            bulkCopy.DestinationTableName = "Student";
            bulkCopy.ColumnMappings.Add(0, "StudentID");
            bulkCopy.ColumnMappings.Add(1, "StudentName");
            con.Open();
            bulkCopy.WriteToServer(dt);
            con.Close();

        }
    }
}