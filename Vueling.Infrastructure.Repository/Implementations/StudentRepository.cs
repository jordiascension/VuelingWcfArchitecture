using System;

using Vueling.Domain.Entities;
using Vueling.Infrastructure.Repository.Contracts;

namespace Vueling.Infrastructure.Repository
{
    public class StudentRepository : IStudentRepository<Student>
    {
        public Student Add(Student model)
        {
            throw new NotImplementedException();
        }
    }
}
