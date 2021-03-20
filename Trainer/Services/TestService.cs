using SUAI.SpbGeographic.Trainer.Models;
using System;
using System.Collections.Generic;

namespace SUAI.SpbGeographic.Trainer.Services
{
    public class TestService
    {
        public IEnumerable<Test> GetAllTests() => new List<Test>();

        public IEnumerable<Test> GetTestsFiltered(TestFilter filter) => throw new NotImplementedException();

        public void CreateNewTest(Test test) => throw new Exception();

        public void EditTest(Test test) => throw new Exception();

        public void DeleteTestById(Guid testId) => throw new Exception();

        public TestLeaderboard GetTestLeaderboard(Guid testId) => new TestLeaderboard();

        public TestResult GetTestResult(Guid testId, Guid userId) => new TestResult();

        public void ProcessTestSolution(TestSolution solution) => throw new NotImplementedException();
    }
}
