using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Runtime.Core;

public unsafe class Root : IRoot
{
	public static IRoot Instance { get; } = new Root();

	private Root()
	{
	}

	public void BroadcastChat(string message, MessageType messageType = MessageType.Custom)
	{
		WrappersFunctions.root_broadcast_chat(message, messageType);
	}
}
