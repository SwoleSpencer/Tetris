using Unity.Entities;
using UnityEngine;

class BoardAuthoring : MonoBehaviour
{
    public GameObject emptySquarePrefab;

    public int width = 10;
    public int height = 20;
    public int header = 4;

    public class Baker : Baker<BoardAuthoring>
    {
        public override void Bake(BoardAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Board());
        }
    }
}