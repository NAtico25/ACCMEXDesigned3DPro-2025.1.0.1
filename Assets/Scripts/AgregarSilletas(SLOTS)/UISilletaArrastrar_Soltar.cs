using UnityEngine;
using UnityEngine.EventSystems;
using static SlotsDrop3D;

public class UISilletaArrastrar_Soltar : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject silletaPrefab;
    public int size;
    public Vector3 localOffset;

    private Canvas canvas;
    private RectTransform rect;
    private Vector2 startPos;
    private Camera mainCam;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        startPos = rect.anchoredPosition;
        mainCam = Camera.main;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        rect.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Regresar el botón a su lugar
        rect.anchoredPosition = startPos;

        Debug.Log("OnEndDrag ejecutado");

        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 20f, Color.red, 2f);

        int layerMask = LayerMask.GetMask("Slot");

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("Raycast golpeó SLOT: " + hit.collider.name);

            SlotsDrop3D slot = hit.collider.GetComponent<SlotsDrop3D>();
            if (slot != null)
            {
                slot.manager.PlaceSilleta(
                    slot.slotIndex,
                    silletaPrefab,
                    size,
                    localOffset
                );
            }
        }
        else
        {
            Debug.Log("No se detectó ningún slot");
        }
    }
    /*//Valores que pide desde el inspector
    public GameObject silletaPrefab;
    public int size;
    public Vector3 localOffset;

    private Canvas canvas;
    private RectTransform rect;
    private Vector2 startPos;
    private Camera mainCam;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        startPos = rect.anchoredPosition;
        mainCam = Camera.main;
    }

    public void OnBeginDrag(PointerEventData eventBase)
    {
        rect.SetAsLastSibling();
        DragState.current = this;
    }

    public void OnDrag(PointerEventData eventBase)
    {
        rect.anchoredPosition += eventBase.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventBase)
    {
        rect.anchoredPosition = startPos;

        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            SlotsDrop3D slot = hit.collider.GetComponent<SlotsDrop3D>();
            if (slot != null)
            {
                slot.manager.PlaceSilleta(
                    slot.slotIndex,
                    silletaPrefab,
                    size,
                    localOffset
                );
            }
        }
    }*/
}
