using CuberiteClr.Sdk.Types;
#pragma warning disable CS8625

namespace CuberiteClr.Sdk.Core;

public interface IRoot
{
	public bool BindCommand(string name, CommandCallback callback, string permission = null, string helpString = null);

	public void BroadcastChat(string message, MessageType type = MessageType.Custom);

	public IWorld GetDefaultWorld();

	public bool ForEachWorld(ForEachWorldCallback callback);

	public bool ForEachPlayer(ForEachPlayerCallback callback);

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
