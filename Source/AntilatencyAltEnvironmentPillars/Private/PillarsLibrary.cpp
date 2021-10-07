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

#include "PillarsLibrary.h"
#include "PillarsLog.h"

#include <ExceptionCheck.h>

#include "IAntilatencyAltEnvironmentPillarsModule.h"

UPillarsLibrary* UPillarsLibrary::GetPillarsLibrary() {
	auto module = IAntilatencyAltEnvironmentPillarsModule::Get();
	auto native = module.GetNativeLibrary();

	if (native == nullptr) {
		return nullptr;
	}

	return ObjectConstructor<UPillarsLibrary>::create(native);
}

Antilatency::InterfaceContract::ExceptionCode UPillarsLibrary::SerializeEnvironment(const TArray<FPillarsData>& pillars, const TArray<float>& proportions, const int32 numMarkersPerPillar, float pillarLength,
	FString& result) {
	if (!IsValid()) {
	    PILLARS_LOG(Warning, TEXT("Calling object wrapper method while native object is null"));
		return Antilatency::InterfaceContract::ExceptionCode::ErrorPointer;
	}

	std::vector<Antilatency::Alt::Environment::Pillars::PillarData> pillarsNative;
	const auto pillarsCount = pillars.Num();
	pillarsNative.reserve(pillarsCount);
	
	for (int32 i = 0; i < pillarsCount; ++i) {
		pillarsNative.push_back(pillars[i].ToNative());
	}

	std::vector<float> proportionsNative;
	const auto proportionsCount = proportions.Num();
	proportionsNative.reserve(proportionsCount);

	for (int32 i = 0; i < proportionsCount; ++i) {
		proportionsNative.push_back(proportions[i]);
	}

	std::string nativeResult;
	auto exception = AsInterface<TInterface>().serialize(pillarsNative, proportionsNative, static_cast<uint32_t>(numMarkersPerPillar), pillarLength,nativeResult);
	ANTILATENCY_EXCEPTION_CHECK_RETURN_ON_FAIL();

	result = {nativeResult.c_str()};
	return exception;
}

Antilatency::InterfaceContract::ExceptionCode UPillarsLibrary::DeserializeEnvironment(const FString& environmentData, UDeserializedEnvironment*& result) {
	if (!IsValid()) {
	    PILLARS_LOG(Warning, TEXT("Calling object wrapper method while native object is null"));
		return Antilatency::InterfaceContract::ExceptionCode::ErrorPointer;
	}

	Antilatency::Alt::Environment::Pillars::IDeserializedEnvironment nativeResult;
	auto exception = AsInterface<TInterface>().deserialize(std::string(TCHAR_TO_UTF8(*environmentData)), nativeResult);
	ANTILATENCY_EXCEPTION_CHECK_RETURN_ON_FAIL();

	result = ObjectConstructor<UDeserializedEnvironment>::create(nativeResult);
	return exception;
}

