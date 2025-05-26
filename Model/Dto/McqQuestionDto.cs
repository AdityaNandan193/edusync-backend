using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace edusync_api.Model.Dto
{
    public class McqQuestionDto
    {
        [Required(ErrorMessage = "Question is required")]
        [JsonPropertyName("question")]
        public string Question { get; set; } = string.Empty;

        [Required(ErrorMessage = "Options are required")]
        [JsonPropertyName("options")]
        public List<string> Options { get; set; } = new List<string>();

        [Required(ErrorMessage = "Correct index is required")]
        [JsonPropertyName("correctIndex")]
        public int CorrectIndex { get; set; }
    }
}
