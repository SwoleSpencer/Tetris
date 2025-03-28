using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Physics;

partial struct ShapeSpawningSystem : ISystem
{
	[BurstCompile]
	public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<SpawnerConfig>();
		state.RequireForUpdate<ShapeSelector>();
	}


    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        if (SystemAPI.TryGetSingleton(out SpawnerConfig spawnerConfig) == false)
        {
            return;
        }

		EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Unity.Collections.Allocator.TempJob);

		foreach (var (spawner,
                entity) 
                in SystemAPI.Query<
                    RefRO<Spawner>>().
                    WithDisabled<Cooldown>().
                    WithEntityAccess())
        {

            Entity spawnedEntity;

			int selectedShapeNumber = 0;

			foreach (var (shapeSelector,
					shapeSelectorEntity)
					in SystemAPI.Query<
					RefRW<ShapeSelector>>().
					WithEntityAccess())
			{
				if (spawner.ValueRO.boardID == shapeSelector.ValueRO.boardID)
				{
					selectedShapeNumber = shapeSelector.ValueRO.value;
					state.EntityManager.SetComponentEnabled<Cooldown>(shapeSelectorEntity, false);
				}
			}

			switch (selectedShapeNumber)
            {
                case 0:
					spawnedEntity = state.EntityManager.Instantiate(spawnerConfig.tetrisShape0);
					break;
                case 1:
					spawnedEntity = state.EntityManager.Instantiate(spawnerConfig.tetrisShape1);
					break;
                case 2:
					spawnedEntity = state.EntityManager.Instantiate(spawnerConfig.tetrisShape2);
					break;
                case 3:
					spawnedEntity = state.EntityManager.Instantiate(spawnerConfig.tetrisShape3);
					break;
                case 4:
					spawnedEntity = state.EntityManager.Instantiate(spawnerConfig.tetrisShape4);
					break;
                case 5:
					spawnedEntity = state.EntityManager.Instantiate(spawnerConfig.tetrisShape5);
					break;
                case 6:
					spawnedEntity = state.EntityManager.Instantiate(spawnerConfig.tetrisShape6);
					break;
                default:
					spawnedEntity = state.EntityManager.Instantiate(spawnerConfig.tetrisShape0);
					break;
            }

			SystemAPI.SetComponent(spawnedEntity, new LocalTransform
            {
                Position = new float3(spawner.ValueRO.position.x, spawner.ValueRO.position.y, 0f),
                Rotation = quaternion.identity,
                Scale = spawnerConfig.scale
            });

			entityCommandBuffer.AddComponent(spawnedEntity, new Shape
            {
                boardID = spawner.ValueRO.boardID,
            });

            PhysicsMass physicsMass = state.EntityManager.GetComponentData<PhysicsMass>(spawnedEntity);
            physicsMass.InverseInertia = float3.zero;
            state.EntityManager.SetComponentData(spawnedEntity, physicsMass);

            state.EntityManager.SetComponentEnabled<Cooldown>(entity, true);

			state.EntityManager.SetComponentData(spawnedEntity, new PhysicsVelocity
			{
				Linear = new float3(0f, -0.1f, 0f)
			});
		};

		entityCommandBuffer.Playback(state.EntityManager);
		entityCommandBuffer.Dispose();
	}
}
