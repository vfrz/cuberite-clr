using System;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public unsafe class Entity : InteropReference, IEntity
{
	public Entity(IntPtr handle) : base(handle)
	{
	}

	public float GetHealth()
	{
		return WrappersFunctions.entity_get_health(Handle);
	}

	public void SetHealth(float health)
	{
		WrappersFunctions.entity_set_health(Handle, health);
	}
}