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
#ifdef _MSC_VER
#pragma warning(push)
#pragma warning(disable: 4946)
#pragma warning(disable: 4265)
#endif
namespace Antilatency {
	namespace TrackingAlignment {
		struct State {
			Antilatency::Math::floatQ rotationARelativeToB;
			Antilatency::Math::floatQ rotationBSpace;
			float timeBAheadOfA;
		};
	} //namespace TrackingAlignment
} //namespace Antilatency

namespace Antilatency {
	namespace TrackingAlignment {
		/* copy and paste this to implementer
		Antilatency::InterfaceContract::ExceptionCode update(Antilatency::Math::floatQ a, Antilatency::Math::floatQ b, float time, Antilatency::TrackingAlignment::State& result) {
			return Antilatency::InterfaceContract::ExceptionCode::NotImplemented;
		}
		*/
		struct ITrackingAlignment : Antilatency::InterfaceContract::IInterface {
			struct VMT : Antilatency::InterfaceContract::IInterface::VMT {
				virtual Antilatency::InterfaceContract::ExceptionCode ANTILATENCY_INTERFACE_CALL update(Antilatency::Math::floatQ a, Antilatency::Math::floatQ b, float time, Antilatency::TrackingAlignment::State& result) = 0;
				static constexpr Antilatency::InterfaceContract::InterfaceID ID() {
					return Antilatency::InterfaceContract::InterfaceID{0x8b90d819,0x966a,0x484a,{0xa3,0xef,0x07,0xa2,0xa3,0xb2,0x35,0x18}};
				}
			private:
				~VMT() = delete;
			};
			ITrackingAlignment() = default;
			ITrackingAlignment(std::nullptr_t) {}
			explicit ITrackingAlignment(VMT* pointer) : Antilatency::InterfaceContract::IInterface(pointer) {}
			template<typename T, typename = typename std::enable_if<std::is_base_of<ITrackingAlignment, T>::value>::type>
			ITrackingAlignment& operator = (const T& other) {
			    Antilatency::InterfaceContract::IInterface::operator=(other);
			    return *this;
			}
			template<class Implementer, class ... TArgs>
			static ITrackingAlignment create(TArgs&&... args) {
			    return *new Implementer(std::forward<TArgs>(args)...);
			}
			void attach(VMT* other) ANTILATENCY_NOEXCEPT {
			    Antilatency::InterfaceContract::IInterface::attach(other);
			}
			VMT* detach() ANTILATENCY_NOEXCEPT {
			    return reinterpret_cast<VMT*>(Antilatency::InterfaceContract::IInterface::detach());
			}
			Antilatency::InterfaceContract::ExceptionCode update(Antilatency::Math::floatQ a, Antilatency::Math::floatQ b, float time, Antilatency::TrackingAlignment::State& result) {
				return (reinterpret_cast<VMT*>(this->_object))->update(a, b, time, result);
			}
		};
	} //namespace TrackingAlignment
} //namespace Antilatency
namespace Antilatency {
	namespace InterfaceContract {
		namespace Details {
			template<typename Implementer, typename LifeTimeController>
			struct InterfaceRemap<Antilatency::TrackingAlignment::ITrackingAlignment, Implementer, LifeTimeController> : Antilatency::InterfaceContract::Details::InterfaceRemap<Antilatency::InterfaceContract::IInterface, Implementer, LifeTimeController> {
			public:
			    InterfaceRemap() = default;
			    static bool isInterfaceSupported(const Antilatency::InterfaceContract::InterfaceID& id) {
					if (id == Antilatency::TrackingAlignment::ITrackingAlignment::VMT::ID()) {
						return true;
					}
					return Antilatency::InterfaceContract::Details::InterfaceRemap<Antilatency::InterfaceContract::IInterface, Implementer, LifeTimeController>::isInterfaceSupported(id);
				}
			public:
				virtual Antilatency::InterfaceContract::ExceptionCode ANTILATENCY_INTERFACE_CALL update(Antilatency::Math::floatQ a, Antilatency::Math::floatQ b, float time, Antilatency::TrackingAlignment::State& result) {
					auto exceptionCode_ = this->_object->update(a, b, time, result);
					return exceptionCode_;
				}
			};
		} //namespace Details
	} //namespace InterfaceContract
} //namespace Antilatency

