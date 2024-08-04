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
    public class EfEducationDal: GenericRepository<Education>, IEducationDal
    {
        public EfEducationDal(EducationPortalDbContext context) : base(context)
        {
        }

        public List<Education> GetEducationsList(int id)
        {
            using var context = new EducationPortalDbContext();
            var values = context.Educations.Where(x => x.Id == id).ToList();
            return values;
        }


        }
    }

