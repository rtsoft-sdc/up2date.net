#include <exception>
#include <thread>
#include "pch.h"
#include "ddiclient.h"
#include "ddi.hpp"
#include "ritms_dps.hpp"
#include "DPSInfoReloadHandler.hpp"

namespace HkbClient {

    void AddConfigAttribute(ddi::ConfigResponseBuilder* responseBuilder, const char* key, const char* value) {
        responseBuilder->addData(key, value);
    }

    void DownloadArtifact(ddi::Artifact* artifact, const char* location) {
        artifact->downloadTo(location + artifact->getFilename());
    }

    Client* BuildClient(const char* clientCertificate, const char* provisioningEndpoint, const char* xApigToken,
        AuthErrorCallbackFunction authErrorAction,
        ConfigRequestCallbackFunction configRequest,
        DeploymentActionCallbackFunction deploymentAction,
        CancelActionCallbackFunction cancelAction) {
        auto dpsBuilder = CloudProvisioningClientBuilder::newInstance();
        auto dpsClient = dpsBuilder->setEndpoint(provisioningEndpoint)
            ->setAuthCrt(clientCertificate)
            ->addHeader("X-Apig-AppCode", std::string(xApigToken))
            ->build();

        auto authErrorHandler = std::shared_ptr<AuthErrorHandler>(new DPSInfoReloadHandler(std::move(dpsClient), authErrorAction));

        auto builder = DDIClientBuilder::newInstance();

        return builder->setAuthErrorHandler(authErrorHandler)
            ->setEventHandler(std::shared_ptr<EventHandler>(new CallbackDispatcher(configRequest, deploymentAction, cancelAction)))
            ->build().release();
    }

    Client* BuildClientWithDeviceToken(const char* deviceToken, const char* hawkbitEndpoint,
        ConfigRequestCallbackFunction configRequest,
        DeploymentActionCallbackFunction deploymentAction,
        CancelActionCallbackFunction cancelAction) {

        auto builder = DDIClientBuilder::newInstance();

        return builder->setHawkbitEndpoint(hawkbitEndpoint)
            ->setDeviceToken(deviceToken)
            ->setEventHandler(std::shared_ptr<EventHandler>(new CallbackDispatcher(configRequest, deploymentAction, cancelAction)))
            ->build().release();
    }

    Client* BuildClientWithGatewayToken(const char* gatewayToken, const char* hawkbitEndpoint,
        ConfigRequestCallbackFunction configRequest,
        DeploymentActionCallbackFunction deploymentAction,
        CancelActionCallbackFunction cancelAction) {

        auto builder = DDIClientBuilder::newInstance();

        return builder->setHawkbitEndpoint(hawkbitEndpoint)
            ->setGatewayToken(gatewayToken)
            ->setEventHandler(std::shared_ptr<EventHandler>(new CallbackDispatcher(configRequest, deploymentAction, cancelAction)))
            ->build().release();
    }

    void Run(Client* client) {
        client->run();
    }

    void Stop(Client* client) {
        client->stop();
    }

    void Delete(Client* client) {
        delete client;
    }
}
