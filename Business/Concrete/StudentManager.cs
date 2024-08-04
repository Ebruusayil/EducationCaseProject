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
    public class StudentManager : IStudentService
    {
        private readonly IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public void TDelete(Student t)
        {
            _studentDal.Delete(t);

        }

        public Student TGetByID(int id)
        {
            return _studentDal.GetByID(id);

        }

        public List<Student> TGetList()
        {
            return _studentDal.GetList();
        }

        public List<Student> TGetStudentsList(int id)
        {
            return _studentDal.GetStudentsList(id);
        }

        public void TInsert(Student t)
        {
            _studentDal.Insert(t);
        }

        public void TUpdate(Student t)
        {
            _studentDal.Update(t);
        }
    }
}
