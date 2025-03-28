using Unity.Entities;
using UnityEngine;

public class EmptySquareAuthoring : MonoBehaviour
{
	public class Baker : Baker<EmptySquareAuthoring>
	{
		public override void Bake(EmptySquareAuthoring authoring)
		{
			Entity entity = GetEntity(TransformUsageFlags.None);
			AddComponent(entity, new EmptySquare());
		}
	}
}
