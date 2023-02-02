//using DG.Tweening;
//using UnityEngine;
//
//namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.Stats.SubStats
//{
//	[System.Serializable]
//	public class Movement {
//        [SerializeField, Range(0.1f, 50)] private float speed;
//        [SerializeField, Range(1, 10)] private float force;
//        [SerializeField, Range(1, 20)] private float returnForce = 5f;
//        [SerializeField, Range(1, 10)] private float loopHoleForce = 1f;
//
//        public float Speed { get => speed; }
//        public float Force { get => force; }
//        public float LoopHoleForce { get => loopHoleForce; }
//        public float ReturnForce { get => returnForce; }
//
//        public Movement()
//        {
//            this.speed = 1f;
//            this.force = 1f;
//            this.returnForce = 5f;
//            this.loopHoleForce = 1f;
//        }
//
//        public Movement(float speed, float force, float returnForce, float loopHoleForce)
//        {
//            this.speed = speed;
//            this.force = force;
//            this.returnForce = returnForce;
//            this.loopHoleForce = loopHoleForce;
//        }
//    }
//}