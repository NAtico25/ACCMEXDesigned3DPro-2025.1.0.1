using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prefap_menu_radial : MonoBehaviour
{
    public botonRadial imagen1;
    public botonRadial imagen2;
    public botonRadial imagen3;
    public botonRadial imagen4;
    public botonRadial imagen5;
    public botonRadial imagen6;
    public botonRadial imagen7;
    public botonRadial imagen8;

    

    public float radio = 50;
    public float radio_externo;
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        

        DetectarSeccionMenuRadial();
    }

    private void DetectarSeccionMenuRadial()
    {
        RectTransform rect = GetComponent<RectTransform>();

        radio_externo = Mathf.Min(rect.rect.width, rect.rect.height) * 0.5f;

        Vector2 centro = RectTransformUtility.WorldToScreenPoint(null, GetComponent<RectTransform>().position);
        Vector2 mouse = Input.mousePosition;
        Vector2 dir = mouse - centro;
        float distancia = dir.magnitude;


        float angulo = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (angulo < 0)
            angulo += 360f;

        if (distancia < radio || distancia > radio_externo)
        {

            imagen1.isHovering = false;
            imagen2.isHovering = false;
            imagen3.isHovering = false;
            imagen4.isHovering = false;
            imagen5.isHovering = false;
            imagen6.isHovering = false;
            imagen7.isHovering = false;
            imagen8.isHovering = false;
            return;
        }
        else
        {
            switch (angulo)
            {
                case float n when (n >= 0 && n < 45):
                    imagen1.isHovering = false;
                    imagen2.isHovering = true;
                    imagen3.isHovering = false;
                    imagen4.isHovering = false;
                    imagen5.isHovering = false;
                    imagen6.isHovering = false;
                    imagen7.isHovering = false;
                    imagen8.isHovering = false;
                    break;
                case float n when (n >= 45 && n < 90):
                    imagen1.isHovering = false;
                    imagen2.isHovering = false;
                    imagen3.isHovering = true;
                    imagen4.isHovering = false;
                    imagen5.isHovering = false;
                    imagen6.isHovering = false;
                    imagen7.isHovering = false;
                    imagen8.isHovering = false;
                    break;
                case float n when (n >= 90 && n < 135):
                    imagen1.isHovering = false;
                    imagen2.isHovering = false;
                    imagen3.isHovering = false;
                    imagen4.isHovering = true;
                    imagen5.isHovering = false;
                    imagen6.isHovering = false;
                    imagen7.isHovering = false;
                    imagen8.isHovering = false;
                    break;
                case float n when (n >= 135 && n < 180):
                    imagen1.isHovering = false;
                    imagen2.isHovering = false;
                    imagen3.isHovering = false;
                    imagen4.isHovering = false;
                    imagen5.isHovering = true;
                    imagen6.isHovering = false;
                    imagen7.isHovering = false;
                    imagen8.isHovering = false;
                    break;
                case float n when (n >= 180 && n < 225):
                    imagen1.isHovering = false;
                    imagen2.isHovering = false;
                    imagen3.isHovering = false;
                    imagen4.isHovering = false;
                    imagen5.isHovering = false;
                    imagen6.isHovering = true;
                    imagen7.isHovering = false;
                    imagen8.isHovering = false;
                    break;
                case float n when (n >= 225 && n < 270):
                    imagen1.isHovering = false;
                    imagen2.isHovering = false;
                    imagen3.isHovering = false;
                    imagen4.isHovering = false;
                    imagen5.isHovering = false;
                    imagen6.isHovering = false;
                    imagen7.isHovering = true;
                    imagen8.isHovering = false;
                    break;
                case float n when (n >= 270 && n < 315):
                    imagen1.isHovering = false;
                    imagen2.isHovering = false;
                    imagen3.isHovering = false;
                    imagen4.isHovering = false;
                    imagen5.isHovering = false;
                    imagen6.isHovering = false;
                    imagen7.isHovering = false;
                    imagen8.isHovering = true;
                    break;
                case float n when (n >= 315 && n < 360):
                    imagen1.isHovering = true;
                    imagen2.isHovering = false;
                    imagen3.isHovering = false;
                    imagen4.isHovering = false;
                    imagen5.isHovering = false;
                    imagen6.isHovering = false;
                    imagen7.isHovering = false;
                    imagen8.isHovering = false;
                    break;
            }
        }
    }
}
