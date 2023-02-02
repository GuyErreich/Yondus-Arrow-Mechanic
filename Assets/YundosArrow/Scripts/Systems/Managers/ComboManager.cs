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
        public int DashNumber
        {
            get => _dashNumber;
        }
        public int DoubleJumpNumber
        {
            get => _doubleJumpNumber;
        }

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
            if (Instance._lastChangeTime != null)
            {
                if (Time.time - Instance._lastChangeTime >= Instance._duration)
                {
                    Instance.CurrentNumber = 0;
                    Instance.OnUpdate?.Invoke();
                    Instance._lastChangeTime = null;
                }
            }
        }

        public void Increase(int amount)
        {
            Instance.CurrentNumber += Mathf.Abs(amount);
            Instance.OnUpdate?.Invoke();

            Instance._lastChangeTime = Time.time;
        }

        public void Decrease(int amount)
        {
            Instance.CurrentNumber -= Mathf.Abs(amount);
            Instance.OnUpdate?.Invoke();

            Instance._lastChangeTime = Time.time;
        }

        public void OnBeforeSerialize() {}

        public void OnAfterDeserialize()
        {
            _dashNumber = Mathf.Clamp(Instance._dashNumber, 0, Instance._maxNumber);
        }
    }
}