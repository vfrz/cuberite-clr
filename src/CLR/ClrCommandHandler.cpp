#include "ClrCommandHandler.h"

bool ClrCommandHandler::ExecuteCommand(
	const AStringVector & a_Split, cPlayer * a_Player,
	const AString & a_Command, cCommandOutputCallback * a_Output)
{
	return cRoot::Get()->GetPluginManager()->GetClrHooks().ExecuteCommandCallback(m_Callback, a_Command, (void*) &a_Split[0], a_Split.size(), a_Player);
}