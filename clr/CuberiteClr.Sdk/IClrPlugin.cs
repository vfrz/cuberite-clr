using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Entities;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Sdk;

public interface IClrPlugin
{
	// Root
	public void OnTick(float delta)
	{
	}

	public bool OnChat(IPlayer player, string message)
	{
		return false;
	}

	public bool OnExecuteCommand(IPlayer player, string[] readStringArrayAuto, string readStringAuto)
	{
		return false;
	}

	// Player
	public bool OnPlayerBreakingBlock(IPlayer player, int x, int y, int z, BlockFace face, BlockType type, byte meta)
	{
		return false;
	}

	public bool OnPlayerBrokenBlock(IPlayer player, int x, int y, int z, BlockFace face, BlockType type, byte meta)
	{
		return false;
	}

	public bool OnPlayerSpawned(IPlayer player)
	{
		return false;
	}

	// World
	public bool OnWorldTick(IWorld world, float delta, float lastTickDuration)
	{
		return false;
	}
}
