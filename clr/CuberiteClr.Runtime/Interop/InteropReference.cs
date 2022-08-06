using System;

namespace CuberiteClr.Runtime.Interop;

public abstract class InteropReference : IDisposable
{
	public IntPtr Handle { get; }

	public bool Disposed { get; private set; }

	public bool CreatedFromManaged { get; }

	protected InteropReference(IntPtr handle, bool createdFromManaged)
	{
		Handle = handle;
		CreatedFromManaged = createdFromManaged;
	}

	~InteropReference()
	{
		Dispose();
	}

	public void Dispose()
	{
		if (!CreatedFromManaged)
			return;

		if (Disposed)
			return;

		Delete();
		Disposed = true;

		GC.SuppressFinalize(this);
	}

	protected virtual void Delete()
	{
		throw new NotImplementedException();
	}
}
