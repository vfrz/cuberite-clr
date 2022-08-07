using System;
using System.Runtime.InteropServices;
using CuberiteClr.Runtime.Entities;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Runtime.Core;

[StructLayout(LayoutKind.Sequential)]
public readonly struct TakeDamageInfoInternal
{
	public readonly DamageType DamageType;
	public readonly IntPtr Attacker;
	public readonly int RawDamage;
	public readonly float FinalDamage;
	public readonly Vector3d Knockback;

	public TakeDamageInfoInternal(DamageType damageType, IntPtr attacker, int rawDamage, float finalDamage, Vector3d knockback)
	{
		DamageType = damageType;
		Attacker = attacker;
		RawDamage = rawDamage;
		FinalDamage = finalDamage;
		Knockback = knockback;
	}

	public TakeDamageInfo ToTakeDamageInfo()
	{
		var attackerEntity = Entity.Create(Attacker);
		return new TakeDamageInfo(DamageType, attackerEntity, RawDamage, FinalDamage, Knockback);
	}
}
