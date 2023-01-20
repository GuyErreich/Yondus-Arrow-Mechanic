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

        [SerializeField] private List<SpawnArea> spawnAreas;
        [SerializeField] private int amount = 10;
        [SerializeField] private float respawnTime = 10f;
        [SerializeField] private LayerMask spawnMask;

        private Queue<Transform> enemiesPool = new Queue<Transform>();

        public List<Transform> Enemies { get; private set; }

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
                DontDestroyOnLoad(this.gameObject);
                instance = this;
            }

            Instance.Init();
        }

        void Start()
        {
            StartCoroutine(Instance.SpawnSupervisor());
        }

        private void Init() {
            Instance.Enemies = new List<Transform>();

            for (int i = 0; i < Instance.amount; i++) {
                var newEnemy = Instantiate(Instance.enemy, Vector3.zero, Quaternion.identity, Instance.enemiesContainer);
                newEnemy.position = Vector3.zero;
                newEnemy.rotation = Quaternion.identity;
                Instance.enemy.gameObject.SetActive(false);
                Instance.enemiesPool.Enqueue(newEnemy);
            }
        }

        private IEnumerator SpawnSupervisor() {
            while (true) {
                if (Instance.Enemies.Count < Instance.amount) {
                    var currentEnemy = Instance.enemiesPool.Dequeue();
                    currentEnemy.position = Instance.GetRandomSpawnPoint();
                    currentEnemy.GetComponent<Health>().OnDeath += this.StashEnemy;
                    currentEnemy.gameObject.SetActive(true);

                    Instance.Enemies.Add(currentEnemy);
                }

                yield return new WaitForSeconds(respawnTime);
            }
        }

        public void StashEnemy(GameObject currentEnemy) {
            currentEnemy.GetComponent<Health>().OnDeath -= this.StashEnemy;
            currentEnemy.SetActive(false);

            Instance.Enemies.Remove(currentEnemy.transform);
            Instance.enemiesPool.Enqueue(currentEnemy.transform);
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