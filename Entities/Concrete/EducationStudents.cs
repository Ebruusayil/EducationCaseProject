using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EducationStudents:BaseEntity
    {
        [ForeignKey(nameof(Education))]
        public int? EducationId { get; set; }
        public Education? Education { get; set; }
        [ForeignKey(nameof(Student))]
        public int? StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
