using System.Collections.Generic;
using ProjectXML.DAL;
using ProjectXML.DTO;
using ProjectXML.Util;

namespace ProjectXML.BUS
{
    public class CategoryBUS
    {
        public CategoryBUS()
        {
            categoryDAL = new CategoryDAL();
        }

        public CategoryDAL categoryDAL { get; set; }

        public List<CategoryDTO> LoadData()
        {
            return categoryDAL.GetAll();
        }

        public int Insert(CategoryDTO category)
        {
            if (categoryDAL.CheckExistName(category.name)) return Predefined.ID_EXIST;
            return categoryDAL.Insert(category);
        }

        public int Update(CategoryDTO category)
        {
            if (categoryDAL.GetById(category.id) == null) return Predefined.ID_NOT_EXIST;
            return categoryDAL.Update(category);
        }

        public int Delete(string maTheLoai)
        {
            if (categoryDAL.GetById(maTheLoai) == null) return Predefined.ID_NOT_EXIST;
            return categoryDAL.Delete(maTheLoai);
        }

        internal int Restore(string maTheLoai)
        {
            return categoryDAL.Restore(maTheLoai);
        }

        internal int ForceDelete(string maTheLoai)
        {
            return categoryDAL.ForceDelete(maTheLoai);
        }

        //public void ReloadData()
        //{
        //    categoryDAL.ReloadData();
        //}

        internal int RestoreAll()
        {
            return categoryDAL.RestoreAll();
        }
    }
}