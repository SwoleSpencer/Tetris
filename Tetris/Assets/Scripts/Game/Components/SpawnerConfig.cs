using Unity.Entities;
public struct SpawnerConfig : IComponentData
{
    public Entity tetrisShape0;
	public Entity tetrisShape1;
	public Entity tetrisShape2;
	public Entity tetrisShape3;
	public Entity tetrisShape4;
	public Entity tetrisShape5;
	public Entity tetrisShape6;

	public float scale;
}