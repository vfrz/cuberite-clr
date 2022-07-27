using System.Collections.Generic;

namespace CuberiteClr.Generator;

public class WrapperFunction
{
	public string Return { get; set; }

	public Dictionary<string, string> Args { get; set; } = new();
}
