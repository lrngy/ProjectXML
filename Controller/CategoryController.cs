using ProjectXML.DAO;
using ProjectXML.Model;
using ProjectXML.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectXML.Controller
{
    public class CategoryController
    {
        public CategoryDAO categoryDAO { get; set; }
        public CategoryController()
        {
            categoryDAO = new CategoryDAO();
        }
        public List<Category> LoadData()
        {
            return categoryDAO.GetAll();
        }

        public int Insert(Category category)
        {
            if(categoryDAO.CheckExist(category.id))
            {
                return Predefined.ID_EXIST;
            }
            return categoryDAO.Insert(category);
        }

        public int Update(Category category)
        {
            if (categoryDAO.GetById(category.id) == null)
            {
                return Predefined.ID_NOT_EXIST;
            }
            return categoryDAO.Update(category);
        }

        public int Delete(string maTheLoai)
        {
            if (categoryDAO.GetById(maTheLoai) == null)
            {
                return Predefined.ID_NOT_EXIST;
            }
            return categoryDAO.Delete(maTheLoai);
            
        }

        internal int Restore(string maTheLoai)
        {
            return categoryDAO.Restore(maTheLoai);
            
        }

        internal int ForceDelete(string maTheLoai)
        {
            return categoryDAO.ForceDelete(maTheLoai);
        }

        public void ReloadData()
        {
            categoryDAO.ReloadData();
        }

        internal int RestoreAll()
        {
            return categoryDAO.RestoreAll();
        }
    }
}
