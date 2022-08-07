using System;
using System.Runtime.InteropServices;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Entities;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Runtime.Core;

public unsafe class World : InteropReference, IWorld
{
	private World(IntPtr handle, bool createdFromManaged) : base(handle, createdFromManaged)
	{
	}

	public static IWorld Create(IntPtr handle, bool fromManaged = false)
	{
		return handle.IsNullPtr() ? null : new World(handle, fromManaged);
	}

	public string GetName()
	{
		return WrapperFunctions.world_get_name(Handle).ToStringAnsi();
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

	public GameMode GetGameMode()
	{
		return WrapperFunctions.world_get_game_mode(Handle);
	}

	public bool AreCommandBlocksEnabled()
	{
		return WrapperFunctions.world_are_command_blocks_enabled(Handle);
	}

	public void SetCommandBlocksEnabled(bool enabled)
	{
		WrapperFunctions.world_set_command_blocks_enabled(Handle, enabled);
	}

	public BlockType GetBlock(Vector3i position)
	{
		return WrapperFunctions.world_get_block(Handle, position);
	}

	public void SetBlock(Vector3i position, BlockType blockType, byte meta)
	{
		WrapperFunctions.world_set_block(Handle, position, blockType, meta);
	}

	public void BroadcastChat(string message, IClientHandle exclude = null, MessageType messageType = MessageType.Custom)
	{
		WrapperFunctions.world_broadcast_chat(Handle, message, exclude.GetOptionalInteropHandle(), messageType);
	}

	public void DigBlock(Vector3i position, IEntity digger = null)
	{
		WrapperFunctions.world_dig_block(Handle, position, digger.GetOptionalInteropHandle());
	}

	public void DoExplosionAt(double size, Vector3d position, bool canCauseFire, ExplosionSource source, object sourceData)
	{
		var sourceDataPtr = IntPtr.Zero;
		if (sourceData is InteropReference)
			sourceDataPtr = sourceData.GetInteropHandle();
		// TODO Handle more cases here
		WrapperFunctions.world_do_explosion_at(Handle, size, position, canCauseFire, source, sourceDataPtr);
	}

	public void CastThunderbolt(Vector3i block)
	{
		WrapperFunctions.world_cast_thunderbolt(Handle, block);
	}
}
