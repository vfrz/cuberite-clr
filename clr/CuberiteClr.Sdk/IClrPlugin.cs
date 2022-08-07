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

	public bool OnPlayerMoving(IPlayer playerPtr, Vector3d oldPosition, Vector3d newPosition, bool previousIsOnGround)
	{
		return false;
	}

	// World
	public bool OnWorldTick(IWorld world, float delta, float lastTickDuration)
	{
		return false;
	}

	public bool OnBlockSpread(IWorld world, Vector3i position, SpreadSource source)
	{
		return false;
	}

	public bool OnBlockToPickups(IWorld world, Vector3i position, BlockType blockType, byte blockMeta,
		IBlockEntity blockEntity, IEntity digger, IItem tool, IItem[] pickups)
	{
		return false;
	}

	public bool OnCollectingPickup(IPlayer player, IPickup pickup)
	{
		return false;
	}

	public bool OnPlayerJoined(IPlayer player)
	{
		return false;
	}

	public bool OnPlayerUsedBlock(IPlayer player, Vector3i blockPosition, BlockFace blockFace, Vector3i cursorPosition,
		BlockType blockType, byte blockMeta)
	{
		return false;
	}

	public bool OnPlayerUsedItem(IPlayer player, Vector3i blockPosition, BlockFace blockFace, Vector3i cursorPosition)
	{
		return false;
	}

	public bool OnPlayerUsingBlock(IPlayer player, Vector3i blockPosition, BlockFace blockFace, Vector3i cursorPosition,
		BlockType blockType, byte blockMeta)
	{
		return false;
	}

	public bool OnPlayerUsingItem(IPlayer player, Vector3i blockPosition, BlockFace blockFace, Vector3i cursorPosition)
	{
		return false;
	}

	public bool OnPlayerTossingItem(IPlayer player)
	{
		return false;
	}

	public bool OnKilled(IEntity victim, TakeDamageInfo takeDamageInfo, string deathMessage)
	{
		return false;
	}

	public bool OnKilling(IEntity victim, IEntity killer, TakeDamageInfo takeDamageInfo)
	{
		return false;
	}

	public bool OnPlayerPlacedBlock(IPlayer player, SetBlock blockChange)
	{
		return false;
	}

	public bool OnPlayerPlacingBlock(IPlayer player, SetBlock blockChange)
	{
		return false;
	}
}
