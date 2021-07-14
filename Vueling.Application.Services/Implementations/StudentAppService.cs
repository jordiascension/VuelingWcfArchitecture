using Vueling.Application.Services.Contracts;
using Vueling.Domain.Entities;
using Vueling.Infrastructure.Repository.Contracts;

namespace Vueling.Application.Services
{
    public class StudentAppService : IStudentAppService<Student>
    {
        private readonly IStudentRepository<Student> _studentRepository;

        public StudentAppService(IStudentRepository<Student> studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        public Student Add(Student model)
        {
            throw new System.NotImplementedException();
        }
    }
}
