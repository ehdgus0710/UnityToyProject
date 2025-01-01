using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeManager : Sington<GameTimeManager>
{
    private const float originTimeScale = 1f;
    private float gameTimeScale = 1f;
    public float GameTimeScale { get { return gameTimeScale; } }

    public float DeltaTime { get { return Time.deltaTime * gameTimeScale; } }
    public float FixedDeltaTime { get { return Time.fixedDeltaTime * gameTimeScale; } }
    public float UnscaleDeltaTime { get { return Time.deltaTime; } }
    public float UnscaleFixedDeltaTime { get { return Time.fixedDeltaTime; } }

    protected override void Awake()
    {
        base.Awake();

        gameTimeScale = Time.timeScale;
        //Time.fixedDeltaTime = 0.02f * gameTimeScale;
    }

    public void Pause()
    {
        if (Time.timeScale != originTimeScale)
            return;

        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0f;
    }

    public void unPause()
    {
        if (Time.timeScale != 0f)
            return;

        Time.timeScale = originTimeScale;
        Time.fixedDeltaTime = 0.02f * originTimeScale;
    }

    public void SetTimeScale(float timeScale)
    {
        gameTimeScale = timeScale;
    }

    public void ResetTimeScale()
    {
        gameTimeScale = originTimeScale;
    }
}
