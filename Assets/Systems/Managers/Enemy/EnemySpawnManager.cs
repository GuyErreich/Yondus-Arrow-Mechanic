using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Systems.Managers.Enemy
{
    public class EnemySpawnManager : MonoBehaviour 
    {
        [SerializeField] private Transform pref_Enemy;
        [SerializeField] private List<SpawnArea> spawnAreas;
        [SerializeField] private float spawnCooldown = 10f;
        [SerializeField] private LayerMask spawnMask;

        void Start()
        {
            StartCoroutine(StartSpawning());
        }

        private IEnumerator StartSpawning() {
            while (true) {
                foreach (var spawnArea in spawnAreas) {
                    var hits = Physics.OverlapBox(spawnArea.transform.position, spawnArea.transform.lossyScale * 0.5f, spawnArea.transform.rotation, spawnMask);
                    foreach (var hit in hits) {
                        //TODO: Do something....
                    }
                }
            }
        }

        [MenuItem("GameObject/Systems/Managers/Enemy/EnemySpawnManager/Manager")]
        private static void CreateSpawnArea(){
            GameObject go = new GameObject("EnemySpawnManager");
            go.AddComponent<EnemySpawnManager>();
        }
    }
}
