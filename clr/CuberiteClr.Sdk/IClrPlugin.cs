using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Entities;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Sdk;

public interface IClrPlugin
{
	public void Load();

	// Root
	public void OnTick(float delta)
	{
	}

	public bool OnChat(IPlayer player, string message)
	{
		return false;
	}

	public bool OnExecuteCommand(IPlayer player, string[] split, string entireCommand, ref CommandResult result)
	{
		return false;
	}

	public bool OnLogin(IClientHandle client, uint protocolVersion, string username)
	{
		return false;
	}

	public bool OnDisconnect(IClientHandle client, string reason)
	{
		return false;
	}

	// Player
	public bool OnPlayerBreakingBlock(IPlayer player, Vector3i position, BlockFace face, BlockType type, byte meta)
	{
		return false;
	}

	public bool OnPlayerBrokenBlock(IPlayer player, Vector3i position, BlockFace face, BlockType type, byte meta)
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
