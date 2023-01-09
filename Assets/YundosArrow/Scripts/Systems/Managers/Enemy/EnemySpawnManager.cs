using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using YundosArrow.Scripts.Systems;
using YundosArrow.Scripts.UI.HealthBars;

namespace YundosArrow.Scripts.Systems.Managers.Enemy
{
    public class EnemySpawnManager : MonoBehaviour 
    {
        [SerializeField] private Transform enemy;
        [SerializeField] private Transform enemiesContainer;
        [SerializeField] private Transform healthBar;
        [SerializeField] private Transform healthBarsContainer;

        [SerializeField] private List<SpawnArea> spawnAreas;
        [SerializeField] private int amount = 10;
        [SerializeField] private float respawnTime = 10f;
        [SerializeField] private LayerMask spawnMask;

        private Queue<Transform> enemiesPool = new Queue<Transform>();
        private Queue<Transform> healthBarsPool = new Queue<Transform>();

        public List<Transform> Enemies { get; private set; }
        public Dictionary<Transform, Transform> HealthBars { get; private set; }

        private static EnemySpawnManager instance;
        public static EnemySpawnManager Instance { get => instance; }

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);

                this.Init();
            }
        }

        void Start()
        {
            StartCoroutine(Instance.StartSpawning());
        }

        private void Init() {
            Instance.Enemies = new List<Transform>();
            Instance.HealthBars = new Dictionary<Transform, Transform>();

            for (int i = 0; i < Instance.amount; i++) {
                var newEnemy = Instantiate(Instance.enemy, Vector3.zero, Quaternion.identity, Instance.enemiesContainer);
                newEnemy.position = Vector3.zero;
                newEnemy.rotation = Quaternion.identity;
                enemy.gameObject.SetActive(false);
                enemiesPool.Enqueue(newEnemy);

                var newHealthBar = Instantiate(Instance.healthBar,Instance.healthBarsContainer);
                newHealthBar.position = Vector3.zero;
                newHealthBar.rotation = Quaternion.identity;
                newHealthBar.gameObject.SetActive(false);
                healthBarsPool.Enqueue(newHealthBar);
            }
        }

        private IEnumerator StartSpawning() {
            while (true) {
                if (Instance.Enemies.Count < Instance.amount) {
                    var enemy = Instance.enemiesPool.Dequeue();
                    enemy.position = Instance.GetRandomSpawnPoint();
                    enemy.gameObject.SetActive(true);

                    if (Instance.HealthBars.Count < Instance.amount) {
                        var healthBar = Instance.healthBarsPool.Dequeue();
                        healthBar.GetComponent<DynamicHealthBar>().Target = enemy;
                        enemy.GetComponent<Health>().OnHealthChanged += healthBar.GetComponent<DynamicHealthBar>().HandleHealthChanged;
                        healthBar.gameObject.SetActive(true);
                        HealthBars.Add(enemy, healthBar);
                    }

                    Enemies.Add(enemy);

                    yield return new WaitForSeconds(respawnTime);
                }

                yield return new WaitForEndOfFrame();
            }
        }

        private Vector3 GetRandomSpawnPoint() {
            var spawnIndex = Random.Range(0, spawnAreas.Count);
            var spawnArea = spawnAreas[spawnIndex];

            var pointX = Random.Range(spawnArea.transform.lossyScale.x * -0.5f,
                                        spawnArea.transform.lossyScale.x * 0.5f);
            var pointZ = Random.Range(spawnArea.transform.lossyScale.z * -0.5f,
                                        spawnArea.transform.lossyScale.z * 0.5f);

            var spawnPoint = new Vector3(pointX, spawnArea.transform.position.y, pointZ);

            return spawnArea.transform.TransformPoint(spawnPoint);
        }

        [MenuItem("GameObject/Systems/Managers/Enemy/EnemySpawnManager/Manager")]
        private static void CreateSpawnArea(){
            GameObject go = new GameObject("EnemySpawnManager");
            go.AddComponent<EnemySpawnManager>();
        }
    }
}