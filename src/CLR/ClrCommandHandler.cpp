#include "ClrCommandHandler.h"

bool ClrCommandHandler::ExecuteCommand(
	const AStringVector & a_Split, cPlayer * a_Player,
	const AString & a_Command, cCommandOutputCallback * a_Output)
{
	return m_Callback(a_Command, a_Player);
}