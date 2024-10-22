﻿using System;
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

        public void RunClient(string clientCertificate, string provisioningEndpoint, string xApigToken, ProvErrorCallbackFunc onProvErrorAction, ProvSuccessCallbackFunc onProvSuccessAction, ConfigRequestFunc configRequest, DeploymentActionFunc deploymentAction, CancelActionFunc cancelAction, NoActionFunc noAction)
        {
            if (IntPtr.Size == 4)
            {
                Wrapper32.RunClient(clientCertificate, provisioningEndpoint, xApigToken, onProvErrorAction, onProvSuccessAction, configRequest, deploymentAction, cancelAction, noAction);
            }
            else
            {
                Wrapper64.RunClient(clientCertificate, provisioningEndpoint, xApigToken, onProvErrorAction, onProvSuccessAction, configRequest, deploymentAction, cancelAction, noAction);
            }
        }

        public void RunClientWithDeviceToken(string deviceToken, string hawkbitEndpoint, ConfigRequestFunc configRequest, DeploymentActionFunc deploymentAction, CancelActionFunc cancelAction, NoActionFunc noAction)
        {
            if (IntPtr.Size == 4)
            {
                Wrapper32.RunClientWithDeviceToken(deviceToken, hawkbitEndpoint, configRequest, deploymentAction, cancelAction, noAction);
            }
            else
            {
                Wrapper64.RunClientWithDeviceToken(deviceToken, hawkbitEndpoint, configRequest, deploymentAction, cancelAction, noAction);
            }
        }

        public void RunClientWithGatewayToken(string gatewayToken, string hawkbitEndpoint, ConfigRequestFunc configRequest, DeploymentActionFunc deploymentAction, CancelActionFunc cancelAction, NoActionFunc noAction)
        {
            if (IntPtr.Size == 4)
            {
                Wrapper32.RunClientWithDeviceToken(gatewayToken, hawkbitEndpoint, configRequest, deploymentAction, cancelAction, noAction);
            }
            else
            {
                Wrapper64.RunClientWithDeviceToken(gatewayToken, hawkbitEndpoint, configRequest, deploymentAction, cancelAction, noAction);
            }
        }

        public void StopClient()
        {
            if (IntPtr.Size == 4)
            {
                Wrapper32.StopClient();
            }
            else
            {
                Wrapper64.StopClient();
            }
        }

        public void RequestToPoll()
        {
            if (IntPtr.Size == 4)
            {
                Wrapper32.RequestToPoll();
            }
            else
            {
                Wrapper64.RequestToPoll();
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
        public static extern void RunClient(string clientCertificate, string provisioningEndpoint, string xApigToken, ProvErrorCallbackFunc onProvErrorAction, ProvSuccessCallbackFunc onProvSuccessAction, ConfigRequestFunc configRequest, DeploymentActionFunc deploymentAction, CancelActionFunc cancelAction, NoActionFunc noAction);

        [DllImport(@"wrapperdll-x64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunClientWithDeviceToken(string deviceToken, string hawkbitEndpoint, ConfigRequestFunc configRequest, DeploymentActionFunc deploymentAction, CancelActionFunc cancelAction, NoActionFunc noAction);

        [DllImport(@"wrapperdll-x64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunClientWithGatewayToken(string gatewayToken, string hawkbitEndpoin, ConfigRequestFunc configRequest, DeploymentActionFunc deploymentAction, CancelActionFunc cancelAction, NoActionFunc noAction);

        [DllImport(@"wrapperdll-x64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopClient();

        [DllImport(@"wrapperdll-x64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RequestToPoll();
    }

    static class Wrapper32
    {
        [DllImport(@"wrapperdll-x86.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DownloadArtifact(IntPtr artifact, string location);

        [DllImport(@"wrapperdll-x86.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddConfigAttribute(IntPtr responseBuilder, string key, string value);

        [DllImport(@"wrapperdll-x86.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunClient(string clientCertificate, string provisioningEndpoint, string xApigToken, ProvErrorCallbackFunc onProvErrorAction, ProvSuccessCallbackFunc onProvSuccessAction, ConfigRequestFunc configRequest, DeploymentActionFunc deploymentAction, CancelActionFunc cancelAction, NoActionFunc noAction);

        [DllImport(@"wrapperdll-x86.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunClientWithDeviceToken(string deviceToken, string hawkbitEndpoint, ConfigRequestFunc configRequest, DeploymentActionFunc deploymentAction, CancelActionFunc cancelAction, NoActionFunc noAction);

        [DllImport(@"wrapperdll-x86.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunClientWithGatewayToken(string gatewayToken, string hawkbitEndpoin, ConfigRequestFunc configRequest, DeploymentActionFunc deploymentAction, CancelActionFunc cancelAction, NoActionFunc noAction);

        [DllImport(@"wrapperdll-x86.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void StopClient();

        [DllImport(@"wrapperdll-x86.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RequestToPoll();
    }

}
