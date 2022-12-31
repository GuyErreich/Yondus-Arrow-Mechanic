using UnityEngine;
using System.Collections;

namespace YundosArrow.Scripts.Player
{
    [RequireComponent(typeof(PlayerStats))]
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

            if (PlayerStats.UsePhysics) {
                // direction = this.GetComponent<CharacterController>().velocity;
                // finalSpeed = 1f;
                direction = (Camera.main.transform.right * InputReceiver.Vector2[InputReceiverType.SmoothMovement].x) + 
                                (Camera.main.transform.forward * InputReceiver.Vector2[InputReceiverType.SmoothMovement].y);
                finalSpeed = (InputReceiver.Bool[InputReceiverType.RunPressed] ? PlayerStats.SprintMultiplier : 1f);
                finalSpeed *= PlayerStats.Speed;
            }

            while (true)
            {
                if (!PlayerStats.UsePhysics) {
                    direction = (Camera.main.transform.right * InputReceiver.Vector2[InputReceiverType.SmoothMovement].x) + 
                                (Camera.main.transform.forward * InputReceiver.Vector2[InputReceiverType.SmoothMovement].y);
                    finalSpeed = (InputReceiver.Bool[InputReceiverType.RunPressed] ? PlayerStats.SprintMultiplier : 1f);
                    finalSpeed *= PlayerStats.Speed;
                }

                MovementHandler.Jump(PlayerStats.JumpForce, PlayerStats.JumpGracePeriod);
                MovementHandler.Move(direction, finalSpeed);
                MovementHandler.Gravity();
                MovementHandler.Rotate(PlayerStats.RotationSpeed);

                Debug.Log("Jumping");

                yield return new WaitForEndOfFrame();

                if (MovementHandler.isGrounded) {
                    nextState = PlayerStates.GroundMovement;
                    break;
                }
            }

            base.ChangeState(nextState);
        }
    }
}