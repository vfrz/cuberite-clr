using System;
using CuberiteClr.Runtime.Core;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public unsafe class Pickup : Entity, IPickup, IDisposable
{
	public Pickup(IntPtr handle, bool fromManaged) : base(handle, fromManaged)
	{
	}

	public bool IsPlayerCreated()
	{
		return WrapperFunctions.pickup_is_player_created(Handle);
	}

	public bool IsCollected()
	{
		return WrapperFunctions.pickup_is_collected(Handle);
	}

	public bool CanCombine()
	{
		return WrapperFunctions.pickup_can_combine(Handle);
	}

	public void SetCanCombine(bool canCombine)
	{
		WrapperFunctions.pickup_set_can_combine(Handle, canCombine);
	}

	public bool CollectedBy(IEntity entity)
	{
		return WrapperFunctions.pickup_collected_by(Handle, entity.GetInteropHandle());
	}

	public int GetAge()
	{
		return WrapperFunctions.pickup_get_age(Handle);
	}

	public void SetAge(int age)
	{
		WrapperFunctions.pickup_set_age(Handle, age);
	}

	public int GetLifetime()
	{
		return WrapperFunctions.pickup_get_lifetime(Handle);
	}

	public void SetLifetime(int lifetime)
	{
		WrapperFunctions.pickup_set_lifetime(Handle, lifetime);
	}

	public IItem GetItem()
	{
		var itemPtr = WrapperFunctions.pickup_get_item(Handle);
		var item = Item.Create(itemPtr);
		return item;
	}

	protected override void Delete()
	{
		WrapperFunctions.delete_pickup(Handle);
	}
}
