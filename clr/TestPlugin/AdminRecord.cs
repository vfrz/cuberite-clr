using LiteDB;

namespace TestPlugin;

public class AdminRecord
{
	[BsonId]
	public Guid PlayerId { get; set; }
}
