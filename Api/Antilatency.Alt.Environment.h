//Copyright 2021, ALT LLC. All Rights Reserved.
//This file is part of Antilatency SDK.
//It is subject to the license terms in the LICENSE file found in the top-level directory
//of this distribution and at http://www.antilatency.com/eula
//You may not use this file except in compliance with the License.
//Unless required by applicable law or agreed to in writing, software
//distributed under the License is distributed on an "AS IS" BASIS,
//WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//See the License for the specific language governing permissions and
//limitations under the License.
#pragma once
#include <Antilatency.InterfaceContract.h>
#include <Antilatency.Math.h>
#include <cstdint>
#ifdef _MSC_VER
#pragma warning(push)
#pragma warning(disable: 4946)
#pragma warning(disable: 4265)
#endif
namespace Antilatency {
	namespace Alt {
		namespace Environment {
			enum class MarkerIndex : uint32_t {
				MaximumValidMarkerIndex = 0xFFFFFFF0,
				Invalid = 0xFFFFFFFE,
				Unknown = 0xFFFFFFFF
			};
			ANTILATENCY_ENUM_INTEGER_BEHAVIOUR_UNSIGNED(MarkerIndex,uint32_t)
		} //namespace Environment
	} //namespace Alt
} //namespace Antilatency
namespace Antilatency {
	inline const char* enumToString(const Antilatency::Alt::Environment::MarkerIndex& x) {
		switch (x) {
			case Antilatency::Alt::Environment::MarkerIndex::MaximumValidMarkerIndex: return "MaximumValidMarkerIndex";
			case Antilatency::Alt::Environment::MarkerIndex::Invalid: return "Invalid";
			case Antilatency::Alt::Environment::MarkerIndex::Unknown: return "Unknown";
		}
		return "";
	}
} //namespace Antilatency

