using Microsoft.EntityFrameworkCore;
using SULS.Data;
using SULS.Models;
using System.Collections.Generic;
using System.Linq;

namespace SULS.Services
{
    public class ProblemService : IProblemService
    {
        private readonly SULSContext db;

        public ProblemService(SULSContext db)
        {
            this.db = db;
        }

        public string CreateProblem(string problemName, int totalPoints)
        {
            var problem = new Problem() { Name = problemName, Points = totalPoints };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();

            return problem.Id;
        }

        public List<Problem> GetAllProblemsHome()
        {
            var problems = this.db.Problems.ToList();

            return problems;
        }

        public Problem GetProblemById(string problemId)
        {
            var problem = this.db.Problems.FirstOrDefault(p => p.Id == problemId);

            return problem;
        }
    }
}
