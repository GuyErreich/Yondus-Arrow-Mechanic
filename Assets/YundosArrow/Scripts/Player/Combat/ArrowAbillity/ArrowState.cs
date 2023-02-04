using System.Collections.Generic;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity
{
    public abstract class ArrowState
    {
		private ArrowController _arrowController;
		protected static Vector3 _direction;
		protected static float _speed;

		public List<Transition> Transitions = new List<Transition>();

		public ArrowState(ArrowController playerController) {
			_arrowController = playerController;
		}

		public abstract void Update();
		public abstract void OnStateEnter();
		public abstract void OnStateExit();
    }
}