using System.Runtime.InteropServices;
using CuberiteClr.Sdk.Core;

namespace CuberiteClr.Sdk.Types;

[StructLayout(LayoutKind.Sequential)]
public readonly struct SetBlock
{
	public readonly int RelativeX;
	public readonly int RelativeY;
	public readonly int RelativeZ;

	public readonly int ChunkX;
	public readonly int ChunkZ;

	public readonly BlockType BlockType;
	public readonly byte BlockMeta;

	public int X => RelativeX + Constants.ChunkWidth * ChunkX;
	public int Y => RelativeY;
	public int Z => RelativeZ + Constants.ChunkWidth * ChunkZ;

	public Vector3i AbsolutePosition => new(X, Y, Z);
	public Vector3i RelativePosition => new(RelativeX, RelativeY, RelativeZ);

	public SetBlock(int relativeX, int relativeY, int relativeZ, int chunkX, int chunkZ, BlockType blockType, byte blockMeta)
	{
		RelativeX = relativeX;
		RelativeY = relativeY;
		RelativeZ = relativeZ;
		ChunkX = chunkX;
		ChunkZ = chunkZ;
		BlockType = blockType;
		BlockMeta = blockMeta;
	}
}
