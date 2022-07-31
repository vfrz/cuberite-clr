namespace CuberiteClr.Sdk.Types;

public enum DamageType
{
	// Canonical names for the types (as documented in the plugin wiki):
	Attack, // Being attacked by a mob
	RangedAttack, // Being attacked by a projectile, possibly from a mob
	Lightning, // Hit by a lightning strike
	Falling, // Falling down; dealt when hitting the ground
	Drowning, // Drowning in water / lava
	Suffocating, // Suffocating inside a block
	Starving, // Hunger
	CactusContact, // Contact with a cactus block
	MagmaContact, // Contact with a magma block
	LavaContact, // Contact with a lava block
	Poisoning, // Having the poison effect
	Withering, // Having the wither effect
	OnFire, // Being on fire
	FireContact, // Standing inside a fire block
	InVoid, // Falling into the Void (Y < 0)
	PotionOfHarming,
	EnderPearl, // Thrown an ender pearl, teleported by it
	Admin, // Damage applied by an admin command
	Explosion, // Damage applied by an explosion
	Environment, // Damage dealt to mobs from environment: enderman in rain, snow golem in desert
}
