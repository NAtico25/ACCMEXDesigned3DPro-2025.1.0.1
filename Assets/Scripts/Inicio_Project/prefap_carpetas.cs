using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class prefap_carpetas : MonoBehaviour
{
    public int idCarpeta;
    public TextMeshProUGUI nombreCarpetaText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AsignarDatos(int id, string nombreCarpeta)
    {
        idCarpeta = id;
        nombreCarpetaText.text = nombreCarpeta;
    }


}
