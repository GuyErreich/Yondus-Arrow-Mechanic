using UnityEngine;
using System.Collections;

namespace CaptainClaw.Scripts.FSM
{
    public abstract class State : MonoBehaviour
    {
        public virtual IEnumerator On()
        {
            yield return null;
        }
    }
}