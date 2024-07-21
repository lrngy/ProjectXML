using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ProjectXML.DAL
{
    internal class DB
    {
        private static string connectString = @"Data Source=LONGPC\SQLEXPRESS;Initial Catalog=QlyHieuThuoc;Integrated Security=True";
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(connectString);
        }
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    conn.Open();
                    try
                    {
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected;
                    } catch(Exception ex)
                    {
                        Debug.Write(ex.ToString());
                    }
                    conn.Close();
                    return 0;
                }
            }
        }

        public static int ExecuteTransaction(Dictionary<string, SqlParameter[]> queryParameters)
        {
            int result = 0;

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlTransaction sqlTran = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
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
