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
        // Esto hace que regrese el botón UI a su posición original
        rect.anchoredPosition = startPos;

        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        //Busca el layer Slot para que no colisione con el otro boxcollider que es el de clic
        int layerMask = LayerMask.GetMask("Slot");

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("Raycast golpeó SLOT: " + hit.collider.name);

            // Aqui crea el clon del prefab 3D
            GameObject silletaClone = Instantiate(silletaPrefab);

            // Lo combierte hijo del slot
            silletaClone.transform.SetParent(hit.collider.transform, false);

            // Pone la posicion que tiene en el inspector local usando el offset del botón
            silletaClone.transform.localPosition = localOffset;

            // Esto rootación y escala seguras
            silletaClone.transform.localRotation = Quaternion.identity;
            silletaClone.transform.localScale = Vector3.one;

            Debug.Log("Silleta clonada y colocada en slot");
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
