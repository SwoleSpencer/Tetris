using Unity.Entities;
using Unity.Collections;
using UnityEngine;

public class SpawnerConfigAuthoring : MonoBehaviour
{
	public GameObject[] tetrisShapePrefabs;
	public float scale;

	public class Baker : Baker<SpawnerConfigAuthoring>
	{
		public override void Bake(SpawnerConfigAuthoring authoring)
		{
			Entity entity = GetEntity(TransformUsageFlags.None);

			Entity tetrisShape0 = GetEntity(authoring.tetrisShapePrefabs[0], TransformUsageFlags.Dynamic);
			Entity tetrisShape1 = GetEntity(authoring.tetrisShapePrefabs[1], TransformUsageFlags.Dynamic);
			Entity tetrisShape2 = GetEntity(authoring.tetrisShapePrefabs[2], TransformUsageFlags.Dynamic);
			Entity tetrisShape3 = GetEntity(authoring.tetrisShapePrefabs[3], TransformUsageFlags.Dynamic);
			Entity tetrisShape4 = GetEntity(authoring.tetrisShapePrefabs[4], TransformUsageFlags.Dynamic);
			Entity tetrisShape5 = GetEntity(authoring.tetrisShapePrefabs[5], TransformUsageFlags.Dynamic);
			Entity tetrisShape6 = GetEntity(authoring.tetrisShapePrefabs[6], TransformUsageFlags.Dynamic);

			AddComponent(entity, new SpawnerConfig
			{
				tetrisShape0 = tetrisShape0,
				tetrisShape1 = tetrisShape1,
				tetrisShape2 = tetrisShape2,
				tetrisShape3 = tetrisShape3,
				tetrisShape4 = tetrisShape4,
				tetrisShape5 = tetrisShape5,
				tetrisShape6 = tetrisShape6,
				scale = authoring.scale
			});
		}
	}
}
