using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using YundosArrow.Scripts.Player.Combat.ArrowAbilities.Utils;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.States
{
    public class Attack : ArrowState {
        public override IEnumerator On() {
            yield return StartCoroutine(Actions.ArrowMovement.Move());
            // while (true) {
            //     Actions.MarkTargets.Mark();
            //     yield return new WaitForEndOfFrame();
            // }

            ChangeState(ArrowStates.Idle);
        }

        private void OnDrawGizmos() {
            Actions.MarkTargets.Draw();
        }
    }
}