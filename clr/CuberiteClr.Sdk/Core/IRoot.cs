namespace CuberiteClr.Sdk.Core;

public interface IRoot
{
	public void RootBroadcastChat(string message, MessageType messageType = MessageType.Custom);
}
