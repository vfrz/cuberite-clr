using System;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Core;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Runtime.Core;

public unsafe class CompositeChat : InteropReference, ICompositeChat
{
	private CompositeChat(IntPtr handle, bool createdFromManaged) : base(handle, createdFromManaged)
	{
	}

	public static ICompositeChat Create(IntPtr handle, bool fromManaged = false)
	{
		return handle.IsNullPtr() ? null : new CompositeChat(handle, fromManaged);
	}

	protected override void Delete()
	{
		WrapperFunctions.delete_composite_chat(Handle);
	}

	public void Clear()
	{
		WrapperFunctions.composite_chat_clear(Handle);
	}

	public void AddTextPart(string message, string style = "")
	{
		WrapperFunctions.composite_chat_add_text_part(Handle, message, style);
	}

	public MessageType GetMessageType()
	{
		return WrapperFunctions.composite_chat_get_message_type(Handle);
	}

	public string GetAdditionalMessageTypeData()
	{
		return WrapperFunctions.composite_chat_get_additional_message_type_data(Handle).ToStringAnsi();
	}

	public string ExtractText()
	{
		return WrapperFunctions.composite_chat_extract_text(Handle).ToStringAnsi();
	}
}
