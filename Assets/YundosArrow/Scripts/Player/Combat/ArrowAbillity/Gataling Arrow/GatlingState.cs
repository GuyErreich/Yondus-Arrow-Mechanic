using UnityEngine;
using System.Collections.Generic;
using Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.GatlingArrow.Stats;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.GatlingArrow
{
    public abstract class GatlingState : MonoBehaviour
    {
		public GatlingStats Stats;
		public List<Transition> Transitions = new List<Transition>();

		public abstract void OnStateEnter();
		public abstract void OnStateExit();
    }
}