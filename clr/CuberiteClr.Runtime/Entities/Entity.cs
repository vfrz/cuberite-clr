using System;
using CuberiteClr.Runtime.Core;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Entities;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Runtime.Entities;

public unsafe class Entity : InteropReference, IEntity
{
	public Entity(IntPtr handle) : base(handle)
	{
	}

	public float GetHealth()
	{
		return WrapperFunctions.entity_get_health(Handle);
	}

	public void SetHealth(float health)
	{
		WrapperFunctions.entity_set_health(Handle, health);
	}

	public IWorld GetWorld()
	{
		return new World(WrapperFunctions.entity_get_world(Handle));
	}

	public void TakeDamage(IEntity attacker)
	{
		WrapperFunctions.entity_take_damage_1(Handle, attacker.GetOptionalInteropHandle());
	}

	public void TakeDamage(DamageType type, IEntity attacker, int rawDamage, double knockbackAmount)
	{
		WrapperFunctions.entity_take_damage_2(Handle, type, attacker.GetOptionalInteropHandle(), rawDamage, knockbackAmount);
	}

	public void TakeDamage(DamageType type, int attackerId, int rawDamage, double knockbackAmount)
	{
		WrapperFunctions.entity_take_damage_3(Handle, type, attackerId, rawDamage, knockbackAmount);
	}

	public void TakeDamage(DamageType type, IEntity attacker, int rawDamage, float finalDamage, double knockbackAmount)
	{
		WrapperFunctions.entity_take_damage_4(Handle, type, attacker.GetOptionalInteropHandle(), rawDamage, finalDamage, knockbackAmount);
	}

	public void Heal(int hitPoints)
	{
		WrapperFunctions.entity_heal(Handle, hitPoints);
	}

	public EntityType GetEntityType()
	{
		return WrapperFunctions.entity_get_entity_type(Handle);
	}
}
