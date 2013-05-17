using System.Web.Mvc;
using FFCG.GitHubIssueTracker.Integration;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFCG.GitHubIssueTracker.Web.Controllers;

namespace FFCG.GitHubIssueTracker.Web.Tests.Integration
{
    [TestClass]
    public class IssueRepositoryTest
    {
        // ReSharper disable InconsistentNaming

        [TestMethod]
        public void GetAllIssues_should_not_return_empty_list()
        {
            // Arrange
            var repository = new IssueRepository();

            // Act
            var result = repository.GetAllIssues();

            // Assert
            result.Should().NotBeEmpty("GetAllIssues should return a non empty list");
        }

        // ReSharper restore InconsistentNaming
    }
}
