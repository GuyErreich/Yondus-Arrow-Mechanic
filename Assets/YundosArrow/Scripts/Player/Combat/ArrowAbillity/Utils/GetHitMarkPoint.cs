using UnityEngine;

namespace Assets.YundosArrow.Scripts.Player.Combat.ArrowAbillity
{
	public partial class Utils
	{
		public static Vector3 GetHitMarkPoint(Vector3 startPoint, float range, float rangeOnNoHit, float radius, LayerMask layerMask)
		{
			Ray ray = Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f));
			var distance = Vector3.Distance(Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f)), startPoint);

			if (Physics.SphereCast(ray, radius, out var hit,
				range,
				layerMask))
			{
				if (hit.distance >= distance)
					return hit.point;
			}

			return Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f)).origin + Camera.main.ViewportPointToRay(new Vector2(0.5f, 0.5f)).direction * rangeOnNoHit;
		}
	}
}
