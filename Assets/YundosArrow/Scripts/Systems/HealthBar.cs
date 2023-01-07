using UnityEngine;
using UnityEngine.UI;
using YundosArrow.Scripts.UI.HealthBars;

namespace YundosArrow.Scripts.Systems {
    public class HealthBar : MonoBehaviour {
        public static void Add(Transform target, GameObject healthBar) {
            
        }
        // public static void Add(Transform target, GameObject healthBar, Transform container) {
        //     var hleahtbar = Instantiate(healthBar, container);
        //     hleahtbar.GetComponent<DynamicHealthBar>().Target = target;
        // }
    }
}