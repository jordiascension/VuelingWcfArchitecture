using log4net;

using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

using System;
using System.IO;
using System.ServiceModel;
using System.Threading.Tasks;

using Vueling.Application.Services.Contracts;
using Vueling.Application.Services.Implementations;
using Vueling.Distributed.WebServices.Contracts;
using Vueling.Distributed.WebServices.Model;
using Vueling.Domain.Entities;
using Vueling.CrossCutting.Resources;
using System.Resources;

namespace Vueling.Distributed.WebServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class StudentWebService : IStudentWebService
    {
        private readonly IStudentAppService<Student> _studentAppService;


        private readonly StudentAppService2 _studentAppService2;

        private readonly ILog _log;

        private const string NameNullValue = "Value is null";

        public StudentWebService()
        {

        }



        public StudentWebService(IStudentAppService<Student> studentAppService, 
            ILog Log, StudentAppService2 studentAppService2)
        {

            this._studentAppService = studentAppService;
            this._log = Log;
            this._studentAppService2 = studentAppService2;
        }

        public User Add(User user)
        {
            return user;
        }

        public async Task<string> ConcatStrings([NotNullValidator(MessageTemplate = "name is null")] string name, [NotNullValidator(MessageTemplate = "surname is null")] string surname)
        {
            string result;

            result = name + " " + surname;

            return await Task.FromResult(result);
        }

        public string GetData([RangeValidator(1, RangeBoundaryType.Inclusive, 1, RangeBoundaryType.Ignore, MessageTemplate = "0 value found")] int value, 
                              [NotNullValidator(MessageTemplate = NameNullValue)] String value1)
        {
           
            
            _log.Error(MessageResource.ErrorGetData);

            //https://www.c-sharpcorner.com/UploadFile/00a8b7/exception-handling-in-wcf-service/
            try
            {
                this._studentAppService2.GetData();
                Student student = new Student();
                student.Name = "Pepe";
                student.Surname = "Soto";
                student.StudentId = 1;
                _studentAppService.Add(student);
            }
            catch (FileNotFoundException Ex)
            {
                _log.Error("El mensaje de error es: " + Ex.Message);
                throw new FaultException(Ex.ToString());
            }

            return string.Format("You entered: {0},{1}", value, value1);

        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
