using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSceneController : MonoBehaviour
{
    void Start()
    {
        SceneLoader.Instance.LoadNextScene();
    }
}
