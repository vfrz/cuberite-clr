namespace CuberiteClr.Sdk.Core;

public enum BlockFace
{
	None = -1, // Interacting with no block face - swinging the item in the air
	Xm = 4, // Interacting with the X- face of the block
	Xp = 5, // Interacting with the X+ face of the block
	Ym = 0, // Interacting with the Y- face of the block
	Yp = 1, // Interacting with the Y+ face of the block
	Zm = 2, // Interacting with the Z- face of the block
	Zp = 3, // Interacting with the Z+ face of the block

	// Synonyms using the (deprecated) world directions:
	Bottom = Ym, // Interacting with the bottom   face of the block
	Top = Yp, // Interacting with the top      face of the block
	North = Zm, // Interacting with the northern face of the block
	South = Zp, // Interacting with the southern face of the block
	West = Xm, // Interacting with the western  face of the block
	East = Xp, // Interacting with the eastern  face of the block

	// Bounds, used for range-checking:
	Min = -1,
	Max = 5,
}
