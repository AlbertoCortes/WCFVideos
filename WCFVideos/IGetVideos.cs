using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFVideos
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGetVideos" in both code and config file together.
    [ServiceContract]
    public interface IGetVideos
    {
        
        [OperationContract]
        List<Videos> ObtenerVideos(string nombre);

    }
}
[DataContract]
public class Videos
{
    [DataMember]
    public string ID { get; set; }
    [DataMember]
    public string Nombre { get; set; }
    [DataMember]
    public string Url { get; set; }
    [DataMember]
    public string Thumbnail { get; set; }
}
