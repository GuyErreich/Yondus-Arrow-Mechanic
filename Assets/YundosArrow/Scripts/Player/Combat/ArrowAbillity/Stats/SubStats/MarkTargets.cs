using DG.Tweening;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats.SubStats
{
	[System.Serializable]
	public class MarkTargets {
		[Header("Spherecast settings")]
        // [SerializeReference] private Transform startPoint;
        [SerializeField] private float _radius;
        [SerializeField] private float _range;
        [SerializeField] private float _rangeOnNoHit;
        [SerializeField] private LayerMask _layerMask;

        // public Transform StartPoint { get => startPoint; }
        public float Radius => _radius;
        public float Range => _range;
        public float RangeOnNoHit => _rangeOnNoHit;
        public LayerMask LayerMask => _layerMask;

        public MarkTargets()
        {
            _radius = 5f;
            _range = 5f;
            _rangeOnNoHit = 20f;
            _layerMask = new LayerMask();
        }
    }
}