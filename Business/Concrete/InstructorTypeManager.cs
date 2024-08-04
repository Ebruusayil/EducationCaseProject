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
    public class InstructorTypeManager : IInstructorTypeService
    {

        private readonly IInstructorTypeDal _InstructorTypeDaL;
        public InstructorTypeManager(IInstructorTypeDal InstructorTypeDaL)
        {
            _InstructorTypeDaL = InstructorTypeDaL;
        }

        public void TDelete(InstructorType t)
        {
            _InstructorTypeDaL.Delete(t);

        }

        public InstructorType TGetByID(int id)
        {
            return _InstructorTypeDaL.GetByID(id);

        }

        public List<InstructorType> TGetList()
        {
            return _InstructorTypeDaL.GetList();
        }



        public void TInsert(InstructorType t)
        {
            _InstructorTypeDaL.Insert(t);
        }

        public void TUpdate(InstructorType t)
        {
            _InstructorTypeDaL.Update(t);
        }
    }
}



