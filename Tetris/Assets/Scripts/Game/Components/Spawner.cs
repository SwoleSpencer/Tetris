using Unity.Mathematics;
using Unity.Entities;

public struct Spawner : IComponentData
{
    public Entity entity;

    public int boardID;
    public float2 position;
}
