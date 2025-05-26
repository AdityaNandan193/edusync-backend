using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace edusync_api.Model.Dto
{
    public class AssessmentAttemptDto
    {
        [Required(ErrorMessage = "Assessment ID is required")]
        public Guid AssessmentId { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Selected answers are required")]
        public List<int> SelectedAnswers { get; set; } = new List<int>();
    }
}
