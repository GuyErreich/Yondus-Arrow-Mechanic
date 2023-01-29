using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace YundosArrow.Scripts.Systems.Managers
{
    public class ComboManager : MonoBehaviour {
        public int Number { get; private set; }

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
            Instance.Number += Mathf.Abs(amount);
            Instance.OnUpdate?.Invoke();
        }

        public void Decrease(int amount) {
            Instance.Number -= Mathf.Abs(amount);
            Instance.OnUpdate?.Invoke();
        }

        [MenuItem("GameObject/Systems/Managers/ComboManager")]
        private static void CreateSpawnArea(){
            GameObject go = new GameObject("ComboManager");
            go.AddComponent<ComboManager>();
        }

    }
}