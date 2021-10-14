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

#include "TrackingAlignment.h"

#include "TrackingAlignmentLog.h"

#include <Antilatency.Math.h>

#include <ExceptionCheck.h>

Antilatency::InterfaceContract::ExceptionCode UTrackingAlignment::Update(const FQuat& a, const FQuat& b, const float time, FTrackingAlignmentState& result) {
    if (!IsValid()) {
        TRACKINGALIGNMENT_LOG(Warning, TEXT("Calling object wrapper method while native object is null"));
        return Antilatency::InterfaceContract::ExceptionCode::ErrorPointer;
    }

    const Antilatency::Math::floatQ aN = { a.X, a.Y, a.Z, a.W };
    const Antilatency::Math::floatQ bN = { b.X, b.Y, b.Z, b.W };

	Antilatency::TrackingAlignment::State nativeResult;
    auto exception = _native.update(aN, bN, time, nativeResult);
	ANTILATENCY_EXCEPTION_CHECK_RETURN_ON_FAIL();

	result = { nativeResult };

    return exception;
}

bool UTrackingAlignment::IsValid() const {
    if (_native == nullptr) {
        return false;
    }

    return true;
}