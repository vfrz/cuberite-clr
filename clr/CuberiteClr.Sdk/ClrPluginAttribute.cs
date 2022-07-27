namespace CuberiteClr.Sdk;

[AttributeUsage(AttributeTargets.Class)]
public class ClrPluginAttribute : Attribute
{
	public string Identifier { get; }

	public ClrPluginAttribute(string identifier)
	{
		Identifier = identifier;
	}
}
