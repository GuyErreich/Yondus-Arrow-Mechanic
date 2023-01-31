using UnityEngine;
using System.Collections;
using YundosArrow.Scripts.Systems.Managers;

namespace YundosArrow.Scripts.Player
{
    [RequireComponent(typeof(MovementHandler))]
    [RequireComponent(typeof(DetectCollision))]
    public class MovementMode : PlayerState {
        public override IEnumerator On() {
            PlayerStates nextState;
            
            while (true)
            {
                var direction = (Camera.main.transform.right * InputReceiver.Vector2[InputReceiverType.SmoothMovement].x) + 
                                (Camera.main.transform.forward * InputReceiver.Vector2[InputReceiverType.SmoothMovement].y);
                var finalSpeed = (InputReceiver.Bool[InputReceiverType.RunPressed] ? PlayerStats.Movement.SprintMultiplier : 1f);
                finalSpeed *= PlayerStats.Movement.Speed;
                MovementHandler.Move(direction, finalSpeed);
                MovementHandler.Gravity();
                MovementHandler.Rotate(PlayerStats.Movement.RotationSpeed);

                Debug.Log("Moving");

                yield return new WaitForEndOfFrame();

                if (InputReceiver.Bool[InputReceiverType.JumpPressed] || MovementHandler.isJumpGracePeriod) {
                    nextState = PlayerStates.Jumping;
                    break;
                }

                if (InputReceiver.Bool[InputReceiverType.RunPressed]) {
                    if (ComboManager.Instance.CurrentNumber >= ComboManager.Instance.DashNumber) {
                        nextState = PlayerStates.Dash;
                        break;
                    }
                }
            }

            base.ChangeState(nextState);
        }

    }
}