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
    public class EfStudentDal : GenericRepository<Student>, IStudentDal
    {
        public EfStudentDal(EducationPortalDbContext context) : base(context)
        {
        }

        public List<Student> GetStudentsList(int id)
		{
			using var context = new EducationPortalDbContext();
			var values = context.Students.Where(x => x.Id == id).ToList();
			return values;
		}
	}
}
