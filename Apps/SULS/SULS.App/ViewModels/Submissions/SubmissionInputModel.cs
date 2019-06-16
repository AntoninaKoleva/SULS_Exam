using SIS.MvcFramework.Attributes.Validation;

namespace SULS.App.ViewModels.Submissions
{
    public class SubmissionInputModel
    {
        [RequiredSis]
        [StringLengthSis(30, 800, "Code length should be between 30 and 800 charackters")]
        public string Code { get; set; }
        [RequiredSis]
        public string ProblemId { get; set; }
    }
}
