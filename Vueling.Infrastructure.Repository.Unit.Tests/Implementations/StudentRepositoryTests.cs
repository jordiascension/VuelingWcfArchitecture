using Autofac.Extras.Moq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Vueling.Domain.Entities;
using Vueling.Infrastructure.Repository.Contracts;

namespace Vueling.Infrastructure.Repository.Unit.Tests
{
    [TestClass()]
    public class StudentRepositoryTests
    {
        [TestMethod()]
        public void AddTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange - configure the mock 
                Student student = new Student
                {
                    Name = "Pepe",
                    Surname = "Soto"

                };

                //Setup
                mock.Mock<IStudentRepository<Student>>().
                    Setup(studentRepository => studentRepository.Add(student)).
                    Returns(student);

                //we create a mocked repository with setup conditions
                var mockedStudentRepository =
                    mock.Create<IStudentRepository<Student>>();

                //Act
                var expectedStudent = mockedStudentRepository.Add(student);

                // Assert
                //verify that GetAll is called one time
                mock.Mock<IStudentRepository<Student>>().
                    Verify(repository => repository.Add(student));

                Assert.IsTrue(student.Equals(expectedStudent));
            }
        }
    }
}