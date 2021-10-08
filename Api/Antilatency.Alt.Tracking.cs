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
namespace Antilatency.Alt.Tracking {

[System.Serializable]
[System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
public partial struct Stage {
	public static readonly Stage InertialDataInitialization = new Stage(){ value = 0x0 };
	public static readonly Stage Tracking3Dof = new Stage(){ value = 0x1 };
	public static readonly Stage Tracking6Dof = new Stage(){ value = 0x2 };
	public static readonly Stage TrackingBlind6Dof = new Stage(){ value = 0x3 };
	[System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
	public int value;
	public override string ToString() {
		switch (value) {
			case 0x0: return "InertialDataInitialization";
			case 0x1: return "Tracking3Dof";
			case 0x2: return "Tracking6Dof";
			case 0x3: return "TrackingBlind6Dof";
		}
		return value.ToString();
	}
	public static implicit operator int(Stage value) { return value.value;}
	public static explicit operator Stage(int value) { return new Stage() { value = value }; }
}

[System.Serializable]
[System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
public partial struct Stability {
	public Antilatency.Alt.Tracking.Stage stage;
	public float value;
}

[System.Serializable]
[System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
public partial struct State {
	public Antilatency.Math.floatP3Q pose;
	public Antilatency.Math.float3 velocity;
	public Antilatency.Math.float3 localAngularVelocity;
	public Antilatency.Alt.Tracking.Stability stability;
}

[Guid("7f8b603c-fa91-4168-92b7-af1644d087db")]
public interface ITrackingCotask : Antilatency.DeviceNetwork.ICotask {
	Antilatency.Alt.Tracking.State getExtrapolatedState(Antilatency.Math.floatP3Q placement, float deltaTime);
	Antilatency.Alt.Tracking.State getState(float angularVelocityAvgTimeInSeconds);
}
namespace Details {
	public class ITrackingCotaskWrapper : Antilatency.DeviceNetwork.Details.ICotaskWrapper, ITrackingCotask {
		private ITrackingCotaskRemap.VMT _VMT = new ITrackingCotaskRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(ITrackingCotaskRemap.VMT).GetFields().Length;
		}
		public ITrackingCotaskWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<ITrackingCotaskRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public Antilatency.Alt.Tracking.State getExtrapolatedState(Antilatency.Math.floatP3Q placement, float deltaTime) {
			Antilatency.Alt.Tracking.State result;
			Antilatency.Alt.Tracking.State resultMarshaler;
			HandleExceptionCode(_VMT.getExtrapolatedState(_object, placement, deltaTime, out resultMarshaler));
			result = resultMarshaler;
			return result;
		}
		public Antilatency.Alt.Tracking.State getState(float angularVelocityAvgTimeInSeconds) {
			Antilatency.Alt.Tracking.State result;
			Antilatency.Alt.Tracking.State resultMarshaler;
			HandleExceptionCode(_VMT.getState(_object, angularVelocityAvgTimeInSeconds, out resultMarshaler));
			result = resultMarshaler;
			return result;
		}
	}
	public class ITrackingCotaskRemap : Antilatency.DeviceNetwork.Details.ICotaskRemap {
		public new struct VMT {
			public delegate Antilatency.InterfaceContract.ExceptionCode getExtrapolatedStateDelegate(System.IntPtr _this, Antilatency.Math.floatP3Q placement, float deltaTime, out Antilatency.Alt.Tracking.State result);
			public delegate Antilatency.InterfaceContract.ExceptionCode getStateDelegate(System.IntPtr _this, float angularVelocityAvgTimeInSeconds, out Antilatency.Alt.Tracking.State result);
			#pragma warning disable 0649
			public getExtrapolatedStateDelegate getExtrapolatedState;
			public getStateDelegate getState;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static ITrackingCotaskRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			Antilatency.DeviceNetwork.Details.ICotaskRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.getExtrapolatedState = (System.IntPtr _this, Antilatency.Math.floatP3Q placement, float deltaTime, out Antilatency.Alt.Tracking.State result) => {
				try {
					var obj = GetContext(_this) as ITrackingCotask;
					var resultMarshaler = obj.getExtrapolatedState(placement, deltaTime);
					result = resultMarshaler;
				}
				catch (System.Exception ex) {
					result = default(Antilatency.Alt.Tracking.State);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.getState = (System.IntPtr _this, float angularVelocityAvgTimeInSeconds, out Antilatency.Alt.Tracking.State result) => {
				try {
					var obj = GetContext(_this) as ITrackingCotask;
					var resultMarshaler = obj.getState(angularVelocityAvgTimeInSeconds);
					result = resultMarshaler;
				}
				catch (System.Exception ex) {
					result = default(Antilatency.Alt.Tracking.State);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public ITrackingCotaskRemap() { }
		public ITrackingCotaskRemap(System.IntPtr context, ushort lifetimeId) {
			AllocateNativeInterface(NativeVmt.Handle, context, lifetimeId);
		}
	}
}

[Guid("009ebfe1-f85c-4638-be9d-af7990a8cd04")]
public interface ITrackingCotaskConstructor : Antilatency.DeviceNetwork.ICotaskConstructor {
	Antilatency.Alt.Tracking.ITrackingCotask startTask(Antilatency.DeviceNetwork.INetwork network, Antilatency.DeviceNetwork.NodeHandle node, Antilatency.Alt.Environment.IEnvironment environment);
}
namespace Details {
	public class ITrackingCotaskConstructorWrapper : Antilatency.DeviceNetwork.Details.ICotaskConstructorWrapper, ITrackingCotaskConstructor {
		private ITrackingCotaskConstructorRemap.VMT _VMT = new ITrackingCotaskConstructorRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(ITrackingCotaskConstructorRemap.VMT).GetFields().Length;
		}
		public ITrackingCotaskConstructorWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<ITrackingCotaskConstructorRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public Antilatency.Alt.Tracking.ITrackingCotask startTask(Antilatency.DeviceNetwork.INetwork network, Antilatency.DeviceNetwork.NodeHandle node, Antilatency.Alt.Environment.IEnvironment environment) {
			Antilatency.Alt.Tracking.ITrackingCotask result;
			System.IntPtr resultMarshaler;
			var networkMarshaler = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.DeviceNetwork.INetwork>(network);
			var environmentMarshaler = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.Alt.Environment.IEnvironment>(environment);
			HandleExceptionCode(_VMT.startTask(_object, networkMarshaler, node, environmentMarshaler, out resultMarshaler));
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new Antilatency.Alt.Tracking.Details.ITrackingCotaskWrapper(resultMarshaler);
			return result;
		}
	}
	public class ITrackingCotaskConstructorRemap : Antilatency.DeviceNetwork.Details.ICotaskConstructorRemap {
		public new struct VMT {
			public delegate Antilatency.InterfaceContract.ExceptionCode startTaskDelegate(System.IntPtr _this, System.IntPtr network, Antilatency.DeviceNetwork.NodeHandle node, System.IntPtr environment, out System.IntPtr result);
			#pragma warning disable 0649
			public startTaskDelegate startTask;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static ITrackingCotaskConstructorRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			Antilatency.DeviceNetwork.Details.ICotaskConstructorRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.startTask = (System.IntPtr _this, System.IntPtr network, Antilatency.DeviceNetwork.NodeHandle node, System.IntPtr environment, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as ITrackingCotaskConstructor;
					var networkMarshaler = network == System.IntPtr.Zero ? null : new Antilatency.DeviceNetwork.Details.INetworkWrapper(network);
					var environmentMarshaler = environment == System.IntPtr.Zero ? null : new Antilatency.Alt.Environment.Details.IEnvironmentWrapper(environment);
					var resultMarshaler = obj.startTask(networkMarshaler, node, environmentMarshaler);
					result = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.Alt.Tracking.ITrackingCotask>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public ITrackingCotaskConstructorRemap() { }
		public ITrackingCotaskConstructorRemap(System.IntPtr context, ushort lifetimeId) {
			AllocateNativeInterface(NativeVmt.Handle, context, lifetimeId);
		}
	}
}

[Guid("91b0a5be-a9c7-4d29-a03a-44fff8e91c68")]
public interface ITrackingDataCotask : Antilatency.DeviceNetwork.ICotask {
	Antilatency.Math.floatQ getOpticsToBodyRotation();
	void setExposure(uint exposure);
}
namespace Details {
	public class ITrackingDataCotaskWrapper : Antilatency.DeviceNetwork.Details.ICotaskWrapper, ITrackingDataCotask {
		private ITrackingDataCotaskRemap.VMT _VMT = new ITrackingDataCotaskRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(ITrackingDataCotaskRemap.VMT).GetFields().Length;
		}
		public ITrackingDataCotaskWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<ITrackingDataCotaskRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public Antilatency.Math.floatQ getOpticsToBodyRotation() {
			Antilatency.Math.floatQ result;
			Antilatency.Math.floatQ resultMarshaler;
			HandleExceptionCode(_VMT.getOpticsToBodyRotation(_object, out resultMarshaler));
			result = resultMarshaler;
			return result;
		}
		public void setExposure(uint exposure) {
			HandleExceptionCode(_VMT.setExposure(_object, exposure));
		}
	}
	public class ITrackingDataCotaskRemap : Antilatency.DeviceNetwork.Details.ICotaskRemap {
		public new struct VMT {
			public delegate Antilatency.InterfaceContract.ExceptionCode getOpticsToBodyRotationDelegate(System.IntPtr _this, out Antilatency.Math.floatQ result);
			public delegate Antilatency.InterfaceContract.ExceptionCode setExposureDelegate(System.IntPtr _this, uint exposure);
			#pragma warning disable 0649
			public getOpticsToBodyRotationDelegate getOpticsToBodyRotation;
			public setExposureDelegate setExposure;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static ITrackingDataCotaskRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			Antilatency.DeviceNetwork.Details.ICotaskRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.getOpticsToBodyRotation = (System.IntPtr _this, out Antilatency.Math.floatQ result) => {
				try {
					var obj = GetContext(_this) as ITrackingDataCotask;
					var resultMarshaler = obj.getOpticsToBodyRotation();
					result = resultMarshaler;
				}
				catch (System.Exception ex) {
					result = default(Antilatency.Math.floatQ);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.setExposure = (System.IntPtr _this, uint exposure) => {
				try {
					var obj = GetContext(_this) as ITrackingDataCotask;
					obj.setExposure(exposure);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public ITrackingDataCotaskRemap() { }
		public ITrackingDataCotaskRemap(System.IntPtr context, ushort lifetimeId) {
			AllocateNativeInterface(NativeVmt.Handle, context, lifetimeId);
		}
	}
}

[System.Serializable]
[System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
public partial struct OpticRay {
	public Antilatency.Math.float2 middleSpacePoint;
	public Antilatency.Math.float2x3 middleSpacePointDerivativeByLocalPosition;
	public Antilatency.Math.float3 direction;
	public float power;
}

[System.Serializable]
[System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
public partial struct InertialLeap {
	public float timeLeap;
	public Antilatency.Math.float3 positionLeap;
	public Antilatency.Math.float3 velocityLeap;
	public Antilatency.Math.floatQ rotationLeap;
	public Antilatency.Math.float3x3 positionLeapByAcceleration;
	public Antilatency.Math.float3x3 velocityLeapByAcceleration;
}

[Guid("8f2dab91-8ba5-40a3-ae73-e3f8ef1fb876")]
public interface ITrackingDataCallback : Antilatency.InterfaceContract.IInterface {
	void onTrackingFrame(Antilatency.Alt.Tracking.OpticRay[] rays, Antilatency.Math.float3 inertialUp, Antilatency.Alt.Tracking.InertialLeap inertialLeap, Antilatency.InterfaceContract.Bool accelerometerOverflowOccured, Antilatency.InterfaceContract.Bool gyroscopeOverflowOccured);
	void onIncompleteLeap(Antilatency.Alt.Tracking.InertialLeap leap);
	void onAdnFinalize();
}
namespace Details {
	public class ITrackingDataCallbackWrapper : Antilatency.InterfaceContract.Details.IInterfaceWrapper, ITrackingDataCallback {
		private ITrackingDataCallbackRemap.VMT _VMT = new ITrackingDataCallbackRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(ITrackingDataCallbackRemap.VMT).GetFields().Length;
		}
		public ITrackingDataCallbackWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<ITrackingDataCallbackRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public void onTrackingFrame(Antilatency.Alt.Tracking.OpticRay[] rays, Antilatency.Math.float3 inertialUp, Antilatency.Alt.Tracking.InertialLeap inertialLeap, Antilatency.InterfaceContract.Bool accelerometerOverflowOccured, Antilatency.InterfaceContract.Bool gyroscopeOverflowOccured) {
			var raysMarshaler = Antilatency.InterfaceContract.Details.ArrayInMarshaler.create(rays);
			HandleExceptionCode(_VMT.onTrackingFrame(_object, raysMarshaler, inertialUp, inertialLeap, accelerometerOverflowOccured, gyroscopeOverflowOccured));
			raysMarshaler.Dispose();
		}
		public void onIncompleteLeap(Antilatency.Alt.Tracking.InertialLeap leap) {
			HandleExceptionCode(_VMT.onIncompleteLeap(_object, leap));
		}
		public void onAdnFinalize() {
			HandleExceptionCode(_VMT.onAdnFinalize(_object));
		}
	}
	public class ITrackingDataCallbackRemap : Antilatency.InterfaceContract.Details.IInterfaceRemap {
		public new struct VMT {
			public delegate Antilatency.InterfaceContract.ExceptionCode onTrackingFrameDelegate(System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate rays, Antilatency.Math.float3 inertialUp, Antilatency.Alt.Tracking.InertialLeap inertialLeap, Antilatency.InterfaceContract.Bool accelerometerOverflowOccured, Antilatency.InterfaceContract.Bool gyroscopeOverflowOccured);
			public delegate Antilatency.InterfaceContract.ExceptionCode onIncompleteLeapDelegate(System.IntPtr _this, Antilatency.Alt.Tracking.InertialLeap leap);
			public delegate Antilatency.InterfaceContract.ExceptionCode onAdnFinalizeDelegate(System.IntPtr _this);
			#pragma warning disable 0649
			public onTrackingFrameDelegate onTrackingFrame;
			public onIncompleteLeapDelegate onIncompleteLeap;
			public onAdnFinalizeDelegate onAdnFinalize;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static ITrackingDataCallbackRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			Antilatency.InterfaceContract.Details.IInterfaceRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.onTrackingFrame = (System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate rays, Antilatency.Math.float3 inertialUp, Antilatency.Alt.Tracking.InertialLeap inertialLeap, Antilatency.InterfaceContract.Bool accelerometerOverflowOccured, Antilatency.InterfaceContract.Bool gyroscopeOverflowOccured) => {
				try {
					var obj = GetContext(_this) as ITrackingDataCallback;
					obj.onTrackingFrame(rays.toArray<Antilatency.Alt.Tracking.OpticRay>(), inertialUp, inertialLeap, accelerometerOverflowOccured, gyroscopeOverflowOccured);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.onIncompleteLeap = (System.IntPtr _this, Antilatency.Alt.Tracking.InertialLeap leap) => {
				try {
					var obj = GetContext(_this) as ITrackingDataCallback;
					obj.onIncompleteLeap(leap);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.onAdnFinalize = (System.IntPtr _this) => {
				try {
					var obj = GetContext(_this) as ITrackingDataCallback;
					obj.onAdnFinalize();
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public ITrackingDataCallbackRemap() { }
		public ITrackingDataCallbackRemap(System.IntPtr context, ushort lifetimeId) {
			AllocateNativeInterface(NativeVmt.Handle, context, lifetimeId);
		}
	}
}

[Guid("b3032673-093a-47c5-a049-31576dcbe894")]
public interface ITrackingDataCotaskConstructor : Antilatency.DeviceNetwork.ICotaskConstructor {
	Antilatency.Alt.Tracking.ITrackingDataCotask startTask(Antilatency.DeviceNetwork.INetwork network, Antilatency.DeviceNetwork.NodeHandle node, Antilatency.Alt.Tracking.ITrackingDataCallback callback);
}
namespace Details {
	public class ITrackingDataCotaskConstructorWrapper : Antilatency.DeviceNetwork.Details.ICotaskConstructorWrapper, ITrackingDataCotaskConstructor {
		private ITrackingDataCotaskConstructorRemap.VMT _VMT = new ITrackingDataCotaskConstructorRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(ITrackingDataCotaskConstructorRemap.VMT).GetFields().Length;
		}
		public ITrackingDataCotaskConstructorWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<ITrackingDataCotaskConstructorRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public Antilatency.Alt.Tracking.ITrackingDataCotask startTask(Antilatency.DeviceNetwork.INetwork network, Antilatency.DeviceNetwork.NodeHandle node, Antilatency.Alt.Tracking.ITrackingDataCallback callback) {
			Antilatency.Alt.Tracking.ITrackingDataCotask result;
			System.IntPtr resultMarshaler;
			var networkMarshaler = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.DeviceNetwork.INetwork>(network);
			var callbackMarshaler = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.Alt.Tracking.ITrackingDataCallback>(callback);
			HandleExceptionCode(_VMT.startTask(_object, networkMarshaler, node, callbackMarshaler, out resultMarshaler));
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new Antilatency.Alt.Tracking.Details.ITrackingDataCotaskWrapper(resultMarshaler);
			return result;
		}
	}
	public class ITrackingDataCotaskConstructorRemap : Antilatency.DeviceNetwork.Details.ICotaskConstructorRemap {
		public new struct VMT {
			public delegate Antilatency.InterfaceContract.ExceptionCode startTaskDelegate(System.IntPtr _this, System.IntPtr network, Antilatency.DeviceNetwork.NodeHandle node, System.IntPtr callback, out System.IntPtr result);
			#pragma warning disable 0649
			public startTaskDelegate startTask;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static ITrackingDataCotaskConstructorRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			Antilatency.DeviceNetwork.Details.ICotaskConstructorRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.startTask = (System.IntPtr _this, System.IntPtr network, Antilatency.DeviceNetwork.NodeHandle node, System.IntPtr callback, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as ITrackingDataCotaskConstructor;
					var networkMarshaler = network == System.IntPtr.Zero ? null : new Antilatency.DeviceNetwork.Details.INetworkWrapper(network);
					var callbackMarshaler = callback == System.IntPtr.Zero ? null : new Antilatency.Alt.Tracking.Details.ITrackingDataCallbackWrapper(callback);
					var resultMarshaler = obj.startTask(networkMarshaler, node, callbackMarshaler);
					result = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.Alt.Tracking.ITrackingDataCotask>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public ITrackingDataCotaskConstructorRemap() { }
		public ITrackingDataCotaskConstructorRemap(System.IntPtr context, ushort lifetimeId) {
			AllocateNativeInterface(NativeVmt.Handle, context, lifetimeId);
		}
	}
}

[Guid("ad4034ee-b77a-4e1f-a55a-c4b30a469a24")]
public interface ILibrary : Antilatency.InterfaceContract.IInterface {
	Antilatency.Math.floatP3Q createPlacement(string code);
	string encodePlacement(Antilatency.Math.float3 position, Antilatency.Math.float3 rotation);
	Antilatency.Alt.Tracking.ITrackingCotaskConstructor createTrackingCotaskConstructor();
	Antilatency.Alt.Tracking.ITrackingDataCotaskConstructor createTrackingDataCotaskConstructor();
}
public static class Library{
    [DllImport("AntilatencyAltTracking")]
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
		public Antilatency.Math.floatP3Q createPlacement(string code) {
			Antilatency.Math.floatP3Q result;
			Antilatency.Math.floatP3Q resultMarshaler;
			var codeMarshaler = Antilatency.InterfaceContract.Details.ArrayInMarshaler.create(code);
			HandleExceptionCode(_VMT.createPlacement(_object, codeMarshaler, out resultMarshaler));
			codeMarshaler.Dispose();
			result = resultMarshaler;
			return result;
		}
		public string encodePlacement(Antilatency.Math.float3 position, Antilatency.Math.float3 rotation) {
			string result;
			var resultMarshaler = Antilatency.InterfaceContract.Details.ArrayOutMarshaler.create();
			HandleExceptionCode(_VMT.encodePlacement(_object, position, rotation, resultMarshaler));
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public Antilatency.Alt.Tracking.ITrackingCotaskConstructor createTrackingCotaskConstructor() {
			Antilatency.Alt.Tracking.ITrackingCotaskConstructor result;
			System.IntPtr resultMarshaler;
			HandleExceptionCode(_VMT.createTrackingCotaskConstructor(_object, out resultMarshaler));
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new Antilatency.Alt.Tracking.Details.ITrackingCotaskConstructorWrapper(resultMarshaler);
			return result;
		}
		public Antilatency.Alt.Tracking.ITrackingDataCotaskConstructor createTrackingDataCotaskConstructor() {
			Antilatency.Alt.Tracking.ITrackingDataCotaskConstructor result;
			System.IntPtr resultMarshaler;
			HandleExceptionCode(_VMT.createTrackingDataCotaskConstructor(_object, out resultMarshaler));
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new Antilatency.Alt.Tracking.Details.ITrackingDataCotaskConstructorWrapper(resultMarshaler);
			return result;
		}
	}
	public class ILibraryRemap : Antilatency.InterfaceContract.Details.IInterfaceRemap {
		public new struct VMT {
			public delegate Antilatency.InterfaceContract.ExceptionCode createPlacementDelegate(System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate code, out Antilatency.Math.floatP3Q result);
			public delegate Antilatency.InterfaceContract.ExceptionCode encodePlacementDelegate(System.IntPtr _this, Antilatency.Math.float3 position, Antilatency.Math.float3 rotation, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate Antilatency.InterfaceContract.ExceptionCode createTrackingCotaskConstructorDelegate(System.IntPtr _this, out System.IntPtr result);
			public delegate Antilatency.InterfaceContract.ExceptionCode createTrackingDataCotaskConstructorDelegate(System.IntPtr _this, out System.IntPtr result);
			#pragma warning disable 0649
			public createPlacementDelegate createPlacement;
			public encodePlacementDelegate encodePlacement;
			public createTrackingCotaskConstructorDelegate createTrackingCotaskConstructor;
			public createTrackingDataCotaskConstructorDelegate createTrackingDataCotaskConstructor;
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
			vmt.createPlacement = (System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate code, out Antilatency.Math.floatP3Q result) => {
				try {
					var obj = GetContext(_this) as ILibrary;
					var resultMarshaler = obj.createPlacement(code);
					result = resultMarshaler;
				}
				catch (System.Exception ex) {
					result = default(Antilatency.Math.floatP3Q);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.encodePlacement = (System.IntPtr _this, Antilatency.Math.float3 position, Antilatency.Math.float3 rotation, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as ILibrary;
					var resultMarshaler = obj.encodePlacement(position, rotation);
					result.assign(resultMarshaler);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.createTrackingCotaskConstructor = (System.IntPtr _this, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as ILibrary;
					var resultMarshaler = obj.createTrackingCotaskConstructor();
					result = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.Alt.Tracking.ITrackingCotaskConstructor>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.createTrackingDataCotaskConstructor = (System.IntPtr _this, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as ILibrary;
					var resultMarshaler = obj.createTrackingDataCotaskConstructor();
					result = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.Alt.Tracking.ITrackingDataCotaskConstructor>(resultMarshaler);
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
	public static Antilatency.Math.float3 InitialPositionFor3Dof {
		get {
			byte[] data = new byte[]{0, 0, 0, 0, 61, 10, 215, 63, 0, 0, 0, 0};
			var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
			Antilatency.Math.float3 result = (Antilatency.Math.float3)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Antilatency.Math.float3));
			handle.Free();
			return result;
		}
	}
	public const float DefaultAngularVelocityAvgTime = 0.016f;
}


}
