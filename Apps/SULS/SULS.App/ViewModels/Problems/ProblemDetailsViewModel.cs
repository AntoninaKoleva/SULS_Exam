using SULS.App.ViewModels.Submissions;
using System;
using System.Collections.Generic;

namespace SULS.App.ViewModels.Problems
{
    public class ProblemDetailsViewModel
    {
        public ProblemDetailsViewModel()
        {
            this.Problems = new List<SubmissionViewModel>();
        }

        public string Name { get; set; }

        public List<SubmissionViewModel> Problems { get; set; }
    }
}
