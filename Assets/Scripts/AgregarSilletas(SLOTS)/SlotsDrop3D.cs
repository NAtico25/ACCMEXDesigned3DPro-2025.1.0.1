using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class SlotsDrop3D : MonoBehaviour
{
    public int slotIndex;
    public AgregarSilletas manager;
    public SilletaInstanciada silletaActual;
    public bool ocupado;

    /*private void OnMouseUp()
    {
        TryPlace();
    }

    void TryPlace()
    {
        if (DragState.current == null) return;

        manager.PlaceSilleta(
            slotIndex,
            DragState.current.silletaPrefab,
            DragState.current.size,
            DragState.current.localOffset
        );
    }

    public static class DragState
    {
        public static UISilletaArrastrar_Soltar current;
    }*/
}
