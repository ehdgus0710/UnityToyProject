using UnityEngine;

public class UITitleView : MonoBehaviour
{
    public void ExitGame()
    {        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();   
#endif
    }
}
