using System;

namespace edusync_api.Model
{
    public class QuizAttemptData
    {
        public Guid AttemptId { get; set; }
        public Guid AssessmentId { get; set; }
        public Guid UserId { get; set; }
        public int Score { get; set; }
        public DateTime AttemptDate { get; set; }
        public TimeSpan Duration { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
    }
} 