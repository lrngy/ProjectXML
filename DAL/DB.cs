using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using QPharma.Properties;
using QPharma.Util;

namespace QPharma.DAL
{
    internal class DB
    {
        private static string connectString = "Data Source=ADMIN0512;Initial Catalog=QlyHieuThuoc;Integrated Security=True;Encrypt=False";

        private static SqlConnection GetConnection()
        {
            return new SqlConnection(connectString);
        }

        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null) cmd.Parameters.AddRange(parameters);

                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            var dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi"); }
            return null;
        }

        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null) cmd.Parameters.AddRange(parameters);
                        conn.Open();
                        try
                        {
                            var rowsAffected = cmd.ExecuteNonQuery();

                            return rowsAffected;
                        }
                        catch (Exception ex)
                        {
                            Debug.Write(ex.ToString());
                        }

                        conn.Close();
                        return 0;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi"); return Predefined.ERROR; }
        }

        public static int ExecuteTransaction(Dictionary<string, SqlParameter[]> queryParameters)
        {
            var result = 0;

            using (var connection = GetConnection())
            {
                connection.Open();
                var sqlTran = connection.BeginTransaction();
                var command = connection.CreateCommand();
                command.Transaction = sqlTran;

                try
                {
                    foreach (var entry in queryParameters)
                    {
                        command.CommandText = entry.Key;
                        command.Parameters.Clear();
                        command.Parameters.AddRange(entry.Value);

                        result += command.ExecuteNonQuery();
                    }

                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);

                    try
                    {
                        sqlTran.Rollback();
                        Debug.WriteLine("Transaction rolled back.");
                    }
                    catch (Exception exRollback)
                    {
                        Debug.WriteLine("Rollback Error: " + exRollback.Message);
                    }
                }

                return result;
            }
        }
    }
}