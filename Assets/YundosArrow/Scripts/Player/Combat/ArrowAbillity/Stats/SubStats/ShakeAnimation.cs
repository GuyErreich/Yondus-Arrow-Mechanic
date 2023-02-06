using DG.Tweening;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.Stats.SubStats
{
	[System.Serializable]
	public class ShakeAnimation {
		[SerializeField] private float _duration;
        [SerializeField] private Vector3 _strength;
        [SerializeField] private int _vibration;
        [SerializeField] private float _randomness;
        [SerializeField] private bool _snapping;
        [SerializeField] private bool _fadeOut;
        [SerializeField] private ShakeRandomnessMode _randomnessMode;

        public float Duration => _duration;
        public Vector3 Strength => _strength;
        public int Vibration => _vibration;
        public float Randomness => _randomness;
        public bool Snapping => _snapping;
        public bool FadeOut => _fadeOut;
        public ShakeRandomnessMode RandomnessMode => _randomnessMode;

        public ShakeAnimation()
        {
            _duration = 1f;
            _strength = new Vector3(0, 2, 0);
            _vibration = 10;
            _randomness = 90f;
            _snapping = false;
            _fadeOut = true;
            _randomnessMode = ShakeRandomnessMode.Full;
        }
    }
}