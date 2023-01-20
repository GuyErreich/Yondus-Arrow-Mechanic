using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using YundosArrow.Scripts.Systems.Managers.Enemy;

public class FollowTarget : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Awake() {
        this.agent = this.GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        this.agent.destination = EnemyManager.Instance.Player.position;
    }
}
