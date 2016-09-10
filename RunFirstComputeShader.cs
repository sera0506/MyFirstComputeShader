using UnityEngine;
using System.Collections;

public class RunFirstComputeShader : MonoBehaviour {

    /// <summary>
    /// 指定要使用的compute shader
    /// </summary>
    public ComputeShader computeShader;
    
    /// <summary>
    /// 可寫入的render texture
    /// </summary>
    RenderTexture rwTexture;

    void Start()
    {
        //512*512 render texture. 8 bits per channel.
        rwTexture = new RenderTexture(512, 512, 0, RenderTextureFormat.ARGB32);
        rwTexture.enableRandomWrite = true;
        rwTexture.Create();
    }

    void OnGUI()
    {
        //將render texture設定給computeShader中的Resulat
        computeShader.SetTexture(0, "Result", rwTexture);
        //execute computeShader init kernel: CSMain
        computeShader.Dispatch(0, rwTexture.width / 8, rwTexture.height / 8, 1);

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), rwTexture);
    }
}
