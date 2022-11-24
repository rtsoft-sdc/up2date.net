using System;
using System.IO;
using System.Threading.Tasks;
using Up2dateDotNet;

namespace ClientExample
{
    internal class Program
    {
        static IWrapper wrapper = new Wrapper();
        const string prompt = "\nEnter command (s - stop, p - poll) : ";

        static void Main(string[] args)
        {
            Console.WriteLine("Client started");

            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ClientExample <provisioningUrl> <certificateFile>");
                Console.WriteLine("   or: ClientExample <hawkbitUrl> <tenant> <controllerId> <token>");
            }
            else if (args.Length < 3)
            {
                StartClientWithCertificate(args[0], args[1]);
            }
            else
            {
                StartClientWithDeviceToken(args[0], args[1], args[2]);
            }
            while (true)
            {
                Console.Write(prompt);
                var key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    case 's':
                    case 'S':
                        wrapper.StopClient();
                        break;
                    case 'p':
                    case 'P':
                        wrapper.RequestToPoll();
                        break;
                }
            }
        }

        private static void StartClientWithDeviceToken(string hawkbitUrl, string controlledId, string token)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    wrapper.RunClientWithDeviceToken(token, hawkbitUrl + "/" + controlledId, onConfigRequest, onDeploymentAction, onCancelAction);
                    Console.WriteLine("\nClient restarted");
                    Console.Write(prompt);
                }
            });
        }

        private static void StartClientWithCertificate(string provisioningUrl, string certFile)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    const string xApigToken = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
                    var cert = File.ReadAllText(certFile);
                    wrapper.RunClient(cert, provisioningUrl, xApigToken, onProvErrorAction, onProvSuccessAction, onConfigRequest, onDeploymentAction, onCancelAction);
                    Console.WriteLine("\nClient restarted");
                    Console.Write(prompt);
                }
            });
        }

        private static void onProvErrorAction(string errorMessage)
        {
            Console.WriteLine($"ProvisioningErrorAction: errorMessage = {errorMessage}");
        }

        private static void onProvSuccessAction(string up2DateEndpoint)
        {
        {
            Console.WriteLine($"\nProvisioningSuccessAction: up2DateEndpoint = {up2DateEndpoint}");
        }

        private static bool onCancelAction(int actionId)
        {
        {
            Console.WriteLine($"\nCancelAction: actionId = {actionId}");
            Console.Write(prompt);
            return true;
        }

        private static void onDeploymentAction(IntPtr artifact, DeploymentInfo info, out ClientResult result)
        {
            Console.WriteLine($"\nDeploymentAction: actionId = {info.id}");
            Console.WriteLine($"    downloadType = {info.downloadType}");
            Console.WriteLine($"    updateType = {info.updateType}");
            Console.WriteLine($"    isInMaintenanceWindow = {info.isInMaintenanceWindow}");
            Console.WriteLine($"    artifactFileName = {info.artifactFileName}");
            Console.Write(prompt);
            result = new ClientResult { Execution = Execution.CLOSED, Finished = Finished.SUCCESS, Message = string.Empty };
        }

        private static void onConfigRequest(IntPtr responseBuilder)
        {
            Console.WriteLine($"\nConfigRequest");
            wrapper.AddConfigAttribute(responseBuilder, "Example.key1", "Example.value1");
            wrapper.AddConfigAttribute(responseBuilder, "Example.key2", "Example.value2");
            Console.Write(prompt);
        }

    }
}
