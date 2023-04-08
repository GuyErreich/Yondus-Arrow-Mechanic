using UnityEngine;
using UnityEngine.AI;

namespace Assets.YundosArrow.Scripts.Enemy.Movement.Stats
{
    [System.Serializable]
    public class EnemyStats
    {
        [SerializeField] private Animator _anim;
        [SerializeField] private RandomMovemebtStats _randomMovemebtStats;
        [SerializeField] private FollowStats _followStats;

        public NavMeshAgent Agent { get; set; }
        public CharacterController CharacterController { get; set; }

        public Animator Anim => _anim;
        public RandomMovemebtStats RandomMovemebtStats => _randomMovemebtStats;
        public FollowStats FollowStats => _followStats;
    }
}