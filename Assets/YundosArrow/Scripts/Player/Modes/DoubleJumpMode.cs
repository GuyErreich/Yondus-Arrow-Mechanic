using UnityEngine;
using System.Collections;
using YundosArrow.Scripts.Systems.Managers;

namespace YundosArrow.Scripts.Player
{
    [RequireComponent(typeof(MovementHandler))]
    public class DoubleJumpMode : PlayerState {
        public override IEnumerator On() {    
            var direction = Vector3.zero;
            var finalSpeed = 0f;

            if (PlayerStats.Jump.UsePhysics) {
                direction = (Camera.main.transform.right * InputReceiver.Vector2[InputReceiverType.SmoothMovement].x) + 
                                (Camera.main.transform.forward * InputReceiver.Vector2[InputReceiverType.SmoothMovement].y);
                finalSpeed = (InputReceiver.Bool[InputReceiverType.RunPressed] ? PlayerStats.Movement.SprintMultiplier : 1f);
                finalSpeed *= PlayerStats.Movement.Speed;
            }

            ComboManager.Instance.Decrease(ComboManager.Instance.DoubleJumpNumber);
            
            if (!PlayerStats.Jump.UsePhysics) {
                direction = (Camera.main.transform.right * InputReceiver.Vector2[InputReceiverType.SmoothMovement].x) + 
                            (Camera.main.transform.forward * InputReceiver.Vector2[InputReceiverType.SmoothMovement].y);
                finalSpeed = (InputReceiver.Bool[InputReceiverType.RunPressed] ? PlayerStats.Movement.SprintMultiplier : 1f);
                finalSpeed *= PlayerStats.Movement.Speed;
            }

            MovementHandler.Jump(PlayerStats.Jump.JumpForce, PlayerStats.Jump.JumpGracePeriod, true);

            Debug.Log("Double Jumping");

            yield return new WaitForEndOfFrame();

            base.ChangeState(PlayerStates.Jumping);
        }
    }
}