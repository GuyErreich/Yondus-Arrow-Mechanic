using UnityEngine;
using System.Collections;

namespace YundosArrow.Scripts.FSM
{
    public abstract class State : MonoBehaviour
    {
        public virtual IEnumerator On()
        {
            yield return null;
        }
    }
}