using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace YundosArrow.Scripts.Systems.Managers
{
    public class ComboManager : MonoBehaviour, ISerializationCallbackReceiver {
        [SerializeField] private int maxNumber;
        [SerializeField] private int dashNumber;

        public int CurrentNumber { get; private set; }
        public int DashNumber { get =>  this.dashNumber; }

        public UnityEvent OnUpdate;

        private static ComboManager instance;
        public static ComboManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<ComboManager>();
                }
                return instance;
            }
        }

        private void Awake()
        {
            if (instance == null)
            {
                DontDestroyOnLoad(this.gameObject);
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(this.gameObject);
            } 
        }

        public void Increase(int amount) {
            Instance.CurrentNumber += Mathf.Abs(amount);
            Instance.OnUpdate?.Invoke();
        }

        public void Decrease(int amount) {
            Instance.CurrentNumber -= Mathf.Abs(amount);
            Instance.OnUpdate?.Invoke();
        }

        [MenuItem("GameObject/Systems/Managers/ComboManager")]
        private static void CreateSpawnArea(){
            GameObject go = new GameObject("ComboManager");
            go.AddComponent<ComboManager>();
        }

        public void OnBeforeSerialize()
        {
            return;
        }

        public void OnAfterDeserialize()
        {
            this.dashNumber = Mathf.Clamp(this.dashNumber, 0, this.maxNumber);
        }
    }
}