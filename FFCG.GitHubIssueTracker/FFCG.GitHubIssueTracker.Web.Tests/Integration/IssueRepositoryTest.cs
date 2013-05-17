using System;
using System.Linq;
using System.Web.Mvc;
using FFCG.GitHubIssueTracker.Integration;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFCG.GitHubIssueTracker.Web.Controllers;
using NUnit.Framework;

namespace FFCG.GitHubIssueTracker.Web.Tests.Integration
{
    public class IssueRepositoryTest
    {
        // ReSharper disable InconsistentNaming

        private string authorizationToken = "8768769532a411f9d7ffdb7a8804af6fae7bad0e";

        [Test]
        public void CreateIssue_should_create_an_Issue()
        {
            // Arrange
            var repository = new IssueRepository(authorizationToken: authorizationToken);

            // Act
            var issue = repository.CreateIssue(
                title:"Test issue " + Guid.NewGuid().ToString(), 
                description:"This is an issue created by a test, it can safely be ignored", 
                assignee:"FredrikGoransson");

            // Assert
            issue.Should().NotBeNull();
        }

        [Test]
        public void CreateIssue_should_create_an_Issue_with_Id_assigned_by_GitHub()
        {
            // Arrange
            var repository = new IssueRepository(authorizationToken: authorizationToken);

            // Act
            var issue = repository.CreateIssue(
                title: "Test issue " + Guid.NewGuid().ToString(),
                description: "This is an issue created by a test, it can safely be ignored",
                assignee: "FredrikGoransson");

            // Assert
            issue.Id.Should().NotBeNullOrEmpty("GitHub should control creation of Id's");
        }

        [Test]
        public void CreateIssue_should_add_an_Issue_to_GitHub()
        {
            // Arrange
            var repository = new IssueRepository(authorizationToken: authorizationToken);

            // Act
            var issue = repository.CreateIssue(
                title: "Test issue " + Guid.NewGuid().ToString(),
                description: "This is an issue created by a test, it can safely be ignored",
                assignee: "FredrikGoransson");
            var retrievedIssue = repository.GetAllIssues().FirstOrDefault(i => i.Id == issue.Id);

            // Assert
            retrievedIssue.Should().NotBeNull("GitHub should store the Issue");
        }

        [Test]
        public void GetAllIssues_should_not_return_empty_list()
        {
            // Arrange
            var repository = new IssueRepository(authorizationToken: authorizationToken);
            repository.CreateIssue("Test issue " + Guid.NewGuid().ToString(), "This is an issue created by a test, it can safely be ignored", "FredrikGoransson");

            // Act
            var result = repository.GetAllIssues();

            // Assert
            result.Should().NotBeEmpty("GetAllIssues should return a non empty list");
        }

        // ReSharper restore InconsistentNaming
    }
}
