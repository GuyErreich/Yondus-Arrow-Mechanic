using HomingArrow = Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity.HomingArrow;
using UnityEngine;
using UnityEngine.Events;

public class ArrowMovementSound : MonoBehaviour {
    [SerializeField] private UnityEvent<float> onMove;

    private void Update() {
        onMove.Invoke(HomingArrow.Actions.normalizedPathPos);
    }
}