using System;
using System.Collections.Generic;
using UnityEngine;


public static class ServicesLocator
{
    private static Dictionary<Type, object> services = new();

    public static void RegisterService<TInterface>(TInterface service)
    {
        try
        {
            services[typeof(TInterface)] = service;
            Debug.Log($"{service} a etais enregistrer");
        }
        catch
        {
            Debug.LogError($"{service} n'a pas etais enregistrer");
            service = default;
        }
    }

    public static TInterface GetService<TInterface>()
    {
        

        return (TInterface)services[typeof(TInterface)];
    }

    public static void UnRegisterService<TInterface>(TInterface service)
    {
        try
        {
            services[typeof(TInterface)] = null;
            Debug.Log($"{service} a etais supprimer");
        }
        catch
        {
            Debug.LogWarning($"{service} n'a pas pu être supprimer");
        }
    }
}
