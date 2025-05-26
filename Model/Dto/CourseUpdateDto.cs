using System.ComponentModel.DataAnnotations;

namespace edusync_api.Model.Dto
{
    public class CourseUpdateDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public string MediaUrl { get; set; }
    }
}