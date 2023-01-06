using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace YundosArrow.Scripts.Systems.Managers.Enemy
{
    public class EnemyManager : MonoBehaviour {
        [SerializeField] private Transform player;

        private static EnemyManager instance;

        public static EnemyManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<EnemyManager>();
                }
                return instance;
            }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(this.gameObject);
            }
            
            DontDestroyOnLoad(this.gameObject);
        }

        private void Start() {
            StartCoroutine(MovementSupervisor());
        }

        private static IEnumerator MovementSupervisor() {
            while (true) {
                foreach(var enemy in EnemySpawnManager.Enemies) {
                    var agent = enemy.GetComponent<NavMeshAgent>();
                    agent.destination = Instance.player.position;
                }

                yield return new WaitForEndOfFrame();
            }
        }

        private void OnDrawGizmos() { 
            Gizmos.matrix = this.transform.localToWorldMatrix;
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireCube(Vector3.zero, this.transform.lossyScale);
        }

        [MenuItem("GameObject/Systems/Managers/Enemy/EnemyManager")]
        private static void CreateSpawnArea(){
            GameObject go = new GameObject("EnemyManager");
            go.AddComponent<EnemyManager>();
        }
    }
}