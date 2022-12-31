using UnityEngine;
using System.Threading.Tasks;
using YundosArrow.Scripts.Player.Combat.ArrowAbilities.Utils;
using System.Collections.Generic;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.Actions 
{
    public class SyncPathWithMovingTargets {
        public static async void DoSync (List<Transform> targets, LinearArrowPath path) => await Task.Run(() => {
            while (true) {
                for (int i = 0; i < targets.Count; i++) {
                    if (path.StartSegment.start != ArrowStats.StartPoint.position) {
                    }
                }
            }
        });
    }
}