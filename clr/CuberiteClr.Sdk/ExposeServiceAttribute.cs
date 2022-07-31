namespace CuberiteClr.Sdk;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ExposeServiceAttribute : Attribute
{
	public Type ServiceType { get; }

	public Type ImplementationType { get; }

	public ExposeServiceAttribute(Type serviceType, Type implementationType)
	{
		ServiceType = serviceType;
		ImplementationType = implementationType;
	}
}
