using System;
using System.ComponentModel.DataAnnotations;

namespace edusync_api.Model
{
    public class Result
    {
        [Key]
        public Guid ResultId { get; set; }

        [Required]
        public Guid AssessmentId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public int Score { get; set; }

        public DateTime AttemptDate { get; set; }

        public Assessment? Assessment { get; set; }
        public User? User { get; set; }
    }
}
