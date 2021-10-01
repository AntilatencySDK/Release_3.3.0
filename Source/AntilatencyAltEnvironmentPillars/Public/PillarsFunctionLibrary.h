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

#pragma once

#include "CoreMinimal.h"
#include "Kismet/BlueprintFunctionLibrary.h"

#include "DeserializedEnvironment.h"
#include "PillarsLibrary.h"
#include "PillarsTypes.h"

#include "PillarsFunctionLibrary.generated.h"

/** An additional enum that is used by the blueprint methods to allow user to check if called method has been executed successfully or not. */
UENUM(BlueprintType)
enum class EPillarsExceptionResult : uint8 {
    /** The method executed successfully. */
    Success = 1 UMETA(DisplayName = "Success"),
    /** The method execution failed with some exception. */
    Fail = 0 UMETA(DisplayName = "Fail"),
};

/**
 * 
 */
UCLASS(BlueprintType)
class ANTILATENCYALTENVIRONMENTPILLARS_API UPillarsFunctionLibrary : public UObject {
    GENERATED_BODY()

public:

#pragma region UPillarsLibrary
    UFUNCTION(BlueprintCallable, Category = "Antilatency|Alt|Environment|Pillars|Library", Meta = (ExpandEnumAsExecs = "exception"))
    static void GetPillarsLibrary(UPillarsLibrary*& result, EPillarsExceptionResult& exception);

    UFUNCTION(BlueprintCallable, Category = "Antilatency|Alt|Environment|Pillars|Library", Meta = (ExpandEnumAsExecs = "exception"))
    static void SerializeEnvironment(
        UPARAM(ref) UPillarsLibrary* pillarsLibrary,
        const TArray<FPillarsData>& pillars,
        const TArray<float>& proportions,
        const int32 numMarkersPerPillar,
        float pillarLength,
        FString& result,
        EPillarsExceptionResult& exception
    );

    UFUNCTION(BlueprintCallable, Category = "Antilatency|Alt|Environment|Pillars|Library", Meta = (ExpandEnumAsExecs = "exception"))
    static void DeserializeEnvironment(UPARAM(ref) UPillarsLibrary* pillarsLibrary, const FString& environmentData, UDeserializedEnvironment*& result, EPillarsExceptionResult& exception);
#pragma endregion

#pragma region UDeserializedEnvironment
    UFUNCTION(BlueprintCallable, Category = "Antilatency|Alt|Environment|Pillars|Deserialized Environment", Meta = (ExpandEnumAsExecs = "exception"))
    static void GetPillars(UPARAM(ref) UDeserializedEnvironment* deserializedEnvironment, TArray<FPillarsData>& result, EPillarsExceptionResult& exception);

    UFUNCTION(BlueprintCallable, Category = "Antilatency|Alt|Environment|Pillars|Deserialized Environment", Meta = (ExpandEnumAsExecs = "exception"))
    static void GetProportions(UPARAM(ref) UDeserializedEnvironment* deserializedEnvironment, TArray<float>& result, EPillarsExceptionResult& exception);

    UFUNCTION(BlueprintCallable, Category = "Antilatency|Alt|Environment|Pillars|Deserialized Environment", Meta = (ExpandEnumAsExecs = "exception"))
    static void GetNumMarkersPerPillar(UPARAM(ref) UDeserializedEnvironment* deserializedEnvironment, int32& result, EPillarsExceptionResult& exception);

    UFUNCTION(BlueprintCallable, Category = "Antilatency|Alt|Environment|Pillars|Deserialized Environment", Meta = (ExpandEnumAsExecs = "exception"))
    static void GetPillarLength(UPARAM(ref) UDeserializedEnvironment* deserializedEnvironment, float& result, EPillarsExceptionResult& exception);

    UFUNCTION(BlueprintPure, Category = "Antilatency|Alt|Environment|Pillars|Deserialized Environment")
    static bool IsValid(const UDeserializedEnvironment* deserializedEnvironment);
#pragma endregion 
};
