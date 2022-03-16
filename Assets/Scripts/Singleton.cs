using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance = null;

    public static T Instance
    {
        get
        {
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance)
        {
            _instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}