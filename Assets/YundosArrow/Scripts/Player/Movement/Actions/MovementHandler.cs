//using UnityEngine;
//
//namespace YundosArrow.Scripts.Player
//{
//    [RequireComponent(typeof(CharacterController))]
//    public class MovementHandler : MonoBehaviour {
//        #region Private Variables
//        private static CharacterController _charController;
//        private static Vector3 _velocity;
//        private static float _ySpeed;
//        private static float? _lastGroundedTime, _jumpButtonPressedTime;
//        #endregion Private Variables
//
//        #region Getters/Setters
//        public static bool UsePhysics { get; private set; }
//        public static bool isGrounded { get => _charController.isGrounded; }
//        public static bool isJumpGracePeriod { get; private set;}
//
//        public static Vector3 Direction { 
//            get {
//                var X = (Camera.main.transform.right.normalized * InputReceiver.Vector2[InputReceiverType.Movement].x);
//                var Z = (Camera.main.transform.forward.normalized * InputReceiver.Vector2[InputReceiverType.Movement].y);
//                var directionXZ = Vector3.Scale(X + Z, new Vector3(1,0,1));
//
//                return directionXZ;
//            }
//        }
//        #endregion Getters/Setters
//        
//        private void Awake() {
//            _charController = this.GetComponent<CharacterController>();
//            _detectCollision = this.GetComponent<DetectCollision>();
//        }
//
//        public static void Move(Vector3 direction, float speed) {
//            _velocity = direction * speed;
//            _velocity.y = _ySpeed;
//
//            _charController.Move(_velocity * Time.deltaTime);
//        }
//
//        public static void Gravity() {
//            //TODO: make it global and serializable with a curve
//            if (!_charController.isGrounded) {
//                if (_ySpeed >= 0f)
//                    _ySpeed += Physics.gravity.y * Time.deltaTime;
//                else 
//                    _ySpeed += Physics.gravity.y * PlayerStats.Jump.FallMultiplier * Time.deltaTime;
//            }
//
//            if(_charController.isGrounded) {
//                _lastGroundedTime = Time.time;
//
//                if(_ySpeed < 0f)
//                    _ySpeed = 0f;
//            }
//        }
//
//        public static void Rotate(float rotationTime) {
//            if(InputReceiver.Vector2[InputReceiverType.Movement] != Vector2.zero)
//            {
//                Quaternion toRotation = Quaternion.LookRotation(Direction, Vector3.up);
//
//                var angle = Quaternion.Angle(_charController.transform.rotation, toRotation);
//
//                _charController.transform.rotation = Quaternion.RotateTowards(_charController.transform.rotation, toRotation, angle / (rotationTime / Time.deltaTime));
//            }
//        }
//
//        public static void Jump(float jumpForce, float jumpGracePeriod, bool forceJump = false) {
//            if (InputReceiver.Bool[InputReceiverType.JumpPressed])
//                _jumpButtonPressedTime = Time.time;
//
//            isJumpGracePeriod = true;
//
//            // The same as checking ground but gives a little period where it still considers you grounded.
//            // this gives the char a better jump interaction because most of the times people don`t press the jump
//            // button in the perfect right time to make the char jump again. 
//            if (Time.time - _jumpButtonPressedTime <= jumpGracePeriod || forceJump) {
//                if (Time.time - _lastGroundedTime <= jumpGracePeriod || forceJump)
//                {
//                    _ySpeed = jumpForce;
//
//                    isJumpGracePeriod = false;
//                    _lastGroundedTime = null;
//                    _jumpButtonPressedTime = null;
//                }
//            }
//        }
//    }
//}