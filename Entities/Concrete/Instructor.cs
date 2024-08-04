using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Instructor:BaseEntity
    {
        public string FullName { get; set; }
        public int InstructorNumber { get; set; }
        public int UserId { get; set; }
        public int? InstructorTypeId { get; set; }
        public virtual InstructorType InstructorType { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Education> Educations { get; set; }  
        
    }
}
