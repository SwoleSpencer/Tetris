using Unity.Entities;

partial struct ShapeSelectorSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
		state.RequireForUpdate<SpawnerConfig>();
	}

    public void OnUpdate(ref SystemState state)
    {
		foreach (var (shapeSelector,
				entity) 
				in SystemAPI.Query<
				RefRW<ShapeSelector>>().
				WithDisabled<Cooldown>().
				WithEntityAccess())
		{
			shapeSelector.ValueRW.value = UnityEngine.Random.Range(0, 7);

			state.EntityManager.SetComponentEnabled<Cooldown>(entity, true);

			ShapeSelectorEventManager.instance?.InvokeOnShapeSelectedAction(shapeSelector.ValueRO.boardID, shapeSelector.ValueRO.value);
		}
	}
}
