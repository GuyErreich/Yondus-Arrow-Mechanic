using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Systems.Managers.Enemy
{
    public class EnemySpawnManager : MonoBehaviour 
    {
        [SerializeField] private Transform _enemy;
        [SerializeField] private Transform _enemiesContainer;
        [SerializeField] private List<SpawnArea> _spawnAreas;
        [SerializeField] private int _amount = 10;
        [SerializeField] private float _respawnTime = 10f;
        [SerializeField] private LayerMask _spawnMask;

        private Queue<Transform> _enemiesPool = new Queue<Transform>();

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
            _instance.Enemies = new List<Transform>();

            for (int i = 0; i < _instance._amount; i++) {
                var newEnemy = Instantiate(_instance._enemy, Vector3.zero, Quaternion.identity, _instance._enemiesContainer);
                newEnemy.position = Vector3.zero;
                newEnemy.rotation = Quaternion.identity;
                _instance._enemy.gameObject.SetActive(false);
                _instance._enemiesPool.Enqueue(newEnemy);
            }
        }

        private IEnumerator SpawnSupervisor() {
            while (true) {
                if (_instance.Enemies.Count < _instance._amount) {
                    var currentEnemy = _instance._enemiesPool.Dequeue();
                    currentEnemy.position = _instance.GetRandomSpawnPoint();
                    // currentEnemy.GetComponent<Health>().OnDeath += this.StashEnemy;
                    currentEnemy.gameObject.SetActive(true);

                    _instance.Enemies.Add(currentEnemy);
                }

                yield return new WaitForSecondsRealtime(_respawnTime);
            }
        }

        public void StashEnemy(GameObject currentEnemy) {
            // currentEnemy.GetComponent<Health>().OnDeath -= this.StashEnemy;
            currentEnemy.SetActive(false);

            _instance.Enemies.Remove(currentEnemy.transform);
            _instance._enemiesPool.Enqueue(currentEnemy.transform);
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