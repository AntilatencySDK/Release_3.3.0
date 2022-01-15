// Copyright 2021, ALT LLC. All Rights Reserved.
// This file is part of Antilatency SDK.
// It is subject to the license terms in the LICENSE file found in the top-level directory
// of this distribution and at http://www.antilatency.com/eula
// You may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#include "BracerCotaskConstructor.h"

#include "BracerLog.h"

#include <ExceptionCheck.h>

Antilatency::InterfaceContract::ExceptionCode UBracerCotaskConstructor::StartTask(UDeviceNetwork* network, const FAdnNode& node, UBracerCotask*& result) {
    if (!IsValid()) {
        BRACER_LOG(Warning, TEXT("Calling object wrapper method while native object is null"));
        return Antilatency::InterfaceContract::ExceptionCode::ErrorPointer;
    }

    Antilatency::Bracer::ICotask nativeResult;
    auto exception = AsInterface<TInterface>().startTask(network->GetNative(), node.ToNative(), nativeResult);
    ANTILATENCY_EXCEPTION_CHECK_RETURN_ON_FAIL();

    if (nativeResult == nullptr) {
        BRACER_LOG(Warning, TEXT("Failed to start bracer task on node"));
        return Antilatency::InterfaceContract::ExceptionCode::ErrorPointer;
    }

    result = ObjectConstructor<UBracerCotask>::create(nativeResult);
    return exception;
}
