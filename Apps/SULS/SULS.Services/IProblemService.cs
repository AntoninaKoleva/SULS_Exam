using SULS.Models;
using System.Collections.Generic;

namespace SULS.Services
{
    public interface IProblemService
    {
        List<Problem> GetAllProblemsHome();
        Problem GetProblemById(string problemId);
        string CreateProblem(string problemName, int totalPoints);
    }
}
