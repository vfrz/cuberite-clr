namespace CuberiteClr.Sdk.Types;

public enum MessageType
{
	Custom, // Send raw data without any processing
	Failure, // Something could not be done (i.e. command not executed due to insufficient privilege)
	Information, // Informational message (i.e. command usage)
	Success, // Something executed successfully
	Warning, // Something concerning (i.e. reload) is about to happen
	Fatal, // Something catastrophic occured (i.e. plugin crash)
	Death, // Denotes death of player
	PrivateMessage, // Player to player messaging identifier
	Join, // A player has joined the server
	Leave, // A player has left the server
	MaxPlusOne // The first invalid type, used for checking on LuaAPI boundaries
}
