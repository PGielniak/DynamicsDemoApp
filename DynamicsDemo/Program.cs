using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Configuration;

namespace DynamicsDemo
{
    class Program
    {
        private static CrmServiceClient _crmServiceClient;

        static void Main(string[] args)
        {
            using (_crmServiceClient = new CrmServiceClient(ConfigurationManager.ConnectionStrings["D365ConnectionString"].ConnectionString))
            {
                if (_crmServiceClient.IsReady)
                {
                    Console.WriteLine("Authenticated To D365.");

                }
                else
                {
                    Console.WriteLine("Authentication Failed.");
                    throw _crmServiceClient.LastCrmException;
                }


                IOrganizationService service = _crmServiceClient.OrganizationServiceProxy;

                Entity acc = new Entity("account");
                acc["name"] = "CreatedFromC#";
                service.Create(acc);

                Console.WriteLine($"Account with name {acc["name"]} has been created");

                Console.ReadKey();

            }
           
          
        }
    }
}
