using System.Runtime.InteropServices;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Sdk.Types;

[StructLayout(LayoutKind.Sequential)]
public readonly struct TakeDamageInfo
{
	public readonly DamageType DamageType;
	public readonly IEntity Attacker;
	public readonly int RawDamage;
	public readonly float FinalDamage;
	public readonly Vector3d Knockback;

	public TakeDamageInfo(DamageType damageType, IEntity attacker, int rawDamage, float finalDamage, Vector3d knockback)
	{
		DamageType = damageType;
		Attacker = attacker;
		RawDamage = rawDamage;
		FinalDamage = finalDamage;
		Knockback = knockback;
	}
}
