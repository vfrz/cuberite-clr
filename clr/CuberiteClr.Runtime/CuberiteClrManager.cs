using System;
using System.Runtime.InteropServices;
using CuberiteClr.Runtime.Core;
using CuberiteClr.Runtime.Entities;
using CuberiteClr.Sdk.Core;

namespace CuberiteClr.Runtime;

public unsafe class CuberiteClrManager
{
	private static IntPtr[] _clrFunctions;

	public static IntPtr* WrappersFunctionsPtr { get; private set; }

	public delegate bool OnPlayerBrokenBlockDelegate(IntPtr playerPtr, int x, int y, int z, BlockFace face, BlockType type);

	public static bool OnPlayerBrokenBlock(IntPtr playerPtr, int x, int y, int z, BlockFace face, BlockType type)
	{
		var player = new Player(playerPtr);
		new Root().RootBroadcastChat($"Player '{player.GetName()}' has broken a block ({type}) at position: {x}:{y}:{z}");
		return false;
	}

	public delegate bool OnPlayerBreakingBlockDelegate(IntPtr playerPtr, int x, int y, int z, BlockFace face, BlockType type);

	public static bool OnPlayerBreakingBlock(IntPtr playerPtr, int x, int y, int z, BlockFace face, BlockType type)
	{
		var player = new Player(playerPtr);
		new Root().RootBroadcastChat($"Player '{player.GetName()}' is breaking a block ({type}) at position: {x}:{y}:{z}");
		return false;
	}

	public delegate void* InitializeDelegate(IntPtr* functions);

	public static void* Initialize(IntPtr* wrappersFunctionsPtr)
	{
		WrappersFunctionsPtr = wrappersFunctionsPtr;

		_clrFunctions = new[]
		{
			Marshal.GetFunctionPointerForDelegate<OnPlayerBrokenBlockDelegate>(OnPlayerBrokenBlock),
			Marshal.GetFunctionPointerForDelegate<OnPlayerBreakingBlockDelegate>(OnPlayerBreakingBlock)
		};

		fixed (void* a = &_clrFunctions[0])
		{
			return a;
		}
	}
}
