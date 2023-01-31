using UnityEngine;
using System.Collections;
using YundosArrow.Scripts.Systems.Managers;

namespace YundosArrow.Scripts.Player
{
    [RequireComponent(typeof(MovementHandler))]
    [RequireComponent(typeof(DetectCollision))]
    public class JumpingMode : PlayerState {
        public override IEnumerator On() {
            PlayerStates nextState;
    
            var direction = Vector3.zero;
            var finalSpeed = 0f;
            var lastJumpTime = Time.time;

            if (PlayerStats.Jump.UsePhysics) {
                direction = (Camera.main.transform.right * InputReceiver.Vector2[InputReceiverType.SmoothMovement].x) + 
                                (Camera.main.transform.forward * InputReceiver.Vector2[InputReceiverType.SmoothMovement].y);
                finalSpeed = (InputReceiver.Bool[InputReceiverType.RunPressed] ? PlayerStats.Movement.SprintMultiplier : 1f);
                finalSpeed *= PlayerStats.Movement.Speed;
            }

            while (true)
            {
                if (!PlayerStats.Jump.UsePhysics) {
                    direction = (Camera.main.transform.right * InputReceiver.Vector2[InputReceiverType.SmoothMovement].x) + 
                                (Camera.main.transform.forward * InputReceiver.Vector2[InputReceiverType.SmoothMovement].y);
                    finalSpeed = (InputReceiver.Bool[InputReceiverType.RunPressed] ? PlayerStats.Movement.SprintMultiplier : 1f);
                    finalSpeed *= PlayerStats.Movement.Speed;
                }

                MovementHandler.Jump(PlayerStats.Jump.JumpForce, PlayerStats.Jump.JumpGracePeriod);
                MovementHandler.Move(direction, finalSpeed);
                MovementHandler.Gravity();
                if (!PlayerStats.Jump.UsePhysics) 
                    MovementHandler.Rotate(PlayerStats.Movement.RotationSpeed);

                Debug.Log("Jumping");

                yield return new WaitForEndOfFrame();

                if (MovementHandler.isGrounded) {
                    nextState = PlayerStates.GroundMovement;
                    break;
                }

                if (InputReceiver.Bool[InputReceiverType.RunPressed]) {
                    if (ComboManager.Instance.CurrentNumber >= ComboManager.Instance.DashNumber) {
                        nextState = PlayerStates.Dash;
                        break;
                    }
                }

                if (InputReceiver.Bool[InputReceiverType.JumpPressed]) {
                    if(Time.time - lastJumpTime >= PlayerStats.Jump.DoubleJump.ReactionGapTime) {
                        if (ComboManager.Instance.CurrentNumber >= ComboManager.Instance.DoubleJumpNumber) {
                            nextState = PlayerStates.DoubleJump;
                            break;
                        }
                    }
                }
            }

            base.ChangeState(nextState);
        }

        
    }
}