using log4net;

using System;
using System.Collections.Generic;
using System.Text;

using Vueling.Infrastructure.Repository.Contracts;

namespace Vueling.Infrastructure.Repository.Implementations
{
    public class SqlStudentRepository : IRepository
    {
        private readonly ILog _log;

        public SqlStudentRepository(ILog log)
        {
            this._log = log;
            _log.Info("SqlStudentRepository Created");
        }
        public void prueba()
        {
            _log.Info("prueba method Executed in SqlStudentRepository class");
        }
    }
}
