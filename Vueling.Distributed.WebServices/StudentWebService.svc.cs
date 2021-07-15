using log4net;

using System;
using System.IO;
using System.ServiceModel;

using Vueling.Application.Services.Contracts;
using Vueling.Distributed.WebServices.Contracts;
using Vueling.Domain.Entities;

namespace Vueling.Distributed.WebServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class StudentWebService : IStudentWebService
    {
        private readonly IStudentAppService<Student> _studentAppService;

        private readonly ILog _log;

        public StudentWebService()
        {

        }



        public StudentWebService(IStudentAppService<Student> studentAppService, ILog Log)
        {

            this._studentAppService = studentAppService;
            this._log = Log;
        }

        public string GetData(int value)
        {
            _log.Error("erqwerqwreq");

            //https://www.c-sharpcorner.com/UploadFile/00a8b7/exception-handling-in-wcf-service/
            try
            {
                _studentAppService.Add(null);
            }
            catch (FileNotFoundException Ex)
            {
                _log.Error("El mensaje de error es: " + Ex.Message);
                throw new FaultException(Ex.ToString());
            }

            return string.Format("You entered: {0}", value);
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
