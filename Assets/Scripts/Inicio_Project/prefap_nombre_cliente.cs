using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class prefap_nombre_cliente : MonoBehaviour
{
    public TMP_Dropdown dropDownCliente;
    // Start is called before the first frame update
    void Start()
    {
        dropDownCliente.onValueChanged.AddListener(OnDropdownChanged);
        LlenarDropdown();
        dropDownCliente.options[dropDownCliente.value].text = ProyectoManager.Instance.proyectoNuevo.clienteProyecto;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        dropDownCliente.onValueChanged.RemoveListener(OnDropdownChanged);
    }

    void OnDropdownChanged(int index)
    {
        string texto = dropDownCliente.options[index].text;
        Debug.Log("Seleccionado: " + texto);
        if (texto == "Nuevo Cliente")
        {
            Debug.Log("Se ha seleccionado 'Nuevo Cliente'.");
        }
        else
        {
            Debug.Log("Cliente existente seleccionado: " + texto);
            ProyectoManager.Instance.ent_Proyecto.clienteProyecto = texto;
        }
    }

    public void ActualizarNombreCliente()
    {
        ProyectoManager.Instance.ent_Proyecto.clienteProyecto = dropDownCliente.options[dropDownCliente.value].text;
    }

    public async void LlenarDropdown()
    {
        DataTable dtClientes = await neg_inicioProyect.neg_ObtenerClientes();
        dropDownCliente.ClearOptions();
        List<TMP_Dropdown.OptionData> opciones = new List<TMP_Dropdown.OptionData>();
        foreach (DataRow row in dtClientes.Rows)
        {
            string nombreCliente = row["Nombre"].ToString();
            opciones.Add(new TMP_Dropdown.OptionData(nombreCliente));
        }
        opciones.Add(new TMP_Dropdown.OptionData("Nuevo Cliente"));
        dropDownCliente.AddOptions(opciones);
        dropDownCliente.RefreshShownValue();
    }
}
