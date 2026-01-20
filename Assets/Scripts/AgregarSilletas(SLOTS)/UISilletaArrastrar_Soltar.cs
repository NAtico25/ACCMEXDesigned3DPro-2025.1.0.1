using UnityEngine;
using UnityEngine.EventSystems;
using static SlotsDrop3D;

public class UISilletaArrastrar_Soltar : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //Valores que pide desde el inspector
    public GameObject silletaPrefab;
    public int size;
    public Vector3 localOffset;

    private Canvas canvas;
    private RectTransform rect;
    private Vector2 startPos;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        startPos = rect.anchoredPosition;
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
    }

    public static class DragState
    {
        public static UISilletaArrastrar_Soltar current;
    }
}
