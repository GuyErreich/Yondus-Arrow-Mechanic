using UnityEngine;
using Assets.YundosArrow.Scripts.Player.Combat;
using UnityEngine.Events;

namespace Assets.YundosArrow.Scripts.Systems.Managers {
    public class GameManager : MonoBehaviour {
        [SerializeField] private Health _playerHealth;
        [SerializeField] private UnityEvent _onGameOver;

        private bool isPlaying;

        private void Start() {
            isPlaying = true;
        }

        private void Update() {
            if (_playerHealth.CurrentHealth <= 0 && isPlaying) {
                Time.timeScale = 0f;
                isPlaying = false;
                _onGameOver.Invoke();
            }

        }
    }
}