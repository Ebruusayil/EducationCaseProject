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
    public class EfInstructorDal : GenericRepository<Instructor>, IInstructorDal
    {
        public EfInstructorDal(EducationPortalDbContext context) : base(context)
        {
        }

        public List<Instructor> GetInstructorList(int id)
        {
            using var context = new EducationPortalDbContext();
            var values = context.Instructors.Where(x => x.Id == id).ToList();
            return values;
        }
    }
}
