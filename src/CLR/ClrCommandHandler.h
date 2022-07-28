#pragma once

#include "Bindings/PluginManager.h"

typedef bool (*CommandCallbackTypeDef)(const AString &, cPlayer *);

class ClrCommandHandler : public cPluginManager::cCommandHandler
{
  public:
	ClrCommandHandler(void * a_Callback) :
		m_Callback((CommandCallbackTypeDef)a_Callback)
	{
	}
	virtual bool ExecuteCommand(
		const AStringVector & a_Split, cPlayer * a_Player,
		const AString & a_Command, cCommandOutputCallback * a_Output) override;

  private:
	CommandCallbackTypeDef m_Callback;
};