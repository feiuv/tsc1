using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using JSONService.Model;
namespace JSONService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceJSON" in both code and config file together.
    [ServiceContract]
    public interface IServiceJSON
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        string Saludos();

        [OperationContract]
        [WebGet(
            UriTemplate = "GetEstudiante?idEstudiante={idEstudiante}&dos={dos}",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
        )]
        Estudiante GetEstudiante(String idEstudiante, int dos);

        [OperationContract]
        [WebGet(
            UriTemplate = "GetEstudiantes",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json
        )]
        Estudiante[] GetEstudiantes();     
    }
}
