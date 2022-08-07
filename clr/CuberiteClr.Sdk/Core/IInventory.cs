using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Sdk.Core;

public interface IInventory
{
	public byte AddItem(IItem item, bool allowNewStacks = true);

	public byte AddItems(IItem[] items, bool allowNewStacks = true);

	public void Clear();

	public int HowManyCanFit(IItem item, bool considerEmptySlots = true);

	public int HowManyCanFit(IItem item, int beginSlotNum, int endSlotNum, bool considerEmptySlots = true);

	public int RemoveItem(IItem itemStack);

	public IItem FindItem(IItem recipeItem);

	public bool RemoveOneEquippedItem();

	public bool ReplaceOneEquippedItem(IItem item, bool tryOtherSlots = true);

	public int HowManyItems(IItem item);

	public bool HasItems(IItem itemStack);

	public IPlayer GetOwner();

	public IItem GetSlot(int slotNum);

	public IItem GetArmorSlot(int armorSlotNum);

	public IItem GetInventorySlot(int inventorySlotNum);

	public IItem GetHotbarSlot(int hotbarSlotNum);

	public IItem GetShieldSlot();

	public IItemGrid GetArmorGrid();

	public IItemGrid GetInventoryGrid();

	public IItemGrid GetHotbarGrid();

	public IItem GetEquippedItem();
}
