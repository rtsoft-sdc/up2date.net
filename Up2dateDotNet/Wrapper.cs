using System;
using System.Runtime.InteropServices;

namespace Up2dateDotNet
{
    public class Wrapper : IWrapper
    {
        public void DownloadArtifact(IntPtr artifact, string location)
        {
            if (IntPtr.Size == 4)
            {
                Wrapper32.DownloadArtifact(artifact, location);
            }
            else
            {
                Wrapper64.DownloadArtifact(artifact, location);
            }
        }

        public void AddConfigAttribute(IntPtr responseBuilder, string key, string value)
        {
            if (IntPtr.Size == 4)
            {
                Wrapper32.AddConfigAttribute(responseBuilder, key, value);
            }
            else
            {
                Wrapper64.AddConfigAttribute(responseBuilder, key, value);
            }
        }

        public IntPtr BuildClient(string clientCertificate, string provisioningEndpoint, string xApigToken, AuthErrorActionFunc onAuthErrorAction, ConfigRequestFunc configRequest, DeploymentActionFunc deploymentAction, CancelActionFunc cancelAction)
        {
            return (IntPtr.Size == 4)
                ? Wrapper32.BuildClient(clientCertificate, provisioningEndpoint, xApigToken, onAuthErrorAction, configRequest, deploymentAction, cancelAction)
                : Wrapper64.BuildClient(clientCertificate, provisioningEndpoint, xApigToken, onAuthErrorAction, configRequest, deploymentAction, cancelAction);
        }

        public IntPtr BuildClientWithDeviceToken(string deviceToken, string hawkbitEndpoint, ConfigRequestFunc configRequest, DeploymentActionFunc deploymentAction, CancelActionFunc cancelAction)
        {
            return (IntPtr.Size == 4)
                ? Wrapper32.BuildClientWithDeviceToken(deviceToken, hawkbitEndpoint, configRequest, deploymentAction, cancelAction)
                : Wrapper64.BuildClientWithDeviceToken(deviceToken, hawkbitEndpoint, configRequest, deploymentAction, cancelAction);
        }

        public IntPtr BuildClientWithGatewayToken(string gatewayToken, string hawkbitEndpoint, ConfigRequestFunc configRequest, DeploymentActionFunc deploymentAction, CancelActionFunc cancelAction)
        {
            return (IntPtr.Size == 4)
                ? Wrapper32.BuildClientWithGatewayToken(gatewayToken, hawkbitEndpoint, configRequest, deploymentAction, cancelAction)
                : Wrapper64.BuildClientWithGatewayToken(gatewayToken, hawkbitEndpoint, configRequest, deploymentAction, cancelAction);
        }

        public void Run(IntPtr client)
        {
            if (IntPtr.Size == 4)
            {
                Wrapper32.Run(client);
            }
            else
            {
                Wrapper64.Run(client);
            }
        }

        public void Stop(IntPtr client)
        {
            if (IntPtr.Size == 4)
            {
                Wrapper32.Stop(client);
            }
            else
            {
                Wrapper64.Stop(client);
            }
        }

        public void Delete(IntPtr client)
        {
            if (IntPtr.Size == 4)
            {
                Wrapper32.Delete(client);
            }
            else
            {
                Wrapper64.Delete(client);
            }
        }
    }

    static class Wrapper64
    {
        [DllImport(@"wrapperdll-x64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DownloadArtifact(IntPtr artifact, string location);

        [DllImport(@"wrapperdll-x64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddConfigAttribute(IntPtr responseBuilder, string key, string value);

        [DllImport(@"wrapperdll-x64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BuildClient(string clientCertificate, string provisioningEndpoint, string xApigToken, AuthErrorActionFunc onAuthErrorAction, ConfigRequestFunc configRequest, DeploymentActionFunc deploymentAction, CancelActionFunc cancelAction);

        [DllImport(@"wrapperdll-x64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BuildClientWithDeviceToken(string deviceToken, string hawkbitEndpoint, ConfigRequestFunc configRequest, DeploymentActionFunc deploymentAction, CancelActionFunc cancelAction);

        [DllImport(@"wrapperdll-x64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BuildClientWithGatewayToken(string gatewayToken, string hawkbitEndpoin, ConfigRequestFunc configRequest, DeploymentActionFunc deploymentAction, CancelActionFunc cancelAction);

        [DllImport(@"wrapperdll-x64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Run(IntPtr client);

        [DllImport(@"wrapperdll-x64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Stop(IntPtr client);

        [DllImport(@"wrapperdll-x64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Delete(IntPtr client);
    }

    static class Wrapper32
    {
        [DllImport(@"wrapperdll-x86.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DownloadArtifact(IntPtr artifact, string location);

        [DllImport(@"wrapperdll-x86.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddConfigAttribute(IntPtr responseBuilder, string key, string value);

        [DllImport(@"wrapperdll-x86.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BuildClient(string clientCertificate, string provisioningEndpoint, string xApigToken, AuthErrorActionFunc onAuthErrorAction, ConfigRequestFunc configRequest, DeploymentActionFunc deploymentAction, CancelActionFunc cancelAction);

        [DllImport(@"wrapperdll-x86.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BuildClientWithDeviceToken(string deviceToken, string hawkbitEndpoint, ConfigRequestFunc configRequest, DeploymentActionFunc deploymentAction, CancelActionFunc cancelAction);

        [DllImport(@"wrapperdll-x86.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BuildClientWithGatewayToken(string gatewayToken, string hawkbitEndpoin, ConfigRequestFunc configRequest, DeploymentActionFunc deploymentAction, CancelActionFunc cancelAction);

        [DllImport(@"wrapperdll-x86.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Run(IntPtr client);

        [DllImport(@"wrapperdll-x86.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Stop(IntPtr client);

        [DllImport(@"wrapperdll-x86.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Delete(IntPtr client);
    }

}
