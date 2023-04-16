using UnityEngine;
using UnityEngine.Events;

namespace Assets.YundosArrow.Scripts.Systems.Managers
{
    public class ComboManager : MonoBehaviour, ISerializationCallbackReceiver
    {
        [SerializeField, Min(1)] private float _duration = 3f;
        [SerializeField] private int _maxNumber = 25;
        [SerializeField] private int _dashNumber = 5;
        [SerializeField] private int _doubleJumpNumber = 5;

        [SerializeField, Range(1, 0)] private float _maxTimeSlow = 0.1f;
        [SerializeField] private float _timeChangeSpeed = 20f;
        [SerializeField] private int _numberToStartSlow = 25;


        public UnityEvent OnUpdate;
        private float? _lastChangeTime;

        public int CurrentNumber { get; private set; }
        public float SlowAmount => Mathf.Clamp(1 - ((CurrentNumber - _numberToStartSlow) / (_maxNumber - _numberToStartSlow)), _maxTimeSlow, 1);
        public int DashNumber => _dashNumber;
        public int DoubleJumpNumber => _doubleJumpNumber;
        private static ComboManager _instance;

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

            float range = _maxNumber - _numberToStartSlow;
            float current = CurrentNumber - _numberToStartSlow;

            Time.timeScale = SlowAmount;

            Debug.Log(1 - current / range);
        }

		// public void FadeScale(float fadeTime, float scaleTo)
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