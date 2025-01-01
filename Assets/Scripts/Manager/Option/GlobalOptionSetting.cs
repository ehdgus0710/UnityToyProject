using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GlobalOptionSetting : Sington<GlobalOptionSetting> , IDataPersistence
{
    [SerializeField]
    private InputActionAsset inputActions;

    [SerializeField]
    private int targetFPSRate = 60;

    [SerializeField]
    private Vector2 currentScreenResolution;
    public Vector2 CurrentScreenResolution { get { return currentScreenResolution; } }

    [SerializeField]
    private FullScreenMode currentScrrenMode;
    public FullScreenMode CurrentScrrenMode { get {  return currentScrrenMode; } }



    //[SerializeField]
    //private float mouseSensitivity;

    void OnEnable()
    {
        SetTargetFPS(targetFPSRate);
    }

    protected override void Awake()
    {
        base.Awake();

        SetTargetFPS(targetFPSRate);
    }

    public void SetTargetFPS(int fps)
    {
        targetFPSRate = fps;
        Application.targetFrameRate = targetFPSRate;
    }

    public void SetScreenMode(FullScreenMode screenMode)
    {
        currentScrrenMode = screenMode;
    }

    public void SetScreenResolution(Vector2 screenResolution)
    {
        currentScreenResolution = screenResolution;
    }

    public void SaveData(ref PlayRecodeData playRecodeOptionData)
    {

    }
    public void LoadData(PlayRecodeData playRecodeOptionData)
    {

    }
}
