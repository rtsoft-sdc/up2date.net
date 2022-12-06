#pragma once

#include <iostream>
#include <thread>
#include "ritms_dps.hpp"
#include "ddi.hpp"

using namespace ritms::dps;
using namespace ddi;

namespace HkbClient {

    class DPSInfoReloadHandler : public AuthErrorHandler {
        std::unique_ptr<ProvisioningClient> client;
        ProvErrorCallbackFunction provErrorAction;
        ProvSuccessCallbackFunction provSuccessAction;

    public:
        explicit DPSInfoReloadHandler(std::unique_ptr<ProvisioningClient> client_, ProvErrorCallbackFunction provErrorAction_, ProvSuccessCallbackFunction provSuccessAction_) : client(std::move(client_)) {
            provErrorAction = provErrorAction_;
            provSuccessAction = provSuccessAction_;
        };

        void onAuthError(std::unique_ptr<AuthRestoreHandler> ptr) override {
            for (;;) {
                try {
                    auto payload = client->doProvisioning();
                    auto keyPair = payload->getKeyPair();
                    ptr->setTLS(keyPair->getCrt(), keyPair->getKey());
                    auto endpoint = payload->getUp2DateEndpoint();
                    std::cout << "|DPSInfoReloadHandler| Setting endpoint [" << endpoint << "] ..." << std::endl;
                    ptr->setEndpoint(endpoint);
                    provSuccessAction(endpoint.c_str());
                    return;
                }
                catch (std::exception &e) {
                    std::this_thread::sleep_for(std::chrono::milliseconds(3000));
                    provErrorAction(e.what());
                }
            }
        }
    };

}
