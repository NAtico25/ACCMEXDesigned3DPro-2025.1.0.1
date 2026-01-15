using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class ComponentesSeccion : MonoBehaviour
{
    [Header("Referencias UI")]
    public TMP_Text TextCompSecc;
    public TMP_InputField inputCompSecc;

    public ListaMaterialesUI listaMaterialesUI;


    [Header("Referencia de datos")]
    public ent_seccion seccionActual;

    void Awake()
    {
        inputCompSecc.onEndEdit.AddListener(OnNoSeccionChanged);
    }

    // Se llama cuando haces clic en un objeto 3D
    public void AsignarSeccion(ent_seccion nuevaSeccion)
    {
        seccionActual = nuevaSeccion;
        MostrarNoSeccion();
    }

    void MostrarNoSeccion()
    {
        if (seccionActual == null) return;

        // Nombre del campo
        TextCompSecc.text = "Numero de Seccion";

        // Valor GET
        inputCompSecc.text = seccionActual.no_seccion.ToString();
    }

    void OnNoSeccionChanged(string valor)
    {
        if (seccionActual == null) return;

        if (int.TryParse(valor, out int nuevoValor))
        {
            // SET
            seccionActual.no_seccion = nuevoValor;
        }
    }
}