namespace Antilatency {
	namespace Alt {
		namespace Environment {
			/* copy and paste this to implementer
			Antilatency::InterfaceContract::ExceptionCode isMutable(Antilatency::InterfaceContract::LongBool& result) {
				return Antilatency::InterfaceContract::ExceptionCode::NotImplemented;
			}
			Antilatency::InterfaceContract::ExceptionCode getMarkers(std::vector<Antilatency::Math::float3>& result) {
				return Antilatency::InterfaceContract::ExceptionCode::NotImplemented;
			}
			Antilatency::InterfaceContract::ExceptionCode filterRay(Antilatency::Math::float3 up, Antilatency::Math::float3 ray, Antilatency::InterfaceContract::LongBool& result) {
				return Antilatency::InterfaceContract::ExceptionCode::NotImplemented;
			}
			Antilatency::InterfaceContract::ExceptionCode match(const std::vector<Antilatency::Math::float3>& raysUpSpace, std::vector<Antilatency::Alt::Environment::MarkerIndex>& markersIndices, Antilatency::Math::floatP3Q& poseOfUpSpace, Antilatency::InterfaceContract::LongBool& result) {
				return Antilatency::InterfaceContract::ExceptionCode::NotImplemented;
			}
			Antilatency::InterfaceContract::ExceptionCode matchByPosition(const std::vector<Antilatency::Math::float3>& rays, Antilatency::Math::float3 origin, std::vector<Antilatency::Alt::Environment::MarkerIndex>& result) {
				return Antilatency::InterfaceContract::ExceptionCode::NotImplemented;
			}
			*/
			struct IEnvironment : Antilatency::InterfaceContract::IInterface {
				struct VMT : Antilatency::InterfaceContract::IInterface::VMT {
					virtual Antilatency::InterfaceContract::ExceptionCode ANTILATENCY_INTERFACE_CALL isMutable(Antilatency::InterfaceContract::LongBool& result) = 0;
					virtual Antilatency::InterfaceContract::ExceptionCode ANTILATENCY_INTERFACE_CALL getMarkers(Antilatency::InterfaceContract::Details::ArrayOutMarshaler::Intermediate result) = 0;
					virtual Antilatency::InterfaceContract::ExceptionCode ANTILATENCY_INTERFACE_CALL filterRay(Antilatency::Math::float3 up, Antilatency::Math::float3 ray, Antilatency::InterfaceContract::LongBool& result) = 0;
					virtual Antilatency::InterfaceContract::ExceptionCode ANTILATENCY_INTERFACE_CALL match(Antilatency::InterfaceContract::Details::ArrayInMarshaler::Intermediate raysUpSpace, Antilatency::InterfaceContract::Details::ArrayOutMarshaler::Intermediate markersIndices, Antilatency::Math::floatP3Q& poseOfUpSpace, Antilatency::InterfaceContract::LongBool& result) = 0;
					virtual Antilatency::InterfaceContract::ExceptionCode ANTILATENCY_INTERFACE_CALL matchByPosition(Antilatency::InterfaceContract::Details::ArrayInMarshaler::Intermediate rays, Antilatency::Math::float3 origin, Antilatency::InterfaceContract::Details::ArrayOutMarshaler::Intermediate result) = 0;
					static constexpr Antilatency::InterfaceContract::InterfaceID ID() {
						return Antilatency::InterfaceContract::InterfaceID{0xc257c858,0xf296,0x43b7,{0xb6,0xb5,0xc1,0x4b,0x9a,0xfb,0x1a,0x13}};
					}
				private:
					~VMT() = delete;
				};
				IEnvironment() = default;
				IEnvironment(std::nullptr_t) {}
				explicit IEnvironment(VMT* pointer) : Antilatency::InterfaceContract::IInterface(pointer) {}
				template<typename T, typename = typename std::enable_if<std::is_base_of<IEnvironment, T>::value>::type>
				IEnvironment& operator = (const T& other) {
				    Antilatency::InterfaceContract::IInterface::operator=(other);
				    return *this;
				}
				template<class Implementer, class ... TArgs>
				static IEnvironment create(TArgs&&... args) {
				    return *new Implementer(std::forward<TArgs>(args)...);
				}
				void attach(VMT* other) ANTILATENCY_NOEXCEPT {
				    Antilatency::InterfaceContract::IInterface::attach(other);
				}
				VMT* detach() ANTILATENCY_NOEXCEPT {
				    return reinterpret_cast<VMT*>(Antilatency::InterfaceContract::IInterface::detach());
				}
				Antilatency::InterfaceContract::ExceptionCode isMutable(Antilatency::InterfaceContract::LongBool& result) {
					return (reinterpret_cast<VMT*>(this->_object))->isMutable(result);
				}
				Antilatency::InterfaceContract::ExceptionCode getMarkers(std::vector<Antilatency::Math::float3>& result) {
					auto resultMarshaler = Antilatency::InterfaceContract::Details::ArrayOutMarshaler::create(result);
					return (reinterpret_cast<VMT*>(this->_object))->getMarkers(resultMarshaler);
				}
				Antilatency::InterfaceContract::ExceptionCode filterRay(Antilatency::Math::float3 up, Antilatency::Math::float3 ray, Antilatency::InterfaceContract::LongBool& result) {
					return (reinterpret_cast<VMT*>(this->_object))->filterRay(up, ray, result);
				}
				Antilatency::InterfaceContract::ExceptionCode match(const std::vector<Antilatency::Math::float3>& raysUpSpace, std::vector<Antilatency::Alt::Environment::MarkerIndex>& markersIndices, Antilatency::Math::floatP3Q& poseOfUpSpace, Antilatency::InterfaceContract::LongBool& result) {
					auto raysUpSpaceMarshaler = Antilatency::InterfaceContract::Details::ArrayInMarshaler::create(raysUpSpace);
					auto markersIndicesMarshaler = Antilatency::InterfaceContract::Details::ArrayOutMarshaler::create(markersIndices);
					return (reinterpret_cast<VMT*>(this->_object))->match(raysUpSpaceMarshaler, markersIndicesMarshaler, poseOfUpSpace, result);
				}
				Antilatency::InterfaceContract::ExceptionCode matchByPosition(const std::vector<Antilatency::Math::float3>& rays, Antilatency::Math::float3 origin, std::vector<Antilatency::Alt::Environment::MarkerIndex>& result) {
					auto raysMarshaler = Antilatency::InterfaceContract::Details::ArrayInMarshaler::create(rays);
					auto resultMarshaler = Antilatency::InterfaceContract::Details::ArrayOutMarshaler::create(result);
					return (reinterpret_cast<VMT*>(this->_object))->matchByPosition(raysMarshaler, origin, resultMarshaler);
				}
			};
		} //namespace Environment
	} //namespace Alt
} //namespace Antilatency
namespace Antilatency {
	namespace InterfaceContract {
		namespace Details {
			template<typename Implementer, typename LifeTimeController>
			struct InterfaceRemap<Antilatency::Alt::Environment::IEnvironment, Implementer, LifeTimeController> : Antilatency::InterfaceContract::Details::InterfaceRemap<Antilatency::InterfaceContract::IInterface, Implementer, LifeTimeController> {
			public:
			    InterfaceRemap() = default;
			    static bool isInterfaceSupported(const Antilatency::InterfaceContract::InterfaceID& id) {
					if (id == Antilatency::Alt::Environment::IEnvironment::VMT::ID()) {
						return true;
					}
					return Antilatency::InterfaceContract::Details::InterfaceRemap<Antilatency::InterfaceContract::IInterface, Implementer, LifeTimeController>::isInterfaceSupported(id);
				}
			public:
				virtual Antilatency::InterfaceContract::ExceptionCode ANTILATENCY_INTERFACE_CALL isMutable(Antilatency::InterfaceContract::LongBool& result) {
					auto exceptionCode_ = this->_object->isMutable(result);
					return exceptionCode_;
				}
				virtual Antilatency::InterfaceContract::ExceptionCode ANTILATENCY_INTERFACE_CALL getMarkers(Antilatency::InterfaceContract::Details::ArrayOutMarshaler::Intermediate result) {
					std::vector<Antilatency::Math::float3> resultMarshaler;
					auto exceptionCode_ = this->_object->getMarkers(resultMarshaler);
					result = resultMarshaler;
					return exceptionCode_;
				}
				virtual Antilatency::InterfaceContract::ExceptionCode ANTILATENCY_INTERFACE_CALL filterRay(Antilatency::Math::float3 up, Antilatency::Math::float3 ray, Antilatency::InterfaceContract::LongBool& result) {
					auto exceptionCode_ = this->_object->filterRay(up, ray, result);
					return exceptionCode_;
				}
				virtual Antilatency::InterfaceContract::ExceptionCode ANTILATENCY_INTERFACE_CALL match(Antilatency::InterfaceContract::Details::ArrayInMarshaler::Intermediate raysUpSpace, Antilatency::InterfaceContract::Details::ArrayOutMarshaler::Intermediate markersIndices, Antilatency::Math::floatP3Q& poseOfUpSpace, Antilatency::InterfaceContract::LongBool& result) {
					std::vector<Antilatency::Alt::Environment::MarkerIndex> markersIndicesMarshaler;
					auto exceptionCode_ = this->_object->match(raysUpSpace, markersIndicesMarshaler, poseOfUpSpace, result);
					markersIndices = markersIndicesMarshaler;
					return exceptionCode_;
				}
				virtual Antilatency::InterfaceContract::ExceptionCode ANTILATENCY_INTERFACE_CALL matchByPosition(Antilatency::InterfaceContract::Details::ArrayInMarshaler::Intermediate rays, Antilatency::Math::float3 origin, Antilatency::InterfaceContract::Details::ArrayOutMarshaler::Intermediate result) {
					std::vector<Antilatency::Alt::Environment::MarkerIndex> resultMarshaler;
					auto exceptionCode_ = this->_object->matchByPosition(rays, origin, resultMarshaler);
					result = resultMarshaler;
					return exceptionCode_;
				}
			};
		} //namespace Details
	} //namespace InterfaceContract
} //namespace Antilatency

