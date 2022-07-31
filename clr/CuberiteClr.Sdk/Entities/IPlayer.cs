using CuberiteClr.Sdk.Core;

namespace CuberiteClr.Sdk.Entities;

public interface IPlayer : IPawn
{
	public const int MaxHealth = 20;

	public const int MaxFoodLevel = 20;

	public IInventory GetInventory();

	public string GetName();

	public Guid GetUUID();

	public void SendMessage(string message);

	public void Feed(int food, double saturation);

	public void SetRespawnLocation(int x, int y, int z, IWorld world);
}
