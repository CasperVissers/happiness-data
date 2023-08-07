using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
        }
        else
        {
            Debug.LogWarning($"Instance of {typeof(T)} already exsists in the game on object {Instance.name}. This instance ({this.name}) will be removed.", this);
            Destroy(this as T);
        }
    }
}
