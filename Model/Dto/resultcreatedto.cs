using System;
using System.ComponentModel.DataAnnotations;

namespace edusync_api.Model.Dto
{
    public class ResultCreateDto
    {
        [Required(ErrorMessage = "Assessment ID is required")]
        public Guid AssessmentId { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Score is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Score must be a positive number")]
        public int Score { get; set; }

        [Required(ErrorMessage = "Attempt date is required")]
        public DateTime AttemptDate { get; set; }
    }
}
