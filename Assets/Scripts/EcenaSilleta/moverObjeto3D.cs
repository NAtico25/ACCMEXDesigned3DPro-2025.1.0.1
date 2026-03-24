using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class moverObjeto3D : MonoBehaviour
{
    public Texture2D cursorClick;

    private bool isDragging = false;
    private Vector3 offset;
    private float zCoord;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        // Guardamos la distancia en Z del objeto respecto a la cámara
        zCoord = Camera.main.WorldToScreenPoint(transform.position).z;

        // Calculamos offset para que no "salte" al centro del mouse
        offset = transform.position - GetMouseWorldPos();

        isDragging = true;

        Cursor.SetCursor(cursorClick, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseUp()
    {
        isDragging = false;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }


    void Update()
    {
        if (isDragging)
        {
            Vector3 newPos = GetMouseWorldPos() + offset;

            // Solo permitimos movimiento en X y Y
            transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }


}
