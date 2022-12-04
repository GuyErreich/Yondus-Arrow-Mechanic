using UnityEngine;
using System.Collections;

namespace CaptainClaw.Scripts.Player
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

            if (MovementHandler.UsePhysics) {
                direction = this.GetComponent<CharacterController>().velocity;
                finalSpeed = 1f;
            }

            while (true)
            {
                if (!PlayerStats.UsePhysics) {
                    direction = (Camera.main.transform.right * InputReceiver.SmoothMovement.x) + 
                                (Camera.main.transform.forward * InputReceiver.SmoothMovement.y);
                    finalSpeed = (InputReceiver.RunPressed ? PlayerStats.SprintMultiplier : 1f);
                    finalSpeed *= PlayerStats.Speed;
                }

                MovementHandler.Jump(PlayerStats.JumpForce, PlayerStats.JumpGracePeriod);
                MovementHandler.Move(direction, finalSpeed);
                MovementHandler.Gravity();
                MovementHandler.Rotate(PlayerStats.RotationSpeed);

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