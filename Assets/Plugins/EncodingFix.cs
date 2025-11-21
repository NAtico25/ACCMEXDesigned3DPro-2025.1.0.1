using System.Text;
using UnityEngine;

public class EncodingFix
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }
}

