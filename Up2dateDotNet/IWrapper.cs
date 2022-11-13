using System;

namespace Up2dateDotNet
{
    public delegate void ConfigRequestFunc(IntPtr responseBuilder);
    public delegate void DeploymentActionFunc(IntPtr artifact, DeploymentInfo info, out ClientResult result);
    public delegate bool CancelActionFunc(int stopId);
    public delegate void AuthErrorActionFunc(string errorMessage);

    public interface IWrapper
    {
        void DownloadArtifact(IntPtr artifact, string location);

        void AddConfigAttribute(IntPtr responseBuilder, string key, string value);

        void RunClient(string clientCertificate, string provisioningEndpoint, string xApigToken,
            AuthErrorActionFunc onAuthErrorAction,
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
    }
}