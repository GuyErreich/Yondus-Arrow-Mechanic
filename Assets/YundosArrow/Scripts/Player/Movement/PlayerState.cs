using System.Collections.Generic;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Movement
{
    public abstract class PlayerState
    {
		private PlayerController _playerController;
		protected static Vector3 _direction;
		protected static float _speed;

		public List<Transition> Transitions = new List<Transition>();

		public PlayerState(PlayerController playerController, CharacterController characterController) {
			_playerController = playerController;
			Actions.CharController = characterController;
		}

		public abstract void Update();
		public abstract void OnStateEnter();
		public abstract void OnStateExit();
    }
}