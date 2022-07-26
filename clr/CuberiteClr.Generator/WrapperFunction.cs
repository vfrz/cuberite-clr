#pragma warning disable CS8618
namespace CuberiteClr.Generator;

public class WrapperFunction
{
	public string Name { get; set; }
	public Signature Cs { get; set; }
	public Signature Cpp { get; set; }

	public class Signature
	{
		public string Return { get; set; }
		public Arg[] Args { get; set; } = Array.Empty<Arg>();

		public class Arg
		{
			public string Name { get; set; }
			public string Type { get; set; }
		}
	}
}
