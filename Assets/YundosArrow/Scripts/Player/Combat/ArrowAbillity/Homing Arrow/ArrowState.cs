using System.Collections.Generic;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow.Stats;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow
{
    public abstract class ArrowState
    {
//		private ArrowController _arrowController;
		protected ArrowStats ArrowStats;

		public List<Transition> Transitions = new List<Transition>();

		public ArrowState(ArrowController arrowController) {
//			_arrowController = arrowController;
			ArrowStats = arrowController.ArrowStats;
			Actions.ArrowStats = arrowController.ArrowStats;
			Actions.Player = arrowController.transform;
		}

		public abstract void Update();
		public abstract void OnStateEnter();
		public abstract void OnStateExit();
    }
}