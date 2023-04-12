using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player
{
    public class DetectCollision : MonoBehaviour {
        [System.Serializable] private struct Detector
        {
			public float Height;
            public float Radius;
            public float Range;

            public Detector(float height, float radius, float range)
            {
				Height = height;
				Radius = radius;
				Range = range;
            }
        }

		public enum Direction {
			Front = 0,
			Bottom = 1,
			FrontFeet = 2
		}

        [Header("Detectors:")]
        [SerializeField] private Detector _frontDetector = new Detector(0f, 0.5f, 0.5f);
        [SerializeField] private Detector _bottomDetector  = new Detector(0f, 0.5f, 0.5f);
        [SerializeField] private Detector _frontFeetDetector = new Detector(-0.5f, 0.5f, 0.5f);

        public RaycastHit? Front { get; private set; }
        public RaycastHit? Bottom { get; private set; }
        public RaycastHit? FrontFeet { get; private set; }

        private void Update() {
            // Front detection
            Front = DetectedCollider(_frontDetector.Height, _frontDetector.Radius, _frontDetector.Range, transform.forward);
            
            // Bottom detection
            Bottom = DetectedCollider(_bottomDetector.Height, _bottomDetector.Radius, _bottomDetector.Range, -transform.up);

            // Front feet detection
            FrontFeet = DetectedCollider(_frontFeetDetector.Height, _frontFeetDetector.Radius, _frontFeetDetector.Range, transform.forward);
            
        }

        private RaycastHit? DetectedCollider(float height, float radius, float range, Vector3 direction) {
            var origin = transform.position + (Vector3.up * height);

            RaycastHit hit;
            if (Physics.SphereCast(origin, radius, direction, out hit, range))
                return hit;
            else
                return null;
        }

        public float GetRange(Direction dir) {
            if (dir == Direction.Front)
                return _frontDetector.Range;
            if (dir == Direction.Bottom)
                return _bottomDetector.Range;
            if (dir == Direction.FrontFeet)
                return _frontFeetDetector.Range;

            throw new System.Exception("Unknown direction");
        }

        public bool CompareTag(string tagName, Direction dir) {
            if (dir == Direction.Front)
				return Front != null && Front.Value.collider.tag == tagName;
            if (dir == Direction.Bottom)
				return Bottom != null && Bottom.Value.collider.tag == tagName;
            if (dir == Direction.FrontFeet)
				return FrontFeet != null && FrontFeet.Value.collider.tag == tagName;

            throw new System.Exception("Unknown direction");
        } 

        void OnDrawGizmosSelected() {
            // Front detection
            DrawDetector(_frontDetector.Height, _frontDetector.Radius, _frontDetector.Range, transform.forward);
            
            // Bottom detection
            DrawDetector(_bottomDetector.Height, _bottomDetector.Radius, _bottomDetector.Range, -transform.up);

            // Front feet detection
            DrawDetector(_frontFeetDetector.Height, _frontFeetDetector.Radius, _frontFeetDetector.Range, transform.forward);
        }


        private void DrawDetector(float height, float radius, float range, Vector3 direction) {
            var startPoint = transform.position + (Vector3.up * height);
            var endPoint = startPoint + (direction * (range - radius));
            Gizmos.DrawLine(startPoint, endPoint);
            Gizmos.DrawWireSphere(startPoint + (direction * range), radius);
        }
    }
}