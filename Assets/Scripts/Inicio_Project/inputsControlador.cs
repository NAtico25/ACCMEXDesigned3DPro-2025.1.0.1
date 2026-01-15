using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputsControlador : MonoBehaviour
{
    public InputAction Guardar;
    
    // Start is called before the first frame update
    void Start()
    {
        Guardar.Enable();
    }

    private void OnEnable()
    {
        Guardar.Enable();
    }
    private void OnDisable()
    {
        Guardar.Disable();
    }

    void Update()
    {
        if (Guardar.WasPressedThisFrame())
        {
            try
            {
                ProyectoManager.Instance.ent_Proyecto = convertidor.ToCampo(ProyectoManager.Instance.proyectoNuevo);
                inpectorDinamico inpector = FindObjectOfType<inpectorDinamico>();
                inpector.Guardar(ProyectoManager.Instance.ent_Proyecto);
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
    }
}
