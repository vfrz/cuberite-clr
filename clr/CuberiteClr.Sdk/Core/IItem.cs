namespace CuberiteClr.Sdk.Core;

public interface IItem
{
	public short Type { get; }

	public byte Count { get; }

	public short Damage { get; }

	public string CustomName { get; }

	public IEnchantments Enchantments { get; }
}
