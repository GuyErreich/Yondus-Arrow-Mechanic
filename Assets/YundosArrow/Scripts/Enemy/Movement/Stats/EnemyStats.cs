using UnityEngine;
using UnityEngine.AI;

namespace Assets.YundosArrow.Scripts.Enemy.Movement.Stats
{
    [System.Serializable]
    public class EnemyStats
    {
        [SerializeField] private string _enemyID;
        [SerializeField] private Animator _anim;
        [SerializeField] private bool _isUnsacledTime = false;
        [SerializeField] private RandomMovemebtStats _randomMovemebtStats;
        [SerializeField] private FollowStats _followStats;
        [SerializeField] private JumpStats _jumpStats;

        public NavMeshAgent Agent { get; set; }
        public CharacterController CharacterController { get; set; }

        public string EnemyID => _enemyID;
        public Animator Anim => _anim;
        public bool IsUnsacledTime => _isUnsacledTime;
        public RandomMovemebtStats RandomMovemebtStats => _randomMovemebtStats;
        public FollowStats FollowStats => _followStats;
        public JumpStats JumpStats => _jumpStats;
        
    }
}