namespace CuberiteClr.Sdk;

[AttributeUsage(AttributeTargets.Class)]
public class DependsOnAttribute : Attribute
{
	public string[] Dependencies { get; }

	public DependsOnAttribute(params string[] dependencies)
	{
		Dependencies = dependencies;
	}
}
