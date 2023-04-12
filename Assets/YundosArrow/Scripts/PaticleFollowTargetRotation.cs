using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace Assets.YundosArrow.Scripts
{
	public class PaticleFollowTargetRotation : MonoBehaviour
	{
		private VisualEffect _vfx;

	    private void Awake()
	    {
			_vfx = GetComponent<VisualEffect>();
	    }

		private void Start()
		{
//			_vfx.enabled = false;
		}

	    // Update is called once per frame
	    void Update()
	    {
			_vfx.SetVector3("Angle", transform.eulerAngles);
	    }
	}
}
