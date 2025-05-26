using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace edusync_api.Model
{
    public class Assessment
    {
        [Key]
        public Guid AssessmentId { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course ID is required.")]
        public Guid CourseId { get; set; }

        public Course? Course { get; set; }

        [Required(ErrorMessage = "Questions are required.")]
        public string Questions { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
