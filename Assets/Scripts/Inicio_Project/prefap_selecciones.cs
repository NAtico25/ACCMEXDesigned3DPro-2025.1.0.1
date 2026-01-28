using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class prefap_selecciones : MonoBehaviour
{
    public GameObject prefabCarpetas;
    private List<prefap_carpetas> items = new List<prefap_carpetas>();
    public Transform contentCarpetas;
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
        RefrescarContenido(path);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RefrescarContenido(string path)
    {
        string[] carpetas = Directory.GetDirectories(path);
        int id = 1;
        foreach (string carpeta in carpetas)
        {
            string nombreCarpeta = Path.GetFileName(carpeta);
            Debug.Log("Carpeta encontrada: " + carpeta);
            GameObject nuevo = Instantiate(prefabCarpetas, contentCarpetas);
            prefap_carpetas item = nuevo.GetComponent<prefap_carpetas>();
            item.path = carpeta;

            if (File.Exists(Path.Combine(carpeta, "data.json")))
            {
                item.spriteSilleta = item.CargarSpriteDesdePNG(Path.Combine(carpeta, "sprite.png"));
                item.AsignarDatos(id, nombreCarpeta, 1);
                id++;
                items.Add(item);
            }
            else
            {
                
                item.AsignarDatos(id, nombreCarpeta, 0);
                id++;
                items.Add(item);
            }
            
        }
    }
}
