using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using SIS.MvcFramework;
using SULS.Services;
using SULS.App.ViewModels.Problems;
using SULS.App.ViewModels.Home;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemService problemService;
        private readonly ISubmissionService submissionService;

        public HomeController(IProblemService problemService, ISubmissionService submissionService)
        {
            this.problemService = problemService;
            this.submissionService = submissionService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        public IActionResult Index()
        {
            ProblemHomeListViewModel problemsListVM = new ProblemHomeListViewModel();

            if (this.IsLoggedIn())
            {
                var problems = this.problemService.GetAllProblemsHome();
                foreach (var problem in problems)
                {
                    var problemsVM = new ProblemHomeViewModel()
                    {
                        Id = problem.Id,
                        Name = problem.Name,
                        Count = this.submissionService.GetSubmissionsCountByProblemName(problem.Name)
                    };

                    problemsListVM.Problems.Add(problemsVM);
                }
            }

            return this.View(problemsListVM);
        }
    }
}