using System.Collections.Generic;
using QPharma.DAL;
using QPharma.DTO;
using QPharma.Util;

namespace QPharma.BUS
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

        public int ForceDelete(string maTheLoai)
        {
            return categoryDAL.ForceDelete(maTheLoai);
        }

        public int Restore(string maTheLoai)
        {
            return categoryDAL.Restore(maTheLoai);
        }

        public int RestoreAll()
        {
            return categoryDAL.RestoreAll();
        }
    }
}