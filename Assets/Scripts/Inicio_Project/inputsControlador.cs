using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputsControlador : MonoBehaviour
{
    public InputActionReference Guardar;
    public Transform objetoPadre;
    public prefap_nombre_proyecto nombre_Proyecto;
    public prefap_guardarNuevoProyecto prefap_GuardarNuevo;

    // Start is called before the first frame update
    void Start()
    {
        Guardar.action.Enable();
        ProyectoManager.Instance.ent_Proyecto = convertidor.ToCampo(ProyectoManager.Instance.proyectoNuevo);
    }

    private void OnEnable()
    {
        Guardar.action.Enable();
    }
    private void OnDisable()
    {
        Guardar.action.Disable();
    }

    void Update()
    {
        if (Guardar.action.WasPressedThisFrame())
        {
            try
            {
                prefap_GuardarNuevo.ActivarVentana();
                ProyectoManager.Instance.ent_Proyecto = convertidor.ToCampo(ProyectoManager.Instance.proyectoNuevo);
                inpectorDinamico inpector = new inpectorDinamico();
                inpector.Guardar(ProyectoManager.Instance.ent_Proyecto);

                //verificarCrearProyecto(ProyectoManager.Instance.esNuevoProyecto);
                //Debug.Log("Proyecto guardado correctamente.");
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
        Actualizar();
    }

    public void Actualizar()
    {
        if (objetoPadre.GetComponentsInChildren<ent_seccion>() != null)
        {
            ent_seccion[] secciones = objetoPadre.GetComponentsInChildren<ent_seccion>();
            //Debug.Log("Secciones encontradas: " + secciones.Length);
           
            ProyectoManager.Instance.ent_Proyecto.seccionesProyecto = secciones;
            ProyectoManager.Instance.proyectoNuevo = convertidor.ToCampo(ProyectoManager.Instance.ent_Proyecto);
        }
    }

    private async void verificarCrearProyecto(bool esNuevo)
    {
        if (ProyectoManager.Instance.esNuevoProyecto == true)
        {
            ProyectoManager.Instance.ent_Proyecto.documentoCotizacion = convertidor.ConvertirJson(ProyectoManager.Instance.ent_Proyecto);
            ProyectoManager.Instance.ent_Proyecto.LayoutProyecto = convertidor.ConvertirJson(ProyectoManager.Instance.ent_Proyecto);
            ProyectoManager.Instance.ent_Proyecto.clienteProyecto = "PruebaClienteCodigo";
            ProyectoManager.Instance.ent_Proyecto.dadoAltaProyecto = true;
            Debug.Log($"Los datos son los siguientes: {ProyectoManager.Instance.ent_Proyecto.clienteProyecto}");
            Debug.Log("Creando nuevo proyecto en la base de datos...");
            int valor = await nombre_Proyecto.CrearProyecto(ProyectoManager.Instance.ent_Proyecto);
        }
    }
}
