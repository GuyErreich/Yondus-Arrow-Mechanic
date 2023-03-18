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

		// private void ScanFollowTargets()
		// {
		// 	var hits = Physics.OverlapSphere(transform.position, _scanRadius, _layerMask, QueryTriggerInteraction.Collide);
		// 	foreach (var hit in hits) {
		// 		if (!_isUnderling && hit.CompareTag("Player"))
		// 		{
		// 			Debug.Log("following player");
		// 			_nextDestination = hit.gameObject.transform.position;

		// 			_isFollowingTarget = true;
		// 			return;
		// 		}
		// 		if (_isUnderling && hit.CompareTag("Enemy"))
		// 		{
		// 			Debug.Log("following Enemy");
		// 			_nextDestination = hit.gameObject.transform.position;

		// 			// _isFollowingTarget = true;
		// 			return;
		// 		}
		// 	}

		// 	_isFollowingTarget = false;
		// }
	}
}
