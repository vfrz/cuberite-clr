using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Entities;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Sdk;

public abstract class ClrPlugin
{
	public IRoot Root { get; }

	public ILogger Logger { get; }

	public ClrPlugin(IRoot root, ILogger logger)
	{
		Root = root;
		Logger = logger;
	}

	// Global
	public virtual void OnTick(float delta)
	{
	}

	public virtual bool OnChat(IPlayer player, string message)
	{
		return false;
	}

	// Player
	public virtual bool OnPlayerBreakingBlock(IPlayer player, int x, int y, int z, BlockFace face, BlockType type, byte meta)
	{
		return false;
	}

	public virtual bool OnPlayerBrokenBlock(IPlayer player, int x, int y, int z, BlockFace face, BlockType type, byte meta)
	{
		return false;
	}

	public virtual bool OnPlayerSpawned(IPlayer player)
	{
		return false;
	}

	// World
	public virtual bool OnWorldTick(IWorld world, float delta, float lastTickDuration)
	{
		return false;
	}
}
