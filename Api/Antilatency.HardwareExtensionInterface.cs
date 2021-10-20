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
#pragma warning disable IDE1006 // Do not warn about naming style violations
#pragma warning disable IDE0017 // Do not suggest to simplify object initialization
using System.Runtime.InteropServices; //GuidAttribute
namespace Antilatency.HardwareExtensionInterface {

[Guid("39e6527d-82db-4615-af8f-0fad4c79f15e")]
public interface IInputPin : Antilatency.InterfaceContract.IInterface {
	Antilatency.HardwareExtensionInterface.Interop.PinState getState();
}
namespace Details {
	public class IInputPinWrapper : Antilatency.InterfaceContract.Details.IInterfaceWrapper, IInputPin {
		private IInputPinRemap.VMT _VMT = new IInputPinRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(IInputPinRemap.VMT).GetFields().Length;
		}
		public IInputPinWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<IInputPinRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public Antilatency.HardwareExtensionInterface.Interop.PinState getState() {
			Antilatency.HardwareExtensionInterface.Interop.PinState result;
			Antilatency.HardwareExtensionInterface.Interop.PinState resultMarshaler;
			HandleExceptionCode(_VMT.getState(_object, out resultMarshaler));
			result = resultMarshaler;
			return result;
		}
	}
	public class IInputPinRemap : Antilatency.InterfaceContract.Details.IInterfaceRemap {
		public new struct VMT {
			public delegate Antilatency.InterfaceContract.ExceptionCode getStateDelegate(System.IntPtr _this, out Antilatency.HardwareExtensionInterface.Interop.PinState result);
			#pragma warning disable 0649
			public getStateDelegate getState;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static IInputPinRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			Antilatency.InterfaceContract.Details.IInterfaceRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.getState = (System.IntPtr _this, out Antilatency.HardwareExtensionInterface.Interop.PinState result) => {
				try {
					var obj = GetContext(_this) as IInputPin;
					var resultMarshaler = obj.getState();
					result = resultMarshaler;
				}
				catch (System.Exception ex) {
					result = default(Antilatency.HardwareExtensionInterface.Interop.PinState);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public IInputPinRemap() { }
		public IInputPinRemap(System.IntPtr context, ushort lifetimeId) {
			AllocateNativeInterface(NativeVmt.Handle, context, lifetimeId);
		}
	}
}

[Guid("20d12574-3ae9-4921-80d3-95217e61f4b2")]
public interface IOutputPin : Antilatency.InterfaceContract.IInterface {
	void setState(Antilatency.HardwareExtensionInterface.Interop.PinState state);
	Antilatency.HardwareExtensionInterface.Interop.PinState getState();
}
namespace Details {
	public class IOutputPinWrapper : Antilatency.InterfaceContract.Details.IInterfaceWrapper, IOutputPin {
		private IOutputPinRemap.VMT _VMT = new IOutputPinRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(IOutputPinRemap.VMT).GetFields().Length;
		}
		public IOutputPinWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<IOutputPinRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public void setState(Antilatency.HardwareExtensionInterface.Interop.PinState state) {
			HandleExceptionCode(_VMT.setState(_object, state));
		}
		public Antilatency.HardwareExtensionInterface.Interop.PinState getState() {
			Antilatency.HardwareExtensionInterface.Interop.PinState result;
			Antilatency.HardwareExtensionInterface.Interop.PinState resultMarshaler;
			HandleExceptionCode(_VMT.getState(_object, out resultMarshaler));
			result = resultMarshaler;
			return result;
		}
	}
	public class IOutputPinRemap : Antilatency.InterfaceContract.Details.IInterfaceRemap {
		public new struct VMT {
			public delegate Antilatency.InterfaceContract.ExceptionCode setStateDelegate(System.IntPtr _this, Antilatency.HardwareExtensionInterface.Interop.PinState state);
			public delegate Antilatency.InterfaceContract.ExceptionCode getStateDelegate(System.IntPtr _this, out Antilatency.HardwareExtensionInterface.Interop.PinState result);
			#pragma warning disable 0649
			public setStateDelegate setState;
			public getStateDelegate getState;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static IOutputPinRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			Antilatency.InterfaceContract.Details.IInterfaceRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.setState = (System.IntPtr _this, Antilatency.HardwareExtensionInterface.Interop.PinState state) => {
				try {
					var obj = GetContext(_this) as IOutputPin;
					obj.setState(state);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.getState = (System.IntPtr _this, out Antilatency.HardwareExtensionInterface.Interop.PinState result) => {
				try {
					var obj = GetContext(_this) as IOutputPin;
					var resultMarshaler = obj.getState();
					result = resultMarshaler;
				}
				catch (System.Exception ex) {
					result = default(Antilatency.HardwareExtensionInterface.Interop.PinState);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public IOutputPinRemap() { }
		public IOutputPinRemap(System.IntPtr context, ushort lifetimeId) {
			AllocateNativeInterface(NativeVmt.Handle, context, lifetimeId);
		}
	}
}

[Guid("e927972f-10e5-43e2-9502-74bcfed32482")]
public interface IAnalogPin : Antilatency.InterfaceContract.IInterface {
	float getValue();
}
namespace Details {
	public class IAnalogPinWrapper : Antilatency.InterfaceContract.Details.IInterfaceWrapper, IAnalogPin {
		private IAnalogPinRemap.VMT _VMT = new IAnalogPinRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(IAnalogPinRemap.VMT).GetFields().Length;
		}
		public IAnalogPinWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<IAnalogPinRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public float getValue() {
			float result;
			float resultMarshaler;
			HandleExceptionCode(_VMT.getValue(_object, out resultMarshaler));
			result = resultMarshaler;
			return result;
		}
	}
	public class IAnalogPinRemap : Antilatency.InterfaceContract.Details.IInterfaceRemap {
		public new struct VMT {
			public delegate Antilatency.InterfaceContract.ExceptionCode getValueDelegate(System.IntPtr _this, out float result);
			#pragma warning disable 0649
			public getValueDelegate getValue;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static IAnalogPinRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			Antilatency.InterfaceContract.Details.IInterfaceRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.getValue = (System.IntPtr _this, out float result) => {
				try {
					var obj = GetContext(_this) as IAnalogPin;
					var resultMarshaler = obj.getValue();
					result = resultMarshaler;
				}
				catch (System.Exception ex) {
					result = default(float);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public IAnalogPinRemap() { }
		public IAnalogPinRemap(System.IntPtr context, ushort lifetimeId) {
			AllocateNativeInterface(NativeVmt.Handle, context, lifetimeId);
		}
	}
}

[Guid("8998b746-5d17-4a47-9c8b-01d5a959536c")]
public interface IPulseCounterPin : Antilatency.InterfaceContract.IInterface {
	ushort getValue();
}
namespace Details {
	public class IPulseCounterPinWrapper : Antilatency.InterfaceContract.Details.IInterfaceWrapper, IPulseCounterPin {
		private IPulseCounterPinRemap.VMT _VMT = new IPulseCounterPinRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(IPulseCounterPinRemap.VMT).GetFields().Length;
		}
		public IPulseCounterPinWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<IPulseCounterPinRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public ushort getValue() {
			ushort result;
			ushort resultMarshaler;
			HandleExceptionCode(_VMT.getValue(_object, out resultMarshaler));
			result = resultMarshaler;
			return result;
		}
	}
	public class IPulseCounterPinRemap : Antilatency.InterfaceContract.Details.IInterfaceRemap {
		public new struct VMT {
			public delegate Antilatency.InterfaceContract.ExceptionCode getValueDelegate(System.IntPtr _this, out ushort result);
			#pragma warning disable 0649
			public getValueDelegate getValue;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static IPulseCounterPinRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			Antilatency.InterfaceContract.Details.IInterfaceRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.getValue = (System.IntPtr _this, out ushort result) => {
				try {
					var obj = GetContext(_this) as IPulseCounterPin;
					var resultMarshaler = obj.getValue();
					result = resultMarshaler;
				}
				catch (System.Exception ex) {
					result = default(ushort);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public IPulseCounterPinRemap() { }
		public IPulseCounterPinRemap(System.IntPtr context, ushort lifetimeId) {
			AllocateNativeInterface(NativeVmt.Handle, context, lifetimeId);
		}
	}
}

[Guid("0793b2f5-2f6f-4a01-8b25-f2ff98360441")]
public interface IPwmPin : Antilatency.InterfaceContract.IInterface {
	void setDuty(float value);
	float getDuty();
	/// <summary>Get actual pwm frequency.</summary>
	uint getFrequency();
}
namespace Details {
	public class IPwmPinWrapper : Antilatency.InterfaceContract.Details.IInterfaceWrapper, IPwmPin {
		private IPwmPinRemap.VMT _VMT = new IPwmPinRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(IPwmPinRemap.VMT).GetFields().Length;
		}
		public IPwmPinWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<IPwmPinRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public void setDuty(float value) {
			HandleExceptionCode(_VMT.setDuty(_object, value));
		}
		public float getDuty() {
			float result;
			float resultMarshaler;
			HandleExceptionCode(_VMT.getDuty(_object, out resultMarshaler));
			result = resultMarshaler;
			return result;
		}
		public uint getFrequency() {
			uint result;
			uint resultMarshaler;
			HandleExceptionCode(_VMT.getFrequency(_object, out resultMarshaler));
			result = resultMarshaler;
			return result;
		}
	}
	public class IPwmPinRemap : Antilatency.InterfaceContract.Details.IInterfaceRemap {
		public new struct VMT {
			public delegate Antilatency.InterfaceContract.ExceptionCode setDutyDelegate(System.IntPtr _this, float value);
			public delegate Antilatency.InterfaceContract.ExceptionCode getDutyDelegate(System.IntPtr _this, out float result);
			public delegate Antilatency.InterfaceContract.ExceptionCode getFrequencyDelegate(System.IntPtr _this, out uint result);
			#pragma warning disable 0649
			public setDutyDelegate setDuty;
			public getDutyDelegate getDuty;
			public getFrequencyDelegate getFrequency;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static IPwmPinRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			Antilatency.InterfaceContract.Details.IInterfaceRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.setDuty = (System.IntPtr _this, float value) => {
				try {
					var obj = GetContext(_this) as IPwmPin;
					obj.setDuty(value);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.getDuty = (System.IntPtr _this, out float result) => {
				try {
					var obj = GetContext(_this) as IPwmPin;
					var resultMarshaler = obj.getDuty();
					result = resultMarshaler;
				}
				catch (System.Exception ex) {
					result = default(float);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.getFrequency = (System.IntPtr _this, out uint result) => {
				try {
					var obj = GetContext(_this) as IPwmPin;
					var resultMarshaler = obj.getFrequency();
					result = resultMarshaler;
				}
				catch (System.Exception ex) {
					result = default(uint);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public IPwmPinRemap() { }
		public IPwmPinRemap(System.IntPtr context, ushort lifetimeId) {
			AllocateNativeInterface(NativeVmt.Handle, context, lifetimeId);
		}
	}
}

[Guid("acd1daa9-9394-4d3a-95ce-177a23bd9b89")]
public interface ICotask : Antilatency.DeviceNetwork.ICotask {
	Antilatency.HardwareExtensionInterface.IInputPin createInputPin(Antilatency.HardwareExtensionInterface.Interop.Pins pin);
	Antilatency.HardwareExtensionInterface.IOutputPin createOutputPin(Antilatency.HardwareExtensionInterface.Interop.Pins pin, Antilatency.HardwareExtensionInterface.Interop.PinState initialState);
	Antilatency.HardwareExtensionInterface.IAnalogPin createAnalogPin(Antilatency.HardwareExtensionInterface.Interop.Pins pin, uint refreshIntervalMs);
	Antilatency.HardwareExtensionInterface.IPulseCounterPin createPulseCounterPin(Antilatency.HardwareExtensionInterface.Interop.Pins pin, uint refreshIntervalMs);
	Antilatency.HardwareExtensionInterface.IPwmPin createPwmPin(Antilatency.HardwareExtensionInterface.Interop.Pins pin, uint frequency, float initialDuty);
	void run();
}
namespace Details {
	public class ICotaskWrapper : Antilatency.DeviceNetwork.Details.ICotaskWrapper, ICotask {
		private ICotaskRemap.VMT _VMT = new ICotaskRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(ICotaskRemap.VMT).GetFields().Length;
		}
		public ICotaskWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<ICotaskRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public Antilatency.HardwareExtensionInterface.IInputPin createInputPin(Antilatency.HardwareExtensionInterface.Interop.Pins pin) {
			Antilatency.HardwareExtensionInterface.IInputPin result;
			System.IntPtr resultMarshaler;
			HandleExceptionCode(_VMT.createInputPin(_object, pin, out resultMarshaler));
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new Antilatency.HardwareExtensionInterface.Details.IInputPinWrapper(resultMarshaler);
			return result;
		}
		public Antilatency.HardwareExtensionInterface.IOutputPin createOutputPin(Antilatency.HardwareExtensionInterface.Interop.Pins pin, Antilatency.HardwareExtensionInterface.Interop.PinState initialState) {
			Antilatency.HardwareExtensionInterface.IOutputPin result;
			System.IntPtr resultMarshaler;
			HandleExceptionCode(_VMT.createOutputPin(_object, pin, initialState, out resultMarshaler));
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new Antilatency.HardwareExtensionInterface.Details.IOutputPinWrapper(resultMarshaler);
			return result;
		}
		public Antilatency.HardwareExtensionInterface.IAnalogPin createAnalogPin(Antilatency.HardwareExtensionInterface.Interop.Pins pin, uint refreshIntervalMs) {
			Antilatency.HardwareExtensionInterface.IAnalogPin result;
			System.IntPtr resultMarshaler;
			HandleExceptionCode(_VMT.createAnalogPin(_object, pin, refreshIntervalMs, out resultMarshaler));
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new Antilatency.HardwareExtensionInterface.Details.IAnalogPinWrapper(resultMarshaler);
			return result;
		}
		public Antilatency.HardwareExtensionInterface.IPulseCounterPin createPulseCounterPin(Antilatency.HardwareExtensionInterface.Interop.Pins pin, uint refreshIntervalMs) {
			Antilatency.HardwareExtensionInterface.IPulseCounterPin result;
			System.IntPtr resultMarshaler;
			HandleExceptionCode(_VMT.createPulseCounterPin(_object, pin, refreshIntervalMs, out resultMarshaler));
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new Antilatency.HardwareExtensionInterface.Details.IPulseCounterPinWrapper(resultMarshaler);
			return result;
		}
		public Antilatency.HardwareExtensionInterface.IPwmPin createPwmPin(Antilatency.HardwareExtensionInterface.Interop.Pins pin, uint frequency, float initialDuty) {
			Antilatency.HardwareExtensionInterface.IPwmPin result;
			System.IntPtr resultMarshaler;
			HandleExceptionCode(_VMT.createPwmPin(_object, pin, frequency, initialDuty, out resultMarshaler));
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new Antilatency.HardwareExtensionInterface.Details.IPwmPinWrapper(resultMarshaler);
			return result;
		}
		public void run() {
			HandleExceptionCode(_VMT.run(_object));
		}
	}
	public class ICotaskRemap : Antilatency.DeviceNetwork.Details.ICotaskRemap {
		public new struct VMT {
			public delegate Antilatency.InterfaceContract.ExceptionCode createInputPinDelegate(System.IntPtr _this, Antilatency.HardwareExtensionInterface.Interop.Pins pin, out System.IntPtr result);
			public delegate Antilatency.InterfaceContract.ExceptionCode createOutputPinDelegate(System.IntPtr _this, Antilatency.HardwareExtensionInterface.Interop.Pins pin, Antilatency.HardwareExtensionInterface.Interop.PinState initialState, out System.IntPtr result);
			public delegate Antilatency.InterfaceContract.ExceptionCode createAnalogPinDelegate(System.IntPtr _this, Antilatency.HardwareExtensionInterface.Interop.Pins pin, uint refreshIntervalMs, out System.IntPtr result);
			public delegate Antilatency.InterfaceContract.ExceptionCode createPulseCounterPinDelegate(System.IntPtr _this, Antilatency.HardwareExtensionInterface.Interop.Pins pin, uint refreshIntervalMs, out System.IntPtr result);
			public delegate Antilatency.InterfaceContract.ExceptionCode createPwmPinDelegate(System.IntPtr _this, Antilatency.HardwareExtensionInterface.Interop.Pins pin, uint frequency, float initialDuty, out System.IntPtr result);
			public delegate Antilatency.InterfaceContract.ExceptionCode runDelegate(System.IntPtr _this);
			#pragma warning disable 0649
			public createInputPinDelegate createInputPin;
			public createOutputPinDelegate createOutputPin;
			public createAnalogPinDelegate createAnalogPin;
			public createPulseCounterPinDelegate createPulseCounterPin;
			public createPwmPinDelegate createPwmPin;
			public runDelegate run;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static ICotaskRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			Antilatency.DeviceNetwork.Details.ICotaskRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.createInputPin = (System.IntPtr _this, Antilatency.HardwareExtensionInterface.Interop.Pins pin, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as ICotask;
					var resultMarshaler = obj.createInputPin(pin);
					result = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.HardwareExtensionInterface.IInputPin>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.createOutputPin = (System.IntPtr _this, Antilatency.HardwareExtensionInterface.Interop.Pins pin, Antilatency.HardwareExtensionInterface.Interop.PinState initialState, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as ICotask;
					var resultMarshaler = obj.createOutputPin(pin, initialState);
					result = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.HardwareExtensionInterface.IOutputPin>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.createAnalogPin = (System.IntPtr _this, Antilatency.HardwareExtensionInterface.Interop.Pins pin, uint refreshIntervalMs, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as ICotask;
					var resultMarshaler = obj.createAnalogPin(pin, refreshIntervalMs);
					result = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.HardwareExtensionInterface.IAnalogPin>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.createPulseCounterPin = (System.IntPtr _this, Antilatency.HardwareExtensionInterface.Interop.Pins pin, uint refreshIntervalMs, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as ICotask;
					var resultMarshaler = obj.createPulseCounterPin(pin, refreshIntervalMs);
					result = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.HardwareExtensionInterface.IPulseCounterPin>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.createPwmPin = (System.IntPtr _this, Antilatency.HardwareExtensionInterface.Interop.Pins pin, uint frequency, float initialDuty, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as ICotask;
					var resultMarshaler = obj.createPwmPin(pin, frequency, initialDuty);
					result = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.HardwareExtensionInterface.IPwmPin>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.run = (System.IntPtr _this) => {
				try {
					var obj = GetContext(_this) as ICotask;
					obj.run();
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public ICotaskRemap() { }
		public ICotaskRemap(System.IntPtr context, ushort lifetimeId) {
			AllocateNativeInterface(NativeVmt.Handle, context, lifetimeId);
		}
	}
}

[Guid("53b72a7a-c61e-4946-8a06-564a7171d477")]
public interface ICotaskConstructor : Antilatency.DeviceNetwork.ICotaskConstructor {
	Antilatency.HardwareExtensionInterface.ICotask startTask(Antilatency.DeviceNetwork.INetwork network, Antilatency.DeviceNetwork.NodeHandle node);
}
namespace Details {
	public class ICotaskConstructorWrapper : Antilatency.DeviceNetwork.Details.ICotaskConstructorWrapper, ICotaskConstructor {
		private ICotaskConstructorRemap.VMT _VMT = new ICotaskConstructorRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(ICotaskConstructorRemap.VMT).GetFields().Length;
		}
		public ICotaskConstructorWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<ICotaskConstructorRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public Antilatency.HardwareExtensionInterface.ICotask startTask(Antilatency.DeviceNetwork.INetwork network, Antilatency.DeviceNetwork.NodeHandle node) {
			Antilatency.HardwareExtensionInterface.ICotask result;
			System.IntPtr resultMarshaler;
			var networkMarshaler = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.DeviceNetwork.INetwork>(network);
			HandleExceptionCode(_VMT.startTask(_object, networkMarshaler, node, out resultMarshaler));
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new Antilatency.HardwareExtensionInterface.Details.ICotaskWrapper(resultMarshaler);
			return result;
		}
	}
	public class ICotaskConstructorRemap : Antilatency.DeviceNetwork.Details.ICotaskConstructorRemap {
		public new struct VMT {
			public delegate Antilatency.InterfaceContract.ExceptionCode startTaskDelegate(System.IntPtr _this, System.IntPtr network, Antilatency.DeviceNetwork.NodeHandle node, out System.IntPtr result);
			#pragma warning disable 0649
			public startTaskDelegate startTask;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static ICotaskConstructorRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			Antilatency.DeviceNetwork.Details.ICotaskConstructorRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.startTask = (System.IntPtr _this, System.IntPtr network, Antilatency.DeviceNetwork.NodeHandle node, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as ICotaskConstructor;
					var networkMarshaler = network == System.IntPtr.Zero ? null : new Antilatency.DeviceNetwork.Details.INetworkWrapper(network);
					var resultMarshaler = obj.startTask(networkMarshaler, node);
					result = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.HardwareExtensionInterface.ICotask>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public ICotaskConstructorRemap() { }
		public ICotaskConstructorRemap(System.IntPtr context, ushort lifetimeId) {
			AllocateNativeInterface(NativeVmt.Handle, context, lifetimeId);
		}
	}
}

[Guid("ef1b555b-bbf4-4514-829b-b0cd15b6fc8d")]
public interface ILibrary : Antilatency.InterfaceContract.IInterface {
	string getVersion();
	Antilatency.HardwareExtensionInterface.ICotaskConstructor getCotaskConstructor();
}
public static class Library{
    [DllImport("AntilatencyHardwareExtensionInterface")]
    private static extern Antilatency.InterfaceContract.ExceptionCode getLibraryInterface(System.IntPtr unloader, out System.IntPtr result);
    public static ILibrary load(){
        System.IntPtr libraryAsIInterfaceIntermediate;
        getLibraryInterface(System.IntPtr.Zero, out libraryAsIInterfaceIntermediate);
        Antilatency.InterfaceContract.IInterface libraryAsIInterface = new Antilatency.InterfaceContract.Details.IInterfaceWrapper(libraryAsIInterfaceIntermediate);
        var library = libraryAsIInterface.QueryInterface<ILibrary>();
        libraryAsIInterface.Dispose();
        return library;
    }
}
namespace Details {
	public class ILibraryWrapper : Antilatency.InterfaceContract.Details.IInterfaceWrapper, ILibrary {
		private ILibraryRemap.VMT _VMT = new ILibraryRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(ILibraryRemap.VMT).GetFields().Length;
		}
		public ILibraryWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<ILibraryRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public string getVersion() {
			string result;
			var resultMarshaler = Antilatency.InterfaceContract.Details.ArrayOutMarshaler.create();
			HandleExceptionCode(_VMT.getVersion(_object, resultMarshaler));
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public Antilatency.HardwareExtensionInterface.ICotaskConstructor getCotaskConstructor() {
			Antilatency.HardwareExtensionInterface.ICotaskConstructor result;
			System.IntPtr resultMarshaler;
			HandleExceptionCode(_VMT.getCotaskConstructor(_object, out resultMarshaler));
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new Antilatency.HardwareExtensionInterface.Details.ICotaskConstructorWrapper(resultMarshaler);
			return result;
		}
	}
	public class ILibraryRemap : Antilatency.InterfaceContract.Details.IInterfaceRemap {
		public new struct VMT {
			public delegate Antilatency.InterfaceContract.ExceptionCode getVersionDelegate(System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate Antilatency.InterfaceContract.ExceptionCode getCotaskConstructorDelegate(System.IntPtr _this, out System.IntPtr result);
			#pragma warning disable 0649
			public getVersionDelegate getVersion;
			public getCotaskConstructorDelegate getCotaskConstructor;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static ILibraryRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			Antilatency.InterfaceContract.Details.IInterfaceRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.getVersion = (System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as ILibrary;
					var resultMarshaler = obj.getVersion();
					result.assign(resultMarshaler);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.getCotaskConstructor = (System.IntPtr _this, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as ILibrary;
					var resultMarshaler = obj.getCotaskConstructor();
					result = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.HardwareExtensionInterface.ICotaskConstructor>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public ILibraryRemap() { }
		public ILibraryRemap(System.IntPtr context, ushort lifetimeId) {
			AllocateNativeInterface(NativeVmt.Handle, context, lifetimeId);
		}
	}
}

public static partial class Constants {
	public const uint AnalogMinRefreshIntervalMs = 1;
	public const uint AnalogMaxRefreshIntervalMs = 65535;
	public const uint PulseCounterMinRefreshIntervalMs = 1;
	public const uint PulseCounterMaxRefreshIntervalMs = 125;
	public const uint PwmMinFrequency = 20;
	public const uint PwmMaxFrequency = 10000;
}


}
