using UnityEngine;
using System.Collections.Generic;

namespace Assets.YundosArrow.Scripts.Player.Input
{
    public enum InputReceiverType {
        Movement = 0,
        SmoothMovement,
        RunPressed,
        JumpPressed,
		DashPressed,
        ShootPressed,
        AimPressed,

    }

	public static class InputReceiver
    {
        public static Dictionary<InputReceiverType, Vector2> Vector2 { get; private set; }
        public static Dictionary<InputReceiverType, bool> Bool { get; private set; }

        static InputReceiver() {
            Vector2 = new Dictionary<InputReceiverType, Vector2>() {
                {InputReceiverType.Movement, UnityEngine.Vector2.zero},
                {InputReceiverType.SmoothMovement, UnityEngine.Vector2.zero}
            };

            Bool = new Dictionary<InputReceiverType, bool>() {
                {InputReceiverType.RunPressed, false},
                {InputReceiverType.JumpPressed, false},
				{InputReceiverType.DashPressed, false},
				{InputReceiverType.ShootPressed, false},
                {InputReceiverType.AimPressed, false}
            };
        }

        public static void Receive(Dictionary<InputReceiverType, Vector2> inputsVector2,
                                    Dictionary<InputReceiverType, bool> inputsBool)
        {
            foreach (var input in inputsVector2) {
                Vector2[input.Key] = input.Value;
            }

            foreach (var input in inputsBool) {
                Bool[input.Key] = input.Value;
            }
        }
    }
}