 using UnityEngine;
 using UnityEngine.AI;

 namespace Assets.YundosArrow.Scripts.Enemy.Movement.Stats
 {
 	[System.Serializable]
 	public class EnemyStats {
		 [SerializeField] private NavMeshAgent _agent;
		 [SerializeField] private RandomMovemebtStats _randomMovemebtStats;

		 public NavMeshAgent Agent => _agent;
		 public RandomMovemebtStats RandomMovemebtStats => _randomMovemebtStats;

//		 public EnemyStats(NavMeshAgent agent)
//		 {
//			 _agent = agent;
//		 }
	 }
 }