using CuberiteClr.Sdk.Core;

namespace CuberiteClr.Sdk.Entities;

public interface IPickup : IEntity
{
	public bool IsPlayerCreated();

	public bool IsCollected();

	public bool CanCombine();

	public void SetCanCombine(bool canCombine);

	public bool CollectedBy(IEntity entity);

	public int GetAge();

	public void SetAge(int age);

	public int GetLifetime();

	public void SetLifetime(int lifetime);

	public IItem GetItem();
}
