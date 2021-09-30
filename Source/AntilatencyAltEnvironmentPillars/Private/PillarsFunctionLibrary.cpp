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

#include "PillarsFunctionLibrary.h"

void UPillarsFunctionLibrary::GetPillarsLibrary(UPillarsLibrary*& result, EPillarsExceptionResult& exception) {
    result = UPillarsLibrary::GetPillarsLibrary();
    exception = static_cast<EPillarsExceptionResult>(result != nullptr);
}

void UPillarsFunctionLibrary::SerializeEnvironment(UPillarsLibrary* pillarsLibrary, const TArray<FPillarsData>& pillars, const TArray<float>& proportions, const int32 numMarkersPerPillar, float pillarLength, FString& result,
    EPillarsExceptionResult& exception) {
    if (pillarsLibrary == nullptr) {
        exception = EPillarsExceptionResult::Fail;
        return;
    }

    const auto callResult = pillarsLibrary->SerializeEnvironment(pillars, proportions, numMarkersPerPillar, pillarLength, result);
    exception = static_cast<EPillarsExceptionResult>(callResult == Antilatency::InterfaceContract::ExceptionCode::Ok);
}

void UPillarsFunctionLibrary::DeserializeEnvironment(UPillarsLibrary* pillarsLibrary, const FString& environmentData, UDeserializedEnvironment*& result, EPillarsExceptionResult& exception) {
    if (pillarsLibrary == nullptr) {
        exception = EPillarsExceptionResult::Fail;
        return;
    }

    const auto callResult = pillarsLibrary->DeserializeEnvironment(environmentData, result);
    exception = static_cast<EPillarsExceptionResult>(callResult == Antilatency::InterfaceContract::ExceptionCode::Ok);
}

void UPillarsFunctionLibrary::GetPillars(UDeserializedEnvironment* deserializedEnvironment, TArray<FPillarsData>& result, EPillarsExceptionResult& exception) {
    if (deserializedEnvironment == nullptr) {
        exception = EPillarsExceptionResult::Fail;
        return;
    }

    const auto callResult = deserializedEnvironment->GetPillars(result);
    exception = static_cast<EPillarsExceptionResult>(callResult == Antilatency::InterfaceContract::ExceptionCode::Ok);
}

void UPillarsFunctionLibrary::GetProportions(UDeserializedEnvironment* deserializedEnvironment, TArray<float>& result, EPillarsExceptionResult& exception) {
    if (deserializedEnvironment == nullptr) {
        exception = EPillarsExceptionResult::Fail;
        return;
    }

    const auto callResult = deserializedEnvironment->GetProportions(result);
    exception = static_cast<EPillarsExceptionResult>(callResult == Antilatency::InterfaceContract::ExceptionCode::Ok);
}

void UPillarsFunctionLibrary::GetNumMarkersPerPillar(UDeserializedEnvironment* deserializedEnvironment, int32& result, EPillarsExceptionResult& exception) {
    if (deserializedEnvironment == nullptr) {
        exception = EPillarsExceptionResult::Fail;
        return;
    }

    uint32 nativeResult;
    const auto callResult = deserializedEnvironment->GetNumMarkersPerPillar(nativeResult);
    result = static_cast<int32>(nativeResult);
    exception = static_cast<EPillarsExceptionResult>(callResult == Antilatency::InterfaceContract::ExceptionCode::Ok);
}

void UPillarsFunctionLibrary::GetPillarLength(UDeserializedEnvironment* deserializedEnvironment, float& result, EPillarsExceptionResult& exception) {
    if (deserializedEnvironment == nullptr) {
        exception = EPillarsExceptionResult::Fail;
        return;
    }

    const auto callResult = deserializedEnvironment->GetPillarLength(result);
    exception = static_cast<EPillarsExceptionResult>(callResult == Antilatency::InterfaceContract::ExceptionCode::Ok);
}

bool UPillarsFunctionLibrary::IsValid(const UDeserializedEnvironment* deserializedEnvironment) {
    if (deserializedEnvironment == nullptr) {
        return false;
    }

    return deserializedEnvironment->IsValid();
}
