using Microsoft.EntityFrameworkCore;
using SULS.Data;
using SULS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SULS.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly SULSContext db;
        private readonly IProblemService problemService;

        public SubmissionService(SULSContext db, IProblemService problemService)
        {
            this.db = db;
            this.problemService = problemService;
        }

        public string CreateSubmission(string code, string problemId, string userId)
        {
            var problem = this.problemService.GetProblemById(problemId);
            var random = new Random();
            var randResult = random.Next(0, problem.Points);

            var submission = new Submission()
            {
                Code = code,
                AchievedResult = randResult,
                CreatedOn = DateTime.UtcNow,
                ProblemId = problem.Id,
                UserId = userId
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();

            return submission.Id;
        }

        public int GetSubmissionsCountByProblemName(string problemName)
        {
            var submissionCount = this.db.Submissions
                    .Include(s => s.Problem)
                    .Where(p => p.Problem.Name == problemName)
                    .Count();

            return submissionCount;
        }

        public List<Submission> GetSubmissionDetalsByProblemId(string problemId)
        {
            var submissions = this.db.Submissions
                .Include(s => s.Problem)
                .Include(s => s.User)
                .Where(s => s.ProblemId == problemId).ToList();

            return submissions;
        }

        public void Delete(string id)
        {
            var submission = this.db.Submissions.FirstOrDefault(s => s.Id == id);
            this.db.Submissions.Remove(submission);
            this.db.SaveChanges();
        }
    }
}
