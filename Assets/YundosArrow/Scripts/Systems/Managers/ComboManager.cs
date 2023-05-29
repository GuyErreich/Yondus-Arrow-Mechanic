using UnityEngine;
using UnityEngine.Events;

namespace Assets.YundosArrow.Scripts.Systems.Managers
{
    public class ComboManager : MonoBehaviour, ISerializationCallbackReceiver
    {
        [Header("Combos Settings")]
        [SerializeField, Min(1)] private float _duration = 3f;
        [SerializeField] private int _maxNumber = 200;
        [SerializeField] private int _dashNumber = 5;
        [SerializeField] private int _doubleJumpNumber = 5;
        [SerializeField] private int _gatlingNumber = 20;
        [Space]
        [Header("Slow Time Settings")]
        [SerializeField, Range(1, 0)] private float _maxTimeSlow = 0.1f;
        [SerializeField] private float _timeChangeSpeed = 20f;
        [SerializeField] private int _numberToStartSlow = 25;
        [SerializeField] private int _numberForFullSlow = 100;


        public UnityEvent OnUpdate;
        private float? _lastChangeTime;

        public int CurrentNumber { get; private set; }
        public float SlowAmount { get; private set; }
        public int DashNumber => _dashNumber;
        public int DoubleJumpNumber => _doubleJumpNumber;
        public int GatlingNumber => _gatlingNumber;
        private static ComboManager _instance;
        private static float _time = 0f;

        public static ComboManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<ComboManager>();
                }

                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                DontDestroyOnLoad(gameObject);
                _instance = this;
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }

            SlowAmount = 1f;
        }

        private void Update()
        {
            ComboSupervisor();
            TimeSpeedSupervisor();
        }

        private void ComboSupervisor()
        {
            if (_instance._lastChangeTime != null)
            {
                if (Time.unscaledTime - _instance._lastChangeTime >= _instance._duration)
                {
                    _instance.CurrentNumber = 0;
                    _instance.OnUpdate?.Invoke();
                    _instance._lastChangeTime = null;
                }
            }
        }

        private void TimeSpeedSupervisor()
        {
            if (CurrentNumber < _numberToStartSlow)
            {
                Time.timeScale = 1f;
                return;
            }

            float range = _numberForFullSlow - _numberToStartSlow;
            float current = CurrentNumber - _numberToStartSlow;
            SlowAmount = Mathf.Clamp(1 - current / range, _maxTimeSlow, 1);
            
            // Time.timeScale = Mathf.Clamp(Mathf.Lerp(Time.timeScale, _maxTimeSlow, _time / _timeChangeSpeed), 0f, 1f);
            // _time += Time.unscaledDeltaTime;
            Time.timeScale = SlowAmount;

            Debug.Log($"Time Scale: {SlowAmount}");
        }

		// private void FadeScale(float fadeTime, float scaleTo)
		// {
		// 	while (Time.timeScale < scaleTo)
		// 	{
		// 		Time.timeScale = Mathf.Clamp(Mathf.Lerp(Time.timeScale, scaleTo, _time / fadeTime), 0f, 1f);
		// 		_time += Time.unscaledDeltaTime;

		// 		yield return new WaitForEndOfFrame();
		// 	}
		// 	Time.timeScale = scaleTo;
		// 	_time = 0;
		// }

        public void Increase(int amount)
        {
            CurrentNumber += Mathf.Abs(amount);
            CurrentNumber = Mathf.Clamp(_instance.CurrentNumber, 0, _maxNumber);
            OnUpdate?.Invoke();

            _lastChangeTime = Time.unscaledTime;
        }

        public void Decrease(int amount)
        {
            _instance.CurrentNumber -= Mathf.Abs(amount);
            CurrentNumber = Mathf.Clamp(_instance.CurrentNumber, 0, _maxNumber);
            _instance.OnUpdate?.Invoke();

            _instance._lastChangeTime = Time.unscaledTime;
        }

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            _dashNumber = Mathf.Clamp(_dashNumber, 0, _maxNumber);
            _numberToStartSlow = Mathf.Clamp(_numberToStartSlow, 0, _maxNumber);
        }
    }
}