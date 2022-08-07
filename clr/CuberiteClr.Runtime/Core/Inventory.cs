using System;
using System.Linq;
using CuberiteClr.Runtime.Entities;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Core;

public unsafe class Inventory : InteropReference, IInventory
{
	private Inventory(IntPtr handle, bool createdFromManaged) : base(handle, createdFromManaged)
	{
	}

	public static IInventory Create(IntPtr handle, bool fromManaged = false)
	{
		return handle.IsNullPtr() ? null : new Inventory(handle, fromManaged);
	}

	public byte AddItem(IItem item, bool allowNewStacks = true)
	{
		var itemHandle = item.GetInteropHandle();
		return WrapperFunctions.inventory_add_item(Handle, itemHandle, allowNewStacks);
	}

	public byte AddItems(IItem[] items, bool allowNewStacks = true)
	{
		var itemsPointers = items
			.Select(item => item.GetInteropHandle())
			.ToArray();
		fixed (void* itemsPtr = &itemsPointers[0])
		{
			return WrapperFunctions.inventory_add_items(Handle, new IntPtr(itemsPtr), items.Length, allowNewStacks);
		}
	}

	public void Clear()
	{
		WrapperFunctions.inventory_clear(Handle);
	}

	public int HowManyCanFit(IItem item, bool considerEmptySlots = true)
	{
		return WrapperFunctions.inventory_how_many_can_fit_1(Handle, item.GetInteropHandle(), considerEmptySlots);
	}

	public int HowManyCanFit(IItem item, int beginSlotNum, int endSlotNum, bool considerEmptySlots = true)
	{
		return WrapperFunctions.inventory_how_many_can_fit_2(Handle, item.GetInteropHandle(), beginSlotNum, endSlotNum,
			considerEmptySlots);
	}

	public int RemoveItem(IItem itemStack)
	{
		return WrapperFunctions.inventory_remove_item(Handle, itemStack.GetInteropHandle());
	}

	public IItem FindItem(IItem recipeItem)
	{
		var itemPtr = WrapperFunctions.inventory_find_item(Handle, recipeItem.GetInteropHandle());
		var item = Item.Create(itemPtr);
		return item;
	}

	public bool RemoveOneEquippedItem()
	{
		return WrapperFunctions.inventory_remove_one_equipped_item(Handle);
	}

	public bool ReplaceOneEquippedItem(IItem item, bool tryOtherSlots = true)
	{
		return WrapperFunctions.inventory_replace_one_equipped_item(Handle, item.GetInteropHandle(), tryOtherSlots);
	}

	public int HowManyItems(IItem item)
	{
		return WrapperFunctions.inventory_how_many_items(Handle, item.GetInteropHandle());
	}

	public bool HasItems(IItem itemStack)
	{
		return WrapperFunctions.inventory_has_items(Handle, itemStack.GetInteropHandle());
	}

	public IPlayer GetOwner()
	{
		var playerPtr = WrapperFunctions.inventory_get_owner(Handle);
		var player = Entity.Create<IPlayer>(playerPtr);
		return player;
	}

	public IItem GetSlot(int slotNum)
	{
		var itemPtr = WrapperFunctions.inventory_get_slot(Handle, slotNum);
		var item = Item.Create(itemPtr);
		return item;
	}

	public IItem GetArmorSlot(int armorSlotNum)
	{
		var itemPtr = WrapperFunctions.inventory_get_armor_slot(Handle, armorSlotNum);
		var item = Item.Create(itemPtr);
		return item;
	}

	public IItem GetInventorySlot(int inventorySlotNum)
	{
		var itemPtr = WrapperFunctions.inventory_get_inventory_slot(Handle, inventorySlotNum);
		var item = Item.Create(itemPtr);
		return item;
	}

	public IItem GetHotbarSlot(int hotbarSlotNum)
	{
		var itemPtr = WrapperFunctions.inventory_get_hotbar_slot(Handle, hotbarSlotNum);
		var item = Item.Create(itemPtr);
		return item;
	}

	public IItem GetShieldSlot()
	{
		var itemPtr = WrapperFunctions.inventory_get_shield_slot(Handle);
		var item = Item.Create(itemPtr);
		return item;
	}

	public IItemGrid GetArmorGrid()
	{
		var itemGridPtr = WrapperFunctions.inventory_get_armor_grid(Handle);
		var itemGrid = ItemGrid.Create(itemGridPtr);
		return itemGrid;
	}

	public IItemGrid GetInventoryGrid()
	{
		var itemGridPtr = WrapperFunctions.inventory_get_inventory_grid(Handle);
		var itemGrid = ItemGrid.Create(itemGridPtr);
		return itemGrid;
	}

	public IItemGrid GetHotbarGrid()
	{
		var itemGridPtr = WrapperFunctions.inventory_get_hotbar_grid(Handle);
		var itemGrid = ItemGrid.Create(itemGridPtr);
		return itemGrid;
	}

	public IItem GetEquippedItem()
	{
		var itemPtr = WrapperFunctions.inventory_get_equipped_item(Handle);
		var item = Item.Create(itemPtr);
		return item;
	}
}
