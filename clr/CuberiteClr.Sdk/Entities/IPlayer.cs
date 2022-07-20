namespace CuberiteClr.Sdk.Entities;

public interface IPlayer
{
	public const int MaxHealth = 20;

	public const int MaxFoodLevel = 20;

	public float GetHealth();

	public void SetHealth(float health);

	public string GetName();

	public Guid GetUUID();
}
