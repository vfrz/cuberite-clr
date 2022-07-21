using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Sdk.Core;

public interface IRoot
{
	public void BroadcastChat(string message, MessageType type = MessageType.Custom);

	// Objects creation
	public IItem CreateItem(short type, byte count = 1, short damage = 0, string enchantments = "",
		string customName = "", string[] loreTable = null);

	public IItem CreateItem(ItemType type, byte count = 1, short damage = 0, string enchantments = "",
		string customName = "", string[] loreTable = null)
		=> CreateItem((short) type, count, damage, enchantments, customName, loreTable);

	public IItem CreateItem(BlockType type, byte count = 1, short damage = 0, string enchantments = "",
		string customName = "", string[] loreTable = null)
		=> CreateItem((short) type, count, damage, enchantments, customName, loreTable);
}
