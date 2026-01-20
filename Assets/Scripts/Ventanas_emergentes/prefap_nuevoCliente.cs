using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class prefap_nuevoCliente : MonoBehaviour
{
    public TMP_InputField input_NombreCliente;
    public Button boton_CrearCliente;
    public Button boton_Cancelar;
    // Start is called before the first frame update
    void Start()
    {
        //Colocar evento de los botones
        boton_CrearCliente.onClick.AddListener(() =>
        {
            string nombreCliente = input_NombreCliente.text;
            if (nombreCliente != "")
            {
                Debug.Log($"Crear cliente con nombre: {nombreCliente}");
                CrearCliente(nombreCliente);
                DesactivarVentana();
            }
        });

        boton_Cancelar.onClick.AddListener(() =>
        {
            DesactivarVentana();
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public void ActivarVentana()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f; // Congela el resto de elementos
    }

   
    public void DesactivarVentana()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f; // Reanuda 
    }

    private async void CrearCliente(string nombreCliente)
    {
        try
        {
            int resultado = await neg_inicioProyect.neg_CrearCliente(nombreCliente);
            if (resultado > 0)
            {
                Debug.Log("Cliente creado exitosamente.");
            }
            else
            {
                Debug.LogWarning("No se pudo crear el cliente.");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error al crear el cliente: {e.Message}");
        }
    }
}
