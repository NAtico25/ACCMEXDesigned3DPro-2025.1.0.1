using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class prefap_selecciones : MonoBehaviour
{
    public static string ProyectosPath
    {
        get
        {
            string path = Path.Combine(Application.persistentDataPath, "Proyectos");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Debug.Log("Carpeta creada en: " + path);
            }

            return path;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        string path = ProyectosPath;
        string[] carpetas = Directory.GetDirectories(path);
        foreach (string carpeta in carpetas)
        {
            Debug.Log("Carpeta encontrada: " + carpeta);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
