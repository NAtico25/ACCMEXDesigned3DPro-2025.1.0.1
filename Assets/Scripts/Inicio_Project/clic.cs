using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clic : MonoBehaviour
{
    public inpectorDinamico inspector;
    private ent_seccion seccion;
    public Button botonVerDatos;

    void Awake()
    {
        // Busca automáticamente el ent_seccion en el mismo objeto
        seccion = GetComponent<ent_seccion>();
        if (seccion == null)
            Debug.LogWarning("No se encontró ent_seccion en el objeto " + gameObject.name);
    }

    private void OnMouseDown()
    {
        if (seccion != null && inspector != null)
        {
            inspector.MostrarObjeto(seccion);
            Debug.Log("Objeto clickeado: " + seccion.name);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // Evento clic boton
        botonVerDatos.onClick.AddListener(() =>
        {
            if (seccion != null && inspector != null)
            {
                inspector.MostrarObjeto(seccion);
                Debug.Log("Objeto clickeado desde boton: " + seccion.name);
            }
        });

       
        inspector.MostrarObjeto(seccion);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
