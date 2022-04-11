using System;
using System.Collections.Generic;
using System.Text;

using Vueling.Application.Services.Contracts;
using Vueling.Domain.Entities;
using Vueling.Infrastructure.Repository.Contracts;
using Vueling.Infrastructure.Repository.Implementations;
namespace Vueling.Application.Services.Implementations
{
    public class StudentAppService2 
    {
        private readonly Func<DatabaseEnum, IRepository> _dataFactory;
        public StudentAppService2( Func<DatabaseEnum, IRepository> dataFactory)
        {
            _dataFactory= dataFactory;
        }
        public void GetData()
        {
            var dataService = this._dataFactory(DatabaseEnum.Sql);
            dataService.prueba();
        }
    }
}
