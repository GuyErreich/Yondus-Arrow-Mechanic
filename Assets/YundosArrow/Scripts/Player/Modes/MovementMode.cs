using UnityEngine;
using System.Collections;

namespace YundosArrow.Scripts.Player
{
    [RequireComponent(typeof(PlayerStats))]
    [RequireComponent(typeof(MovementHandler))]
    [RequireComponent(typeof(DetectCollision))]
    public class MovementMode : PlayerState {
        private bool Jump { get => InputReceiver.Bool[InputReceiverType.JumpPressed] || MovementHandler.jumpAgain; }

        private DetectCollision detectCollision;

        private void Awake() => this.detectCollision = this.GetComponent<DetectCollision>();

        public override IEnumerator On() {
            PlayerStates nextState;
            
            while (true)
            {
                var direction = (Camera.main.transform.right * InputReceiver.Vector2[InputReceiverType.SmoothMovement].x) + 
                                (Camera.main.transform.forward * InputReceiver.Vector2[InputReceiverType.SmoothMovement].y);
                var finalSpeed = (InputReceiver.Bool[InputReceiverType.RunPressed] ? PlayerStats.SprintMultiplier : 1f);
                finalSpeed *= PlayerStats.Speed;
                MovementHandler.Move(direction, finalSpeed);
                MovementHandler.Gravity();
                MovementHandler.Rotate(PlayerStats.RotationSpeed);

                Debug.Log("Moving");

                yield return new WaitForEndOfFrame();

                if (this.Jump) {
                    nextState = PlayerStates.Jumping;
                    break;
                }
            }

            base.ChangeState(nextState);
        }

    }
}