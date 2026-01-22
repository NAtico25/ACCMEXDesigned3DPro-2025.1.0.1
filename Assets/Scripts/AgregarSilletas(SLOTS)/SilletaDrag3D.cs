using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilletaDrag3D : MonoBehaviour
{
    private Camera cam;
    private SilletaInstanciada silleta;
    private Vector3 offset;
    private AgregarSilletas manager;

    void Awake()
    {
        cam = Camera.main;
        silleta = GetComponent<SilletaInstanciada>();
        manager = GetComponentInParent<AgregarSilletas>();
    }

    void OnMouseDown()
    {
        LiberarSlots();

        Plane p = new Plane(Vector3.up, transform.position);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (p.Raycast(ray, out float d))
            offset = transform.position - ray.GetPoint(d);
    }

    void OnMouseDrag()
    {
        Plane p = new Plane(Vector3.up, transform.position);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (p.Raycast(ray, out float d))
            transform.position = ray.GetPoint(d) + offset;
    }

    void OnMouseUp()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            SlotsDrop3D slot = hit.collider.GetComponent<SlotsDrop3D>();
            if (slot && manager.TryPlaceSilleta(silleta, slot.slotIndex))
                return;
        }

        // no válido regresar
        transform.position = silleta.lastValidPosition;
        ReocuparSlots();
    }

    void LiberarSlots()
    {
        if (silleta.slotsOcupados == null) return;

        foreach (var s in silleta.slotsOcupados)
            s.ocupado = false;
    }

    void ReocuparSlots()
    {
        manager.TryPlaceSilleta(silleta, silleta.startSlot);
    }
}
