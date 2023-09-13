using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

// Singlton class to be inherited by manager classes
public class SingletonBase<T> : MonoBehaviour where T : Component
{
    
    private static T instance;
    public static T Instance
    {
        get
        {
            // If there is no instance of this component already, search the scene for an object with the singleton component
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                // If instance is still null, create an object with the singleton component
                if(instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = typeof(T).Name;
                    instance = go.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    public virtual void Awake()
    {
        // If there is no instance, set one
        if(instance == null)
        {
            instance = this as T;
            // Allows the game object to not be detroyed upon loading a new scene
            DontDestroyOnLoad(gameObject);
        }
        // If there already is an instance in the scene, delete this game object
        else
        {
            Destroy(gameObject);
        }
    }
}
