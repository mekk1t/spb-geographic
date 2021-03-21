using SUAI.SpbGeographic.Trainer.Abstractions;
using SUAI.SpbGeographic.Trainer.Models;
using System;
using System.Collections.Generic;

namespace SUAI.SpbGeographic.Trainer.Services
{
    public class TestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IAccessValidator _accessValidator;

        public TestService(ITestRepository testRepository, IAccessValidator accessValidator)
        {
            _testRepository = testRepository;
            _accessValidator = accessValidator;
        }

        public IEnumerable<Test> GetAllTests() => _testRepository.GetAllTests();

        public IEnumerable<Test> GetFilteredTests(TestFilter filter) => _testRepository.GetFilteredTests(filter);

        public void CreateNewTest(Test test)
        {
            if (_accessValidator.CurrentUserHasAccessLevel(AccessLevel.Teacher))
            {
                _testRepository.CreateNewTest(test);
                return;
            }

            throw new ForbiddenException();
        }

        public void EditTest(Test test)
        {
            if (_accessValidator.CurrentUserHasAccessLevel(AccessLevel.Teacher))
            {
                _testRepository.EditTest(test);
                return;
            }

            throw new ForbiddenException();
        }

        public void DeleteTestById(Guid testId)
        {
            if (_accessValidator.CurrentUserHasAccessLevel(AccessLevel.Administrator))
            {
                _testRepository.DeleteTest(testId);
                return;
            }

            throw new ForbiddenException();
        }

        public TestLeaderboard GetTestLeaderboard(Guid testId) => throw new NotImplementedException();

        public TestResult GetTestResult(Guid testId, Guid userId) => throw new NotImplementedException();

        public void ProcessTestSolution(TestSolution solution) => throw new NotImplementedException();
    }
}
