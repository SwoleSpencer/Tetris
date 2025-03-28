using Unity.Entities;
using UnityEngine;

public class LandedAuthoring : MonoBehaviour
{
	public class Baker : Baker<LandedAuthoring>
	{
		public override void Bake(LandedAuthoring authoring)
		{
			Entity entity = GetEntity(TransformUsageFlags.Dynamic);

			AddComponent(entity, new Landed());
			SetComponentEnabled<Landed>(entity, false);
		}
	}
}
