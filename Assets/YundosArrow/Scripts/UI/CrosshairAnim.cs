using UnityEngine;

namespace YundosArrow.Scripts.UI
{
    public class CrosshairAnim : MonoBehaviour
    {
        [SerializeField] private Animator anim;

        public void Open() {
            this.anim.SetBool("isOpen", true);
        }

        public void Close() {
            this.anim.SetBool("isOpen", false);
        }
    }
}
