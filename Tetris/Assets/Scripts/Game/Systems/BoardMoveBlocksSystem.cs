using Unity.Burst;
using Unity.Entities;
using Unity.Physics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

[BurstCompile]
public partial class BoardMoveBlocksSystem : SystemBase
{
    private InputActionAsset _inputActionAsset;

    private InputAction _movePlayer1Action;
    private InputAction _movePlayer2Action;

    [BurstCompile]
    protected override void OnCreate()
    {
        RequireForUpdate<SpawnerConfig>();

        _inputActionAsset = Resources.Load<InputActionAsset>("InputSystem_Actions");

        _movePlayer1Action = _inputActionAsset.FindAction("Move_Player1");
        _movePlayer2Action = _inputActionAsset.FindAction("Move_Player2");

        _movePlayer1Action.Enable();
        _movePlayer2Action.Enable();
    }

    [BurstCompile]
    protected override void OnUpdate()
    {
        float2 player1Input = _movePlayer1Action.ReadValue<Vector2>();
        float2 player2Input = _movePlayer2Action.ReadValue<Vector2>();

        float deltaTime = SystemAPI.Time.DeltaTime;

        foreach (
            var (shape,
                physicsVelocity,
                entity)
                in SystemAPI.Query<
                RefRO<Shape>,
                RefRW<PhysicsVelocity>>().
				WithDisabled<Landed>().
				WithEntityAccess())
        {
            float2 moveDirection = float2.zero;

			if (shape.ValueRO.boardID == 0)
            {
                moveDirection = player1Input;
            }
            else if (shape.ValueRO.boardID == 1)
            {
                moveDirection = player2Input;
            }

            if (moveDirection.y < 0)
            {
                physicsVelocity.ValueRW.Linear.y += -25 * deltaTime;
            }
            else
            {
                physicsVelocity.ValueRW.Linear.y = -25f * deltaTime;
            }

            if (moveDirection.x < 0)
			{
				physicsVelocity.ValueRW.Linear.x += -25f * deltaTime;
			}
			else if (moveDirection.x > 0)
			{
				physicsVelocity.ValueRW.Linear.x += 25f * deltaTime;
			}
            else
            {
                physicsVelocity.ValueRW.Linear.x *= 0.25f * deltaTime;
            }
        }
    }
}
