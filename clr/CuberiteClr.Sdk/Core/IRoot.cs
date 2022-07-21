using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Sdk.Core;

public interface IRoot
{
	public void BroadcastChat(string message, MessageType messageType = MessageType.Custom);
}
