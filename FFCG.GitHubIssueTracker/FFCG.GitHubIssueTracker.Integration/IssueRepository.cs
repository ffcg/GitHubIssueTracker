using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FFCG.GitHubIssueTracker.Integration.Models;

namespace FFCG.GitHubIssueTracker.Integration
{
    public class IssueRepository
    {
        public IEnumerable<Issue> GetAllIssues()
        {
            return new List<Issue>();
        } 
    }
}
