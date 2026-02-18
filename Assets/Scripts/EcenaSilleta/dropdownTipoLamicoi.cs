using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropdownTipoLamicoi : MonoBehaviour
{
    public GameObject Contenido;
    public GameObject ObjetoAInstanciar;
    public TMPro.TMP_Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        //Evento del dropdown para detectar cuando se cambia la opcion seleccionada
        dropdown.onValueChanged.AddListener(delegate { CambiarTipoLamicoi((Mat_lamicoi.TipoLamicoi)dropdown.value); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarTipoLamicoi(Mat_lamicoi.TipoLamicoi lami)
    {
        //Limpiar el contenido antes de instanciar los nuevos objetos
        foreach (Transform child in Contenido.transform)
        {
            Destroy(child.gameObject);
        }

        switch (lami)
        {
            case Mat_lamicoi.TipoLamicoi.Doble:
                //Instanciar el prefab del lamicoi doble
                Instantiate(ObjetoAInstanciar, Contenido.transform);
                Instantiate(ObjetoAInstanciar, Contenido.transform);
                break;
            case Mat_lamicoi.TipoLamicoi.Triple:
                //Instanciar el prefab del lamicoi triple
                Instantiate(ObjetoAInstanciar, Contenido.transform);
                Instantiate(ObjetoAInstanciar, Contenido.transform);
                Instantiate(ObjetoAInstanciar, Contenido.transform);
                break;
            case Mat_lamicoi.TipoLamicoi.Cuadrupe:
                //Instanciar el prefab del lamicoi cuadruple
                Instantiate(ObjetoAInstanciar, Contenido.transform);
                Instantiate(ObjetoAInstanciar, Contenido.transform);
                Instantiate(ObjetoAInstanciar, Contenido.transform);
                Instantiate(ObjetoAInstanciar, Contenido.transform);
                break;
            case Mat_lamicoi.TipoLamicoi.Quituple:
                //Instanciar el prefab del lamicoi quituple
                Instantiate(ObjetoAInstanciar, Contenido.transform);
                Instantiate(ObjetoAInstanciar, Contenido.transform);
                Instantiate(ObjetoAInstanciar, Contenido.transform);
                Instantiate(ObjetoAInstanciar, Contenido.transform);
                Instantiate(ObjetoAInstanciar, Contenido.transform);
                break;
        }
    }
}
