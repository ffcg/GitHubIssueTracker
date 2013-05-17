using System.Collections.Generic;
using FFCG.GitHubIssueTracker.Integration.Models;

namespace FFCG.GitHubIssueTracker.Integration
{
    public class IssueRepository
    {
        public string AuthorizationToken { get; set; }

        public IssueRepository(string authorizationToken)
        {
            AuthorizationToken = authorizationToken;
        }

        public IEnumerable<Issue> GetAllIssues()
        {
            // C:\Code> curl -i -H 'Authorization: token 8768769532a411f9d7ffdb7a8804af6fae7bad0e' https://api.github.com/repos/ffcg/GitHubIssueTracker/issues
            return new List<Issue>();
        }

        public Issue CreateIssue(string title, string description, string assignee)
        {
            var issue = new Issue() {Title = title, Description = description, Assignee = assignee};    
            return issue;
        }
    }
}
