using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class prefap_MainInterruptor : MonoBehaviour
{
    public TMP_InputField NumeroParteInterruptor;
    public TMP_InputField CantidadInterruptor;
    public TMP_InputField PrecioInterruptor;
    public TMP_InputField DescripcionInterruptor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Mat_interruptor ObtenerDatosInterruptor()
    {
        Mat_interruptor interruptor = new Mat_interruptor();
        interruptor.Numero_Parte = NumeroParteInterruptor.text;
        try
        {
            interruptor.cantidad = int.Parse(CantidadInterruptor.text);
        }
        catch
        {
            interruptor.cantidad = 1; // Valor predeterminado en caso de error
        }
        try
        {
            interruptor.Precio = float.Parse(PrecioInterruptor.text);
        }catch
        {
            interruptor.Precio = 0f; // Valor predeterminado en caso de error
        }

        interruptor.descripcion = DescripcionInterruptor.text;
        Debug.Log("Datos del interruptor obtenidos: " + interruptor.Numero_Parte + ", " + interruptor.cantidad + ", " + interruptor.Precio + ", " + interruptor.descripcion);
        return interruptor;
    }
}
