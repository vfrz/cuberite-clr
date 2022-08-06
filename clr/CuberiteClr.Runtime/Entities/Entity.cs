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
	internal Entity(IntPtr handle) : base(handle)
	{
	}

	public static IEntity Create(IntPtr handle)
	{
		if (handle == IntPtr.Zero)
			return null;

		var className = WrapperFunctions.entity_get_class(handle).ToStringAnsi();
		return className switch
		{
			"cEntity" => new Entity(handle),
			"cPawn" => new Pawn(handle),
			"cPlayer" => new Player(handle),
			"cPickup" => new Pickup(handle),
			_ => new Entity(handle)
		};
	}

	public static T Create<T>(IntPtr handle) where T : class, IEntity
	{
		return Create(handle) as T;
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
		return World.Create(WrapperFunctions.entity_get_world(Handle));
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

	public Vector3d GetPosition()
	{
		return WrapperFunctions.entity_get_position(Handle).ToVector3d();
	}

	public string GetClass()
	{
		return WrapperFunctions.entity_get_class(Handle).ToStringAnsi();
	}

	public string GetParentClass()
	{
		return WrapperFunctions.entity_get_parent_class(Handle).ToStringAnsi();
	}

	public bool IsA(string className)
	{
		return WrapperFunctions.entity_is_a(Handle, className);
	}
}
