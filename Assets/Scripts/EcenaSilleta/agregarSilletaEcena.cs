using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class agregarSilletaEcena : MonoBehaviour
{
    public GameObject estratix;
    public GameObject medioFactor;
    public GameObject silletaUnFactor;
    public GameObject silletaFactorMedio;
    public GameObject silletaDosFactor;
    public GameObject ObjetoActual;
    public Transform padre;
    private bool agregado = false;
    public prefap_confirmarNuevaSilleta prefapConfirmarNuevaSilletaScript;

    public Button botonAgregarEstratix;
    public Button botonAgregarSilletaMedioFactor;
    public Button botonAgregarSilletaUnFactor;
    public Button botonAgregarSilletaFactorMedio;
    public Button botonAgregarSilletaDosFactor;
    // Start is called before the first frame update
    void Start()
    {
        botonAgregarEstratix.onClick.AddListener(agregarStratix);
        botonAgregarSilletaMedioFactor.onClick.AddListener(agregarMedioFactor);
        botonAgregarSilletaUnFactor.onClick.AddListener(agregarFactor);
        botonAgregarSilletaFactorMedio.onClick.AddListener(agregarFactorMedio);
        botonAgregarSilletaDosFactor.onClick.AddListener(agregarDosFactor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void agregarStratix()
    {
        if (!agregado)
        {
            GameObject obj = Instantiate(estratix, padre);
            obj.transform.localPosition = new Vector3(2.7f, -0.04f, 0f);
            obj.transform.localRotation = Quaternion.Euler(-180f, 173f, 0f);
            obj.transform.localScale = new Vector3(1.6f, 1.6f, 1f);
            agregado = true;
            ProyectoManager.Instance.ent_silleta = new Silleta(Silleta.TipoSilleta.Stratix);
        }
        else
        {

            agregado = false;
            prefapConfirmarNuevaSilletaScript.ActivarVentana(1);
        }
    }

    public void agregarMedioFactor()
    {
        if (!agregado)
        {
            GameObject obj = Instantiate(medioFactor, padre);
            obj.transform.localPosition = new Vector3(-6.16f, -8.75f, -1.36f);
            obj.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            obj.transform.localScale = new Vector3(2, 2, 1f);
            agregado = true;
            ProyectoManager.Instance.ent_silleta = new Silleta(Silleta.TipoSilleta.FVNR);
            ObjetoActual = obj;
           
                
        }
        else
        {
            agregado = false;
            prefapConfirmarNuevaSilletaScript.ActivarVentana(2);
        }
    }

    public void agregarFactor()
    {
        if (!agregado)
        {
            GameObject obj = Instantiate(silletaUnFactor, padre);
            obj.transform.localPosition = new Vector3(3.2f, 0.6f, 0f);
            obj.transform.localRotation = Quaternion.Euler(-7.78f, 0f, 0f);
            obj.transform.localScale = new Vector3(2, 2, 1f);
            agregado = true;
            ProyectoManager.Instance.ent_silleta = new Silleta(Silleta.TipoSilleta.FVNR);
        }
        else
        {
            agregado = false;
            prefapConfirmarNuevaSilletaScript.ActivarVentana(3);
        }
    }

    public void agregarFactorMedio()
    {
        if (!agregado)
        {
            GameObject obj = Instantiate(silletaFactorMedio, padre);
            obj.transform.localPosition = new Vector3(2.7f, 0f, 0f);
            obj.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            obj.transform.localScale = new Vector3(3, 3, 1f);
            agregado = true;
            ProyectoManager.Instance.ent_silleta = new Silleta(Silleta.TipoSilleta.FVNR);
        }
        else
        {
            agregado = false;
            prefapConfirmarNuevaSilletaScript.ActivarVentana(4);
        }
    }

    public void agregarDosFactor()
    {
        if (!agregado)
        {
            GameObject obj = Instantiate(silletaDosFactor, padre);
            obj.transform.localPosition = new Vector3(3.4f, 1.65f, 0f);
            obj.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            obj.transform.localScale = new Vector3(2.4f, 2.4f, 1f);
            agregado = true;
            ProyectoManager.Instance.ent_silleta = new Silleta(Silleta.TipoSilleta.FVNR);
        }
        else
        {
            agregado = false;
            prefapConfirmarNuevaSilletaScript.ActivarVentana(5);
        }
    }

    public void OcultarMostrarPorNombre(GameObject padre, string nombre, bool estado)
    {
        if (padre == null) return;

        Transform hijo = padre.transform.Find(nombre);
        if (hijo != null)
            hijo.gameObject.SetActive(estado);
    }
}
