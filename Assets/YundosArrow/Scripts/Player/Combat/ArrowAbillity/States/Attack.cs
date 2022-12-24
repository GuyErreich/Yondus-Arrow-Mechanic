using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using YundosArrow.Scripts.Player.Combat.ArrowAbilities.Utils;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.States
{
    public class Attack : ArrowState {
        public override IEnumerator On() {
            TargetsCollection.Points =  new List<Transform>();
            // StartCoroutine()
            while (true) {
                Actions.MarkTargets.Mark();

                yield return new WaitForEndOfFrame();
                print("Attack");
            }
        }

        private void OnDrawGizmos() {
            Actions.MarkTargets.Draw();
        }
    }
}