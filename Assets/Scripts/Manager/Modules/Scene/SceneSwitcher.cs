using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public virtual void SwitchScene(string sceneName)
    {
        SceneLoader.Instance.SwitchScene(sceneName);
    }

    public virtual void SwitchDirectScene(string sceneName)
    {
        SceneLoader.Instance.SwitchDirectScene(sceneName);
    }
}
