using System;
using System.Collections.Generic;

namespace edusync_api.Model
{
    public class QuizSubmissionModel
    {
        public int QuizId { get; set; }
        public int UserId { get; set; }
        public DateTime SubmissionTime { get; set; }
        public double Score { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public Dictionary<int, string> UserAnswers { get; set; }
        public TimeSpan TimeTaken { get; set; }
    }
} 