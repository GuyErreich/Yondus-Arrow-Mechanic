using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using Assets.YundosArrow.Scripts.Systems.Managers.Enemy;
using System.Collections.Generic;

namespace Assets.YundosArrow.Scripts.Enemy {
    [RequireComponent(typeof(BoxCollider))]
    public class HitBox : MonoBehaviour {
        public UnityEvent<float> OnHit;

        private void OnEnable() {
			GetComponent<Collider>().enabled = true;
        }

        public void Hit(float amount) {
            Debug.Log($"amount: {amount}");
            OnHit?.Invoke(amount);
        }
    }
}