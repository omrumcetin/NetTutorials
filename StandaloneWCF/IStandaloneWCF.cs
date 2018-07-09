using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace StandaloneWCF
{
    [ServiceContract]
    public interface IStandaloneWCF
    {
        [WebGet(UriTemplate = "Info", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract()]
        int Add(int val1, int val2);
    }
}