namespace Antilatency {
	namespace Alt {
		namespace Environment {
			/* copy and paste this to implementer
			Antilatency::InterfaceContract::ExceptionCode createEnvironment(const std::string& data, Antilatency::Alt::Environment::IEnvironment& result) {
				return Antilatency::InterfaceContract::ExceptionCode::NotImplemented;
			}
			*/
			struct IEnvironmentConstructor : Antilatency::InterfaceContract::IInterface {
				struct VMT : Antilatency::InterfaceContract::IInterface::VMT {
					virtual Antilatency::InterfaceContract::ExceptionCode ANTILATENCY_INTERFACE_CALL createEnvironment(Antilatency::InterfaceContract::Details::ArrayInMarshaler::Intermediate data, Antilatency::Alt::Environment::IEnvironment& result) = 0;
					static constexpr Antilatency::InterfaceContract::InterfaceID ID() {
						return Antilatency::InterfaceContract::InterfaceID{0xb691107e,0xd628,0x4c62,{0x80,0x03,0xe4,0xd7,0x84,0xb3,0x42,0xe7}};
					}
				private:
					~VMT() = delete;
				};
				IEnvironmentConstructor() = default;
				IEnvironmentConstructor(std::nullptr_t) {}
				explicit IEnvironmentConstructor(VMT* pointer) : Antilatency::InterfaceContract::IInterface(pointer) {}
				template<typename T, typename = typename std::enable_if<std::is_base_of<IEnvironmentConstructor, T>::value>::type>
				IEnvironmentConstructor& operator = (const T& other) {
				    Antilatency::InterfaceContract::IInterface::operator=(other);
				    return *this;
				}
				template<class Implementer, class ... TArgs>
				static IEnvironmentConstructor create(TArgs&&... args) {
				    return *new Implementer(std::forward<TArgs>(args)...);
				}
				void attach(VMT* other) ANTILATENCY_NOEXCEPT {
				    Antilatency::InterfaceContract::IInterface::attach(other);
				}
				VMT* detach() ANTILATENCY_NOEXCEPT {
				    return reinterpret_cast<VMT*>(Antilatency::InterfaceContract::IInterface::detach());
				}
				Antilatency::InterfaceContract::ExceptionCode createEnvironment(const std::string& data, Antilatency::Alt::Environment::IEnvironment& result) {
					auto dataMarshaler = Antilatency::InterfaceContract::Details::ArrayInMarshaler::create(data);
					return (reinterpret_cast<VMT*>(this->_object))->createEnvironment(dataMarshaler, result);
				}
			};
		} //namespace Environment
	} //namespace Alt
} //namespace Antilatency
namespace Antilatency {
	namespace InterfaceContract {
		namespace Details {
			template<typename Implementer, typename LifeTimeController>
			struct InterfaceRemap<Antilatency::Alt::Environment::IEnvironmentConstructor, Implementer, LifeTimeController> : Antilatency::InterfaceContract::Details::InterfaceRemap<Antilatency::InterfaceContract::IInterface, Implementer, LifeTimeController> {
			public:
			    InterfaceRemap() = default;
			    static bool isInterfaceSupported(const Antilatency::InterfaceContract::InterfaceID& id) {
					if (id == Antilatency::Alt::Environment::IEnvironmentConstructor::VMT::ID()) {
						return true;
					}
					return Antilatency::InterfaceContract::Details::InterfaceRemap<Antilatency::InterfaceContract::IInterface, Implementer, LifeTimeController>::isInterfaceSupported(id);
				}
			public:
				virtual Antilatency::InterfaceContract::ExceptionCode ANTILATENCY_INTERFACE_CALL createEnvironment(Antilatency::InterfaceContract::Details::ArrayInMarshaler::Intermediate data, Antilatency::Alt::Environment::IEnvironment& result) {
					auto exceptionCode_ = this->_object->createEnvironment(data, result);
					return exceptionCode_;
				}
			};
		} //namespace Details
	} //namespace InterfaceContract
} //namespace Antilatency


#ifdef _MSC_VER
#pragma warning(pop)
#endif
