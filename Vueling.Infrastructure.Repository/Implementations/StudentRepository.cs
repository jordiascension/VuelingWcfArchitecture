
using log4net;

using System;

using Vueling.Domain.Entities;
using Vueling.Infrastructure.Repository.Contracts;

namespace Vueling.Infrastructure.Repository
{

    public class StudentRepository : IStudentRepository<Student>
    {
        private readonly ILog _log;

        public StudentRepository(ILog log)
        {
            this._log = log;
            _log.Info("StudentRepository Created");
        }


        public Student Add(Student model)
        {
            _log.Info("Add method Executed");
            //throw new NotImplementedException();
            return null;
        }
    }
}
