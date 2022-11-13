#pragma once
#include <ddi.hpp>
#include <ritms_dps.hpp>

#include "CallbackDispatcher.hpp"
#include "dllexport.h"

namespace HkbClient {

    typedef bool (__stdcall *AuthErrorCallbackFunction)(const char* errorMessage);

	extern "C" {
		WDLL_EXPORT void AddConfigAttribute(ddi::ConfigResponseBuilder* responseBuilder, const char* key, const char* value);
		WDLL_EXPORT void DownloadArtifact(ddi::Artifact* artifact, const char* location);
		WDLL_EXPORT Client* BuildClient(const char* clientCertificate, const char* provisioningEndpoint, const char* xApigToken,
			AuthErrorCallbackFunction authErrorAction,
			ConfigRequestCallbackFunction configRequest,
			DeploymentActionCallbackFunction deploymentAction,
			CancelActionCallbackFunction cancelAction);
		WDLL_EXPORT Client* BuildClientWithDeviceToken(const char* deviceToken, const char* hawkbitEndpoint,
			ConfigRequestCallbackFunction configRequest,
			DeploymentActionCallbackFunction deploymentAction,
			CancelActionCallbackFunction cancelAction);
		WDLL_EXPORT Client* BuildClientWithGatewayToken(const char* gatewayToken, const char* hawkbitEndpoint,
			ConfigRequestCallbackFunction configRequest,
			DeploymentActionCallbackFunction deploymentAction,
			CancelActionCallbackFunction cancelAction);
		WDLL_EXPORT void Run(Client* client);
		WDLL_EXPORT void Stop(Client* client);
		WDLL_EXPORT void Delete(Client* client);
	}
}
