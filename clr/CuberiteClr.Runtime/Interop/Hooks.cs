using System;
using System.Runtime.InteropServices;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Runtime.Interop;

public static class Hooks
{
	private delegate bool OnChatMessageDelegate(IntPtr player, IntPtr message);
	private delegate bool OnPlayerBreakingBlockDelegate(IntPtr player, int x, int y, int z, BlockFace face, BlockType type, byte meta);
	private delegate bool OnPlayerBrokenBlockDelegate(IntPtr player, int x, int y, int z, BlockFace face, BlockType type, byte meta);

	internal static IntPtr[] GetHooksPointers()
	{
		return new[]
		{
			Marshal.GetFunctionPointerForDelegate<OnChatMessageDelegate>(CuberiteClrManager.OnChatMessage),
			Marshal.GetFunctionPointerForDelegate<OnPlayerBrokenBlockDelegate>(CuberiteClrManager.OnPlayerBrokenBlock),
			Marshal.GetFunctionPointerForDelegate<OnPlayerBreakingBlockDelegate>(CuberiteClrManager.OnPlayerBreakingBlock)
		};
	}
}
