namespace QPharma.DAL;

public class CategoryDAL
{
    public List<CategoryDTO> GetAll()
    {
        var list = new List<CategoryDTO>();
        try
        {
            var query = "SELECT * FROM categories";
            var dt = DB.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                var id = dr["category_id"].ToString();
                var name = dr["category_name"].ToString();
                var note = dr["category_note"].ToString();
                var status = bool.Parse(dr["category_status"].ToString());
                var created = dr["category_created"].ToString();
                var updated = dr["category_updated"].ToString();
                var deleted = dr["category_deleted"].ToString();

                var category = new CategoryDTO(id, name, note, status, created, updated, deleted);
                list.Add(category);
            }
        }
        catch (Exception)
        {
        }

        return list;
    }

    public CategoryDTO GetById(string id)
    {
        CategoryDTO category = null;
        try
        {
            var query = $"SELECT * FROM categories WHERE category_id = @id";
            SqlParameter[] sqlParameter = { new SqlParameter("@id", id) };

            var dt = DB.ExecuteQuery(query, sqlParameter);
            if (dt.Rows.Count != 0)
            {
                var deleted = dt.Rows[0]["category_deleted"].ToString();
                var name = dt.Rows[0]["category_name"].ToString();
                var note = dt.Rows[0]["category_note"].ToString();
                var status = bool.Parse(dt.Rows[0]["category_status"].ToString());
                var created = dt.Rows[0]["category_created"].ToString();
                var updated = dt.Rows[0]["category_updated"].ToString();
                category = new CategoryDTO(id, name, note, status, created, updated, deleted);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return category;
    }

    public CategoryDTO GetByName(string name)
    {
        CategoryDTO categoryDto = null;
        try
        {

            var query = "SELECT * FROM categories WHERE category_name = @name";
            SqlParameter[] sqlParameters = { new("@name", name) };
            var dt = DB.ExecuteQuery(query, sqlParameters);
            if (dt.Rows.Count != 0)
            {
                var deleted = dt.Rows[0]["category_deleted"].ToString();
                var id = dt.Rows[0]["category_id"].ToString();
                var note = dt.Rows[0]["category_note"].ToString();
                var status = bool.Parse(dt.Rows[0]["category_status"].ToString());
                var created = dt.Rows[0]["category_created"].ToString();
                var updated = dt.Rows[0]["category_updated"].ToString();
                categoryDto = new CategoryDTO(id, name, note, status, created, updated, deleted);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);

        }

        return categoryDto;
    }

public int Insert(CategoryDTO category)
{
    try
    {
        var query =
            "INSERT INTO categories(category_name, category_note, category_status, category_created) VALUES (@name, @note, @status, @created)";
        SqlParameter[] sqlParameters =
        {
                new("@name", category.name),
                new("@note", category.note),
                new("@status", category.status),
                new("@created", category.created)
            };
        DB.ExecuteNonQuery(query, sqlParameters);
        return Predefined.SUCCESS;
    }
    catch (XmlException ex)
    {
        Debug.WriteLine(ex.Message);
        return Predefined.ERROR;
    }
}

public int Update(CategoryDTO category)
{
    try
    {
        var query =
            "UPDATE categories SET category_name = @name, category_note = @note, category_status = @status, category_updated = @updated WHERE category_id = @id";
        SqlParameter[] sqlParameters =
        {
                new("@name", category.name),
                new("@note", category.note),
                new("@status", category.status),
                new("@updated", category.updated),
                new("@id", category.id)
            };
        DB.ExecuteNonQuery(query, sqlParameters);

        return Predefined.SUCCESS;
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex.Message);
        return Predefined.ERROR;
    }
}

public int Delete(string maTheLoai)
{
    try
    {
        var query =
            "UPDATE categories SET category_deleted = @deleted WHERE category_id = @id";
        SqlParameter[] sqlParameters =
        {
                new("@id", maTheLoai),
                new("@deleted", CustomDateTime.GetNow())
            };
        DB.ExecuteNonQuery(query, sqlParameters);

        return Predefined.SUCCESS;
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex.Message);
        return Predefined.ERROR;
    }
}

internal int Restore(string maTheLoai)
{
    try
    {
        var query = "UPDATE categories SET category_deleted = null WHERE category_id = @id";
        SqlParameter[] sqlParameters =
        {
                new("@id", maTheLoai)
            };
        DB.ExecuteNonQuery(query, sqlParameters);

        return Predefined.SUCCESS;
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex.Message);
        return Predefined.ERROR;
    }
}

internal int ForceDelete(string maTheLoai)
{
    try
    {
        var query = new Dictionary<string, SqlParameter[]>
            {
                {
                    "Update medicines set category_id = @dbnull",
                    [
                        new SqlParameter("@dbnull", DBNull.Value)
                    ]
                },
                {
                    "DELETE FROM categories WHERE category_id = @id",
                    [
                        new SqlParameter("@id", maTheLoai)
                    ]
                },
            };
        DB.ExecuteTransaction(query);
        return Predefined.SUCCESS;
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex.Message);
        return Predefined.ERROR;
    }
}

internal int RestoreAll()
{
    try
    {
        var query = "UPDATE categories SET category_deleted = null";
        DB.ExecuteNonQuery(query);
        return Predefined.SUCCESS;
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex.Message);
        return Predefined.ERROR;
    }
}
}