using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class CinemaBlend : MonoBehaviour
{
    [SerializeField] private UnityEvent _onComplete;

    private CinemachineBrain cmb;
    private bool isBlendActive;

    // Start is called before the first frame update
    void Start()
    {
        cmb = Camera.main.GetComponent<CinemachineBrain>();
        isBlendActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cmb.IsBlending) 
            isBlendActive = true;

        if (!cmb.IsBlending && isBlendActive) {
            isBlendActive = false;
            _onComplete.Invoke();
        }
    }
}
