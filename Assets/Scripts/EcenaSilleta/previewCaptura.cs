using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class previewCaptura : MonoBehaviour
{
    public Camera previewCamera;
    public RenderTexture renderTexture;
    public string nombreArchivo = "sprite.png";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Captura(string path)
    {



        RenderTexture.active = renderTexture;
        previewCamera.Render();

        Texture2D tex = new Texture2D(
            renderTexture.width,
            renderTexture.height,
            TextureFormat.RGBA32,
            false
        );

        tex.ReadPixels(
            new Rect(0, 0, renderTexture.width, renderTexture.height),
            0, 0
        );
        tex.Apply();

        byte[] png = tex.EncodeToPNG();

        path += "/" + nombreArchivo;
        File.WriteAllBytes(path, png);

        RenderTexture.active = null;

        Debug.Log("PNG generado en: " + path);
    }

   
       
}
