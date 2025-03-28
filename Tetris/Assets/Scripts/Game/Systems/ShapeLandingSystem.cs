using Unity.Burst;
using Unity.Entities;
using Unity.Physics;

partial struct ShapeLandingSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<Spawner>();
        state.RequireForUpdate<Shape>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Unity.Collections.Allocator.TempJob);

        foreach (var (shape,
                physicsVelocity,
                entity) 
                in SystemAPI.Query<
                RefRO<Shape>,
                RefRO<PhysicsVelocity>>().
                WithDisabled<Landed>().
                WithEntityAccess())
        {

			if (physicsVelocity.ValueRO.Linear.y.Equals(0f))
			{
				entityCommandBuffer.SetComponentEnabled<Landed>(entity, true);

				foreach (var (spawner, spawnerEntity)
	                    in SystemAPI.Query<
		                RefRO<Spawner>>().
		                WithEntityAccess())
				{
					if (spawner.ValueRO.boardID == shape.ValueRO.boardID)
					{
						entityCommandBuffer.SetComponentEnabled<Cooldown>(spawnerEntity, false);
					}
				}
			}
        }

        entityCommandBuffer.Playback(state.EntityManager);
        entityCommandBuffer.Dispose();
    }
}
