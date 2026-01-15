using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputsControlador : MonoBehaviour
{
    public InputActionReference Guardar;
    
    // Start is called before the first frame update
    void Start()
    {
        Guardar.action.Enable();
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
    }
}
