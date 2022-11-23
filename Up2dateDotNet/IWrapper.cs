using System;

namespace Up2dateDotNet
{
    public delegate void ConfigRequestFunc(IntPtr responseBuilder);
    public delegate void DeploymentActionFunc(IntPtr artifact, DeploymentInfo info, out ClientResult result);
    public delegate bool CancelActionFunc(int stopId);
    public delegate void AuthErrorCallbackFunc(string errorMessage);
    public delegate void AuthSuccessCallbackFunc(string up2DateEndpoint);

    public interface IWrapper
    {
        void DownloadArtifact(IntPtr artifact, string location);

        void AddConfigAttribute(IntPtr responseBuilder, string key, string value);

        void RunClient(string clientCertificate, string provisioningEndpoint, string xApigToken,
            AuthErrorCallbackFunc onAuthErrorAction,
            AuthSuccessCallbackFunc onAuthSuccessAction,
            ConfigRequestFunc configRequest,
            DeploymentActionFunc deploymentAction,
            CancelActionFunc cancelAction);

        void RunClientWithDeviceToken(string deviceToken, string hawkbitEndpoint,
            ConfigRequestFunc configRequest,
            DeploymentActionFunc deploymentAction,
            CancelActionFunc cancelAction);

        void RunClientWithGatewayToken(string gatewayToken, string hawkbitEndpoint,
            ConfigRequestFunc configRequest,
            DeploymentActionFunc deploymentAction,
            CancelActionFunc cancelAction);

        void StopClient();
    }
}