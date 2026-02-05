using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activar_prefap_menu_radial : MonoBehaviour
{
    public GameObject menuRadial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        menuRadial.SetActive(Input.GetKey(KeyCode.Tab));
    }
}
