using log4net;

using Vueling.Application.Services.Contracts;
using Vueling.Domain.Entities;
using Vueling.Infrastructure.Repository.Contracts;
using Vueling.Infrastructure.Repository.Implementations;

namespace Vueling.Application.Services
{
    public class StudentAppService : IStudentAppService<Student>
    {
        private readonly IStudentRepository<Student> _studentRepository;
        private readonly ILog _log;

        public StudentAppService(IStudentRepository<Student> studentRepository, ILog log)
        {
            this._studentRepository = studentRepository;
            this._log = log;
            _log.Info("StudentAppService Created");
        }

        public Student Add(Student model)
        {
            _log.Info("StudentAppService Add method called");
            _log.Info("Student object: " + model.ToString());
            return _studentRepository.Add(model);

        }
    }
}
