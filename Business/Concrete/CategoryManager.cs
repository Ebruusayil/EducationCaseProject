using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Repository.EntityRepository;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager:ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal CategoryDal)
        {
            _categoryDal = CategoryDal;
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);

        }

        public Category TGetByID(int id)
        {
            return _categoryDal.GetByID(id);

        }
        
        public List<Category> TGetList()
        {
            return _categoryDal.GetList();
        }

        public List<Category> TGetCategoriesList(int id)
        {
            return _categoryDal.GetCategoriesList(id);
        }

        public void TInsert(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }

     
    }
}

