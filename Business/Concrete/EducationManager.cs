using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Repository.EntityRepository;
using Dto;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EducationManager : IEducationService
    {

        private readonly IEducationDal _educationDaL;

        public EducationManager(IEducationDal educationDaL)
        {
            _educationDaL = educationDaL;
        }

        public void TDelete(Education t)
        {
            _educationDaL.Delete(t);

        }

        public Education TGetByID(int id)
        {
            return _educationDaL.GetByID(id);

        }

        public List<Education> TGetList()
        {
            return _educationDaL.GetList();
        }

       

        public void TInsert(Education t)
        {
            _educationDaL.Insert(t);
        }

        public void TUpdate(Education t)
        {
            _educationDaL.Update(t);
        }

        public List<Education> TGetEducationsList(int id)
        {
            return _educationDaL.GetEducationsList(id);
        }
        public IEnumerable<EducationDto> GetAllEducationsAsync()
        {
            var educations =  _educationDaL.GetList();

            var educationDtos = educations.Select(e => new EducationDto
            {
                Id = e.Id,
                Name = e.Name,
                Quota = e.Quota,
                Price = e.Price,
                Duration = e.Duration,
                InstructorId = e.InstructorId,
                CategoryId = e.CategoryId,
                CompletionPercentage = e.CompletionPercentage,
                InstructorFullName = e.Instructor.FullName, 
                CategoryFullName = e.Category.Name 
            }).ToList();

            return educationDtos;
        }
    }
}

