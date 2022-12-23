using UnityEngine;
using System.Collections;
using DG.Tweening;
// using YundosArrow.Scripts.Player.Combat.ArrowAbilities;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.States
{
    public class Attack : ArrowState {
        public override IEnumerator On() {
            while (true) {
                yield return new WaitForEndOfFrame();
                print("Attack");
            }
        }
    }
}