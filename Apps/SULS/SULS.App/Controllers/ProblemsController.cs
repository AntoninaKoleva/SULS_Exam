using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Problems;
using SULS.App.ViewModels.Submissions;
using SULS.Services;

namespace SULS.App.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemService problemService;
        private readonly ISubmissionService submissionService;

        public ProblemsController(IProblemService problemService, ISubmissionService submissionService)
        {
            this.problemService = problemService;
            this.submissionService = submissionService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(ProblemInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect($"/Problems/Create");
            }

            this.problemService.CreateProblem(input.Name, input.Points);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var problem = this.problemService.GetProblemById(id);
            var submissions = this.submissionService.GetSubmissionDetalsByProblemId(problem.Id);

            var problemDetails = new ProblemDetailsViewModel()
            {
                Name = problem.Name
            };

            foreach (var submission in submissions)
            {
                var submissionsDetails = new SubmissionViewModel()
                {
                    SubmissionId = submission.Id,
                    Username = submission.User.Username,
                    AchievedResult = submission.AchievedResult,
                    CreatedOn = submission.CreatedOn,
                    MaxPoints = submission.Problem.Points
                };

                problemDetails.Problems.Add(submissionsDetails);
            }

            return this.View(problemDetails);
        }
    }
}
