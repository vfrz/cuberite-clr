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
		_root.BindCommand("/worlds", WorldsCallback);
		_root.BindCommand("/players", PlayersCallback);
		_root.BindCommand("/pos", PositionCallback);
		_root.BindCommand("/spawn", SpawnCallback);
		_root.BindCommand("/switch", (command, split, player) =>
		{
			_roleService.SwitchAdmin(player);
			return true;
		});
	}

	private bool SpawnCallback(string command, string[] split, IPlayer player)
	{
		player.SetRespawnLocation(player.GetPosition().Round().ToVector3i(), player.GetWorld());
		return true;
	}

	private bool PositionCallback(string command, string[] split, IPlayer player)
	{
		player.SendMessage(player.GetPosition().ToString());
		return true;
	}

	private bool PlayersCallback(string command, string[] split, IPlayer player)
	{
		player.SendMessage("Player list:");
		_root.ForEachPlayer(p =>
		{
			player.SendMessage($"- {p.GetName()} [{p.GetUUID()}]");
			return false;
		});
		return true;
	}

	private bool WorldsCallback(string command, string[] split, IPlayer player)
	{
		_root.ForEachWorld(world =>
		{
			player.SendMessage(world.GetName());
			return false;
		});
		return true;
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
			var item = _root.CreateItem(BlockType.Cactus);
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

	public bool OnExecuteCommand(IPlayer player, string[] split, string entireCommand, ref CommandResult result)
	{
		if (entireCommand == "/nopermission")
		{
			result = CommandResult.NoPermission;
			return true;
		}

		if (entireCommand == "/error")
		{
			result = CommandResult.Error;
			return true;
		}

		//Root.BroadcastChat($"Command executed [{readStringArrayAuto.Length}]: {string.Join(',', readStringArrayAuto)}");
		return false;
	}

	public bool OnPlayerBrokenBlock(IPlayer player, Vector3i position, BlockFace face, BlockType type, byte meta)
	{
		_root.BroadcastChat($"Player '{player.GetName()}' has broken a block at: {position.ToString()}");
		return false;
	}
}
