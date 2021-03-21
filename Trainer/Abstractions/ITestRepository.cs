using SUAI.SpbGeographic.Trainer.Models;
using System;
using System.Collections.Generic;

namespace SUAI.SpbGeographic.Trainer.Abstractions
{
    public interface ITestRepository
    {
        IEnumerable<Test> GetAllTests();
        IEnumerable<Test> GetFilteredTests(TestFilter filter);
        void CreateNewTest(Test test);
        void EditTest(Test test);
        void DeleteTest(Guid testId);
    }
}
