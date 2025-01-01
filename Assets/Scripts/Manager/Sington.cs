using UnityEngine;

public class Sington<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance = null;

    [SerializeField]
    private bool isDontDestory = true;

    public static T Instance
    {
        get
        {
            if (ReferenceEquals(instance, null))
            {
                instance = FindObjectOfType<T>();
                if (ReferenceEquals(instance, null))
                {
                    var gameObject = new GameObject(nameof(T));
                    instance = gameObject.AddComponent<T>();
                }

                DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (ReferenceEquals(instance, null))
        {
            instance = this as T;

            if (isDontDestory)
                DontDestroyOnLoad(gameObject);
        }
        else if (!ReferenceEquals(instance.gameObject, gameObject))
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        instance = null;
    }
}
