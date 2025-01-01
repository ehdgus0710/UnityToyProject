using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Sington<CameraManager>
{
    [SerializeField]
    private CameraController mainCamara;

    protected override void Awake()
    {
        base.Awake();
    }

    public Camera GetPlayerCamara { get {  return mainCamara.GetComponent<Camera>(); } }
}
