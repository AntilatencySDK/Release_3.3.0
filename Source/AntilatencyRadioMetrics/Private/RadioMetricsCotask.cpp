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

#include "RadioMetricsCotask.h"

#include "RadioMetricsLog.h"

#include <ExceptionCheck.h>

Antilatency::InterfaceContract::ExceptionCode URadioMetricsCotask::GetMetrics(const FAdnNode& targetNode, FRadioMetrics& result) {
	if (!IsValid()) {
	    RADIOMETRICS_LOG(Warning, TEXT("Calling object wrapper method while native object is null"));
		return Antilatency::InterfaceContract::ExceptionCode::ErrorPointer;
	}

	Antilatency::RadioMetrics::Metrics nativeResult;
	auto exception = AsInterface<TInterface>().getMetrics(targetNode.ToNative(), nativeResult);
	ANTILATENCY_EXCEPTION_CHECK_RETURN_ON_FAIL();

	result = static_cast<FRadioMetrics>(nativeResult);
	return exception;
}

Antilatency::InterfaceContract::ExceptionCode URadioMetricsCotask::GetExtendedMetrics(const FAdnNode& targetNode, FExtendedMetrics& result) {
	if (!IsValid()) {
	    RADIOMETRICS_LOG(Warning, TEXT("Calling object wrapper method while native object is null"));
		return Antilatency::InterfaceContract::ExceptionCode::ErrorPointer;
	}

	Antilatency::RadioMetrics::Interop::ExtendedMetrics nativeResult;
	auto exception = AsInterface<TInterface>().getExtendedMetrics(targetNode.ToNative(), nativeResult);
	ANTILATENCY_EXCEPTION_CHECK_RETURN_ON_FAIL();

	result = static_cast<FExtendedMetrics>(nativeResult);
	return exception;
}