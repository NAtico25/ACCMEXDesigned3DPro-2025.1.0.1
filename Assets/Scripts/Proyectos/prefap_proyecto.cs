using System;
using System.Data;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class prefap_proyecto : MonoBehaviour, IPointerClickHandler
{
    public CanvasRenderer favoritoProyecto;
    public TextMeshProUGUI nombreProyecto;
    public TextMeshProUGUI ultimaModificacionProyecto;
    public TextMeshProUGUI fechaProyecto;
    public int idProyecto;

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

}
