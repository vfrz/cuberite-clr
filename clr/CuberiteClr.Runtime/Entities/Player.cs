using System;
using CuberiteClr.Runtime.Extensions;
using CuberiteClr.Runtime.Interop;
using CuberiteClr.Sdk.Entities;

namespace CuberiteClr.Runtime.Entities;

public unsafe class Player : InteropReference, IPlayer
{
	public Player(IntPtr handle) : base(handle)
	{
	}

	public string GetName()
	{
		var pointer = *(CuberiteClrManager.WrappersFunctionsPtr + WrappersFunctionsOffsets.Entities.Player.GetName);
		var getPlayerNameFunction = (delegate* unmanaged[Cdecl]<IntPtr, IntPtr>) (void*) pointer;
		var playerName = getPlayerNameFunction(Handle).ReadStringAuto();
		return playerName;
	}
}
