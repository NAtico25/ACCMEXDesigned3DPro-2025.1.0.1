using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class prefap_datosSilleta : MonoBehaviour
{
    public TMP_InputField inputFieldNombre;
    public TMP_InputField inputFieldNumeroParte;
    public TMP_Dropdown dropdownTipoSilleta;
    public TMP_Dropdown dropdownCapacidadSilleta;
    public TMP_Dropdown dropdownPiso;
    public prefap_datosSilletaMinimizar Clemas;
    public prefap_datosSilletaMinimizar PortaClemas;

    // Start is called before the first frame update
    void Start()
    {
        if (ProyectoManager.Instance.ent_silleta != null)
        {
            Silleta silleta = ProyectoManager.Instance.ent_silleta;
            inputFieldNombre.text = silleta.Nombre;
            inputFieldNumeroParte.text = silleta.NumeroParte;
            dropdownTipoSilleta.value = (int)silleta.tipoSilleta;
            dropdownCapacidadSilleta.value = (int)silleta.capacidad;
            dropdownPiso.value = (int)silleta.piso;

            if (ProyectoManager.Instance.ent_silleta.clemas != null)
            {
                if (ProyectoManager.Instance.ent_silleta.clemas.cantidad > 0)
                    Clemas.Maximizar();
                else
                    Clemas.Minimizar();
            }
            else
                Clemas.Minimizar();



            if (ProyectoManager.Instance.ent_silleta.portaClemas != null)
            {
                if (ProyectoManager.Instance.ent_silleta.portaClemas.cantidad > 0)
                    PortaClemas.Maximizar();
                else
                    PortaClemas.Minimizar();

            }
            else
                PortaClemas.Minimizar();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        GuardarDatosSilleta();

    }

    public void GuardarDatosSilleta()
    {
        string nombre = inputFieldNombre.text;
        string numeroParte = inputFieldNumeroParte.text;
        Silleta.TipoSilleta tipoSilleta = (Silleta.TipoSilleta)dropdownTipoSilleta.value;
        Silleta.Capacidad capacidad = (Silleta.Capacidad)dropdownCapacidadSilleta.value;
        Mat_piso.piso piso = (Mat_piso.piso)dropdownPiso.value;
        // Aquí puedes crear una instancia de Silleta y asignar los valores
        Silleta nuevaSilleta = new Silleta(tipoSilleta)
        {
            Nombre = nombre,
            NumeroParte = numeroParte,
            piso = piso
        };
        //asignar seleccion en la dropdown de capacidad dependiendo del tipo de silleta seleccionado

        dropdownCapacidadSilleta.value = (int)nuevaSilleta.capacidad;

        // Aquí puedes agregar la lógica para guardar o utilizar la nueva silleta
        Debug.Log($"Datos de la silleta guardados: {nuevaSilleta.Nombre} {nuevaSilleta.NumeroParte} {nuevaSilleta.tipoSilleta} {nuevaSilleta.capacidad} {nuevaSilleta.piso}");

        ProyectoManager.Instance.ent_silleta = nuevaSilleta;
        Debug.Log($"Silleta asignada al proyecto: {ProyectoManager.Instance.ent_silleta.Nombre} {ProyectoManager.Instance.ent_silleta.NumeroParte} {ProyectoManager.Instance.ent_silleta.tipoSilleta} {ProyectoManager.Instance.ent_silleta.capacidad} {ProyectoManager.Instance.ent_silleta.piso}");
    }
}
