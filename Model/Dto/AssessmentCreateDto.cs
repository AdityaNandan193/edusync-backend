using System.ComponentModel.DataAnnotations;

namespace edusync_api.Model.Dto
{
    public class AssessmentCreateDto
    {
        [Required(ErrorMessage = "Course ID is required")]
        public Guid CourseId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Questions are required")]
        public string Questions { get; set; }

        public int MaxScore { get; set; }
    }
}
