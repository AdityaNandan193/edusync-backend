using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace edusync_api.Model
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string MediaUrl { get; set; } = string.Empty;

        [Required]
        public int InstructorId { get; set; }

        [ForeignKey("InstructorId")]
        public User Instructor { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
