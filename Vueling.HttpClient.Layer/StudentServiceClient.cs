using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.HttpClient.Layer
{
    public class StudentServiceClient
    {
        public string GetData()
        {
            ServiceWebReference.IStudentWebService studentWebServiceClient = new ServiceWebReference.StudentWebServiceClient();
            return studentWebServiceClient.GetData(1, "Test");
        }
    }
}
