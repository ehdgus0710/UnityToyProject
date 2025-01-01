using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : Sington<SceneLoader>
{
    [SerializeField]
    private string loadSceneName;

    [SerializeField]
    private string nextSceneName;

    private Scrollbar scrollbar;

    [SerializeField]
    private GameObject loadingPrefab;

    public void SwitchScene(string nextScene, bool useFade = true)
    {
        nextSceneName = nextScene;
        if (useFade)
        {
            LoadScene(loadSceneName);
        }
        else
        {
            LoadScene(loadSceneName);
        }
    }

    public void SwitchDirectScene(string nextScene, bool useFade = true)
    {
        nextSceneName = nextScene;

        if (useFade)
        {
            LoadScene(nextSceneName);
        }
        else
        {
            LoadScene(nextSceneName);
        }
    }

    private void LoadScene(string loadSceneName)
    {
        SceneManager.LoadScene(loadSceneName);
        //LoadSceneAsync(loadSceneName);
    }

    public void LoadNextScene()
    {
        loadingPrefab = GameObject.Instantiate(loadingPrefab);
        scrollbar = loadingPrefab.gameObject.GetComponentInChildren<Scrollbar>();

        StartCoroutine(LoadSceneAsync(nextSceneName));
    }

    private void LoadScene(string loadSceneName, LoadSceneMode loadMode = LoadSceneMode.Single, UnityAction loadEndAction = null)
    {


        //SceneManager.LoadScene(loadSceneName, loadMode);

        StartCoroutine(LoadSceneAsync(nextSceneName, loadMode));

        //LoadSceneAsync(loadSceneName);
        loadEndAction?.Invoke();
    }

    IEnumerator LoadSceneAsync(string sceneName, LoadSceneMode loadMode = LoadSceneMode.Single, bool allowActive = true, UnityAction<float> updateLoadingAction = null, UnityAction endAction = null)
    {
        yield return null;

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, loadMode);
        operation.allowSceneActivation = false;

        float timer = 0.0f;
        while (!operation.isDone)
        {
            yield return null;
            timer += Time.deltaTime;

            if (operation.progress < 0.9f)
            {
                scrollbar.size = Mathf.Lerp(scrollbar.size, operation.progress, timer);

                if (scrollbar.size >= operation.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                scrollbar.size = Mathf.Lerp(scrollbar.size, 1f, timer);

                if (scrollbar.size == 1.0f)
                {
                    operation.allowSceneActivation = true;
                    yield break;
                }
            }
        }

        Debug.Log("로딩 완료");
        Debug.Log(timer);
    }
}
