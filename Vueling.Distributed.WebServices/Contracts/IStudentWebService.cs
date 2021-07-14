using System.Runtime.Serialization;
using System.ServiceModel;

namespace Vueling.Distributed.WebServices.Contracts
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IStudentWebService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);


    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class CompositeType
    {
        [DataMember]
        public bool BoolValue { get; set; } = true;

        [DataMember]
        public string StringValue { get; set; } = "Hello ";
    }
}
