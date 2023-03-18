using Assets.YundosArrow.Scripts.Systems.Managers.Enemy;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.YundosArrow.Scripts.Enemy
{
    public class FollowTarget : MonoBehaviour, ISerializationCallbackReceiver
    {
		[SerializeField, Range(0, 10)] private float _minMoveTime = 2f;
		[SerializeField, Range(0, 10)] private float _maxMoveTime = 2f;
		[SerializeField] private float _moveRadius = 2f;
		[Space]
		[SerializeField] private float _scanRadius = 200f;
		[SerializeField] private float _avoidanceRadius = 2f;
		[SerializeField] private LayerMask _layerMask;

        private NavMeshAgent _agent;
        private float _timeCounter = 0f;
		private Vector3 _currentDestination;
		private Vector3 _nextDestination;
		private bool _isFollowingTarget = false;
		private bool _isUnderling = false;


        private void Awake() {
			_agent = GetComponent<NavMeshAgent>();
			_currentDestination = _nextDestination = Vector3.zero;
        }

		private void OnEnable()
		{
			_isUnderling = Random.Range(0, 10) > 7;
		}

        // Update is called once per frame
        void Update()
        {
			ScanFollowTargets();
			if (!_isFollowingTarget)
				RandomMovement();

			if (_nextDestination != _currentDestination)
			{
				_currentDestination = _nextDestination;
				_agent.SetDestination(_currentDestination);
			}
        }

        private void RandomMovement() {
			_timeCounter += Time.deltaTime;
			NavMeshHit hit;

			if (_timeCounter >= Random.Range(_minMoveTime, _maxMoveTime))
            {
				_timeCounter = 0f;
				Vector3 randomDirection = Random.insideUnitSphere * _moveRadius;
                randomDirection += transform.position;
				NavMesh.SamplePosition(randomDirection, out hit, _moveRadius, 1);
				_nextDestination = hit.position;
            }
			else if (_agent.remainingDistance <= 0f)
			{
				_timeCounter = 0f;
				Vector3 randomDirection = Random.insideUnitSphere * _moveRadius;
				randomDirection += transform.position;
				NavMesh.SamplePosition(randomDirection, out hit, _moveRadius, 1);
				_nextDestination = hit.position;
			}
        }

		private void ScanFollowTargets()
		{
			var hits = Physics.OverlapSphere(transform.position, _scanRadius, _layerMask, QueryTriggerInteraction.Collide);
			foreach (var hit in hits) {
				if (hit.CompareTag("Player"))
				{
					Debug.Log("following player");
					_nextDestination = hit.gameObject.transform.position;

					_isFollowingTarget = true;
					return;
				}
				if (_isUnderling && hit.CompareTag("Enemy"))
				{
					Debug.Log("following Enemy");
					_nextDestination = hit.gameObject.transform.position;

					// _isFollowingTarget = true;
					return;
				}
			}

			_isFollowingTarget = false;
		}

		 void OnTriggerStay(Collider other)
		 {
//			 if (!other.gameObject.CompareTag("Player"))
//			 {
			 Vector3 avoidanceDirection = transform.position - other.transform.position;
			 _agent.Move(avoidanceDirection.normalized * _avoidanceRadius / avoidanceDirection.magnitude);
//			 }
		 }

		public void OnBeforeSerialize() {}

        public void OnAfterDeserialize()
        {
			_minMoveTime = Mathf.Clamp(_minMoveTime, 0, _maxMoveTime);
			_maxMoveTime = Mathf.Clamp(_maxMoveTime, _minMoveTime, 10);
		}

		private void OnDrawGizmos()
		{
			Gizmos.matrix = transform.localToWorldMatrix;
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(Vector3.zero, _scanRadius);
		}
    }
}