using TMPro;
using UnityEngine;

public class Medidas : MonoBehaviour
{
    [Header("Referencia")]
    public ent_seccion seccion;

    [Header("UI")]
    public TMP_Text textoLargo;
    public TMP_Text textoAncho;

    void Awake()
    {
        ActualizarTexto();
    }

    public void ActualizarTexto()
    {
        if (seccion == null || textoLargo == null) return;

        textoLargo.text = $"{seccion.largo_Seccion:F2} cm";
        textoAncho.text = $"{seccion.ancho_Seccion:F2} cm";
    }
}
