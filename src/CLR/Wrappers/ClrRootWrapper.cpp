#include "ClrRootWrapper.h"

void ClrRootWrapper::root_broadcast_chat(char * message, eMessageType messageType) {
	cRoot::Get()->BroadcastChat(message, messageType);
}