using UnityEditor;
using UnityEngine;

namespace YundosArrow.Scripts.Systems.Managers.Enemy
{
    public class SpawnArea : MonoBehaviour {
        private void OnDrawGizmos() { 
            Gizmos.matrix = this.transform.localToWorldMatrix;
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireCube(Vector3.zero, this.transform.lossyScale);
        }
    }
}