using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.Utils
{
    public static class GlobalCollections
    {
        public static LinearArrowPath Path { get; set; }
        public static List<Transform> Targets { get; set; }
    }
}
