using System.IO;
using CuberiteClr.Runtime.Plugins;
using CuberiteClr.Sdk;
using LiteDB;

namespace CuberiteClr.Runtime.Database;

public class LiteDbDatabase<T> : LiteDatabase, IDatabase<T> where T : IClrPlugin
{
	private static string DatabasePath => Path.Combine(PluginLoader.PluginDatabasesFolder,
		$"{PluginDescription.FromType(typeof(T)).Identifier}.db");

	public LiteDbDatabase() : base(DatabasePath)
	{
	}
}
