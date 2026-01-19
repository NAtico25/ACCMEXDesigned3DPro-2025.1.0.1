using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputsControlador : MonoBehaviour
{
    public InputActionReference Guardar;
    public Transform objetoPadre;
    
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
                ProyectoManager.Instance.ent_Proyecto = convertidor.ToCampo(ProyectoManager.Instance.proyectoNuevo);
                inpectorDinamico inpector = new inpectorDinamico();
                inpector.Guardar(ProyectoManager.Instance.ent_Proyecto);
                Debug.Log("Proyecto guardado correctamente.");
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
            Debug.Log("Secciones encontradas: " + secciones.Length);
           
            ProyectoManager.Instance.ent_Proyecto.seccionesProyecto = secciones;
            ProyectoManager.Instance.proyectoNuevo = convertidor.ToCampo(ProyectoManager.Instance.ent_Proyecto);
        }
    }
}
