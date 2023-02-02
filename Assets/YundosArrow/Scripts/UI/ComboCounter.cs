using Assets.YundosArrow.Scripts.Systems.Managers;
using UnityEngine;
using TMPro;

namespace Assets.YundosArrow.Scripts.UI
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
