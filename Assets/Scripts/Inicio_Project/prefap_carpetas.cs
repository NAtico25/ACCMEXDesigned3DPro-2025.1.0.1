using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class prefap_carpetas : MonoBehaviour
{
    public int idCarpeta;
    public string path;
    public TextMeshProUGUI nombreCarpetaText;
    public Sprite spriteCarpeta;
    public Sprite spriteSilleta;
    public UnityEngine.UI.Button botonPrincipal;
    public GameObject prefapSeleccioes;
    private modo modoBoton;
    private enum modo
    {
        Carpeta,
        Silleta
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AsignarDatos(int id, string nombreCarpeta, int modo)
    {
        CambiarModo(modo);
        idCarpeta = id;
        nombreCarpetaText.text = nombreCarpeta;
    }
    public void CambiarModo(int modoSeleccionado)
    {
        if (modoSeleccionado == 1)
        {
            modoBoton = modo.Silleta;
            botonPrincipal.image.sprite = spriteSilleta;

            //asignar codigo que ocurre al presionar el boton
            botonPrincipal.onClick.AddListener(() =>
            {
                Debug.Log($"Boton Silleta presionado en carpeta ID: {idCarpeta} con path {path}");
                
            });
        }
        else
        {
            modoBoton = modo.Carpeta;
            botonPrincipal.image.sprite = spriteCarpeta;

            botonPrincipal.onClick.AddListener(() =>
            {
                Debug.Log($"Boton Carpeta presionado en carpeta ID: {idCarpeta} con path {path}");
                prefap_selecciones selecciones = prefapSeleccioes.GetComponent<prefap_selecciones>();
                selecciones.RefrescarContenido(path);
            });
        }
           
    }

    public Sprite CargarSpriteDesdePNG(string rutaImagen)
    {
        if (!File.Exists(rutaImagen))
        {
            Debug.LogError("No existe la imagen: " + rutaImagen);
            return null;
        }

        // 1. Leer bytes del archivo
        byte[] bytes = File.ReadAllBytes(rutaImagen);

        // 2. Crear textura vacía
        Texture2D textura = new Texture2D(2, 2);

        // 3. Cargar los bytes en la textura
        textura.LoadImage(bytes);

        // 4. Convertir textura en sprite
        Sprite sprite = Sprite.Create(
            textura,
            new Rect(0, 0, textura.width, textura.height),
            new Vector2(0.5f, 0.5f)
        );

        return sprite;
    }


}
