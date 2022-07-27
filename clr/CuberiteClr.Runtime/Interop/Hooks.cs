// This file is auto-generated, please do not modify manually
using System;
using System.Runtime.InteropServices;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Runtime.Interop;

public static class Hooks
{
	private delegate void OnTickDelegate(float delta);
	private delegate bool OnChatDelegate(IntPtr player,IntPtr message);
	private delegate bool OnPlayerBreakingBlockDelegate(IntPtr player,int x,int y,int z,BlockFace face,BlockType type,byte meta);
	private delegate bool OnPlayerBrokenBlockDelegate(IntPtr player,int x,int y,int z,BlockFace face,BlockType type,byte meta);
	private delegate bool OnPlayerSpawnedDelegate(IntPtr player);
	private delegate bool OnWorldTickDelegate(IntPtr world,float delta,float lastTickDuration);


	internal static IntPtr[] GetHooksPointers()
	{
		return new[]
		{
			Marshal.GetFunctionPointerForDelegate<OnTickDelegate>(CuberiteClrManager.OnTick),
			Marshal.GetFunctionPointerForDelegate<OnChatDelegate>(CuberiteClrManager.OnChat),
			Marshal.GetFunctionPointerForDelegate<OnPlayerBreakingBlockDelegate>(CuberiteClrManager.OnPlayerBreakingBlock),
			Marshal.GetFunctionPointerForDelegate<OnPlayerBrokenBlockDelegate>(CuberiteClrManager.OnPlayerBrokenBlock),
			Marshal.GetFunctionPointerForDelegate<OnPlayerSpawnedDelegate>(CuberiteClrManager.OnPlayerSpawned),
			Marshal.GetFunctionPointerForDelegate<OnWorldTickDelegate>(CuberiteClrManager.OnWorldTick),

		};
	}
}
