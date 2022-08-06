namespace CuberiteClr.Sdk.Entities;

public interface IPickup : IEntity
{
	public bool IsPlayerCreated();

	public bool IsCollected();
}
