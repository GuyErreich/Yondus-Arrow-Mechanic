using UnityEngine;
using UnityEngine.Events;

namespace YundosArrow.Scripts.Systems.Managers
{
    public class ComboManager : MonoBehaviour, ISerializationCallbackReceiver
    {
        [SerializeField, Min(1)] private float duration = 3f;
        [SerializeField] private int maxNumber = 25;
        [SerializeField] private int dashNumber = 5;
        [SerializeField] private int doubleJumpNumber = 5;

        public int CurrentNumber { get; private set; }

        public int DashNumber
        {
            get => this.dashNumber;
        }

        public int DoubleJumpNumber
        {
            get => this.doubleJumpNumber;
        }

        public UnityEvent onUpdate;
        private float? lastChangeTime;

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
                DontDestroyOnLoad(this.gameObject);
                _instance = this;
            }
            else if (_instance != this)
            {
                Destroy(this.gameObject);
            }
        }

        private void Update()
        {
            if (Instance.lastChangeTime != null)
            {
                if (Time.time - Instance.lastChangeTime >= Instance.duration)
                {
                    Instance.CurrentNumber = 0;
                    Instance.onUpdate?.Invoke();
                    Instance.lastChangeTime = null;
                }
            }
        }

        public void Increase(int amount)
        {
            Instance.CurrentNumber += Mathf.Abs(amount);
            Instance.onUpdate?.Invoke();

            Instance.lastChangeTime = Time.time;
        }

        public void Decrease(int amount)
        {
            Instance.CurrentNumber -= Mathf.Abs(amount);
            Instance.onUpdate?.Invoke();

            Instance.lastChangeTime = Time.time;
        }

        public void OnBeforeSerialize()
        {
            return;
        }

        public void OnAfterDeserialize()
        {
            Instance.dashNumber = Mathf.Clamp(Instance.dashNumber, 0, Instance.maxNumber);
        }
    }
}