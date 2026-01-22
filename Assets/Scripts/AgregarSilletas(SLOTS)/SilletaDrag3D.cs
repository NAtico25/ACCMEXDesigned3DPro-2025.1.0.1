using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SilletaDrag3D : MonoBehaviour, 
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Camera cam;
    private SilletaInstanciada silleta;
    private Vector3 offset;
    private AgregarSilletas manager;

    private Plane dragPlane;


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

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Liberar slots al comenzar a mover
        LiberarSlots();

        dragPlane = new Plane(Vector3.up, transform.position);
        Ray ray = cam.ScreenPointToRay(eventData.position);

        if (dragPlane.Raycast(ray, out float d))
        {
            offset = transform.position - ray.GetPoint(d);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Ray ray = cam.ScreenPointToRay(eventData.position);

        if (dragPlane.Raycast(ray, out float d))
        {
            transform.position = ray.GetPoint(d) + offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Ray ray = cam.ScreenPointToRay(eventData.position);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            SlotsDrop3D slot = hit.collider.GetComponent<SlotsDrop3D>();

            if (slot && manager.TryPlaceSilleta(silleta, slot.slotIndex))
                return;
        }

        //No válido  regresar
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
