using System;

namespace CuberiteClr.Generator;

public class WrapperFunction
{
	public string Name { get; set; }

	public string Return { get; set; }

	public Arg[] Args { get; set; } = Array.Empty<Arg>();

	public class Arg
	{
		public string Name { get; set; }
		public string Type { get; set; }
	}
}
