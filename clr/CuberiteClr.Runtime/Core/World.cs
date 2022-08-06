using System;
using System.Runtime.InteropServices;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Runtime.Core;

public unsafe class World : InteropReference, IWorld
{
	private World(IntPtr handle) : base(handle)
	{
	}

	public static IWorld Create(IntPtr handle)
	{
		return handle.IsNullPtr() ? null : new World(handle);
	}

	public string GetName()
	{
		return WrapperFunctions.world_get_name(Handle).ToStringAuto();
	}

	public Weather GetWeather()
	{
		return WrapperFunctions.world_get_weather(Handle);
	}

	public void SetWeather(Weather weather)
	{
		WrapperFunctions.world_set_weather(Handle, weather);
	}

	public int GetTimeOfDay()
	{
		return WrapperFunctions.world_get_time_of_day(Handle);
	}

	public void SetTimeOfDay(int time)
	{
		WrapperFunctions.world_set_time_of_day(Handle, time);
	}

	public long GetWorldAge()
	{
		return WrapperFunctions.world_get_world_age(Handle);
	}

	public long GetWorldTickAge()
	{
		return WrapperFunctions.world_get_world_tick_age(Handle);
	}

	public long GetWorldDate()
	{
		return WrapperFunctions.world_get_world_date(Handle);
	}

	public bool ForEachPlayer(ForEachPlayerCallback callback)
	{
		var gcHandle = GCHandle.Alloc(callback, GCHandleType.Normal);
		var callbackPointer = GCHandle.ToIntPtr(gcHandle);
		return WrapperFunctions.world_for_each_player(Handle, callbackPointer);
	}
}
