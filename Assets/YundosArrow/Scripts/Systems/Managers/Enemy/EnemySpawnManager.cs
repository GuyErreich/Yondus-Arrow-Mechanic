using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Systems.Managers.Enemy
{
    public class EnemySpawnManager : MonoBehaviour 
    {
        [Header("Global")]
        [SerializeField] private Transform _enemiesContainer;
        [SerializeField] private List<SpawnArea> _spawnAreas;
        [Space]
        [Header("Normal Enemy")]
        [SerializeField] private Transform _normalEnemy;
        [SerializeField] private int _normalEnemyAmount = 10;
        [SerializeField] private float __normalEnemyRespawnTime = 10f;
        [Space]
        [Header("Light Speed Enemy")]
        [SerializeField] private Transform _lightSpeedEnemy;
        [SerializeField] private int _lightSpeedEnemyAmount = 10;
        [SerializeField] private float __lightSpeedEnemyRespawnTime = 10f;
        [SerializeField, Range(0f, 1f)] private float _slowAmountToSpawLightSpeed;

        private Queue<Transform> _normalEnemyPool = new Queue<Transform>();
        private Queue<Transform> _lightSpeedEnemyPool = new Queue<Transform>();

        public List<Transform> Enemies { get; private set; }

        private static EnemySpawnManager _instance;
        public static EnemySpawnManager Instance => _instance;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                DontDestroyOnLoad(this.gameObject);
                _instance = this;
            }

			_instance.Init();
        }

        void Start()
        {
            StartCoroutine(_instance.SpawnSupervisor());
        }

        private void Init() {
            Enemies = new List<Transform>();

            CreateEnemies(_normalEnemyAmount, _normalEnemy, _normalEnemyPool);
            CreateEnemies(_lightSpeedEnemyAmount, _lightSpeedEnemy, _lightSpeedEnemyPool);
        }

        private IEnumerator SpawnSupervisor() {
            while (true) {
                if (Enemies.Count < _normalEnemyAmount) {
                    Transform currentEnemy;
                    if(ComboManager.Instance.SlowAmount > _slowAmountToSpawLightSpeed)
                        currentEnemy = _lightSpeedEnemyPool.Dequeue();
                    else
                        currentEnemy = _normalEnemyPool.Dequeue();

                    currentEnemy.position = GetRandomSpawnPoint();
                    // currentEnemy.GetComponent<Health>().OnDeath += this.StashEnemy;
                    currentEnemy.gameObject.SetActive(true);

                    Enemies.Add(currentEnemy);
                }

                yield return new WaitForSecondsRealtime(__normalEnemyRespawnTime);
            }
        }

        private void CreateEnemies(int amount, Transform enemy, Queue<Transform> pool) {
            for (int i = 0; i < amount; i++) {
                var newEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity, _enemiesContainer);
                newEnemy.gameObject.SetActive(false);
                pool.Enqueue(newEnemy);
            }
        }

        //TODO: make it work for to types of enemies
        public void StashEnemy(GameObject currentEnemy) {
            // currentEnemy.GetComponent<Health>().OnDeath -= this.StashEnemy;
            currentEnemy.SetActive(false);

            _instance.Enemies.Remove(currentEnemy.transform);
            _instance._normalEnemyPool.Enqueue(currentEnemy.transform);
        }

        private Vector3 GetRandomSpawnPoint() {
            var spawnIndex = Random.Range(0, _spawnAreas.Count);
            var spawnArea = _spawnAreas[spawnIndex];

            var pointX = Random.Range(spawnArea.transform.lossyScale.x * -0.5f,
                                        spawnArea.transform.lossyScale.x * 0.5f);
            var pointZ = Random.Range(spawnArea.transform.lossyScale.z * -0.5f,
                                        spawnArea.transform.lossyScale.z * 0.5f);
            var pointY = Random.Range(spawnArea.transform.lossyScale.y * -0.5f,
                                        spawnArea.transform.lossyScale.y * 0.5f);

            var spawnPoint = new Vector3(pointX, pointY, pointZ);

            return spawnArea.transform.TransformPoint(spawnPoint);
        }
    }
}