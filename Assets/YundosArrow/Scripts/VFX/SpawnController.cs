using UnityEngine;
using UnityEngine.VFX;

namespace Assets.YundosArrow.Scripts.VFX
{
	public class SpawnController : MonoBehaviour {
		private VisualEffect vfx;

		private void Awake()
		{
			vfx = GetComponent<VisualEffect>();
		}

		public void SetSpawnStrength(float amount)
		{
			vfx?.SetFloat("Spawn Strength", Mathf.Clamp(amount, 0f, 1f));
		}
	}
}
