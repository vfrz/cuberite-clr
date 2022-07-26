using System;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Runtime.Core;

public unsafe class World : InteropReference, IWorld
{
	public World(IntPtr handle) : base(handle)
	{
	}

	public Weather GetWeather()
	{
		return WrapperFunctions.world_get_weather(Handle);
	}

	public void SetWeather(Weather weather)
	{
		WrapperFunctions.world_set_weather(Handle, weather);
	}
}
