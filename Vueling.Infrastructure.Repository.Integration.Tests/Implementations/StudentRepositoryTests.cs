using Microsoft.VisualStudio.TestTools.UnitTesting;

using Vueling.Domain.Entities;
using Vueling.Infrastructure.Repository.Contracts;
using Vueling.Infrastructure.Repository.Integration.Tests.AutofacModule;
using Vueling.Infrastructure.Repository.Integration.Tests.Implementations;

namespace Vueling.Infrastructure.Repository.Integration.Tests
{
    [TestClass()]
    public class StudentRepositoryTests : IoCSupportedTest<RepositoryModuleTest>
    {
        private IStudentRepository<Student> _studentRepository = null;


        [TestInitialize]
        public void SetUp()
        {
            _studentRepository = Resolve<IStudentRepository<Student>>();
        }

        [TestMethod()]
        public void AddTest()
        {
            Student student = new Student
            {
                Name = "Pepe",
                Surname = "Soto"

            };
            Assert.IsTrue(_studentRepository.Add(student) != null);
        }
    }
}