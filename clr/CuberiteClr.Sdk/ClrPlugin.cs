using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Entities;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Sdk;

public abstract class ClrPlugin
{
	public IRoot Root { get; }

	public ILogger Logger { get; }

	public virtual int Priority { get; set; } = 0;

	public ClrPlugin(IRoot root, ILogger logger)
	{
		Root = root;
		Logger = logger;
	}

	public virtual bool PlayerBreakingBlock(IPlayer player, int x, int y, int z, BlockFace face, BlockType type, byte meta)
	{
		return false;
	}

	public virtual bool PlayerBrokenBlock(IPlayer player, int x, int y, int z, BlockFace face, BlockType type, byte meta)
	{
		return false;
	}

	public virtual bool Tick(float timeDelta)
	{
		return false;
	}

	public virtual bool WorldTick(IWorld world, float timeDelta)
	{
		return false;
	}
}