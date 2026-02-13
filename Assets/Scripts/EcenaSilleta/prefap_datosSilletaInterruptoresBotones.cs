using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prefap_datosSilletaInterruptoresBotones : MonoBehaviour
{
    public GameObject Contenido;
    public GameObject ObjetoAInstanciar;
    public Button botonInstanciar;
    public Button botonQuitarUltimaInstancia;
    public agregarSilletaEcena scripAgregarSilletaEcena;

    
    // Start is called before the first frame update
    void Start()
    {
        botonInstanciar.onClick.AddListener(InstanciarObjeto);
        botonQuitarUltimaInstancia.onClick.AddListener(QuitarUltimaInstancia);
    }

    // Update is called once per frame
    void Update()
    {
        

       

    }

    public void InstanciarObjeto()
    {
        
        //Se debera colocar el objeto ObjetoAInstanciar como hijo del objeto Contenido para que se muestre en la interfaz
        GameObject nuevaInstancia = Instantiate(ObjetoAInstanciar, Contenido.transform);
    }

    public void QuitarUltimaInstancia()
    {
        //Se debera eliminar la ultima instancia del objeto ObjetoAInstanciar que se haya creado
        if (Contenido.transform.childCount > 0)
        {
            Transform ultimaInstancia = Contenido.transform.GetChild(Contenido.transform.childCount - 1);
            Destroy(ultimaInstancia.gameObject);
        }
    }
}
