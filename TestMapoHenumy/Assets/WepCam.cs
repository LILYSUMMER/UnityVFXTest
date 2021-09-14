using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//웹캠으로 부터 텍스쳐를 받아와, 렌더 텍스쳐에 할당하고 
// 이를 플레인에 매핑해보자
public class WepCam : MonoBehaviour
{
    [Header("연결된 카메라중 몇번째 카메라를 사용할것 인가(디폴트=0)")]
    public int DeviceIndex;

    [Header("사용할 카메라의 해상도 및 프레임")]
    public int width = 128;
    public int height = 128;
    public int fps = 30;

    [Header("웹캠으로 부터 텍스쳐를 받아 저장할 렌더 텍스쳐")]
    public RenderTexture renderTexture;
    WebCamTexture webCamTexture;
    void SetWebCamTexture(int index)
    {
        //웹캠텍스쳐가 사용중이라면
        if (webCamTexture != null && webCamTexture.isPlaying) webCamTexture.Stop();
        WebCamDevice[] devices = WebCamTexture.devices;
        webCamTexture = new WebCamTexture(devices[index].name, this.width, this.height, this.fps);
        webCamTexture.Play();
    }
    void Start()
    {
        SetWebCamTexture(DeviceIndex);
        if(renderTexture == null)
        {
            Debug.LogError("renderTexture == null");
            return;
        }
    }

    void Update()
    {
        Graphics.Blit(webCamTexture, renderTexture);
    }
}
