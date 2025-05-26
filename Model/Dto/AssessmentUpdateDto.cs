using System.ComponentModel.DataAnnotations;

namespace edusync_api.Model.Dto
{
    public class AssessmentUpdateDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Questions are required")]
        public string Questions { get; set; }

        public int MaxScore { get; set; }
    }
}