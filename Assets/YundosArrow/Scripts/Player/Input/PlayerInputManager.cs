using System.Collections.Generic;
using Assets.YundosArrow.Scripts.Input;
using Assets.YundosArrow.Scripts.Player.Movement;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Input
{
    public class PlayerInputManager : MonoBehaviour {
        [SerializeField] private float _smoothMovementTime = 0.2f;
        [SerializeField, Range(0.001f, 0.01f)] private float _smoothMovementThreshHold = 0.005f;
//        [SerializeField] private CrosshairAnim _crosshairAnim;
        

        private PlayerControls _controls;
        private PlayerControls.CharacterActions _characterInput;

        private Vector2 _smoothMovement, _movement;
        private bool _isMoving ,_isJumping, _isRunnig, _isShooting, _isAiming, _isDashing;

        private Vector2 _currentMovementInput, _smoothMovementVelocity;

        private void Awake() {
            //to lock in the centre of window
            Cursor.lockState = CursorLockMode.Locked;

            //to hide the curser
            Cursor.visible = false;

            _controls = new PlayerControls();

            CharacterInput();
        }

        private void FixedUpdate() {
            var smoothedMovement = Vector2.SmoothDamp(_smoothMovement, _currentMovementInput, ref _smoothMovementVelocity, _smoothMovementTime);
            var x = (smoothedMovement.x < _smoothMovementThreshHold) && (smoothedMovement.x > -_smoothMovementThreshHold) ? 0 : smoothedMovement.x;
            var y = (smoothedMovement.y < _smoothMovementThreshHold) && (smoothedMovement.y > -_smoothMovementThreshHold) ? 0 : smoothedMovement.y;
            _smoothMovement = new Vector2(x, y);

            InputReceiver.Receive(InputsVector2, InputsBool);
        }

        private void CharacterInput() {
            _characterInput = _controls.Character;

            _characterInput.Movement.performed += ctx => _currentMovementInput  = ctx.ReadValue<Vector2>();
            _characterInput.Movement.performed += ctx => _movement  = ctx.ReadValue<Vector2>();
			
            _characterInput.Run.started += ctx => _isRunnig = true;
            _characterInput.Run.canceled += ctx => _isRunnig = false;

			_characterInput.Jump.started += ctx => _isJumping = true;
			_characterInput.Jump.started += ctx => JumpGracePeriodHandler.Jump();
			_characterInput.Jump.canceled += ctx => _isJumping = false;

			_characterInput.Dash.started += ctx => _isDashing = true;
			_characterInput.Dash.performed += ctx => _isDashing = false;
			_characterInput.Dash.canceled += ctx => _isDashing = false;

			_characterInput.Shoot.started += ctx => _isShooting = true;
            _characterInput.Shoot.canceled += ctx => _isShooting = false;

            _characterInput.Aim.started += ctx => _isAiming = true;
            _characterInput.Aim.canceled += ctx => _isAiming = false;
        }

        private Dictionary<InputReceiverType, bool> InputsBool {
            get => new Dictionary<InputReceiverType, bool>() {
                {InputReceiverType.RunPressed, _isRunnig},
                {InputReceiverType.JumpPressed, _isJumping},
				{InputReceiverType.DashPressed, _isDashing},
				{InputReceiverType.ShootPressed, _isShooting},
                {InputReceiverType.AimPressed, _isAiming}
            };
        }

        private Dictionary<InputReceiverType, Vector2> InputsVector2 {
            get => new Dictionary<InputReceiverType, Vector2>() {
                {InputReceiverType.Movement, _movement},
                {InputReceiverType.SmoothMovement, _smoothMovement}
            };
        }

        private void OnEnable() {
            _controls.Enable();
        }

        private void OnDestroy() {
            _controls.Disable();
        }
    }
}
