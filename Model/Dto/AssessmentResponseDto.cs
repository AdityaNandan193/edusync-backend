using System;
using System.ComponentModel.DataAnnotations;

namespace edusync_api.Model.Dto
{
    public class AssessmentResponseDto
    {
        public Guid AssessmentId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Questions are required")]
        public string Questions { get; set; } = string.Empty;

        public int MaxScore { get; set; }

        public Guid CourseId { get; set; }

        [Required(ErrorMessage = "Course title is required")]
        public string CourseTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = "Instructor name is required")]
        public string InstructorName { get; set; } = string.Empty;
    }
}