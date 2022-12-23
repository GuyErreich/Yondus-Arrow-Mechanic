using UnityEngine;
using System.Collections;
// using DG.Tweening;
using YundosArrow.Scripts.Player.Combat.ArrowAbilities;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.States
{
    public class Idle : ArrowState {
        public override IEnumerator On() {
            ArrowStates nextState;
            var anim = StartCoroutine(Actions.Idle.FloatAnimation());
            
            while (true) {
                yield return new WaitForEndOfFrame();

                print("Idle");
                
                if (InputReceiver.Bool[InputReceiverType.ShootPressed]) {
                    nextState = ArrowStates.Attack;
                    break;
                }
            }

            StopCoroutine(anim);

            ChangeState(nextState);
        }
    }
}