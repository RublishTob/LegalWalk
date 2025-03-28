using System;
using System.Collections.Generic;
using UnityEngine;

namespace DmitryRubic 
{ 
public class ServiceLocator : MonoBehaviour
{
    [SerializeField] private static readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

    public static ServiceLocator Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    public void RegisterService<T>(T service)
    {
        if (services.ContainsKey(typeof(T)))
        {
            Debug.Log("Service locator error, this key is already exist");
            if (services.ContainsValue(typeof(T)) == false)
            {
                services[typeof(T)] = service;
            }
            if (services.ContainsValue(typeof(T)))
            {
                Debug.Log("Service locator error, this key is already exist");
            }
        }
        else
        {
            services[typeof(T)] = service;
        }
    }
    public T GetService<T>()
    {
        if (services.ContainsKey(typeof(T)) == false)
        {
            Debug.Log($"Service locator error, no found a key {typeof(T)}");
            return default;
        }
        else
        {
            return (T)services[typeof(T)];
        }
    }
}

}
