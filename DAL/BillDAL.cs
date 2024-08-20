using System.Collections.Generic;

namespace QPharma.DAL;

public class BillDAL
{
    public (int totalPage, int numRecord, List<BillDTO> listBills) GetAll(int pageSize, int currentPage, bool isNotDeleted = true, List<SqlParameter> listParams = null, string whereClause = "where 1 = 1")
    {
        List<BillDTO> listBills = new List<BillDTO>();
        int totalPage = 0;
        int numRecord = 0;
        listParams ??= new List<SqlParameter>();
        string deletedNotNull = isNotDeleted ? "and bill_deleted is null" : "and bill_deleted is not null";
        try
        {
            var query = $"WITH BillCount AS (SELECT COUNT(*) AS cnt FROM bills {whereClause} {deletedNotNull}) " +
                        $"SELECT b.*, bc.cnt FROM bills b CROSS JOIN BillCount bc" +
                        $" {whereClause} {deletedNotNull} order by (select null) " +
                        $"offset IIF(@currentPage > 0, (@currentPage - 1) * @pageSize, 0) rows " +
                        $"fetch next @pageSize rows only";
            listParams.Add(new SqlParameter("@currentPage", currentPage));
            listParams.Add(new SqlParameter("@pageSize", pageSize));
            var dt = DB.ExecuteQuery(query, listParams.ToArray());
            listBills = new List<BillDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                var id = dr["bill_id"].ToString();
                var total = decimal.Parse(dr["bill_total"].ToString());
                var customerPaid = decimal.Parse(dr["bill_customer_paid"].ToString());
                var status = bool.Parse(dr["bill_status"].ToString());
                var note = dr["bill_note"].ToString();
                var created = !string.IsNullOrEmpty(dr["bill_created"].ToString()) ? DateTime.Parse(dr["bill_created"].ToString()).ToString("dd/MM/yyyy HH:mm") : "";
                var deleted = !string.IsNullOrEmpty(dr["bill_deleted"].ToString()) ? DateTime.Parse(dr["bill_deleted"].ToString()).ToString("dd/MM/yyyy HH:mm") : "";
                var doctorPrescribed = dr["bill_doctor_prescribed"].ToString();
                var customer = new CustomerDAL().GetById(dr["customer_id"].ToString());
                var staff = StaffDAL.GetById(dr["staff_id"].ToString());
                var billDetails = new BillDetailDAL().GetById(dr["bill_id"].ToString());

                var bill = new BillDTO(id, total, customerPaid, status, note,
                    customer, staff, created, deleted,
                    billDetails, doctorPrescribed);
                listBills.Add(bill);
            }

            if (dt.Rows.Count > 0)
            {
                numRecord = int.Parse(dt.Rows[0]["cnt"].ToString());
            }
            totalPage = (int)Math.Ceiling((double)numRecord / pageSize);

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.StackTrace);
        }

        return (totalPage, numRecord, listBills);
    }

    internal int Delete(string id)
    {
        try
        {
            var query = "update bills set bill_deleted = getdate() where bill_id = @id";
            SqlParameter[] sqlParameters = { new SqlParameter("@id", id) };
            DB.ExecuteNonQuery(query, sqlParameters);
            return Predefined.SUCCESS;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.StackTrace);
        }

        return Predefined.ERROR;
    }

    public List<string> GetDateList()
    {
        List<string> listDate = new List<string>();
        try
        {
            var query = "select distinct cast(bill_created as date) as bill_created from bills where bill_deleted is null";
            var dt = DB.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                listDate.Add(DateTime.Parse(dr["bill_created"].ToString()).ToString("dd/MM/yyyy"));
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.StackTrace);
        }

        return listDate;
    }

    public List<string> GetPriceList()
    {
        List<string> listPrice = new List<string>();
        try
        {
            var query = "select distinct bill_total from bills where bill_deleted is null";
            var dt = DB.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                listPrice.Add(dr["bill_total"].ToString());
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.StackTrace);
        }

        return listPrice;

    }

    public List<string> GetStaffList()
    {
        List<string> listStaff = new List<string>();
        try
        {
            var query = "select distinct b.staff_id, s.staff_name from bills b inner join staffs s on b.staff_id = s.staff_id ";

            var dt = DB.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                listStaff.Add(dr["staff_id"].ToString() + "-" + dr["staff_name"]);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.StackTrace);
        }

        return listStaff;
    }

    public int RestoreAll()
    {
        try
        {
            var query = "update bills set bill_deleted = null where bill_deleted is not null";
            DB.ExecuteNonQuery(query);
            return Predefined.SUCCESS;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.StackTrace);
        }

        return Predefined.ERROR;

    }

    public int Restore(string id)
    {
        try
        {
            var query = "update bills set bill_deleted = null where bill_id = @id";
            SqlParameter[] sqlParameters = { new SqlParameter("@id", id) };
            DB.ExecuteNonQuery(query, sqlParameters);
            return Predefined.SUCCESS;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.StackTrace);
        }

        return Predefined.ERROR;
    }

    public int ForceDelete(string id)
    {
        try
        {
            var query = new Dictionary<string, SqlParameter[]>()
            {
                {
                    "delete from bill_details where bill_id = @id",
                    [
                        new SqlParameter("@id", id)
                    ]
                },
                {
                    "delete from bills where bill_id = @id",
                    [
                        new SqlParameter("@id", id)
                    ]
                }
            };
            DB.ExecuteTransaction(query);
            return Predefined.SUCCESS;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.StackTrace);
        }

        return Predefined.ERROR;
    }

    public int ForceDeleteAll()
    {
        try
        {
            var query = new Dictionary<string, SqlParameter[]>()
            {
                {
                    "delete from bill_details where bill_id in (select bill_id from bills where bill_deleted is not null)",
                    []
                },
                {
                    "delete from bills where bill_deleted is not null",
                    []
                }
            };
            DB.ExecuteTransaction(query);
            return Predefined.SUCCESS;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.StackTrace);
        }

        return Predefined.ERROR;
    }

    public int SaveBill(BillDTO bill)
    {
        try
        {
            StringBuilder sb1 = new();
            StringBuilder sb2 = new();
            foreach (var detail in bill.BillDetails)
            {
                sb1.Append(
                    $"INSERT INTO bill_details(bill_id, medicine_id, bill_detail_quantity, bill_detail_price) " +
                    $"VALUES('{bill.Id}', '{detail.medicine.id}', {detail.quantity}, {detail.price});");
                sb2.Append(
                    $"update medicines " +
                    $"set medicine_quantity = {detail.medicine.quantity} - {(detail.quantity > detail.medicine.quantity ? 0 : detail.quantity)} where medicine_id = '{detail.medicine.id}';");
            }

            var query = new Dictionary<string, SqlParameter[]>()
            {
                {
                    "INSERT INTO bills" +
                    "(bill_id, bill_total, bill_customer_paid, bill_status, bill_note, customer_id, staff_id, bill_created, bill_doctor_prescribed)" +
                    "values (@id, @total, @paid, @status, @note, @customer_id, @staff_id, getdate(), @doctor)",
                    [
                        new SqlParameter("@id", bill.Id),
                        new SqlParameter("@total", bill.Total),
                        new SqlParameter("@paid", bill.CustomerPaid),
                        new SqlParameter("@status", bill.Status),
                        new SqlParameter("@note", bill.Note),
                        new SqlParameter("@customer_id", bill.Customer.Id),
                        new SqlParameter("@staff_id", bill.Staff.id),
                        new SqlParameter("@doctor", bill.DoctorPrescribed)
                    ]
                },
                {
                    sb1.ToString(),
                    []
                    },
                {
                    sb2.ToString(),
                    []
                }
            };
            DB.ExecuteTransaction(query);
            return Predefined.SUCCESS;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.StackTrace);
        }
        return Predefined.ERROR;
    }

    public int Update(BillDTO bill)
    {
        try
        {
            StringBuilder sb1 = new();
            StringBuilder sb2 = new();
            foreach (var detail in bill.BillDetails)
            {
                sb1.Append(
                    $"INSERT INTO bill_details(bill_id, medicine_id, bill_detail_quantity, bill_detail_price) " +
                    $"VALUES('{bill.Id}', '{detail.medicine.id}', {detail.quantity}, {detail.price});");
                sb2.Append(
                    $"update medicines " +
                    $"set medicine_quantity = medicine_quantity - IIF({detail.quantity} > medicine_quantity, 0, {detail.quantity}) where medicine_id = '{detail.medicine.id}';");
            }

            var query = new Dictionary<string, SqlParameter[]>()
            {
                {
                    "update bills set bill_total = @total, " +
                    "bill_customer_paid = @paid, " +
                    "bill_status = @status, " +
                    "bill_note = @note, " +
                    "customer_id = @customer_id, " +
                    "staff_id = @staff_id" +
                    ", bill_created = getdate(), bill_doctor_prescribed = @doctor where bill_id = @id",
                    [
                        new("@id", bill.Id),
                        new("@total", bill.Total),
                        new("@paid", bill.CustomerPaid),
                        new("@status", bill.Status),
                        new("@note", bill.Note),
                        new("@customer_id", bill.Customer.Id),
                        new("@staff_id", bill.Staff.id),
                        new("@doctor", bill.DoctorPrescribed)
                    ]
                },
                {
                    "UPDATE medicines " +
                    "SET medicine_quantity = medicine_quantity + (SELECT COALESCE(SUM(bill_details.bill_detail_quantity), 0) " +
                    "FROM bill_details " +
                    "WHERE bill_id = @id and bill_details.medicine_id = medicines.medicine_id) " +
                    "WHERE EXISTS " +
                    "(SELECT 1 FROM bill_details " +
                    "WHERE bill_id = @id and bill_details.medicine_id = medicines.medicine_id)",
                    [new("@id", bill.Id)]
                },
                {
                    "delete from bill_details where bill_id = @id",
                    [
                        new("id", bill.Id)
                    ]
                },

                {
                    sb1.ToString(),
                    []
                },
                {
                    sb2.ToString(),
                    []
                }
            };
            DB.ExecuteTransaction(query);
            return Predefined.SUCCESS;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.StackTrace);
        }

        return Predefined.ERROR;
    }

    public int RevertSellBill(string id)
    {
        try
        {
            var query = new Dictionary<string, SqlParameter[]>()
            {
                {
                    "UPDATE medicines " +
                    "SET medicine_quantity = medicine_quantity + (SELECT COALESCE(SUM(bill_details.bill_detail_quantity), 0) " +
                    "FROM bill_details " +
                    "WHERE bill_id = @id and bill_details.medicine_id = medicines.medicine_id) " +
                    "WHERE EXISTS " +
                    "(SELECT 1 FROM bill_details " +
                    "WHERE bill_id = @id and bill_details.medicine_id = medicines.medicine_id)",
                    [new("@id", id)]

                },
                {
                    "delete from bill_details where bill_id = @id",
                    [
                        new("@id", id)
                    ]
                },
                {
                    "delete from bills where bill_id = @id",
                    [
                        new("@id", id)
                    ]
                }
            };
            DB.ExecuteTransaction(query);
            return Predefined.SUCCESS;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.StackTrace);
        }

        return Predefined.ERROR;
    }
}