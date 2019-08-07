using System;
using StandaloneWCF;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WCFServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a URI to serve as the base address 8090
            Uri httpUrl = new Uri("http://localhost:10005/wcfservice");

            //Create ServiceHost
            ServiceHost host = new ServiceHost(typeof(StandaloneWCF.StandaloneWCF), httpUrl);


            host.AddServiceEndpoint(typeof(StandaloneWCF.IStandaloneWCF), new WSHttpBinding(), "");

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);
            //Add a service endpoint
            //var tcpBinding = new NetTcpBinding("OSSServiceTcpBinding");           
            //host.AddServiceEndpoint(typeof(IStandaloneWCF), new NetTcpBinding("OSSServiceTcpBinding"), "net.tcp://localhost:9970/wcfservice");
            //var bindingWeb = new WebHttpBinding("OSSServiceBinding");
            //host.AddServiceEndpoint(typeof(IStandaloneWCF), new WebHttpBinding("OSSServiceTcpBinding"), "http://localhost:9972/wcfservice");

            //var bindingWeb = new WebHttpBinding(WebHttpSecurityMode.None);
            //var baseAddress = host.Description.Endpoints[0].Address.Uri.AbsoluteUri;
            //var endPoint = new ServiceEndpoint(ContractDescription.GetContract(typeof(IStandaloneWCF)), bindingWeb,
            //    new EndpointAddress(baseAddress + "/Web"));
            //var webBehavior = new WebHttpBehavior();
            //endPoint.Behaviors.Add(webBehavior);
            //host.AddServiceEndpoint(endPoint);

            //Start the Service
            host.Open();
            Console.WriteLine("Service is host at " + DateTime.Now.ToString());
            Console.WriteLine("Host is running... Press  key to stop");
            Console.ReadLine();
        }
    }
}
