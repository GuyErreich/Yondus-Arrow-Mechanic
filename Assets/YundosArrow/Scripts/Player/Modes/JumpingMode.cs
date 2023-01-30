using UnityEngine;
using System.Collections;

namespace YundosArrow.Scripts.Player
{
    [RequireComponent(typeof(MovementHandler))]
    [RequireComponent(typeof(DetectCollision))]
    public class JumpingMode : PlayerState {
        private DetectCollision detectCollision;

        private bool Climb { get => this.detectCollision.CompareTag("Ladder", DetectCollision.direction.front); }

        private void Awake() => this.detectCollision = this.GetComponent<DetectCollision>();

        public override IEnumerator On() {
            PlayerStates nextState;
    
            var direction = Vector3.zero;
            var finalSpeed = 0f;

            if (PlayerStats.Jump.UsePhysics) {
                // direction = this.GetComponent<CharacterController>().velocity;
                // finalSpeed = 1f;
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
                MovementHandler.Rotate(PlayerStats.Movement.RotationSpeed);

                Debug.Log("Jumping");

                yield return new WaitForEndOfFrame();

                if (MovementHandler.isGrounded) {
                    nextState = PlayerStates.GroundMovement;
                    break;
                }

                if (InputReceiver.Bool[InputReceiverType.RunPressed]) {
                    nextState = PlayerStates.Dash;
                    break;
                }
            }

            base.ChangeState(nextState);
        }
    }
}