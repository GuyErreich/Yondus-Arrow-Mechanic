using UnityEngine;

namespace CaptainClaw.Scripts.Player
{
    public class DetectCollision : MonoBehaviour {
        [System.Serializable] private struct Detector
        {
            public float height;
            public float radius;
            public float range;

            public Detector(float height, float radius, float range)
            {
                this.height = 0f;
                this.radius = 0.5f;
                this.range = 0.5f;
            }
        }

        public enum direction {
            front = 0,
            bottom = 1,
            frontFeet = 2
        }

        [Header("Stats:")]
        [SerializeField] private int precision = 10;

        [Header("Detectors:")]
        [SerializeField] private Detector FrontDetector = new Detector(0f, 0.5f, 0.5f);
        [SerializeField] private Detector BottomDetector  = new Detector(0f, 0.5f, 0.5f);
        [SerializeField] private Detector FrontFeetDetector = new Detector(-0.5f, 0.5f, 0.5f);

        public RaycastHit? Front { get; private set; }
        public RaycastHit? Bottom { get; private set; }
        public RaycastHit? FrontFeet { get; private set; }

        private void Update() {
            // Front detection
            this.Front = this.DetectedCollider(this.FrontDetector.height, this.FrontDetector.radius, this.FrontDetector.range, this.transform.forward);
            
            // Bottom detection
            this.Bottom = this.DetectedCollider(this.BottomDetector.height, this.BottomDetector.radius, this.BottomDetector.range, -this.transform.up);

            // Front feet detection
            this.FrontFeet = this.DetectedCollider(this.FrontFeetDetector.height, this.FrontFeetDetector.radius, this.FrontFeetDetector.range, this.transform.forward);
            
        }

        private RaycastHit? DetectedCollider(float height, float radius, float range, Vector3 direction) {
            var origin = this.transform.position + (Vector3.up * height);

            RaycastHit hit;
            if (Physics.SphereCast(origin, radius, direction, out hit, range))
                return hit;
            else
                return null;
        }
        
        private RaycastHit? DetectedCollider360(float height, float radius, float range) {
            var origin = this.transform.position + (Vector3.up * height);

            RaycastHit hit;
            //Check around the character in a 360, 10 times (increase if more accuracy is needed)
            for (int i = 0; i < 360; i += (360 / this.precision)) {
                var direction = new Vector3(Mathf.Cos(i), 0, Mathf.Sin(i));
                //Check if anything with the platform layer touches this object
                if (Physics.SphereCast(origin, radius, direction, out hit, range))
                    return hit;
            }
            
            return null;
        }        

        public float GetRange(direction dir) {
            if (dir == direction.front)
                return this.FrontDetector.range;
            if (dir == direction.bottom)
                return this.BottomDetector.range;
            if (dir == direction.frontFeet)
                return this.FrontFeetDetector.range;

            throw new System.Exception("Unknown direction");
        }

        public bool CompareTag(string tag, direction dir) {
            if (dir == direction.front)
                return this.Front != null && this.Front.Value.collider.tag == tag;
            if (dir == direction.bottom)
                return this.Bottom != null && this.Bottom.Value.collider.tag == tag;
            if (dir == direction.frontFeet)
                return this.FrontFeet != null && this.FrontFeet.Value.collider.tag == tag;

            throw new System.Exception("Unknown direction");
        } 

        void OnDrawGizmosSelected() {
            // Front detection
            this.DrawDetector(this.FrontDetector.height, this.FrontDetector.radius, this.FrontDetector.range, this.transform.forward);
            
            // Bottom detection
            this.DrawDetector(this.BottomDetector.height, this.BottomDetector.radius, this.BottomDetector.range, -this.transform.up);

            // Front feet detection
            this.DrawDetector(this.FrontFeetDetector.height, this.FrontFeetDetector.radius, this.FrontFeetDetector.range, this.transform.forward);
        }


        private void DrawDetector(float height, float radius, float range, Vector3 direction) {
            var startPoint = this.transform.position + (Vector3.up * height);
            var endPoint = startPoint + (direction * (range - radius));
            Gizmos.DrawLine(startPoint, endPoint);
            Gizmos.DrawWireSphere(startPoint + (direction * range), radius);
        }

        private void DrawDetector360(float height, float radius, float range) {
            var startPoint = this.transform.position + (Vector3.up * height);
            
            //Check around the character in a 360, 10 times (increase if more accuracy is needed)
            for (int i = 0; i < 360; i += (360 / this.precision)) {
                var direction = new Vector3(Mathf.Cos(i), 0, Mathf.Sin(i));
                var endPoint = startPoint + (direction * (range - radius));
                Gizmos.DrawLine(startPoint, endPoint);
                Gizmos.DrawWireSphere(startPoint + (direction * range), radius);
            }
        }

    }
}