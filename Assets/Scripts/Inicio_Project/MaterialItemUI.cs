using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using TMPro;
using UnityEngine;

public class MaterialItemUI : MonoBehaviour
{
    [Header("Referencias UI")]
    public TMP_Text txtNombre;
    public TMP_InputField inputPrecio;

    public UnityEngine.UI.Toggle toggleActivo;

    [Header("Referencia de datos")]
    public ent_seccion PrecioActual;

    public double precio_Seccion;

    Material material;

    void Awake()
    {
        inputPrecio.onEndEdit.RemoveAllListeners();
        inputPrecio.onEndEdit.AddListener(OnNoPrecioChanged);
    }

    public void AsignarPrecio(ent_seccion nuevoprecio)
    {
        PrecioActual = nuevoprecio;
        MostrarPrecio();
    }

    public void MostrarPrecio()
    {
        if (PrecioActual == null || PrecioActual.piezas_Anclaje.Precio == 0.00) return;

        // Nombre del campo
        txtNombre.text = "Precio: ";

        // Valor del precio
        inputPrecio.text = PrecioActual.piezas_Anclaje.Precio.ToString();

        inputPrecio.onEndEdit.AddListener(v =>
        {
            if (double.TryParse(v, out double p))
                PrecioActual.acople_L.Precio = p;
        });

    }

    void OnNoPrecioChanged (string valor)
    {
        if (PrecioActual == null) return;

        if (double.TryParse(valor, out double p))
        {
            PrecioActual.piezas_Anclaje.Precio = p;

            // Recalcula el total
        }
    }
}
