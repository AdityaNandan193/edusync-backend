using System;
using System.ComponentModel.DataAnnotations;

namespace edusync_api.Model.Dto
{
    public class CourseWithInstructorDto
    {
        public Guid CourseId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;

        public string MediaUrl { get; set; } = string.Empty;

        public Guid InstructorId { get; set; }

        [Required(ErrorMessage = "Instructor name is required")]
        public string InstructorName { get; set; } = string.Empty;
    }
}
