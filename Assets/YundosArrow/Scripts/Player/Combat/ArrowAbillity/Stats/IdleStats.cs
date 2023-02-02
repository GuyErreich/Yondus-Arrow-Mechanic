//using DG.Tweening;
//using UnityEngine;
//
//namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.Stats
//{
//	[System.Serializable]
//	public class IdleStats {
//		[Header("Move")]
//		[SerializeField] private float duration;
//        [SerializeField] private Vector3 strength;
//        [SerializeField] private int vibration;
//        [SerializeField] private float randomness;
//        [SerializeField] private bool snapping;
//        [SerializeField] private bool fadeOut;
//        [SerializeField] private ShakeRandomnessMode randomnessMode;
//
//        public float Duration { get => duration; }
//        public Vector3 Strength { get => strength; }
//        public int Vibration { get => vibration; }
//        public float Randomness { get => randomness; }
//        public bool Snapping { get => snapping; }
//        public bool FadeOut { get => fadeOut; }
//        public ShakeRandomnessMode RandomnessMode { get => randomnessMode; }
//
//        public IdleStats()
//        {
//            this.duration = 1f;
//            this.strength = new Vector3(0, 2, 0);
//            this.vibration = 10;
//            this.randomness = 90f;
//            this.snapping = false;
//            this.fadeOut = true;
//            this.randomnessMode = ShakeRandomnessMode.Full;
//        }
//
//        public IdleStats(float duration, Vector3 strength, int vibration, float randomness, bool snapping, bool fadeOut, ShakeRandomnessMode randomnessMode)
//        {
//            this.duration = duration;
//            this.strength = strength;
//            this.vibration = vibration;
//            this.randomness = randomness;
//            this.snapping = snapping;
//            this.fadeOut = fadeOut;
//            this.randomnessMode = randomnessMode;
//        }
//    }
//}