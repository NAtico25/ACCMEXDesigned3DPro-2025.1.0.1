using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class botonRadial : MonoBehaviour
{
    public Sprite spriteNormal; 
    public Sprite spriteHover;
    private Image image;
    public bool isHovering = false;


    void Awake()
    {
        image = GetComponent<Image>();
        image.sprite = spriteNormal;
        if (image == null)
        {
            Debug.LogError("No se encontró el componente Image en el GameObject.");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isHovering)
            image.sprite = spriteHover;
        else
            image.sprite = spriteNormal;
    }
}
