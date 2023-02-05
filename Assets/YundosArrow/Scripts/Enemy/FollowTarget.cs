using Assets.YundosArrow.Scripts.Systems.Managers.Enemy;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.YundosArrow.Scripts.Enemy
{
    public class FollowTarget : MonoBehaviour
    {
        private NavMeshAgent _agent;

        private void Awake() {
            _agent = GetComponent<NavMeshAgent>();
        }
        // Update is called once per frame
        void Update()
        {
            _agent.destination = EnemyManager.Instance.Player.position;
        }
    }
}
