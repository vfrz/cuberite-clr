using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Sdk.Entities;

public interface IEntity
{
	public float GetHealth();

	public void SetHealth(float health);

	public IWorld GetWorld();

	public void TakeDamage(IEntity attacker);

	public void TakeDamage(DamageType type, IEntity attacker, int rawDamage, double knockbackAmount);

	public void TakeDamage(DamageType type, int attackerId, int rawDamage, double knockbackAmount);

	public void TakeDamage(DamageType type, IEntity attacker, int rawDamage, float finalDamage, double knockbackAmount);

	public void Heal(int hitPoints);

	public EntityType GetEntityType();
}
