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
    public TMP_Text TextCompSecc2;
    public TMP_InputField inputCompSecc2;    
    public TMP_Text TextCompSecc3;
    public TMP_InputField inputCompSecc3;
    public TMP_Text TextCompSecc4;
    public TMP_InputField inputCompSecc4;
    public TMP_Text TextCompSecc5;
    public TMP_InputField inputCompSecc5;    
    public TMP_Text TextCompSecc6;
    public TMP_InputField inputCompSecc6;
    public TMP_Text TextCompSecc7;
    public TMP_InputField inputCompSecc7;
    public TMP_Text TextCompSecc8;
    public TMP_InputField inputCompSecc8;

    public ListaMaterialesUI listaMaterialesUI;


    [Header("Referencia de datos")]
    public ent_seccion seccionActual;

    void Awake()
    {
        inputCompSecc.onEndEdit.AddListener(OnNoSeccionChanged);
        inputCompSecc2.onEndEdit.AddListener(OnNoParteChanged);
    }

    // Se llama cuando haces clic en un objeto 3D
    public void AsignarSeccion(ent_seccion nuevaSeccion)
    {
        seccionActual = nuevaSeccion;
        MostrarNoParte();
        MostrarSeccionComp();
    }

    void MostrarNoParte()
    {
        if (seccionActual == null) return;

        // Nombre del campo
        TextCompSecc.text = "Numero de Seccion:";

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

    public void MostrarSeccionComp()
    {
        if (seccionActual == null) return;
        //Zoclo
        if (seccionActual.zoclo != null)
        {
            TextCompSecc2.text = seccionActual.zoclo.nombre_Material.ToString();
            inputCompSecc2.text = seccionActual.zoclo.Numero_Parte.ToString();
        }
        //Piso Anclaje
        if (seccionActual.piezas_Anclaje != null)
        {
            TextCompSecc3.text = seccionActual.piezas_Anclaje.nombre_Material.ToString();
            inputCompSecc3.text = seccionActual.piezas_Anclaje.cantidad.ToString();
        }
        //Orejas Carga
        if (seccionActual.orejas_Carga != null)
        {
            TextCompSecc4.text = seccionActual.orejas_Carga.nombre_Material.ToString();
            inputCompSecc4.text = seccionActual.orejas_Carga.Numero_Parte.ToString();
        }
        //Piso Seccion
        if (seccionActual.piso_Seccion != null)
        {
            TextCompSecc5.text = seccionActual.piso_Seccion.nombre_Material.ToString();
            inputCompSecc5.text = seccionActual.piso_Seccion.Numero_Parte.ToString();
        }
        //Perfiles
        //if (seccionActual == null || seccionActual.perfiles == null) return;
        //if (seccionActual.perfiles.Count == 0) return;

        //Sale con error, checar como funciona las listas
        /*Mat_perfil perfil = seccionActual.perfiles[0];
        inputCompSecc5.text = seccionActual.perfiles.Numero_Parte.ToString();*/
        //Tapa trasera de seccion
        if (seccionActual.tapa_trasera_seccion != null)
        {
            TextCompSecc6.text = seccionActual.tapa_trasera_seccion.nombre_Material.ToString();
            inputCompSecc6.text = seccionActual.tapa_trasera_seccion.Numero_Parte.ToString();
        }
        //Tapas laterales
        if (seccionActual.tapas_laterales_seccion != null)
        {
            TextCompSecc7.text = seccionActual.tapas_laterales_seccion.nombre_Material.ToString();
            inputCompSecc7.text = seccionActual.tapas_laterales_seccion.Numero_Parte.ToString();
        }
        //Tapa laterial inferior
        if (seccionActual.tapa_lateral_Inferior_seccion != null)
        {
            TextCompSecc8.text = seccionActual.tapa_lateral_Inferior_seccion.nombre_Material.ToString();
            inputCompSecc8.text = seccionActual.tapa_lateral_Inferior_seccion.Numero_Parte.ToString();
        }
    }

    void OnNoParteChanged(string componente)
    {
        if (seccionActual == null || seccionActual.zoclo == null) return;
        seccionActual.zoclo.Numero_Parte = componente;
        seccionActual.piezas_Anclaje.cantidad = int.Parse(componente);
        seccionActual.piso_Seccion.Numero_Parte = componente;
        //seccionActual.piso_Seccion.Numero_Parte = componente;
        seccionActual.tapa_trasera_seccion.Numero_Parte = componente;
        seccionActual.tapas_laterales_seccion.Numero_Parte = componente;
        seccionActual.tapa_lateral_Inferior_seccion.Numero_Parte = componente;
    }
}
