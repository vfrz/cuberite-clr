#pragma once

#include "Bindings/PluginManager.h"

class ClrCommandHandler : public cPluginManager::cCommandHandler
{
  public:
	ClrCommandHandler(void * a_Callback) : m_Callback(a_Callback) {}
	virtual bool ExecuteCommand(
		const AStringVector & a_Split, cPlayer * a_Player,
		const AString & a_Command, cCommandOutputCallback * a_Output) override;

  private:
	void * m_Callback;
};