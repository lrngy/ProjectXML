
namespace QPharma.BUS
{
    public class BillBUS
    {
        private BillDAL billDAL;
        public BillBUS()
        {
            billDAL = new BillDAL();
        }


        public (int totalPage, int numRecord, List<BillDTO> listBills) LoadData(int pageSize, int currentPage,
            bool isNotDeleted = true)
        {
            return billDAL.GetAll(pageSize, currentPage, isNotDeleted);
        }

        internal int Delete(string id)
        {
            return billDAL.Delete(id);
        }

        public int ForceDelete(string id)
        {
            return billDAL.ForceDelete(id);
        }

        public (int totalPage, int numRecord, List<BillDTO> listBills) Search(int pageSize, int currentPage, string maHoaDon, string maHoacTenThuoc, 
            string tenKhachHang, int trangThai, string tuNgay, string denNgay, string giaTriTu, string giaTriDen, string maNhanVien)
        {
            StringBuilder whereClause = new StringBuilder("Where 1 = 1");
            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(maHoaDon))
            {
                whereClause.Append(" AND bill_id = @maHoaDon");
                parameters.Add(new SqlParameter("@maHoaDon", maHoaDon));
            }
            if (!string.IsNullOrEmpty(maHoacTenThuoc))
            {
                whereClause.Append(" AND bill_id in (select bill_id from bill_details where medicine_id in (select medicine_id from medicines where medicine_id like @maHoacTenThuoc or medicine_name like @maHoacTenThuoc))");
                parameters.Add(new SqlParameter("@maHoacTenThuoc", "%" + maHoacTenThuoc + "%"));
            }
            if (!string.IsNullOrEmpty(tenKhachHang))
            {
                whereClause.Append(" AND customer_id in (select customer_id from customers where customer_name like @tenKhachHang)");
                parameters.Add(new SqlParameter("@tenKhachHang", "%" + tenKhachHang + "%"));
            }
            if (trangThai != -1)
            {
                whereClause.Append(" AND bill_status = @trangThai");
                parameters.Add(new SqlParameter("@trangThai", trangThai == 0));
            }
            if (!string.IsNullOrEmpty(tuNgay))
            {
                whereClause.Append(" AND cast(bill_created as date) >= @tuNgay");
                parameters.Add(new SqlParameter("@tuNgay", DateTime.ParseExact(tuNgay, "dd/MM/yyyy", null)));
            }
            if (!string.IsNullOrEmpty(denNgay))
            {
                whereClause.Append(" AND cast(bill_created as date) <= @denNgay");
                parameters.Add(new SqlParameter("@denNgay", DateTime.ParseExact(denNgay, "dd/MM/yyyy", null)));
            }
            if (!string.IsNullOrEmpty(giaTriTu))
            {
                whereClause.Append(" AND bill_total >= @giaTriTu");
                parameters.Add(new SqlParameter("@giaTriTu", giaTriTu));
            }
            if (!string.IsNullOrEmpty(giaTriDen))
            {
                whereClause.Append(" AND bill_total <= @giaTriDen");
                parameters.Add(new SqlParameter("@giaTriDen", giaTriDen));
            }

            if (!string.IsNullOrEmpty(maNhanVien))
            {
                whereClause.Append(" AND staff_id = @maNhanVien");
                parameters.Add(new SqlParameter("@maNhanVien", maNhanVien));
            }

            return billDAL.GetAll(pageSize, currentPage, true, parameters, whereClause.ToString());
        }

        public List<string> GetDateList()
        {
            return billDAL.GetDateList();
        }

        public List<string> GetPriceList()
        {
            return billDAL.GetPriceList();
        }

        public List<string> GetStaffList()
        {
            return billDAL.GetStaffList();
        }

        public int RestoreAll()
        {
            return billDAL.RestoreAll();
        }

        public int Restore(string id)
        {
            return billDAL.Restore(id);
        }

        public int ForceDeleteAll()
        {
            return billDAL.ForceDeleteAll();
        }
    }
}