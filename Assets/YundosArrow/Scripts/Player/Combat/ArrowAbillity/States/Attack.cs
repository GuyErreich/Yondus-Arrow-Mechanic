using UnityEngine;
using System.Collections;
using YundosArrow.Scripts.Player.Combat.ArrowAbilities.Actions;
using YundosArrow.Scripts.Player.Combat.ArrowAbilities.Utils;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.States
{
    public class Attack : ArrowState {
        public override IEnumerator On() {
            ArrowStates nextState;

            var shoot = StartCoroutine(ArrowMovement.Move());

            while (true) {
                MarkTargets.Mark();
                ArrowStats.CrosshairAnim.Open();

                yield return new WaitForEndOfFrame();

                print("Attack");
                
                if (!ArrowMovement.IsMoving) {
                    nextState = ArrowStates.Idle;
                    break;
                }
            }

            StopCoroutine(shoot);

            ChangeState(nextState);
        }

        private void OnDrawGizmos() {
            Actions.MarkTargets.Draw();
        }
    }
}