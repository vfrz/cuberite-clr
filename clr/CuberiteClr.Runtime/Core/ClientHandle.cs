using System;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;

namespace CuberiteClr.Runtime.Core;

public class ClientHandle : InteropReference, IClientHandle
{
	public ClientHandle(IntPtr handle) : base(handle)
	{
	}
}