namespace Antilatency {
	namespace TrackingAlignment {
		/* copy and paste this to implementer
		Antilatency::InterfaceContract::ExceptionCode createTrackingAlignment(Antilatency::Math::floatQ initialARelativeToB, float initialTimeBAheadOfA, Antilatency::TrackingAlignment::ITrackingAlignment& result) {
			return Antilatency::InterfaceContract::ExceptionCode::NotImplemented;
		}
		*/
		struct ILibrary : Antilatency::InterfaceContract::IInterface {
			struct VMT : Antilatency::InterfaceContract::IInterface::VMT {
				virtual Antilatency::InterfaceContract::ExceptionCode ANTILATENCY_INTERFACE_CALL createTrackingAlignment(Antilatency::Math::floatQ initialARelativeToB, float initialTimeBAheadOfA, Antilatency::TrackingAlignment::ITrackingAlignment& result) = 0;
				static constexpr Antilatency::InterfaceContract::InterfaceID ID() {
					return Antilatency::InterfaceContract::InterfaceID{0xbf75e5e0,0x2990,0x4550,{0x8b,0xaf,0x62,0xd3,0x84,0x4b,0x0a,0xae}};
				}
			private:
				~VMT() = delete;
			};
			ILibrary() = default;
			ILibrary(std::nullptr_t) {}
			explicit ILibrary(VMT* pointer) : Antilatency::InterfaceContract::IInterface(pointer) {}
			template<typename T, typename = typename std::enable_if<std::is_base_of<ILibrary, T>::value>::type>
			ILibrary& operator = (const T& other) {
			    Antilatency::InterfaceContract::IInterface::operator=(other);
			    return *this;
			}
			template<class Implementer, class ... TArgs>
			static ILibrary create(TArgs&&... args) {
			    return *new Implementer(std::forward<TArgs>(args)...);
			}
			void attach(VMT* other) ANTILATENCY_NOEXCEPT {
			    Antilatency::InterfaceContract::IInterface::attach(other);
			}
			VMT* detach() ANTILATENCY_NOEXCEPT {
			    return reinterpret_cast<VMT*>(Antilatency::InterfaceContract::IInterface::detach());
			}
			Antilatency::InterfaceContract::ExceptionCode createTrackingAlignment(Antilatency::Math::floatQ initialARelativeToB, float initialTimeBAheadOfA, Antilatency::TrackingAlignment::ITrackingAlignment& result) {
				return (reinterpret_cast<VMT*>(this->_object))->createTrackingAlignment(initialARelativeToB, initialTimeBAheadOfA, result);
			}
		};
	} //namespace TrackingAlignment
} //namespace Antilatency
namespace Antilatency {
	namespace InterfaceContract {
		namespace Details {
			template<typename Implementer, typename LifeTimeController>
			struct InterfaceRemap<Antilatency::TrackingAlignment::ILibrary, Implementer, LifeTimeController> : Antilatency::InterfaceContract::Details::InterfaceRemap<Antilatency::InterfaceContract::IInterface, Implementer, LifeTimeController> {
			public:
			    InterfaceRemap() = default;
			    static bool isInterfaceSupported(const Antilatency::InterfaceContract::InterfaceID& id) {
					if (id == Antilatency::TrackingAlignment::ILibrary::VMT::ID()) {
						return true;
					}
					return Antilatency::InterfaceContract::Details::InterfaceRemap<Antilatency::InterfaceContract::IInterface, Implementer, LifeTimeController>::isInterfaceSupported(id);
				}
			public:
				virtual Antilatency::InterfaceContract::ExceptionCode ANTILATENCY_INTERFACE_CALL createTrackingAlignment(Antilatency::Math::floatQ initialARelativeToB, float initialTimeBAheadOfA, Antilatency::TrackingAlignment::ITrackingAlignment& result) {
					auto exceptionCode_ = this->_object->createTrackingAlignment(initialARelativeToB, initialTimeBAheadOfA, result);
					return exceptionCode_;
				}
			};
		} //namespace Details
	} //namespace InterfaceContract
} //namespace Antilatency


#ifdef _MSC_VER
#pragma warning(pop)
#endif
