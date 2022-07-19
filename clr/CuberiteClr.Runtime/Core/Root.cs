using CuberiteClr.Sdk.Core;

namespace CuberiteClr.Runtime.Core;

public unsafe class Root : IRoot
{
	public void RootBroadcastChat(string message, MessageType messageType = MessageType.Custom)
	{
		var pointer = *(CuberiteClrManager.WrappersFunctionsPtr + WrappersFunctionsOffsets.Root.BroadcastChat);
		var broadcastChatFunction = (delegate* unmanaged[Cdecl]<string, MessageType, void>) (void*) pointer;
		broadcastChatFunction(message, messageType);
	}
}
