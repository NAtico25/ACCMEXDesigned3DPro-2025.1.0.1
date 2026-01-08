using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectoManager : MonoBehaviour
{
    public static ProyectoManager Instance;

    public datosJsonProyecto proyectoNuevo;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void AutoCreate()
    {
        if (Instance == null)
        {
            GameObject go = new GameObject("ProyectoManager");
            go.AddComponent<ProyectoManager>();
        }
    }
}
