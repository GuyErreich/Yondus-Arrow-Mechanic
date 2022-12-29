using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace YundosArrow.Scripts.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField] private Transform player;
        private NavMeshAgent agent;

        // Start is called before the first frame update
        private void Awake() {
            this.agent = this.GetComponent<NavMeshAgent>();    
        }

        // Update is called once per frame
        void Update()
        {
            agent.Move(player.position);
        }
    }
}
