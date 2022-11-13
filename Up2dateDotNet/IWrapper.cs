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

        IntPtr BuildClient(string clientCertificate, string provisioningEndpoint, string xApigToken,
            AuthErrorActionFunc onAuthErrorAction,
            ConfigRequestFunc configRequest,
            DeploymentActionFunc deploymentAction,
            CancelActionFunc cancelAction);

        IntPtr BuildClientWithDeviceToken(string deviceToken, string hawkbitEndpoint,
            ConfigRequestFunc configRequest,
            DeploymentActionFunc deploymentAction,
            CancelActionFunc cancelAction);

        IntPtr BuildClientWithGatewayToken(string gatewayToken, string hawkbitEndpoint,
            ConfigRequestFunc configRequest,
            DeploymentActionFunc deploymentAction,
            CancelActionFunc cancelAction);

        void Run(IntPtr client);

        void Stop(IntPtr client);

        void Delete(IntPtr client);
    }
}