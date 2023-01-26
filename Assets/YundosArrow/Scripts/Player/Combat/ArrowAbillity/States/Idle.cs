using UnityEngine;
using System.Collections;
using YundosArrow.Scripts.Player.Combat.ArrowAbilities.Actions;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.States
{
    public class Idle : ArrowState {
        public override IEnumerator On() {
            ArrowStates nextState;

            var anim = StartCoroutine(Actions.Idle.FloatAnimation());
            
            while (true) {
                MarkTargets.Mark();
                // ArrowStats.CrosshairAnim.Close();

                yield return new WaitForEndOfFrame();

                print("Idle");
                
                if (MarkTargets.IsMarked) {
                    nextState = ArrowStates.Attack;
                    break;
                }
            }

            StopCoroutine(anim);

            ChangeState(nextState);
        }

        private void OnDrawGizmos() {
            Actions.MarkTargets.Draw();
        }
    }
}