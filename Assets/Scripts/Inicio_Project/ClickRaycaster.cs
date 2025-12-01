using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Opcional: asigna desde Inspector para limitar a ciertas capas
    public LayerMask layerMask = ~0; // por defecto todas las capas
    public Camera cam; // si no asignas, toma Camera.main

    void Awake()
    {
        if (cam == null)
        {
            cam = Camera.main;
            if (cam == null)
                Debug.LogError("ClickRaycaster: No se encontró Camera.main. Asigna la cámara en el inspector.");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (cam == null) return;

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.green, 2f);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f, layerMask))
            {
                Debug.Log($"Raycast hit: {hit.collider.name} (transform: {hit.transform.name}) - GameObject: {hit.transform.gameObject.name}");

                // intenta obtener ent_seccion en el objeto golpeado
                var seccion = hit.transform.GetComponent<ent_seccion>();
                if (seccion == null)
                {
                    // intenta en los padres (muy útil si el collider está en un hijo)
                    seccion = hit.transform.GetComponentInParent<ent_seccion>();
                }

                if (seccion != null)
                {
                    Debug.Log($"Encontrada ent_seccion en: {seccion.gameObject.name}");
                    // intenta obtener el inspector dinámico desde la escena
                    var inspector = FindObjectOfType<inpectorDinamico>();
                    if (inspector != null)
                    {
                        inspector.MostrarObjeto(seccion);
                        Debug.Log($"MostrarObjeto llamado para: {seccion.gameObject.name}");
                    }
                    else
                    {
                        Debug.LogWarning("No se encontró inpectorDinamico en la escena. Asigna uno o referencia desde aquí.");
                    }
                }
                else
                {
                    Debug.Log("No se encontró ent_seccion en el objeto clickeado ni en sus padres.");
                }
            }
            else
            {
                Debug.Log("Raycast no golpeó ningún collider.");
            }
        }
    }
}
