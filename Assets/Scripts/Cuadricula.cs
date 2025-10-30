using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways] //Se ve sin darle play
public class Cuadricula : MonoBehaviour
{
    public int gridWidth = 10;
    public int gridHeight = 10;
    public float cellSize = 1f;
    public Color gridColor = Color.green;

    void OnDrawGizmos()
    {
        Gizmos.color = gridColor;

        // Dibuja la cuadrícula en el suelo
        for (int x = 0; x <= gridWidth; x++)
        {
            Vector3 start = transform.position + new Vector3(x * cellSize, 0, 0);
            Vector3 end = transform.position + new Vector3(x * cellSize, 0, gridHeight * cellSize);
            Gizmos.DrawLine(start, end);
        }

        for (int z = 0; z <= gridHeight; z++)
        {
            Vector3 start = transform.position + new Vector3(0, 0, z * cellSize);
            Vector3 end = transform.position + new Vector3(gridWidth * cellSize, 0, z * cellSize);
            Gizmos.DrawLine(start, end);
        }
    }


    public Vector3 GetWorldPosition(int x, int z)
    {
        return transform.position + new Vector3(x, 0, z) * cellSize;
    }

    public Vector2Int GetGridPosition(Vector3 worldPosition)
    {
        Vector3 localPos = worldPosition - transform.position;
        int x = Mathf.RoundToInt(worldPosition.x / cellSize);
        int z = Mathf.RoundToInt(worldPosition.z / cellSize);
        return new Vector2Int(x, z);
    }
}
