using Unity.Entities;
using UnityEngine;

public class ShapeAuthoring : MonoBehaviour
{
	public class Baker : Baker<ShapeAuthoring>
	{
		public override void Bake(ShapeAuthoring authoring)
		{
			Entity entity = GetEntity(TransformUsageFlags.Dynamic);
			AddComponent(entity, new Shape());
		}
	}
}
