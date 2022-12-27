using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YundosArrow.Scripts.Player.Combat.ArrowAbilities.Utils 
{
    public struct Segment
    {
        public Vector3 start;
        public Vector3 end;

        public Segment(Vector3 start, Vector3 end)
        {
            this.start = start;
            this.end = end;
        }
    }
}