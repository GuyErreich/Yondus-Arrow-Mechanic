using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Systems.Managers.Enemy
{
    public class EnemySpawnManager : MonoBehaviour 
    {
        [SerializeField] private Transform enemiesContainer;
        [SerializeField] private GameObject pref_Enemy;
        [SerializeField] private List<SpawnArea> spawnAreas;
        [SerializeField] private int amount = 10;
        [SerializeField] private float respawnTime = 10f;
        [SerializeField] private LayerMask spawnMask;

        private static List<Transform> enemies;
        private static Queue<Transform> enemiesPool;

        void Start()
        {
            enemies = new List<Transform>();
            enemiesPool = new Queue<Transform>();

            for (int i = 0; i < this.amount; i++) {
                GameObject enemy = Instantiate(this.pref_Enemy);
                enemy.transform.SetParent(enemiesContainer);
                enemy.SetActive(false);
                enemiesPool.Enqueue(enemy.transform);
            }

            StartCoroutine(this.StartSpawning());
        }

        private IEnumerator StartSpawning() {
            while (true) {
                if (enemies.Count < this.amount) {
                    var enemy = enemiesPool.Dequeue();

                    var spawnIndex = Random.Range(0, spawnAreas.Count);
                    var spawnArea = spawnAreas[spawnIndex];

                    var pointX = Random.Range(spawnArea.transform.lossyScale.x * -0.5f,
                                                spawnArea.transform.lossyScale.x * 0.5f);
                    var pointZ = Random.Range(spawnArea.transform.lossyScale.z * -0.5f,
                                                spawnArea.transform.lossyScale.z * 0.5f);

                    var spawnPoint = new Vector3(pointX, spawnArea.transform.position.y, pointZ);

                    enemy.gameObject.SetActive(true);
                    enemy.transform.position = spawnArea.transform.TransformPoint(spawnPoint);

                    enemies.Add(enemy);

                    yield return new WaitForSeconds(respawnTime);
                }

                yield return new WaitForEndOfFrame();
            }
        }

        [MenuItem("GameObject/Systems/Managers/Enemy/EnemySpawnManager/Manager")]
        private static void CreateSpawnArea(){
            GameObject go = new GameObject("EnemySpawnManager");
            go.AddComponent<EnemySpawnManager>();
        }
    }
}
