using System.ComponentModel.DataAnnotations;

namespace edusync_api.Model.Dto
{
    public class CourseCreateDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Instructor ID is required")]
        public Guid InstructorId { get; set; }

        public string MediaUrl { get; set; }
    }
}
