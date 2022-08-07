using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Sdk.Core;

public interface ICompositeChat
{
	public void Clear();

	public void AddTextPart(string message, string style = "");

	public MessageType GetMessageType();

	public string GetAdditionalMessageTypeData();

	public string ExtractText();
}
