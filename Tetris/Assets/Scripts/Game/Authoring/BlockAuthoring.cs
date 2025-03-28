using Unity.Entities;
using UnityEngine;

public class BlockAuthoring : MonoBehaviour
{
	public class Baker : Baker<BlockAuthoring>
	{
		public override void Bake(BlockAuthoring authoring)
		{
			Entity entity = GetEntity(TransformUsageFlags.Dynamic);
			AddComponent(entity, new Block());
		}
	}
}
