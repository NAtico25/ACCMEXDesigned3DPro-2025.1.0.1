using System;
using System.Data;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class prefap_proyecto : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public CanvasRenderer favoritoProyecto;
    public TextMeshProUGUI nombreProyecto;
    public TextMeshProUGUI ultimaModificacionProyecto;
    public TextMeshProUGUI fechaProyecto;
    public int idProyecto;

    public Image fondo;      // el Image que creaste como Background
    public Color normalColor = new Color(1, 1, 1, 0);      // transparente
    public Color hoverColor = new Color(0.8f, 0.8f, 0.8f, 0.3f);  // gris claro

    private float lastClickTime = 0f;
    private const float doubleClickThreshold = 0.25f;
    // Start is called before the first frame update

    public void SetData(int id, string nombre, string fecha)
    {
        idProyecto = id;
        nombreProyecto.text = nombre;
        fechaProyecto.text = fecha;
        
    }
    void Start()
    {
        if (fondo != null)
            fondo.color = normalColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        float timeSinceLastClick = Time.time - lastClickTime;

        if (timeSinceLastClick <= doubleClickThreshold)
        {
            // Doble clic detectado
            Debug.Log($"Doble clic en proyecto: {idProyecto} - {nombreProyecto.text}");
            OnClick();
        }

        lastClickTime = Time.time;
    }

    private void OnClick()
    {
        Debug.Log($"Proyecto seleccionado: {idProyecto} - {nombreProyecto.text}");
    }

    


    public void OnPointerEnter(PointerEventData eventData)
    {
        fondo.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        fondo.color = normalColor;
    }

}
