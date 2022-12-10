using UnityEngine;
using Movement.Input;

namespace CaptainClaw.Scripts.Player
{
    public class PlayerInputManager : MonoBehaviour {
        [SerializeField] private float smoothMovementTime = 0.2f;
        [SerializeField, Range(0.001f, 0.01f)] private float smoothMovementThreshHold = 0.005f;

        private PlayerControls controls;
        private PlayerControls.CharacterActions characterInput;

        private Vector2 smoothMovement, movement;
        private bool isMoving ,isJumping, isRunnig;

        private Vector2 currentMovementInput, smoothMovementVelocity;

        private void Awake() {
            //to lock in the centre of window
            Cursor.lockState = CursorLockMode.Locked;

            //to hide the curser
            Cursor.visible = false;

            this.controls = new PlayerControls();

            this.CharacterInput();
        }

        private void Update() {
            var smoothedMovement = Vector2.SmoothDamp(this.smoothMovement, this.currentMovementInput, ref this.smoothMovementVelocity, this.smoothMovementTime);
            var x = (smoothedMovement.x < smoothMovementThreshHold) && (smoothedMovement.x > -smoothMovementThreshHold) ? 0 : smoothedMovement.x;
            var y = (smoothedMovement.y < smoothMovementThreshHold) && (smoothedMovement.y > -smoothMovementThreshHold) ? 0 : smoothedMovement.y;
            this.smoothMovement = new Vector2(x, y);

            InputReceiver.Receive(this.movement ,this.smoothMovement, this.isRunnig, this.isJumping);
        }

        private void CharacterInput() {
            this.characterInput = this.controls.Character;

            this.characterInput.Movement.performed += ctx => this.currentMovementInput  = ctx.ReadValue<Vector2>();
            this.characterInput.Movement.performed += ctx => this.movement  = ctx.ReadValue<Vector2>();
            this.characterInput.Run.started += ctx => this.isRunnig = true;
            this.characterInput.Run.canceled += ctx => this.isRunnig = false;
            this.characterInput.Jump.started += ctx => this.isJumping = ctx.ReadValueAsButton();
            this.characterInput.Jump.canceled += ctx => this.isJumping = ctx.ReadValueAsButton();
        }

        private void OnEnable() {
            controls.Enable();
        }

        private void OnDestroy() {
            controls.Disable();
        }
    }
}
