using CuberiteClr.Sdk;
using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Entities;
using CuberiteClr.Sdk.Types;

namespace TestPlugin;

[ClrPlugin("dev-test-plugin")]
public class DevTestPlugin : ClrPlugin
{
	public DevTestPlugin(IRoot root, ILogger logger) : base(root, logger)
	{
	}

	public override bool OnChatMessage(IPlayer player, string message)
	{
		if (message == "cactus pls")
		{
			var item = Root.CreateItem(BlockType.Cactus, 1);
			player.GetInventory().AddItem(item);
		}
		else if (message.Contains("thunder"))
		{
			Root.GetDefaultWorld().SetWeather(Weather.ThunderStorm);
		}
		else if (message.Contains("sunny"))
		{
			Root.GetDefaultWorld().SetWeather(Weather.Sunny);
		}
		return false;
	}

	public override bool OnPlayerBreakingBlock(IPlayer player, int x, int y, int z, BlockFace face, BlockType type, byte meta)
	{
		//Root.BroadcastChat($"Player '{player.GetUUID()}' is breaking a block ({type}) at position: {x}:{y}:{z}");
		return false;
	}
}
