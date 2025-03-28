using Unity.Entities;
using UnityEngine;

public class ShapeSelectorAuthoring : MonoBehaviour
{
	public int boardID;

	public class Baker : Baker<ShapeSelectorAuthoring>
	{
		public override void Bake(ShapeSelectorAuthoring authoring)
		{
			Entity entity = GetEntity(TransformUsageFlags.None);

			AddComponent(entity, new ShapeSelector
			{
				boardID = authoring.boardID,
				value = 0
			});
		}
	}
}
