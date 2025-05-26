using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace edusync_api.Model
{
    public class Assessment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Questions { get; set; } = string.Empty;

        [Required]
        public int MaxScore { get; set; }

        [Required]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Result> Results { get; set; } = new List<Result>();

        public List<McqQuestion> GetQuestions()
        {
            return JsonSerializer.Deserialize<List<McqQuestion>>(Questions) ?? new List<McqQuestion>();
        }

        public void SetQuestions(List<McqQuestion> questions)
        {
            Questions = JsonSerializer.Serialize(questions);
        }
    }

    public class McqQuestion
    {
        public string Question { get; set; } = string.Empty;
        public List<string> Options { get; set; } = new List<string>();
        public int CorrectIndex { get; set; }
    }
}
