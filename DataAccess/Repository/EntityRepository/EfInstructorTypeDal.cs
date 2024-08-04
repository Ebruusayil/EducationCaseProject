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
    public class EfInstructorTypeDal : GenericRepository<InstructorType>, IInstructorTypeDal
    {
        public EfInstructorTypeDal(EducationPortalDbContext context) : base(context)
        {
        }
    }
}
