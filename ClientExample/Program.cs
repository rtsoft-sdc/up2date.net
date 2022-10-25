using System;
using System.Collections.Generic;
using System.IO;
using Up2dateDotNet;

namespace ClientExample
{
    internal class Program
    {
        static IWrapper wrapper = new Wrapper();


        static void Main(string[] args)
        {
            const string provisioningUrl = "https://dps.ritms.online/provisioning";
            const string xApigToken = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";

            if (args.Length < 1)
            {
                Console.WriteLine("Usage: ClientExample <certificate.cer>");
                return;
            }

            var cert = File.ReadAllText(args[0]);
            
            var dispatcher = wrapper.CreateDispatcher(onConfigRequest, onDeploymentAction, onCancelAction);

            Console.WriteLine("Client started");

            wrapper.RunClient(cert, provisioningUrl, xApigToken, dispatcher, onAuthErrorAction);

            Console.WriteLine("Client stopped");


            wrapper.DeleteDispatcher(dispatcher);
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
