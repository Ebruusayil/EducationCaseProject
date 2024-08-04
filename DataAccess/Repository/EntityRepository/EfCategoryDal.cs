using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.EntityRepository
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(EducationPortalDbContext context) : base(context)
        {
        }

        public List<Category> GetCategoriesList(int id)
        {
            using var context = new EducationPortalDbContext();
            var values = context.Categories.Where(x => x.Id == id).ToList();
            return values;
        }
    }
}
