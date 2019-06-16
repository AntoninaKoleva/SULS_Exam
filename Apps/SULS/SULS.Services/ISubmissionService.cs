using SULS.Models;
using System.Collections.Generic;

namespace SULS.Services
{
    public interface ISubmissionService
    {
        int GetSubmissionsCountByProblemName(string problemName);

        string CreateSubmission(string code, string problemId, string userId);

        List<Submission> GetSubmissionDetalsByProblemId(string problemId);

        void Delete(string id);
    }
}
