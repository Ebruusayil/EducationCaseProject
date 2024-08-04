namespace Dto
{
    public class EducationDto
    {
        public string Name { get; set; }
        public int Quota { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public int InstructorId { get; set; }
        public int CategoryId { get; set; }
        public double CompletionPercentage { get; set; }
        public int Id { get; set; }
        public string InstructorFullName { get; set; }
        public string CategoryFullName { get; set; }
    }
}
