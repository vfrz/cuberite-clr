namespace CuberiteClr.Sdk;

[AttributeUsage(AttributeTargets.Class)]
public class ClrPluginAttribute : Attribute
{
	public string Identifier { get; }

	public bool HasDatabase { get; }

	public ClrPluginAttribute(string identifier, bool hasDatabase = false)
	{
		Identifier = identifier;
		HasDatabase = hasDatabase;
	}
}
