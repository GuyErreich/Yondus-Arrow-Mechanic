using UnityEditor;
using UnityEngine;

namespace Systems.Managers.Enemy
{
    public class SpawnArea : MonoBehaviour {
        [MenuItem("GameObject/Systems/Managers/Enemy/EnemySpawnManager/SpawnArea")]
        private static void CreateSpawnArea(){
            GameObject go = new GameObject("SpawnArea");
            go.AddComponent<SpawnArea>();
        }

        private void OnDrawGizmos() { 
            Gizmos.matrix = this.transform.localToWorldMatrix;
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireCube(Vector3.zero, this.transform.lossyScale);
        }


    }
}