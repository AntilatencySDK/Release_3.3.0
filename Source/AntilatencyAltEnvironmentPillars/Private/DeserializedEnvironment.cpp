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

#include "DeserializedEnvironment.h"

#include "PillarsLog.h"

#include <ExceptionCheck.h>

UDeserializedEnvironment::TInterface UDeserializedEnvironment::GetNative() {
	return _native;
}

Antilatency::InterfaceContract::ExceptionCode UDeserializedEnvironment::GetPillars(TArray<FPillarsData>& result) {
	if (!IsValid()) {
	    PILLARS_LOG(Warning, TEXT("Calling object wrapper method while native object is null"));
		return Antilatency::InterfaceContract::ExceptionCode::ErrorPointer;
	}

	std::vector<Antilatency::Alt::Environment::Pillars::PillarData> nativeResult;
	auto exception = _native.getPillars(nativeResult);
	ANTILATENCY_EXCEPTION_CHECK_RETURN_ON_FAIL();

	for(auto pillar : nativeResult) {
		result.Add({pillar});
	}

	return exception;
}

Antilatency::InterfaceContract::ExceptionCode UDeserializedEnvironment::GetProportions(TArray<float>& result) {
	if (!IsValid()) {
	    PILLARS_LOG(Warning, TEXT("Calling object wrapper method while native object is null"));
		return Antilatency::InterfaceContract::ExceptionCode::ErrorPointer;
	}

	std::vector<float> nativeResult;
	auto exception = _native.getProportions(nativeResult);
	ANTILATENCY_EXCEPTION_CHECK_RETURN_ON_FAIL();

	for(auto proportion : nativeResult) {
		result.Add({proportion});
	}

	return exception;
}

Antilatency::InterfaceContract::ExceptionCode UDeserializedEnvironment::GetNumMarkersPerPillar(uint32& result) {
	if (!IsValid()) {
	    PILLARS_LOG(Warning, TEXT("Calling object wrapper method while native object is null"));
		return Antilatency::InterfaceContract::ExceptionCode::ErrorPointer;
	}

	uint32_t nativeResult;
	auto exception = _native.getNumMarkersPerPillar(nativeResult);
	ANTILATENCY_EXCEPTION_CHECK_RETURN_ON_FAIL();

	result = static_cast<uint32>(nativeResult);
	return exception;
}

Antilatency::InterfaceContract::ExceptionCode UDeserializedEnvironment::GetPillarLength(float& result) {
	if (!IsValid()) {
	    PILLARS_LOG(Warning, TEXT("Calling object wrapper method while native object is null"));
		return Antilatency::InterfaceContract::ExceptionCode::ErrorPointer;
	}

	auto exception = _native.getPillarLength(result);
	ANTILATENCY_EXCEPTION_CHECK_RETURN_ON_FAIL();

	return exception;
}

bool UDeserializedEnvironment::IsValid() const {
	return _native != nullptr;
}


