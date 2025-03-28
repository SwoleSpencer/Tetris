using Unity.Entities;
using UnityEngine;

public class CooldownAuthoring : MonoBehaviour
{
	public class Baker : Baker<CooldownAuthoring> 
	{
		public override void Bake(CooldownAuthoring authoring)
		{
			Entity entity = GetEntity(TransformUsageFlags.None);

			AddComponent(entity, new Cooldown());
			SetComponentEnabled<Cooldown>(entity, false);
		}
	}
}
