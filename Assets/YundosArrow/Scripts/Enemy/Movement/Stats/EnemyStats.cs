 using UnityEngine;
 using UnityEngine.AI;

 namespace Assets.YundosArrow.Scripts.Enemy.Movement.Stats
 {
 	[System.Serializable]
 	public class EnemyStats {
		 [SerializeField] private RandomMovemebtStats _randomMovemebtStats;
		 [SerializeField] private FollowStats _followStats;

		 public RandomMovemebtStats RandomMovemebtStats => _randomMovemebtStats;
		 public FollowStats FollowStats => _followStats;
	 }
 }