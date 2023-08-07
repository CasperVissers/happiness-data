using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObject
{
    public T Instance
    {
        get
        {
            if (_instance == null)
            {
                // Load all scriptable objects of this type
                var scriptableObjects = Resources.LoadAll<T>("");
                if (scriptableObjects == null || scriptableObjects.Length == 0)
                {
                    throw new Exception($"No scriptable object of type {typeof(T)} found!");
                }
                if (scriptableObjects.Length > 1)
                {
                    throw new Exception($"Found {scriptableObjects.Length} scriptable object(s) of type {typeof(T)}, cannot determine instance!");
                }
                // Set instance
                _instance = scriptableObjects[0];
            }
            return _instance;
        }
    }
    private T _instance;
}
