using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.Managers
{
    [System.Serializable]
    struct SpawnArea {
        public Vector3 pos;
        public Vector3 rotation;
        public Vector3 scale;
    }
    public class EnemyPoolManager : MonoBehaviour
    {
        [SerializeField] private Transform pref_Enemy;
        [SerializeField] private List<SpawnArea> spawnAreas;
        [SerializeField] private float spawnCooldown = 10f;

        void Start()
        {
            StartCoroutine(StartSpawning());
        }

        private IEnumerator StartSpawning() {
            while (true) {
                foreach (var spawnArea in spawnAreas) {
                    Physics
                }
                yield return new WaitForSeconds(spawnCooldown);
            }
        }

        private void OnDrawGizmos() {
            foreach (var spawnArea in spawnAreas) {
                Gizmos.matrix = Matrix4x4.TRS(this.transform.localToWorldMatrix.GetPosition(), Quaternion.Euler(spawnArea.rotation), this.transform.localToWorldMatrix.lossyScale);
                Gizmos.color = Color.magenta;
                Gizmos.DrawWireCube(spawnArea.pos, spawnArea.scale);
            }
        }
    }
}
