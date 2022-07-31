using CuberiteClr.Sdk;
using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Entities;
using CuberiteClr.Sdk.Types;
using TestPlugin.Services;

namespace TestPlugin;

[ClrPlugin("dev-test-plugin", hasDatabase: true)]
[ExposeService(typeof(IRoleService), typeof(RoleService))]
public class DevTestPlugin : IClrPlugin
{
	private readonly IRoot _root;

	private readonly ILogger _logger;

	private readonly IRoleService _roleService;

	public DevTestPlugin(IRoot root, ILogger logger, IRoleService roleService)
	{
		_root = root;
		_logger = logger;
		_roleService = roleService;
	}

	public void Load()
	{
		_root.BindCommand("/hello", HelloCallback);
		_root.BindCommand("/time", TimeCallback);
		_root.BindCommand("/heal", HealCallback);
		_root.BindCommand("/switch", (command, split, player) =>
		{
			_roleService.SwitchAdmin(player);
			return true;
		});
	}

	private bool HealCallback(string command, string[] split, IPlayer player)
	{
		if (split.Length == 1)
			player.Heal(1000);
		else if (split.Length == 2)
			player.Heal(int.Parse(split[1]));
		return true;
	}

	private bool TimeCallback(string command, string[] split, IPlayer player)
	{
		player.GetWorld().SetTimeOfDay(int.Parse(split[1]));
		return true;
	}

	private bool HelloCallback(string command, string[] split, IPlayer player)
	{
		_root.BroadcastChat($"Hello, {player.GetName()}!");
		return true;
	}

	public bool OnChat(IPlayer player, string message)
	{
		if (message == "cactus pls")
		{
			var item = _root.CreateItem(BlockType.Cactus, 1);
			player.GetInventory().AddItem(item);
		}
		else if (message.Contains("thunder"))
		{
			_root.GetDefaultWorld().SetWeather(Weather.ThunderStorm);
		}
		else if (message.Contains("sunny"))
		{
			_root.GetDefaultWorld().SetWeather(Weather.Sunny);
		}

		return false;
	}

	public bool OnExecuteCommand(IPlayer player, string[] readStringArrayAuto, string readStringAuto)
	{
		//Root.BroadcastChat($"Command executed [{readStringArrayAuto.Length}]: {string.Join(',', readStringArrayAuto)}");
		return false;
	}
}
