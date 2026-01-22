using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilletaInstanciada : MonoBehaviour
{
    [Header("Configuración del prefab")]
    public int size = 1; // cuántos slots ocupa ESTE prefab

    [HideInInspector] public int startSlot;
    [HideInInspector] public SlotsDrop3D[] slotsOcupados;

    [HideInInspector] public Vector3 lastValidPosition;
}
