using LiteDB;

namespace TestPlugin;

internal class AdminRecord
{
	[BsonId]
	public Guid PlayerId { get; set; }
}
