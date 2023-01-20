using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace YundosArrow.Scripts.UI.HealthBars
{
    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Image))]
    public class DynamicHealthBar : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float speed = 0.5f;
        [SerializeField] private float positionOffset = 2f;
        [SerializeField] private float maxDistanceToScale = 30000;

        private Vector3 targetScreenPosition, maxScale;
        private bool isOnScreen;
        private Image image;

        public Transform Target { get; set;}

        private void Awake()
        {
            this.image = this.GetComponent<Image>();

            this.maxScale = this.transform.localScale;

            var rect = this.GetComponent<RectTransform>();

            rect.anchoredPosition = new Vector2(0f, 0f);
            rect.anchorMin = new Vector2(0, 0);
            rect.anchorMax = new Vector2(0, 0);
            rect.pivot = new Vector2(0.5f, 0.5f);
            rect.sizeDelta = new Vector2(100f, 100f);
        }

        private void OnEnable() {
            this.image.fillAmount = 1f;
        }

        public void HandleHealthChanged(float currentHealth, float maxHealth)
        {
            var percentage = currentHealth / maxHealth;
            this.image.DOFillAmount(percentage, speed);
        }

        private void LateUpdate()
        {
            this.transform.position = Camera.main.WorldToScreenPoint(this.Target.transform.position + Camera.main.transform.up * 
                                                                    (this.positionOffset + (this.positionOffset * this.GetDistancePercentage())));

            this.Visibile(this.transform.position);

            this.ChangeSizeByDistance();
        }

        private void ChangeSizeByDistance()
        {
            if (!this.isOnScreen)
             return;

            Vector3 newScale;

            newScale.x = Mathf.Clamp(this.maxScale.x - this.GetDistancePercentage(), 0.1f, 1f);
            newScale.y = Mathf.Clamp(this.maxScale.y - this.GetDistancePercentage(), 0.1f, 1f);
            newScale.z = Mathf.Clamp(this.maxScale.z - this.GetDistancePercentage(), 0.1f, 1f);

            this.transform.localScale = newScale;
        }

        private float GetDistancePercentage()
        {
            float distance = Vector3.Distance(Camera.main.transform.position, this.Target.transform.position);
            float distancePercentage = distance / this.maxDistanceToScale;
            return distancePercentage;
        }

        private void Visibile(Vector3 screenPosition)
        {
            this.isOnScreen = screenPosition.x >= 0 && screenPosition.x <= Screen.width &&
                            screenPosition.y >= 0 && screenPosition.y <= Screen.height &&
                            screenPosition.z > 0;

            this.GetComponent<CanvasGroup>().alpha = this.isOnScreen ? 1 : 0;
        }

        [MenuItem("GameObject/Systems/Health/DynamicHealthBar")]
        private static void CreateDynamicHealthBar(){
            GameObject go = new GameObject("DynamicHealthBar");
            go.AddComponent<DynamicHealthBar>();
            var image = go.GetComponent<Image>();

            image.type = Image.Type.Filled;
            image.fillMethod = Image.FillMethod.Horizontal;
            image.fillOrigin = (int)Image.OriginHorizontal.Right;
        }
    }
}
