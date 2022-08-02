#pragma once

enum CommandResult
{
	crExecuted,
	crUnknownCommand,
	crError,
	crBlocked,
	crNoPermission,
};