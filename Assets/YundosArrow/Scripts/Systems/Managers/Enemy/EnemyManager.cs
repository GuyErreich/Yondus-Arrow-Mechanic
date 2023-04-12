using System.Collections.Generic;
using UnityEngine;
using YundosArrow.Scripts.UI.HealthBars;

namespace Assets.YundosArrow.Scripts.Systems.Managers.Enemy
{
    public class EnemyManager : MonoBehaviour {
        [SerializeField] private Transform _player;
        [SerializeField] private Transform _healthBar;
        [SerializeField] private Transform _healthBarsContainer;

        private Queue<DynamicHealthBar> _healthBarsPool = new Queue<DynamicHealthBar>();
        
        public Transform Player => _player;

        public DynamicHealthBar HealthBar {
            get {
                if (_instance._healthBarsPool == null || _instance._healthBarsPool.Count == 0)
                    return Instantiate(_instance._healthBar, _instance._healthBarsContainer).GetComponent<DynamicHealthBar>();
                else
                    return _instance._healthBarsPool.Dequeue();
            }

            set {
                if (value.GetComponent<DynamicHealthBar>() != null)
                    _instance._healthBarsPool.Enqueue(value);
                else
                    throw new System.TypeLoadException("You can only set Transform type to HealthBar");
            }
        }

        private static EnemyManager _instance;

        public static EnemyManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<EnemyManager>();
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
    }
}