//using DG.Tweening;
//using UnityEngine;
//
//namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.Stats.SubStats
//{
//	[System.Serializable]
//	public class MarkTargets {
//		[Header("Spherecast settings")]
//        // [SerializeReference] private Transform startPoint;
//        [SerializeField] private float radius;
//        [SerializeField] private float range;
//        [SerializeField] private float rangeOnNoHit;
//        [SerializeField] private LayerMask layerMask;
//
//        // public Transform StartPoint { get => startPoint; }
//        public float Radius { get => radius; }
//        public float Range { get => range; }
//        public float RangeOnNoHit { get => rangeOnNoHit; }
//        public LayerMask LayerMask { get => layerMask; }
//
//        public MarkTargets()
//        {
//            this.radius = 5f;
//            this.range = 5f;
//            this.rangeOnNoHit = 20f;
//            this.layerMask = new LayerMask();
//        }
//
//        public MarkTargets(float radius, float range, float rangeOnNoHit, LayerMask layerMask)
//        {
//            // this.startPoint = startPoint;
//            this.radius = radius;
//            this.range = range;
//            this.rangeOnNoHit = rangeOnNoHit;
//            this.layerMask = layerMask;
//        }
//    }
//}