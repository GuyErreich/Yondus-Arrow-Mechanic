using UnityEngine;
using TMPro;
using YundosArrow.Scripts.Systems.Managers;

namespace YundosArrow.Scripts.UI
{
    public class ComboCounter : MonoBehaviour
    {
        private TMP_Text text;

        private void Awake() {
            this.text = this.GetComponent<TMP_Text>();
            this.UpdateText();
        }

        public void UpdateText() {
            if (ComboManager.Instance.CurrentNumber == 0)
                this.text.text = "";
            else 
                this.text.text = $"x{ComboManager.Instance.CurrentNumber.ToString()}";
        }
    }
}
