using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ConstrainedExecution;
using Up2dateDotNet;

namespace ClientExample
{
    internal class Program
    {
        static IWrapper wrapper = new Wrapper();


        static void Main(string[] args)
        {
            var dispatcher = wrapper.CreateDispatcher(onConfigRequest, onDeploymentAction, onCancelAction);

            Console.WriteLine("Client started");

            if (args.Length < 1)
            {
                Console.WriteLine("Usage: ClientExample <provisioningUrl> <certificateFile>");
                Console.WriteLine("   or: ClientExample <hawkbitUrl> <tenant> <controllerId> <token>");
            }
            else if (args.Length < 3)
            {
                RunClientWithCertificate(dispatcher, args[0], args[1]);
                Console.WriteLine("Client stopped");
            }
            else
            {
                RunClientWithDeviceToken(dispatcher, args[0], args[1], args[2], args[2]);
                Console.WriteLine("Client stopped");
            }

            wrapper.DeleteDispatcher(dispatcher);
        }

        private static void RunClientWithDeviceToken(IntPtr dispatcher, string hawkbitUrl, string tenant, string controlledId, string token)
        {
            wrapper.RunClientWithDeviceToken(token, hawkbitUrl, controlledId, tenant, dispatcher);
        }

        private static void RunClientWithCertificate(IntPtr dispatcher, string provisioningUrl, string certFile)
        {
            const string xApigToken = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";

            var cert = File.ReadAllText(certFile);

            wrapper.RunClient(cert, provisioningUrl, xApigToken, dispatcher, onAuthErrorAction);
        }

        private static void onAuthErrorAction(string errorMessage)
        {
            Console.WriteLine($"AuthErrorAction: errorMessage = {errorMessage}");
        }

        private static bool onCancelAction(int actionId)
        {
            Console.WriteLine($"CancelAction: actionId = {actionId}");
            return true;
        }

        private static void onDeploymentAction(IntPtr artifact, DeploymentInfo info, out ClientResult result)
        {
            Console.WriteLine($"DeploymentAction: actionId = {info.id}");
            Console.WriteLine($"    downloadType = {info.downloadType}");
            Console.WriteLine($"    updateType = {info.updateType}");
            Console.WriteLine($"    isInMaintenanceWindow = {info.isInMaintenanceWindow}");
            Console.WriteLine($"    artifactFileName = {info.artifactFileName}");
            result = new ClientResult { Execution = Execution.CLOSED, Finished = Finished.SUCCESS, Message = string.Empty };
        }

        private static void onConfigRequest(IntPtr responseBuilder)
        {
            Console.WriteLine($"ConfigRequest");
            wrapper.AddConfigAttribute(responseBuilder, "Example.key1", "Example.value1");
            wrapper.AddConfigAttribute(responseBuilder, "Example.key2", "Example.value2");
        }

    }
}
