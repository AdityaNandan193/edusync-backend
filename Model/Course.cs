using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace edusync_api.Model
{
    public class Course
    {
        [Key]
        public Guid CourseId { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Instructor ID is required.")]
        public Guid InstructorId { get; set; }

        [Url]
        public string MediaUrl { get; set; } = string.Empty;

        [ForeignKey("InstructorId")]
        public virtual User? Instructor { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
