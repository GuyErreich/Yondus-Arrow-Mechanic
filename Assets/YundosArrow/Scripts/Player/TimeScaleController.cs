using System.Collections;
using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player
{
	public class TimeScaleController : MonoBehaviour {

		private static float _cacheTimeScale;
		private static float _time = 0;
		private static float _lastSlowValue;

		private void Update()
		{
			Debug.Log($"Current time scale: {Time.timeScale}");
		}

        public void SetScale(float scale, float fadeTime)
		{
			_cacheTimeScale = Time.timeScale;
			Time.timeScale = Mathf.Clamp(scale, 0f, 1f);
			_lastSlowValue = Time.timeScale;

			StartCoroutine(FadeScale(fadeTime, 1f));
		}

		public IEnumerator FadeScale(float fadeTime, float scaleTo)
		{
			while (Time.timeScale < scaleTo)
			{
				Time.timeScale = Mathf.Clamp(Mathf.Lerp(_lastSlowValue, scaleTo, _time / fadeTime), 0f, 1f);
				_time += Time.unscaledDeltaTime;

				yield return new WaitForEndOfFrame();
			}
			Time.timeScale = scaleTo;
			_time = 0;
		}
	}
}
