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

		public UnityEvent OnUpdate;
        private float? _lastChangeTime;

        public int CurrentNumber { get; private set; }
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
            if (_instance._lastChangeTime != null)
            {
                if (Time.time - _instance._lastChangeTime >= _instance._duration)
                {
                    _instance.CurrentNumber = 0;
                    _instance.OnUpdate?.Invoke();
                    _instance._lastChangeTime = null;
                }
            }
        }

        public void Increase(int amount)
        {
            _instance.CurrentNumber += Mathf.Abs(amount);
            _instance.OnUpdate?.Invoke();

            _instance._lastChangeTime = Time.time;
        }

        public void Decrease(int amount)
        {
            _instance.CurrentNumber -= Mathf.Abs(amount);
            _instance.OnUpdate?.Invoke();

            _instance._lastChangeTime = Time.time;
        }

        public void OnBeforeSerialize() {
        }

        public void OnAfterDeserialize()
        {
            _dashNumber = Mathf.Clamp(_dashNumber, 0, _maxNumber);
        }
    }
}