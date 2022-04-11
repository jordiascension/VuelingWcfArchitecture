using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

using CustomValidations;

using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

using Vueling.Distributed.WebServices.Model;

namespace Vueling.Distributed.WebServices.Contracts
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    [ValidationBehavior]
    public interface IStudentWebService
    {

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        string GetData([RangeValidator(1, RangeBoundaryType.Inclusive,1,RangeBoundaryType.Ignore)] int value,
            [NotNullValidator(MessageTemplate = "Null value found")] string value1);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        Task<string> ConcatStrings([NotNullValidator(MessageTemplate = "name is null")] string name,
            [NotNullValidator(MessageTemplate = "surname is null")] string surname);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        User Add(User user);


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
