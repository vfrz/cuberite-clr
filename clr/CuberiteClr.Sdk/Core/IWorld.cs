using CuberiteClr.Sdk.Entities;
using CuberiteClr.Sdk.Types;

namespace CuberiteClr.Sdk.Core;

public interface IWorld
{
	public string GetName();

	public Weather GetWeather();

	public void SetWeather(Weather weather);

	public int GetTimeOfDay();

	public void SetTimeOfDay(int time);

	public long GetWorldAge();

	public long GetWorldTickAge();

	public long GetWorldDate();

	public bool ForEachPlayer(ForEachPlayerCallback callback);

	public GameMode GetGameMode();

	public bool AreCommandBlocksEnabled();

	public void SetCommandBlocksEnabled(bool enabled);

	public BlockType GetBlock(Vector3i position);

	public void SetBlock(Vector3i position, BlockType blockType, byte meta);

	public void BroadcastChat(string message, IClientHandle? exclude = null, MessageType messageType = MessageType.Custom);

	public void DigBlock(Vector3i position, IEntity? digger = null);

	public void DoExplosionAt(double size, Vector3d position, bool canCauseFire, ExplosionSource source, object sourceData);

	public void CastThunderbolt(Vector3i block);
}
