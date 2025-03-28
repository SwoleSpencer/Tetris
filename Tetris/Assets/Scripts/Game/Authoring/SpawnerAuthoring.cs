using Unity.Entities;
using UnityEngine;

public class SpawnerAuthoring : MonoBehaviour
{
	public Vector2 Position;
	public int boardID;

	public class Baker : Baker<SpawnerAuthoring>
	{
		public override void Bake(SpawnerAuthoring authoring)
		{
			Entity entity = GetEntity(TransformUsageFlags.Dynamic);
			AddComponent(entity, new Spawner()
			{
				position = authoring.Position,
				boardID = authoring.boardID
			});
		}
	}
}
