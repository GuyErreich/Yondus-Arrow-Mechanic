using System.Collections.Generic;
using UnityEngine;
using YundosArrow.Scripts.Input;
using YundosArrow.Scripts.UI;

namespace YundosArrow.Scripts.Player
{
    public class PlayerInputManager : MonoBehaviour {
        [SerializeField] private float smoothMovementTime = 0.2f;
        [SerializeField, Range(0.001f, 0.01f)] private float smoothMovementThreshHold = 0.005f;
        [SerializeField] private CrosshairAnim crosshairAnim;
        

        private PlayerControls controls;
        private PlayerControls.CharacterActions characterInput;

        private Vector2 smoothMovement, movement;
        private bool isMoving ,isJumping, isRunnig, isShooting, isAiming;

        private Vector2 currentMovementInput, smoothMovementVelocity;

        private void Awake() {
            //to lock in the centre of window
            Cursor.lockState = CursorLockMode.Locked;

            //to hide the curser
            Cursor.visible = false;

            this.controls = new PlayerControls();

            this.CharacterInput();
        }

        private void FixedUpdate() {
            var smoothedMovement = Vector2.SmoothDamp(this.smoothMovement, this.currentMovementInput, ref this.smoothMovementVelocity, this.smoothMovementTime);
            var x = (smoothedMovement.x < smoothMovementThreshHold) && (smoothedMovement.x > -smoothMovementThreshHold) ? 0 : smoothedMovement.x;
            var y = (smoothedMovement.y < smoothMovementThreshHold) && (smoothedMovement.y > -smoothMovementThreshHold) ? 0 : smoothedMovement.y;
            this.smoothMovement = new Vector2(x, y);

            InputReceiver.Receive(this.InputsVector2, this.InputsBool);
        }

        private void CharacterInput() {
            this.characterInput = this.controls.Character;

            this.characterInput.Movement.performed += ctx => this.currentMovementInput  = ctx.ReadValue<Vector2>();
            this.characterInput.Movement.performed += ctx => this.movement  = ctx.ReadValue<Vector2>();
            this.characterInput.Run.started += ctx => this.isRunnig = true;
            this.characterInput.Run.canceled += ctx => this.isRunnig = false;
            this.characterInput.Jump.started += ctx => this.isJumping = true;
            this.characterInput.Jump.canceled += ctx => this.isJumping = false;

            this.characterInput.Shoot.started += ctx => this.isShooting = true;
            this.characterInput.Shoot.canceled += ctx => this.isShooting = false;

            // this.characterInput.Shoot.started += ctx => crosshairAnim.Open();
            // this.characterInput.Shoot.canceled += ctx => crosshairAnim.Close();

            this.characterInput.Aim.started += ctx => this.isAiming = true;
            this.characterInput.Aim.canceled += ctx => this.isAiming = false;
        }

        private Dictionary<InputReceiverType, bool> InputsBool {
            get => new Dictionary<InputReceiverType, bool>() {
                {InputReceiverType.RunPressed, this.isRunnig},
                {InputReceiverType.JumpPressed, this.isJumping},
                {InputReceiverType.ShootPressed, this.isShooting},
                {InputReceiverType.AimPressed, this.isAiming}
            };
        }

        private Dictionary<InputReceiverType, Vector2> InputsVector2 {
            get => new Dictionary<InputReceiverType, Vector2>() {
                {InputReceiverType.Movement, this.movement},
                {InputReceiverType.SmoothMovement, this.smoothMovement}
            };
        }

        private void OnEnable() {
            controls.Enable();
        }

        private void OnDestroy() {
            controls.Disable();
        }
    }
}
