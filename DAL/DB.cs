namespace QPharma.DAL;

internal class DB
{
    private static readonly string connectString =  Config.Instance.ConfigureFile.ConnectionString;

    private static SqlConnection GetConnection()
    {
        return new SqlConnection(connectString);
    }

    public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
    {
        var dataTable = new DataTable();
        try
        {
            using (var conn = GetConnection())
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        dataTable = new DataTable();
                        adapter.Fill(dataTable);

                    }
                }
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return dataTable;
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
                    var rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rowsAffected;
                }
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return 0;
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
