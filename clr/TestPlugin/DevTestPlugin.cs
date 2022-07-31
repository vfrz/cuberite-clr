using CuberiteClr.Sdk;
using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Entities;
using CuberiteClr.Sdk.Types;

namespace TestPlugin;

[ClrPlugin("dev-test-plugin")]
public class DevTestPlugin : IClrPlugin
{
	public IRoot Root { get; }

	public ILogger Logger { get; }

	public DevTestPlugin(IRoot root, ILogger logger)
	{
		Root = root;
		Logger = logger;

	}

	public void Load()
	{
		Root.BindCommand("/hello", HelloCallback);
		Root.BindCommand("/time", TimeCallback);
		Root.BindCommand("/kill", KillCallback);
		Root.BindCommand("/heal", HealCallback);
	}

	private bool HealCallback(string command, string[] split, IPlayer player)
	{
		if (split.Length == 1)
			player.Heal(1000);
		else if (split.Length == 2)
			player.Heal(int.Parse(split[1]));
		return true;
	}

	private bool KillCallback(string command, string[] split, IPlayer player)
	{
		if (split.Length == 1)
			player.TakeDamage(DamageType.Admin, null, 1000, 1000, 0);
		return true;
	}

	private bool TimeCallback(string command, string[] split, IPlayer player)
	{
		player.GetWorld().SetTimeOfDay(int.Parse(split[1]));
		return true;
	}

	private bool HelloCallback(string command, string[] split, IPlayer player)
	{
		Root.BroadcastChat($"Hello, {player.GetName()}!");
		return true;
	}

	public bool OnChat(IPlayer player, string message)
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

	public bool OnExecuteCommand(IPlayer player, string[] readStringArrayAuto, string readStringAuto)
	{
		//Root.BroadcastChat($"Command executed [{readStringArrayAuto.Length}]: {string.Join(',', readStringArrayAuto)}");
		return false;
	}
}
