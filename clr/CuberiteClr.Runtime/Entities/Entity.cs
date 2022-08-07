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
	internal Entity(IntPtr handle, bool createdFromManaged) : base(handle, createdFromManaged)
	{
	}

	public static IEntity Create(IntPtr handle, bool fromManaged = false)
	{
		if (handle == IntPtr.Zero)
			return null;

		var className = WrapperFunctions.entity_get_class(handle).ToStringAnsi();
		return className switch
		{
			"cAggressiveMonster" => new AggressiveMonster(handle, fromManaged),
			"cBat" => new Bat(handle, fromManaged),
			"cBlaze" => new Blaze(handle, fromManaged),
			"cCaveSpider" => new CaveSpider(handle, fromManaged),
			"cChicken" => new Chicken(handle, fromManaged),
			"cCow" => new Cow(handle, fromManaged),
			"cCreeper" => new Creeper(handle, fromManaged),
			"cEnderDragon" => new EnderDragon(handle, fromManaged),
			"cEnderman" => new Enderman(handle, fromManaged),
			"cEntity" => new Entity(handle, fromManaged),
			"cGhast" => new Ghast(handle, fromManaged),
			"cGiant" => new Giant(handle, fromManaged),
			"cGuardian" => new Guardian(handle, fromManaged),
			"cHorse" => new Horse(handle, fromManaged),
			"cIronGolem" => new IronGolem(handle, fromManaged),
			"cMagmaCube" => new MagmaCube(handle, fromManaged),
			"cMonster" => new Monster(handle, fromManaged),
			"cMooshroom" => new Mooshroom(handle, fromManaged),
			"cOcelot" => new Ocelot(handle, fromManaged),
			"cPassiveAggressiveMonster" => new PassiveAggressiveMonster(handle, fromManaged),
			"cPassiveMonster" => new PassiveMonster(handle, fromManaged),
			"cPawn" => new Pawn(handle, fromManaged),
			"cPickup" => new Pickup(handle, fromManaged),
			"cPig" => new Pig(handle, fromManaged),
			"cPlayer" => new Player(handle, fromManaged),
			"cRabbit" => new Rabbit(handle, fromManaged),
			"cSheep" => new Sheep(handle, fromManaged),
			"cSilverfish" => new Silverfish(handle, fromManaged),
			"cSkeleton" => new Skeleton(handle, fromManaged),
			"cSlime" => new Slime(handle, fromManaged),
			"cSnowGolem" => new SnowGolem(handle, fromManaged),
			"cSpider" => new Spider(handle, fromManaged),
			"cSquid" => new Squid(handle, fromManaged),
			"cVillager" => new Villager(handle, fromManaged),
			"cWitch" => new Witch(handle, fromManaged),
			"cWither" => new Wither(handle, fromManaged),
			"cWitherSkeleton" => new WitherSkeleton(handle, fromManaged),
			"cWolf" => new Wolf(handle, fromManaged),
			"cZombie" => new Zombie(handle, fromManaged),
			"cZombiePigman" => new ZombiePigman(handle, fromManaged),
			"cZombieVillager" => new ZombieVillager(handle, fromManaged),
			_ => new Entity(handle, fromManaged)
		};
	}

	public static T Create<T>(IntPtr handle, bool fromManaged = false) where T : class, IEntity
	{
		return Create(handle, fromManaged) as T;
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
		return WrapperFunctions.entity_get_position(Handle);
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

	public bool IsInvisible()
	{
		return WrapperFunctions.entity_is_invisible(Handle);
	}

	public void TeleportToCoords(Vector3d position)
	{
		WrapperFunctions.entity_teleport_to_coords(Handle, position);
	}

	public void TeleportToEntity(IEntity entity)
	{
		WrapperFunctions.entity_teleport_to_entity(Handle, entity.GetInteropHandle());
	}
}
