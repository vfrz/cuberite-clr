using System.Runtime.InteropServices;
using CuberiteClr.Sdk.Entities;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Sdk.Core;

public delegate bool CommandCallback(string command, string[] split, IPlayer player);

public interface IRoot
{
	public bool BindCommand(string name, CommandCallback callback, string permission, string helpString);

	public void BroadcastChat(string message, MessageType type = MessageType.Custom);

	public IWorld GetDefaultWorld();

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
