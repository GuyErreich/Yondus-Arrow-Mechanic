using UnityEngine;
using DG.Tweening;
using System.Collections;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.Actions
{
    public class Idle {
        public static IEnumerator FloatAnimation() {
            while (true) {
                ArrowStats.Arrow.DOShakePosition(
                    ArrowStats.IdleStats.Duration,
                    ArrowStats.IdleStats.Strength,
                    ArrowStats.IdleStats.Vibration,
                    ArrowStats.IdleStats.Randomness,
                    ArrowStats.IdleStats.Snapping,
                    ArrowStats.IdleStats.FadeOut,
                    ArrowStats.IdleStats.RandomnessMode
                );

                yield return new WaitForSeconds(ArrowStats.IdleStats.Duration);
            }
        }
    }
}