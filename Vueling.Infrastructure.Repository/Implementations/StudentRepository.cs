﻿
using log4net;

using System;

using Vueling.Domain.Entities;
using Vueling.Infrastructure.Repository.Contracts;
using Vueling.Infrastructure.Repository.Implementations;

namespace Vueling.Infrastructure.Repository
{

    public class StudentRepository : IStudentRepository<Student>, IRepository
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

        public void prueba()
        {
            _log.Info("prueba method Executed in StudentRepository class");
        }
    }
}
