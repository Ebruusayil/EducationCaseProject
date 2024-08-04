using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class InstructorManager : IInstructorService
    {

        private readonly IInstructorDal _InstructorDaL;

        public InstructorManager(IInstructorDal InstructorDaL)
        {
            _InstructorDaL = InstructorDaL;
        }

        public void TDelete(Instructor t)
        {
            _InstructorDaL.Delete(t);

        }

        public Instructor TGetByID(int id)
        {
            return _InstructorDaL.GetByID(id);

        }

        public List<Instructor> TGetList()
        {
            return _InstructorDaL.GetList();
        }



        public void TInsert(Instructor t)
        {
            _InstructorDaL.Insert(t);
        }

        public void TUpdate(Instructor t)
        {
            _InstructorDaL.Update(t);
        }

   

     
    }
}

