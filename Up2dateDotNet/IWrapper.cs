using System;

namespace Up2dateDotNet
{
    public delegate void ConfigRequestFunc(IntPtr responseBuilder);
    public delegate void DeploymentActionFunc(IntPtr artifact, DeploymentInfo info, out ClientResult result);
    public delegate bool CancelActionFunc(int stopId);
    public delegate void NoActionFunc();
    public delegate void ProvErrorCallbackFunc(string errorMessage);
    public delegate void ProvSuccessCallbackFunc(string up2DateEndpoint);

    public interface IWrapper
    {
        void DownloadArtifact(IntPtr artifact, string location);

        void AddConfigAttribute(IntPtr responseBuilder, string key, string value);

        void RunClient(string clientCertificate, string provisioningEndpoint, string xApigToken,
            ProvErrorCallbackFunc onProvErrorAction,
            ProvSuccessCallbackFunc onProvSuccessAction,
            ConfigRequestFunc configRequest,
            DeploymentActionFunc deploymentAction,
            CancelActionFunc cancelAction,
            NoActionFunc noAction);

        void RunClientWithDeviceToken(string deviceToken, string hawkbitEndpoint,
            ConfigRequestFunc configRequest,
            DeploymentActionFunc deploymentAction,
            CancelActionFunc cancelAction,
            NoActionFunc noAction);

        void RunClientWithGatewayToken(string gatewayToken, string hawkbitEndpoint,
            ConfigRequestFunc configRequest,
            DeploymentActionFunc deploymentAction,
            CancelActionFunc cancelAction,
            NoActionFunc noAction);

        void StopClient();

        void RequestToPoll();
    }
}