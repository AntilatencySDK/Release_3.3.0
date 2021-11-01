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
namespace Antilatency.DeviceNetwork {

[System.Serializable]
[System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
public partial struct UsbVendorId {
	public static readonly UsbVendorId Antilatency = new UsbVendorId(){ value = 0x3237 };
	[System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
	public ushort value;
	public override string ToString() {
		switch (value) {
			case 0x3237: return "Antilatency";
		}
		return value.ToString();
	}
	public static implicit operator ushort(UsbVendorId value) { return value.value;}
	public static explicit operator UsbVendorId(ushort value) { return new UsbVendorId() { value = value }; }
}

[System.Serializable]
[System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
public partial struct UsbDeviceFilter {
	public Antilatency.DeviceNetwork.UsbVendorId vid;
	public ushort pid;
	public ushort pidMask;
}

[Guid("9e6bdb45-e7cb-4f46-a5ee-ce7353a734c9")]
public interface IDeviceFilter : Antilatency.InterfaceContract.IInterface {
	void addUsbDevice(Antilatency.DeviceNetwork.UsbDeviceFilter usbDeviceType);
	void addIpDevice(string ip, string mask);
	Antilatency.DeviceNetwork.UsbDeviceFilter getUsbDevice(uint index);
	string getIpDevice(uint index);
	string getIpDeviceMask(uint index);
}
namespace Details {
	public class IDeviceFilterWrapper : Antilatency.InterfaceContract.Details.IInterfaceWrapper, IDeviceFilter {
		private IDeviceFilterRemap.VMT _VMT = new IDeviceFilterRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(IDeviceFilterRemap.VMT).GetFields().Length;
		}
		public IDeviceFilterWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<IDeviceFilterRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public void addUsbDevice(Antilatency.DeviceNetwork.UsbDeviceFilter usbDeviceType) {
			HandleExceptionCode(_VMT.addUsbDevice(_object, usbDeviceType));
		}
		public void addIpDevice(string ip, string mask) {
			var ipMarshaler = Antilatency.InterfaceContract.Details.ArrayInMarshaler.create(ip);
			var maskMarshaler = Antilatency.InterfaceContract.Details.ArrayInMarshaler.create(mask);
			HandleExceptionCode(_VMT.addIpDevice(_object, ipMarshaler, maskMarshaler));
			ipMarshaler.Dispose();
			maskMarshaler.Dispose();
		}
		public Antilatency.DeviceNetwork.UsbDeviceFilter getUsbDevice(uint index) {
			Antilatency.DeviceNetwork.UsbDeviceFilter result;
			Antilatency.DeviceNetwork.UsbDeviceFilter resultMarshaler;
			HandleExceptionCode(_VMT.getUsbDevice(_object, index, out resultMarshaler));
			result = resultMarshaler;
			return result;
		}
		public string getIpDevice(uint index) {
			string result;
			var resultMarshaler = Antilatency.InterfaceContract.Details.ArrayOutMarshaler.create();
			HandleExceptionCode(_VMT.getIpDevice(_object, index, resultMarshaler));
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public string getIpDeviceMask(uint index) {
			string result;
			var resultMarshaler = Antilatency.InterfaceContract.Details.ArrayOutMarshaler.create();
			HandleExceptionCode(_VMT.getIpDeviceMask(_object, index, resultMarshaler));
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
	}
	public class IDeviceFilterRemap : Antilatency.InterfaceContract.Details.IInterfaceRemap {
		public new struct VMT {
			public delegate Antilatency.InterfaceContract.ExceptionCode addUsbDeviceDelegate(System.IntPtr _this, Antilatency.DeviceNetwork.UsbDeviceFilter usbDeviceType);
			public delegate Antilatency.InterfaceContract.ExceptionCode addIpDeviceDelegate(System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate ip, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate mask);
			public delegate Antilatency.InterfaceContract.ExceptionCode getUsbDeviceDelegate(System.IntPtr _this, uint index, out Antilatency.DeviceNetwork.UsbDeviceFilter result);
			public delegate Antilatency.InterfaceContract.ExceptionCode getIpDeviceDelegate(System.IntPtr _this, uint index, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate Antilatency.InterfaceContract.ExceptionCode getIpDeviceMaskDelegate(System.IntPtr _this, uint index, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			#pragma warning disable 0649
			public addUsbDeviceDelegate addUsbDevice;
			public addIpDeviceDelegate addIpDevice;
			public getUsbDeviceDelegate getUsbDevice;
			public getIpDeviceDelegate getIpDevice;
			public getIpDeviceMaskDelegate getIpDeviceMask;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static IDeviceFilterRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			Antilatency.InterfaceContract.Details.IInterfaceRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.addUsbDevice = (System.IntPtr _this, Antilatency.DeviceNetwork.UsbDeviceFilter usbDeviceType) => {
				try {
					var obj = GetContext(_this) as IDeviceFilter;
					obj.addUsbDevice(usbDeviceType);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.addIpDevice = (System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate ip, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate mask) => {
				try {
					var obj = GetContext(_this) as IDeviceFilter;
					obj.addIpDevice(ip, mask);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.getUsbDevice = (System.IntPtr _this, uint index, out Antilatency.DeviceNetwork.UsbDeviceFilter result) => {
				try {
					var obj = GetContext(_this) as IDeviceFilter;
					var resultMarshaler = obj.getUsbDevice(index);
					result = resultMarshaler;
				}
				catch (System.Exception ex) {
					result = default(Antilatency.DeviceNetwork.UsbDeviceFilter);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.getIpDevice = (System.IntPtr _this, uint index, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as IDeviceFilter;
					var resultMarshaler = obj.getIpDevice(index);
					result.assign(resultMarshaler);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.getIpDeviceMask = (System.IntPtr _this, uint index, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as IDeviceFilter;
					var resultMarshaler = obj.getIpDeviceMask(index);
					result.assign(resultMarshaler);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public IDeviceFilterRemap() { }
		public IDeviceFilterRemap(System.IntPtr context, ushort lifetimeId) {
			AllocateNativeInterface(NativeVmt.Handle, context, lifetimeId);
		}
	}
}

[System.Serializable]
[System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
public partial struct NodeHandle {
	public static readonly NodeHandle Null = new NodeHandle(){ value = 0x0 };
	[System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
	public uint value;
	public override string ToString() {
		switch (value) {
			case 0x0: return "Null";
		}
		return value.ToString();
	}
	public static implicit operator uint(NodeHandle value) { return value.value;}
	public static explicit operator NodeHandle(uint value) { return new NodeHandle() { value = value }; }
}

[System.Serializable]
[System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
public partial struct NodeStatus {
	public static readonly NodeStatus Idle = new NodeStatus(){ value = 0x0 };
	public static readonly NodeStatus TaskRunning = new NodeStatus(){ value = 0x1 };
	public static readonly NodeStatus Invalid = new NodeStatus(){ value = 0x2 };
	[System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
	public int value;
	public override string ToString() {
		switch (value) {
			case 0x0: return "Idle";
			case 0x1: return "TaskRunning";
			case 0x2: return "Invalid";
		}
		return value.ToString();
	}
	public static implicit operator int(NodeStatus value) { return value.value;}
	public static explicit operator NodeStatus(int value) { return new NodeStatus() { value = value }; }
}

[Guid("af7402e8-2a23-442b-8230-d41f55ef5dc0")]
public interface ISynchronousConnection : Antilatency.InterfaceContract.IInterface {
	Antilatency.DeviceNetwork.Interop.Packet[] getPackets();
	Antilatency.DeviceNetwork.Interop.Packet[] getAvailablePackets(out Antilatency.InterfaceContract.Bool taskFinished);
	Antilatency.InterfaceContract.Bool writePacket(Antilatency.DeviceNetwork.Interop.Packet packet);
}
namespace Details {
	public class ISynchronousConnectionWrapper : Antilatency.InterfaceContract.Details.IInterfaceWrapper, ISynchronousConnection {
		private ISynchronousConnectionRemap.VMT _VMT = new ISynchronousConnectionRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(ISynchronousConnectionRemap.VMT).GetFields().Length;
		}
		public ISynchronousConnectionWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<ISynchronousConnectionRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public Antilatency.DeviceNetwork.Interop.Packet[] getPackets() {
			Antilatency.DeviceNetwork.Interop.Packet[] result;
			var resultMarshaler = Antilatency.InterfaceContract.Details.ArrayOutMarshaler.create<Antilatency.DeviceNetwork.Interop.Packet>();
			HandleExceptionCode(_VMT.getPackets(_object, resultMarshaler));
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public Antilatency.DeviceNetwork.Interop.Packet[] getAvailablePackets(out Antilatency.InterfaceContract.Bool taskFinished) {
			Antilatency.DeviceNetwork.Interop.Packet[] result;
			var resultMarshaler = Antilatency.InterfaceContract.Details.ArrayOutMarshaler.create<Antilatency.DeviceNetwork.Interop.Packet>();
			Antilatency.InterfaceContract.Bool taskFinishedMarshaler;
			HandleExceptionCode(_VMT.getAvailablePackets(_object, out taskFinishedMarshaler, resultMarshaler));
			taskFinished = taskFinishedMarshaler;
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public Antilatency.InterfaceContract.Bool writePacket(Antilatency.DeviceNetwork.Interop.Packet packet) {
			Antilatency.InterfaceContract.Bool result;
			Antilatency.InterfaceContract.Bool resultMarshaler;
			HandleExceptionCode(_VMT.writePacket(_object, packet, out resultMarshaler));
			result = resultMarshaler;
			return result;
		}
	}
	public class ISynchronousConnectionRemap : Antilatency.InterfaceContract.Details.IInterfaceRemap {
		public new struct VMT {
			public delegate Antilatency.InterfaceContract.ExceptionCode getPacketsDelegate(System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate Antilatency.InterfaceContract.ExceptionCode getAvailablePacketsDelegate(System.IntPtr _this, out Antilatency.InterfaceContract.Bool taskFinished, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate Antilatency.InterfaceContract.ExceptionCode writePacketDelegate(System.IntPtr _this, Antilatency.DeviceNetwork.Interop.Packet packet, out Antilatency.InterfaceContract.Bool result);
			#pragma warning disable 0649
			public getPacketsDelegate getPackets;
			public getAvailablePacketsDelegate getAvailablePackets;
			public writePacketDelegate writePacket;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static ISynchronousConnectionRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			Antilatency.InterfaceContract.Details.IInterfaceRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.getPackets = (System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as ISynchronousConnection;
					var resultMarshaler = obj.getPackets();
					result.assign(resultMarshaler);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.getAvailablePackets = (System.IntPtr _this, out Antilatency.InterfaceContract.Bool taskFinished, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as ISynchronousConnection;
					Antilatency.InterfaceContract.Bool taskFinishedMarshaler;
					taskFinished = default(Antilatency.InterfaceContract.Bool);
					var resultMarshaler = obj.getAvailablePackets(out taskFinishedMarshaler);
					taskFinished = taskFinishedMarshaler;
					result.assign(resultMarshaler);
				}
				catch (System.Exception ex) {
					taskFinished = default(Antilatency.InterfaceContract.Bool);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.writePacket = (System.IntPtr _this, Antilatency.DeviceNetwork.Interop.Packet packet, out Antilatency.InterfaceContract.Bool result) => {
				try {
					var obj = GetContext(_this) as ISynchronousConnection;
					var resultMarshaler = obj.writePacket(packet);
					result = resultMarshaler;
				}
				catch (System.Exception ex) {
					result = default(Antilatency.InterfaceContract.Bool);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public ISynchronousConnectionRemap() { }
		public ISynchronousConnectionRemap(System.IntPtr context, ushort lifetimeId) {
			AllocateNativeInterface(NativeVmt.Handle, context, lifetimeId);
		}
	}
}

[Guid("fd95f649-562a-4819-a816-26b76cd9d8d6")]
public interface ICotask : Antilatency.InterfaceContract.IInterface {
	Antilatency.InterfaceContract.Bool isTaskFinished();
}
namespace Details {
	public class ICotaskWrapper : Antilatency.InterfaceContract.Details.IInterfaceWrapper, ICotask {
		private ICotaskRemap.VMT _VMT = new ICotaskRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(ICotaskRemap.VMT).GetFields().Length;
		}
		public ICotaskWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<ICotaskRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public Antilatency.InterfaceContract.Bool isTaskFinished() {
			Antilatency.InterfaceContract.Bool result;
			Antilatency.InterfaceContract.Bool resultMarshaler;
			HandleExceptionCode(_VMT.isTaskFinished(_object, out resultMarshaler));
			result = resultMarshaler;
			return result;
		}
	}
	public class ICotaskRemap : Antilatency.InterfaceContract.Details.IInterfaceRemap {
		public new struct VMT {
			public delegate Antilatency.InterfaceContract.ExceptionCode isTaskFinishedDelegate(System.IntPtr _this, out Antilatency.InterfaceContract.Bool result);
			#pragma warning disable 0649
			public isTaskFinishedDelegate isTaskFinished;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static ICotaskRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			Antilatency.InterfaceContract.Details.IInterfaceRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.isTaskFinished = (System.IntPtr _this, out Antilatency.InterfaceContract.Bool result) => {
				try {
					var obj = GetContext(_this) as ICotask;
					var resultMarshaler = obj.isTaskFinished();
					result = resultMarshaler;
				}
				catch (System.Exception ex) {
					result = default(Antilatency.InterfaceContract.Bool);
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

[Guid("81ea9312-f66e-4708-acd1-d40a3e6ef9aa")]
public interface IPropertyCotask : Antilatency.DeviceNetwork.ICotask {
	string getPropertyKey(uint index);
	string getStringProperty(string key);
	void setStringProperty(string key, string value);
	byte[] getBinaryProperty(string key);
	void setBinaryProperty(string key, byte[] value);
	void deleteProperty(string key);
}
namespace Details {
	public class IPropertyCotaskWrapper : Antilatency.DeviceNetwork.Details.ICotaskWrapper, IPropertyCotask {
		private IPropertyCotaskRemap.VMT _VMT = new IPropertyCotaskRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(IPropertyCotaskRemap.VMT).GetFields().Length;
		}
		public IPropertyCotaskWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<IPropertyCotaskRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public string getPropertyKey(uint index) {
			string result;
			var resultMarshaler = Antilatency.InterfaceContract.Details.ArrayOutMarshaler.create();
			HandleExceptionCode(_VMT.getPropertyKey(_object, index, resultMarshaler));
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public string getStringProperty(string key) {
			string result;
			var resultMarshaler = Antilatency.InterfaceContract.Details.ArrayOutMarshaler.create();
			var keyMarshaler = Antilatency.InterfaceContract.Details.ArrayInMarshaler.create(key);
			HandleExceptionCode(_VMT.getStringProperty(_object, keyMarshaler, resultMarshaler));
			keyMarshaler.Dispose();
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public void setStringProperty(string key, string value) {
			var keyMarshaler = Antilatency.InterfaceContract.Details.ArrayInMarshaler.create(key);
			var valueMarshaler = Antilatency.InterfaceContract.Details.ArrayInMarshaler.create(value);
			HandleExceptionCode(_VMT.setStringProperty(_object, keyMarshaler, valueMarshaler));
			keyMarshaler.Dispose();
			valueMarshaler.Dispose();
		}
		public byte[] getBinaryProperty(string key) {
			byte[] result;
			var resultMarshaler = Antilatency.InterfaceContract.Details.ArrayOutMarshaler.create<byte>();
			var keyMarshaler = Antilatency.InterfaceContract.Details.ArrayInMarshaler.create(key);
			HandleExceptionCode(_VMT.getBinaryProperty(_object, keyMarshaler, resultMarshaler));
			keyMarshaler.Dispose();
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public void setBinaryProperty(string key, byte[] value) {
			var keyMarshaler = Antilatency.InterfaceContract.Details.ArrayInMarshaler.create(key);
			var valueMarshaler = Antilatency.InterfaceContract.Details.ArrayInMarshaler.create(value);
			HandleExceptionCode(_VMT.setBinaryProperty(_object, keyMarshaler, valueMarshaler));
			keyMarshaler.Dispose();
			valueMarshaler.Dispose();
		}
		public void deleteProperty(string key) {
			var keyMarshaler = Antilatency.InterfaceContract.Details.ArrayInMarshaler.create(key);
			HandleExceptionCode(_VMT.deleteProperty(_object, keyMarshaler));
			keyMarshaler.Dispose();
		}
	}
	public class IPropertyCotaskRemap : Antilatency.DeviceNetwork.Details.ICotaskRemap {
		public new struct VMT {
			public delegate Antilatency.InterfaceContract.ExceptionCode getPropertyKeyDelegate(System.IntPtr _this, uint index, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate Antilatency.InterfaceContract.ExceptionCode getStringPropertyDelegate(System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate key, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate Antilatency.InterfaceContract.ExceptionCode setStringPropertyDelegate(System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate key, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate value);
			public delegate Antilatency.InterfaceContract.ExceptionCode getBinaryPropertyDelegate(System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate key, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate Antilatency.InterfaceContract.ExceptionCode setBinaryPropertyDelegate(System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate key, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate value);
			public delegate Antilatency.InterfaceContract.ExceptionCode deletePropertyDelegate(System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate key);
			#pragma warning disable 0649
			public getPropertyKeyDelegate getPropertyKey;
			public getStringPropertyDelegate getStringProperty;
			public setStringPropertyDelegate setStringProperty;
			public getBinaryPropertyDelegate getBinaryProperty;
			public setBinaryPropertyDelegate setBinaryProperty;
			public deletePropertyDelegate deleteProperty;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static IPropertyCotaskRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			Antilatency.DeviceNetwork.Details.ICotaskRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.getPropertyKey = (System.IntPtr _this, uint index, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as IPropertyCotask;
					var resultMarshaler = obj.getPropertyKey(index);
					result.assign(resultMarshaler);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.getStringProperty = (System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate key, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as IPropertyCotask;
					var resultMarshaler = obj.getStringProperty(key);
					result.assign(resultMarshaler);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.setStringProperty = (System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate key, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate value) => {
				try {
					var obj = GetContext(_this) as IPropertyCotask;
					obj.setStringProperty(key, value);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.getBinaryProperty = (System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate key, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as IPropertyCotask;
					var resultMarshaler = obj.getBinaryProperty(key);
					result.assign(resultMarshaler);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.setBinaryProperty = (System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate key, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate value) => {
				try {
					var obj = GetContext(_this) as IPropertyCotask;
					obj.setBinaryProperty(key, value.toArray<byte>());
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.deleteProperty = (System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate key) => {
				try {
					var obj = GetContext(_this) as IPropertyCotask;
					obj.deleteProperty(key);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public IPropertyCotaskRemap() { }
		public IPropertyCotaskRemap(System.IntPtr context, ushort lifetimeId) {
			AllocateNativeInterface(NativeVmt.Handle, context, lifetimeId);
		}
	}
}

[Guid("4cb2369c-7a66-4e85-9a0c-dbc89fc1c75e")]
public interface INetwork : Antilatency.InterfaceContract.IInterface {
	uint getUpdateId();
	Antilatency.DeviceNetwork.IDeviceFilter getDeviceFilter();
	Antilatency.DeviceNetwork.NodeHandle[] getNodes();
	Antilatency.DeviceNetwork.NodeStatus nodeGetStatus(Antilatency.DeviceNetwork.NodeHandle node);
	Antilatency.InterfaceContract.Bool nodeIsTaskSupported(Antilatency.DeviceNetwork.NodeHandle node, System.Guid taskId);
	Antilatency.DeviceNetwork.NodeHandle nodeGetParent(Antilatency.DeviceNetwork.NodeHandle node);
	string nodeGetPhysicalPath(Antilatency.DeviceNetwork.NodeHandle node);
	Antilatency.DeviceNetwork.Interop.IDataReceiver nodeStartTask(Antilatency.DeviceNetwork.NodeHandle node, System.Guid taskId, Antilatency.DeviceNetwork.Interop.IDataReceiver taskDataReceiver);
	Antilatency.DeviceNetwork.ISynchronousConnection nodeStartTask2(Antilatency.DeviceNetwork.NodeHandle node, System.Guid taskId);
	string nodeGetStringProperty(Antilatency.DeviceNetwork.NodeHandle node, string key);
	byte[] nodeGetBinaryProperty(Antilatency.DeviceNetwork.NodeHandle node, string key);
	Antilatency.DeviceNetwork.IPropertyCotask nodeStartPropertyTask(Antilatency.DeviceNetwork.NodeHandle node);
}
namespace Details {
	public class INetworkWrapper : Antilatency.InterfaceContract.Details.IInterfaceWrapper, INetwork {
		private INetworkRemap.VMT _VMT = new INetworkRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(INetworkRemap.VMT).GetFields().Length;
		}
		public INetworkWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<INetworkRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public uint getUpdateId() {
			uint result;
			uint resultMarshaler;
			HandleExceptionCode(_VMT.getUpdateId(_object, out resultMarshaler));
			result = resultMarshaler;
			return result;
		}
		public Antilatency.DeviceNetwork.IDeviceFilter getDeviceFilter() {
			Antilatency.DeviceNetwork.IDeviceFilter result;
			System.IntPtr resultMarshaler;
			HandleExceptionCode(_VMT.getDeviceFilter(_object, out resultMarshaler));
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new Antilatency.DeviceNetwork.Details.IDeviceFilterWrapper(resultMarshaler);
			return result;
		}
		public Antilatency.DeviceNetwork.NodeHandle[] getNodes() {
			Antilatency.DeviceNetwork.NodeHandle[] result;
			var resultMarshaler = Antilatency.InterfaceContract.Details.ArrayOutMarshaler.create<Antilatency.DeviceNetwork.NodeHandle>();
			HandleExceptionCode(_VMT.getNodes(_object, resultMarshaler));
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public Antilatency.DeviceNetwork.NodeStatus nodeGetStatus(Antilatency.DeviceNetwork.NodeHandle node) {
			Antilatency.DeviceNetwork.NodeStatus result;
			Antilatency.DeviceNetwork.NodeStatus resultMarshaler;
			HandleExceptionCode(_VMT.nodeGetStatus(_object, node, out resultMarshaler));
			result = resultMarshaler;
			return result;
		}
		public Antilatency.InterfaceContract.Bool nodeIsTaskSupported(Antilatency.DeviceNetwork.NodeHandle node, System.Guid taskId) {
			Antilatency.InterfaceContract.Bool result;
			Antilatency.InterfaceContract.Bool resultMarshaler;
			HandleExceptionCode(_VMT.nodeIsTaskSupported(_object, node, taskId, out resultMarshaler));
			result = resultMarshaler;
			return result;
		}
		public Antilatency.DeviceNetwork.NodeHandle nodeGetParent(Antilatency.DeviceNetwork.NodeHandle node) {
			Antilatency.DeviceNetwork.NodeHandle result;
			Antilatency.DeviceNetwork.NodeHandle resultMarshaler;
			HandleExceptionCode(_VMT.nodeGetParent(_object, node, out resultMarshaler));
			result = resultMarshaler;
			return result;
		}
		public string nodeGetPhysicalPath(Antilatency.DeviceNetwork.NodeHandle node) {
			string result;
			var resultMarshaler = Antilatency.InterfaceContract.Details.ArrayOutMarshaler.create();
			HandleExceptionCode(_VMT.nodeGetPhysicalPath(_object, node, resultMarshaler));
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public Antilatency.DeviceNetwork.Interop.IDataReceiver nodeStartTask(Antilatency.DeviceNetwork.NodeHandle node, System.Guid taskId, Antilatency.DeviceNetwork.Interop.IDataReceiver taskDataReceiver) {
			Antilatency.DeviceNetwork.Interop.IDataReceiver result;
			System.IntPtr resultMarshaler;
			var taskDataReceiverMarshaler = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.DeviceNetwork.Interop.IDataReceiver>(taskDataReceiver);
			HandleExceptionCode(_VMT.nodeStartTask(_object, node, taskId, taskDataReceiverMarshaler, out resultMarshaler));
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new Antilatency.DeviceNetwork.Interop.Details.IDataReceiverWrapper(resultMarshaler);
			return result;
		}
		public Antilatency.DeviceNetwork.ISynchronousConnection nodeStartTask2(Antilatency.DeviceNetwork.NodeHandle node, System.Guid taskId) {
			Antilatency.DeviceNetwork.ISynchronousConnection result;
			System.IntPtr resultMarshaler;
			HandleExceptionCode(_VMT.nodeStartTask2(_object, node, taskId, out resultMarshaler));
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new Antilatency.DeviceNetwork.Details.ISynchronousConnectionWrapper(resultMarshaler);
			return result;
		}
		public string nodeGetStringProperty(Antilatency.DeviceNetwork.NodeHandle node, string key) {
			string result;
			var resultMarshaler = Antilatency.InterfaceContract.Details.ArrayOutMarshaler.create();
			var keyMarshaler = Antilatency.InterfaceContract.Details.ArrayInMarshaler.create(key);
			HandleExceptionCode(_VMT.nodeGetStringProperty(_object, node, keyMarshaler, resultMarshaler));
			keyMarshaler.Dispose();
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public byte[] nodeGetBinaryProperty(Antilatency.DeviceNetwork.NodeHandle node, string key) {
			byte[] result;
			var resultMarshaler = Antilatency.InterfaceContract.Details.ArrayOutMarshaler.create<byte>();
			var keyMarshaler = Antilatency.InterfaceContract.Details.ArrayInMarshaler.create(key);
			HandleExceptionCode(_VMT.nodeGetBinaryProperty(_object, node, keyMarshaler, resultMarshaler));
			keyMarshaler.Dispose();
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public Antilatency.DeviceNetwork.IPropertyCotask nodeStartPropertyTask(Antilatency.DeviceNetwork.NodeHandle node) {
			Antilatency.DeviceNetwork.IPropertyCotask result;
			System.IntPtr resultMarshaler;
			HandleExceptionCode(_VMT.nodeStartPropertyTask(_object, node, out resultMarshaler));
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new Antilatency.DeviceNetwork.Details.IPropertyCotaskWrapper(resultMarshaler);
			return result;
		}
	}
	public class INetworkRemap : Antilatency.InterfaceContract.Details.IInterfaceRemap {
		public new struct VMT {
			public delegate Antilatency.InterfaceContract.ExceptionCode getUpdateIdDelegate(System.IntPtr _this, out uint result);
			public delegate Antilatency.InterfaceContract.ExceptionCode getDeviceFilterDelegate(System.IntPtr _this, out System.IntPtr result);
			public delegate Antilatency.InterfaceContract.ExceptionCode getNodesDelegate(System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate Antilatency.InterfaceContract.ExceptionCode nodeGetStatusDelegate(System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, out Antilatency.DeviceNetwork.NodeStatus result);
			public delegate Antilatency.InterfaceContract.ExceptionCode nodeIsTaskSupportedDelegate(System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, System.Guid taskId, out Antilatency.InterfaceContract.Bool result);
			public delegate Antilatency.InterfaceContract.ExceptionCode nodeGetParentDelegate(System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, out Antilatency.DeviceNetwork.NodeHandle result);
			public delegate Antilatency.InterfaceContract.ExceptionCode nodeGetPhysicalPathDelegate(System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate Antilatency.InterfaceContract.ExceptionCode nodeStartTaskDelegate(System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, System.Guid taskId, System.IntPtr taskDataReceiver, out System.IntPtr result);
			public delegate Antilatency.InterfaceContract.ExceptionCode nodeStartTask2Delegate(System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, System.Guid taskId, out System.IntPtr result);
			public delegate Antilatency.InterfaceContract.ExceptionCode nodeGetStringPropertyDelegate(System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate key, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate Antilatency.InterfaceContract.ExceptionCode nodeGetBinaryPropertyDelegate(System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate key, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate Antilatency.InterfaceContract.ExceptionCode nodeStartPropertyTaskDelegate(System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, out System.IntPtr result);
			#pragma warning disable 0649
			public getUpdateIdDelegate getUpdateId;
			public getDeviceFilterDelegate getDeviceFilter;
			public getNodesDelegate getNodes;
			public nodeGetStatusDelegate nodeGetStatus;
			public nodeIsTaskSupportedDelegate nodeIsTaskSupported;
			public nodeGetParentDelegate nodeGetParent;
			public nodeGetPhysicalPathDelegate nodeGetPhysicalPath;
			public nodeStartTaskDelegate nodeStartTask;
			public nodeStartTask2Delegate nodeStartTask2;
			public nodeGetStringPropertyDelegate nodeGetStringProperty;
			public nodeGetBinaryPropertyDelegate nodeGetBinaryProperty;
			public nodeStartPropertyTaskDelegate nodeStartPropertyTask;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static INetworkRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			Antilatency.InterfaceContract.Details.IInterfaceRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.getUpdateId = (System.IntPtr _this, out uint result) => {
				try {
					var obj = GetContext(_this) as INetwork;
					var resultMarshaler = obj.getUpdateId();
					result = resultMarshaler;
				}
				catch (System.Exception ex) {
					result = default(uint);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.getDeviceFilter = (System.IntPtr _this, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as INetwork;
					var resultMarshaler = obj.getDeviceFilter();
					result = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.DeviceNetwork.IDeviceFilter>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.getNodes = (System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as INetwork;
					var resultMarshaler = obj.getNodes();
					result.assign(resultMarshaler);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.nodeGetStatus = (System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, out Antilatency.DeviceNetwork.NodeStatus result) => {
				try {
					var obj = GetContext(_this) as INetwork;
					var resultMarshaler = obj.nodeGetStatus(node);
					result = resultMarshaler;
				}
				catch (System.Exception ex) {
					result = default(Antilatency.DeviceNetwork.NodeStatus);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.nodeIsTaskSupported = (System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, System.Guid taskId, out Antilatency.InterfaceContract.Bool result) => {
				try {
					var obj = GetContext(_this) as INetwork;
					var resultMarshaler = obj.nodeIsTaskSupported(node, taskId);
					result = resultMarshaler;
				}
				catch (System.Exception ex) {
					result = default(Antilatency.InterfaceContract.Bool);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.nodeGetParent = (System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, out Antilatency.DeviceNetwork.NodeHandle result) => {
				try {
					var obj = GetContext(_this) as INetwork;
					var resultMarshaler = obj.nodeGetParent(node);
					result = resultMarshaler;
				}
				catch (System.Exception ex) {
					result = default(Antilatency.DeviceNetwork.NodeHandle);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.nodeGetPhysicalPath = (System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as INetwork;
					var resultMarshaler = obj.nodeGetPhysicalPath(node);
					result.assign(resultMarshaler);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.nodeStartTask = (System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, System.Guid taskId, System.IntPtr taskDataReceiver, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as INetwork;
					var taskDataReceiverMarshaler = taskDataReceiver == System.IntPtr.Zero ? null : new Antilatency.DeviceNetwork.Interop.Details.IDataReceiverWrapper(taskDataReceiver);
					var resultMarshaler = obj.nodeStartTask(node, taskId, taskDataReceiverMarshaler);
					result = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.DeviceNetwork.Interop.IDataReceiver>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.nodeStartTask2 = (System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, System.Guid taskId, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as INetwork;
					var resultMarshaler = obj.nodeStartTask2(node, taskId);
					result = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.DeviceNetwork.ISynchronousConnection>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.nodeGetStringProperty = (System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate key, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as INetwork;
					var resultMarshaler = obj.nodeGetStringProperty(node, key);
					result.assign(resultMarshaler);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.nodeGetBinaryProperty = (System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, Antilatency.InterfaceContract.Details.ArrayInMarshaler.Intermediate key, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as INetwork;
					var resultMarshaler = obj.nodeGetBinaryProperty(node, key);
					result.assign(resultMarshaler);
				}
				catch (System.Exception ex) {
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.nodeStartPropertyTask = (System.IntPtr _this, Antilatency.DeviceNetwork.NodeHandle node, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as INetwork;
					var resultMarshaler = obj.nodeStartPropertyTask(node);
					result = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.DeviceNetwork.IPropertyCotask>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			buffer.Add(vmt);
		}
		public INetworkRemap() { }
		public INetworkRemap(System.IntPtr context, ushort lifetimeId) {
			AllocateNativeInterface(NativeVmt.Handle, context, lifetimeId);
		}
	}
}

[Guid("9ecfa909-d13c-4c29-a87e-8925b7846638")]
public interface ICotaskConstructor : Antilatency.InterfaceContract.IInterface {
	Antilatency.InterfaceContract.Bool isSupported(Antilatency.DeviceNetwork.INetwork network, Antilatency.DeviceNetwork.NodeHandle node);
	Antilatency.DeviceNetwork.NodeHandle[] findSupportedNodes(Antilatency.DeviceNetwork.INetwork network);
}
namespace Details {
	public class ICotaskConstructorWrapper : Antilatency.InterfaceContract.Details.IInterfaceWrapper, ICotaskConstructor {
		private ICotaskConstructorRemap.VMT _VMT = new ICotaskConstructorRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(ICotaskConstructorRemap.VMT).GetFields().Length;
		}
		public ICotaskConstructorWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<ICotaskConstructorRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public Antilatency.InterfaceContract.Bool isSupported(Antilatency.DeviceNetwork.INetwork network, Antilatency.DeviceNetwork.NodeHandle node) {
			Antilatency.InterfaceContract.Bool result;
			Antilatency.InterfaceContract.Bool resultMarshaler;
			var networkMarshaler = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.DeviceNetwork.INetwork>(network);
			HandleExceptionCode(_VMT.isSupported(_object, networkMarshaler, node, out resultMarshaler));
			result = resultMarshaler;
			return result;
		}
		public Antilatency.DeviceNetwork.NodeHandle[] findSupportedNodes(Antilatency.DeviceNetwork.INetwork network) {
			Antilatency.DeviceNetwork.NodeHandle[] result;
			var resultMarshaler = Antilatency.InterfaceContract.Details.ArrayOutMarshaler.create<Antilatency.DeviceNetwork.NodeHandle>();
			var networkMarshaler = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.DeviceNetwork.INetwork>(network);
			HandleExceptionCode(_VMT.findSupportedNodes(_object, networkMarshaler, resultMarshaler));
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
	}
	public class ICotaskConstructorRemap : Antilatency.InterfaceContract.Details.IInterfaceRemap {
		public new struct VMT {
			public delegate Antilatency.InterfaceContract.ExceptionCode isSupportedDelegate(System.IntPtr _this, System.IntPtr network, Antilatency.DeviceNetwork.NodeHandle node, out Antilatency.InterfaceContract.Bool result);
			public delegate Antilatency.InterfaceContract.ExceptionCode findSupportedNodesDelegate(System.IntPtr _this, System.IntPtr network, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			#pragma warning disable 0649
			public isSupportedDelegate isSupported;
			public findSupportedNodesDelegate findSupportedNodes;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static ICotaskConstructorRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			Antilatency.InterfaceContract.Details.IInterfaceRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.isSupported = (System.IntPtr _this, System.IntPtr network, Antilatency.DeviceNetwork.NodeHandle node, out Antilatency.InterfaceContract.Bool result) => {
				try {
					var obj = GetContext(_this) as ICotaskConstructor;
					var networkMarshaler = network == System.IntPtr.Zero ? null : new Antilatency.DeviceNetwork.Details.INetworkWrapper(network);
					var resultMarshaler = obj.isSupported(networkMarshaler, node);
					result = resultMarshaler;
				}
				catch (System.Exception ex) {
					result = default(Antilatency.InterfaceContract.Bool);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.findSupportedNodes = (System.IntPtr _this, System.IntPtr network, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result) => {
				try {
					var obj = GetContext(_this) as ICotaskConstructor;
					var networkMarshaler = network == System.IntPtr.Zero ? null : new Antilatency.DeviceNetwork.Details.INetworkWrapper(network);
					var resultMarshaler = obj.findSupportedNodes(networkMarshaler);
					result.assign(resultMarshaler);
				}
				catch (System.Exception ex) {
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

[Guid("1f3f7579-813e-4528-82f9-5a5fc35a9295")]
public interface ICotaskBatteryPowered : Antilatency.DeviceNetwork.ICotask {
	float getBatteryLevel();
}
namespace Details {
	public class ICotaskBatteryPoweredWrapper : Antilatency.DeviceNetwork.Details.ICotaskWrapper, ICotaskBatteryPowered {
		private ICotaskBatteryPoweredRemap.VMT _VMT = new ICotaskBatteryPoweredRemap.VMT();
		protected new int GetTotalNativeMethodsCount() {
		    return base.GetTotalNativeMethodsCount() + typeof(ICotaskBatteryPoweredRemap.VMT).GetFields().Length;
		}
		public ICotaskBatteryPoweredWrapper(System.IntPtr obj) : base(obj) {
		    _VMT = LoadVMT<ICotaskBatteryPoweredRemap.VMT>(base.GetTotalNativeMethodsCount());
		}
		public float getBatteryLevel() {
			float result;
			float resultMarshaler;
			HandleExceptionCode(_VMT.getBatteryLevel(_object, out resultMarshaler));
			result = resultMarshaler;
			return result;
		}
	}
	public class ICotaskBatteryPoweredRemap : Antilatency.DeviceNetwork.Details.ICotaskRemap {
		public new struct VMT {
			public delegate Antilatency.InterfaceContract.ExceptionCode getBatteryLevelDelegate(System.IntPtr _this, out float result);
			#pragma warning disable 0649
			public getBatteryLevelDelegate getBatteryLevel;
			#pragma warning restore 0649
		}
		public new static readonly NativeInterfaceVmt NativeVmt;
		static ICotaskBatteryPoweredRemap() {
			var vmtBlocks = new System.Collections.Generic.List<object>();
			AppendVmt(vmtBlocks);
			NativeVmt = new NativeInterfaceVmt(vmtBlocks);
		}
		protected static new void AppendVmt(System.Collections.Generic.List<object> buffer) {
			Antilatency.DeviceNetwork.Details.ICotaskRemap.AppendVmt(buffer);
			var vmt = new VMT();
			vmt.getBatteryLevel = (System.IntPtr _this, out float result) => {
				try {
					var obj = GetContext(_this) as ICotaskBatteryPowered;
					var resultMarshaler = obj.getBatteryLevel();
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
		public ICotaskBatteryPoweredRemap() { }
		public ICotaskBatteryPoweredRemap(System.IntPtr context, ushort lifetimeId) {
			AllocateNativeInterface(NativeVmt.Handle, context, lifetimeId);
		}
	}
}

[System.Serializable]
[System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
public partial struct LogLevel {
	public static readonly LogLevel Trace = new LogLevel(){ value = 0x0 };
	public static readonly LogLevel Debug = new LogLevel(){ value = 0x1 };
	public static readonly LogLevel Info = new LogLevel(){ value = 0x2 };
	public static readonly LogLevel Warning = new LogLevel(){ value = 0x3 };
	public static readonly LogLevel Error = new LogLevel(){ value = 0x4 };
	public static readonly LogLevel Critical = new LogLevel(){ value = 0x5 };
	public static readonly LogLevel Off = new LogLevel(){ value = 0x6 };
	[System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.Never)]
	public int value;
	public override string ToString() {
		switch (value) {
			case 0x0: return "Trace";
			case 0x1: return "Debug";
			case 0x2: return "Info";
			case 0x3: return "Warning";
			case 0x4: return "Error";
			case 0x5: return "Critical";
			case 0x6: return "Off";
		}
		return value.ToString();
	}
	public static implicit operator int(LogLevel value) { return value.value;}
	public static explicit operator LogLevel(int value) { return new LogLevel() { value = value }; }
}

[Guid("a5b7a3b0-da59-4726-9ba2-36d771dcde8a")]
public interface ILibrary : Antilatency.InterfaceContract.IInterface {
	Antilatency.DeviceNetwork.IDeviceFilter createFilter();
	Antilatency.DeviceNetwork.INetwork createNetwork(Antilatency.DeviceNetwork.IDeviceFilter deviceFilter);
	string getVersion();
	void setLogLevel(Antilatency.DeviceNetwork.LogLevel level);
}
public static class Library{
    [DllImport("AntilatencyDeviceNetwork")]
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
		public Antilatency.DeviceNetwork.IDeviceFilter createFilter() {
			Antilatency.DeviceNetwork.IDeviceFilter result;
			System.IntPtr resultMarshaler;
			HandleExceptionCode(_VMT.createFilter(_object, out resultMarshaler));
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new Antilatency.DeviceNetwork.Details.IDeviceFilterWrapper(resultMarshaler);
			return result;
		}
		public Antilatency.DeviceNetwork.INetwork createNetwork(Antilatency.DeviceNetwork.IDeviceFilter deviceFilter) {
			Antilatency.DeviceNetwork.INetwork result;
			System.IntPtr resultMarshaler;
			var deviceFilterMarshaler = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.DeviceNetwork.IDeviceFilter>(deviceFilter);
			HandleExceptionCode(_VMT.createNetwork(_object, deviceFilterMarshaler, out resultMarshaler));
			result = (resultMarshaler==System.IntPtr.Zero) ? null : new Antilatency.DeviceNetwork.Details.INetworkWrapper(resultMarshaler);
			return result;
		}
		public string getVersion() {
			string result;
			var resultMarshaler = Antilatency.InterfaceContract.Details.ArrayOutMarshaler.create();
			HandleExceptionCode(_VMT.getVersion(_object, resultMarshaler));
			result = resultMarshaler.value;
			resultMarshaler.Dispose();
			return result;
		}
		public void setLogLevel(Antilatency.DeviceNetwork.LogLevel level) {
			HandleExceptionCode(_VMT.setLogLevel(_object, level));
		}
	}
	public class ILibraryRemap : Antilatency.InterfaceContract.Details.IInterfaceRemap {
		public new struct VMT {
			public delegate Antilatency.InterfaceContract.ExceptionCode createFilterDelegate(System.IntPtr _this, out System.IntPtr result);
			public delegate Antilatency.InterfaceContract.ExceptionCode createNetworkDelegate(System.IntPtr _this, System.IntPtr deviceFilter, out System.IntPtr result);
			public delegate Antilatency.InterfaceContract.ExceptionCode getVersionDelegate(System.IntPtr _this, Antilatency.InterfaceContract.Details.ArrayOutMarshaler.Intermediate result);
			public delegate Antilatency.InterfaceContract.ExceptionCode setLogLevelDelegate(System.IntPtr _this, Antilatency.DeviceNetwork.LogLevel level);
			#pragma warning disable 0649
			public createFilterDelegate createFilter;
			public createNetworkDelegate createNetwork;
			public getVersionDelegate getVersion;
			public setLogLevelDelegate setLogLevel;
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
			vmt.createFilter = (System.IntPtr _this, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as ILibrary;
					var resultMarshaler = obj.createFilter();
					result = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.DeviceNetwork.IDeviceFilter>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
			vmt.createNetwork = (System.IntPtr _this, System.IntPtr deviceFilter, out System.IntPtr result) => {
				try {
					var obj = GetContext(_this) as ILibrary;
					var deviceFilterMarshaler = deviceFilter == System.IntPtr.Zero ? null : new Antilatency.DeviceNetwork.Details.IDeviceFilterWrapper(deviceFilter);
					var resultMarshaler = obj.createNetwork(deviceFilterMarshaler);
					result = Antilatency.InterfaceContract.Details.InterfaceMarshaler.ManagedToNative<Antilatency.DeviceNetwork.INetwork>(resultMarshaler);
				}
				catch (System.Exception ex) {
					result = default(System.IntPtr);
					return handleRemapException(ex, _this);
				}
				return Antilatency.InterfaceContract.ExceptionCode.Ok;
			};
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
			vmt.setLogLevel = (System.IntPtr _this, Antilatency.DeviceNetwork.LogLevel level) => {
				try {
					var obj = GetContext(_this) as ILibrary;
					obj.setLogLevel(level);
				}
				catch (System.Exception ex) {
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
	public static Antilatency.DeviceNetwork.UsbDeviceFilter AllUsbDevices {
		get {
			byte[] data = new byte[]{55, 50, 0, 0, 0, 240};
			var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
			Antilatency.DeviceNetwork.UsbDeviceFilter result = (Antilatency.DeviceNetwork.UsbDeviceFilter)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Antilatency.DeviceNetwork.UsbDeviceFilter));
			handle.Free();
			return result;
		}
	}
	public const string AllIpDevicesIp = "0.0.0.0";
	public const string AllIpDevicesMask = "0.0.0.0";
	public const ushort UsbAllDeviceMask = 61440;
	public const ushort UsbOneDeviceMask = 65535;
}


}
