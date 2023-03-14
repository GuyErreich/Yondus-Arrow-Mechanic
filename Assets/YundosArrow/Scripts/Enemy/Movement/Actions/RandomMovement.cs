using UnityEngine;
using UnityEngine.AI;

namespace Assets.YundosArrow.Scripts.Enemy.Movement
{
	public partial class Actions
	{
//		[Space]
//		[SerializeField] private float _scanRadius = 200f;
//		[SerializeField] private float _avoidanceRadius = 2f;
//		[SerializeField] private LayerMask _layerMask;

		public static Vector3 RandomMovement(Vector3 position, float moveRadius) {
			Vector3 randomDirection = Random.insideUnitSphere * moveRadius;
			randomDirection += position;
			NavMesh.SamplePosition(randomDirection,out var hit, moveRadius, 1);
			return hit.position;
		}
	}
}
