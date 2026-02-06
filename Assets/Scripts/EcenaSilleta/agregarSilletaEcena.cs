using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class agregarSilletaEcena : MonoBehaviour
{
    public GameObject estratix;
    public Transform padre;
    private bool agregado = false;

    public Button botonAgregarEstratix;
    // Start is called before the first frame update
    void Start()
    {
        botonAgregarEstratix.onClick.AddListener(agregarSilleta);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void agregarSilleta()
    {
        if (!agregado)
        {
            GameObject obj = Instantiate(estratix, padre);
            obj.transform.localPosition = new Vector3(1f, 0.15f, -0.3f);
            obj.transform.localRotation = Quaternion.Euler(180f, 0f, 0f);
            obj.transform.localScale = Vector3.one;
            agregado = true;
        }
    }
}
