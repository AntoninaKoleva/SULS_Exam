using System.Collections.Generic;

namespace SULS.App.ViewModels.Home
{
    public class ProblemHomeListViewModel
    {
        public ProblemHomeListViewModel()
        {
            this.Problems = new List<ProblemHomeViewModel>();
        }

        public List<ProblemHomeViewModel> Problems { get; set; }

    }
}
