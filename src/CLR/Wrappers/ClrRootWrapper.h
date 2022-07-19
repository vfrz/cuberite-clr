#ifndef CUBERITE_CLRROOTWRAPPER_H
#define CUBERITE_CLRROOTWRAPPER_H

namespace ClrRootWrapper
{
extern "C"
{
	void root_broadcast_chat(char * message, eMessageType messageType);
}
}

#endif
