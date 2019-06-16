using System;

namespace SULS.App.ViewModels.Submissions
{
    public class SubmissionViewModel
    {
        public string SubmissionId { get; set; }
        public string Username { get; set; }
        public int AchievedResult { get; set; }
        public DateTime CreatedOn { get; set; }
        public int MaxPoints { get; set; }
    }
}
