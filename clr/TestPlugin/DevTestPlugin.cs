using CuberiteClr.Sdk;
using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Entities;

namespace TestPlugin;

public class DevTestPlugin : ClrPlugin
{
	public DevTestPlugin(IRoot root) : base(root)
	{
	}

	public override bool PlayerBreakingBlock(IPlayer player, int x, int y, int z, BlockFace face, BlockType type, byte meta)
	{
		Root.BroadcastChat($"Player '{player.GetUUID()}' is breaking a block ({type}) at position: {x}:{y}:{z}");
		return false;
	}
}
