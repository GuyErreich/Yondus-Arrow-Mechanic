using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using YundosArrow.Scripts.UI.HealthBars;

namespace YundosArrow.Scripts.Systems.Managers.Enemy
{
    public class EnemyManager : MonoBehaviour {
        [SerializeField] private Transform player;
        [SerializeField] private Transform healthBar;
        [SerializeField] private Transform healthBarsContainer;

        private Queue<DynamicHealthBar> healthBarsPool = new Queue<DynamicHealthBar>();
        
        public Transform Player { get => player; }

        public DynamicHealthBar HealthBar { 
            get {
                if (Instance.healthBarsPool == null || Instance.healthBarsPool.Count == 0)
                    return Instantiate(Instance.healthBar, Instance.healthBarsContainer).GetComponent<DynamicHealthBar>();
                else 
                    return Instance.healthBarsPool.Dequeue();
            }

            set {
                if (value.GetComponent<DynamicHealthBar>() != null)
                    Instance.healthBarsPool.Enqueue(value);
                else
                    throw new System.TypeLoadException("You can only set Transform type to HealthBar");
            }            
        }

        private static EnemyManager instance;

        public static EnemyManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<EnemyManager>();
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

        [MenuItem("GameObject/Systems/Managers/Enemy/EnemyManager")]
        private static void CreateSpawnArea(){
            GameObject go = new GameObject("EnemyManager");
            go.AddComponent<EnemyManager>();
        }

    }
}