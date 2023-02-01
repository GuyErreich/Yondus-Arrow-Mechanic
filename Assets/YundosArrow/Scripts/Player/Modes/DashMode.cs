using UnityEngine;
using System.Collections;
using YundosArrow.Scripts.Systems.Managers;

namespace YundosArrow.Scripts.Player
{
    [RequireComponent(typeof(MovementHandler))]
    public class DashMode : PlayerState {
        public override IEnumerator On() {
            PlayerStates nextState;
            
            var direction = (Camera.main.transform.right * InputReceiver.Vector2[InputReceiverType.SmoothMovement].x) + 
                            (Camera.main.transform.forward * InputReceiver.Vector2[InputReceiverType.SmoothMovement].y);
            var dashEndPos = this.transform.position + direction * PlayerStats.Movement.Dash.Distance;
            var startTime = Time.time;

            ComboManager.Instance.Decrease(ComboManager.Instance.DashNumber);
            
            while (Time.time - startTime < PlayerStats.Movement.Dash.Duration)
            {
                    
                var speed = PlayerStats.Movement.Dash.Distance / PlayerStats.Movement.Dash.Duration;
                MovementHandler.Move(direction, speed);
                MovementHandler.Gravity();

                Debug.Log("Dashing");

                yield return new WaitForEndOfFrame();

                if (InputReceiver.Bool[InputReceiverType.JumpPressed] && MovementHandler.isGrounded) {
                    nextState = PlayerStates.Jumping;
                    break;
                } else if (InputReceiver.Bool[InputReceiverType.JumpPressed]) {
                    if (ComboManager.Instance.CurrentNumber >= ComboManager.Instance.DoubleJumpNumber) {
                        nextState = PlayerStates.DoubleJump;
                        break;
                    }
                }
            }

            if (MovementHandler.isGrounded)
                nextState = PlayerStates.GroundMovement;
            else
                nextState = PlayerStates.Jumping;
            
            base.ChangeState(nextState);
        }

    }
}