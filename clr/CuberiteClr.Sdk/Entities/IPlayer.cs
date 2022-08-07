using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Sdk.Entities;

public interface IPlayer : IPawn
{
	public const int MaxHealth = 20;

	public const int MaxFoodLevel = 20;

	public IInventory GetInventory();

	public string GetName();

	public Guid GetUUID();

	public void SendMessage(string message);

	public void SendMessageInfo(string message);

	public void SendMessageFailure(string message);

	public void SendMessageSuccess(string message);

	public void SendMessageWarning(string message);

	public void SendMessageFatal(string message);

	public void SendPrivateMessage(string message, string sender);

	public void SendMessage(ICompositeChat message);

	public void SendMessageRaw(string message, ChatType type = ChatType.System);

	public void SendSystemMessage(string message);

	public void SendAboveActionBarMessage(string message);

	public void SendSystemMessage(ICompositeChat message);

	public void SendAboveActionBarMessage(ICompositeChat message);

	public void Feed(int food, double saturation);

	public void SetRespawnLocation(Vector3i position, IWorld world);

	public IItem GetEquippedItem();

	public void Freeze(Vector3d position);

	public bool IsFrozen();

	public void Unfreeze();

	public GameMode GetGameMode();

	public void SetGameMode(GameMode gameMode);

	public void SetVisible(bool visible);

	public IClientHandle GetClientHandle();

	public bool HasPermission(string permission);
}
