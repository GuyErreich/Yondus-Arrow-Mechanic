using UnityEditor;
using UnityEngine;

namespace Systems.Managers.Enemy
{
    public class EnemyManager : MonoBehaviour {
        [MenuItem("GameObject/Systems/Managers/Enemy/EnemyManager")]
        private static void CreateSpawnArea(){
            GameObject go = new GameObject("EnemyManager");
            go.AddComponent<SpawnArea>();
        }

        private void OnDrawGizmos() { 
            Gizmos.matrix = this.transform.localToWorldMatrix;
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireCube(Vector3.zero, this.transform.lossyScale);
        }


    }
}