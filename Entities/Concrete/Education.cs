using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Education : BaseEntity
    {
        public Education() : base()
        { }

        public Education(string name, int quota, decimal price, TimeSpan duration, int ınstructorId, int categoryId, double completionPercentage)
        {
            Name = name;
            Quota = quota;
            Price = price;
            Duration = duration;
            InstructorId = ınstructorId;
            CategoryId = categoryId;
            CompletionPercentage = completionPercentage;
            
        }


        public string Name { get; set; }
        public int Quota { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public int InstructorId { get; set; }

        public int CategoryId { get; set; } 
        public double CompletionPercentage { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
