using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Collections;

//텍스쳐 자연산을 위하여
public class WepCam2 : MonoBehaviour
{
    [Header("연결된 카메라중 몇번째 카메라를 사용할것 인가(디폴트=0)")]
    public int DeviceIndex;

    [Header("사용할 카메라의 해상도 및 프레임")]
    public int width = 128;
    public int height = 128;
    public int fps = 30;

    WebCamTexture webCamTexture;
    void SetWebcamTexture(int index)
    {
        if (webCamTexture != null && webCamTexture.isPlaying)
            webCamTexture.Stop();

        WebCamDevice[] devices = WebCamTexture.devices;
        webCamTexture = new WebCamTexture(devices[index].name, this.width, this.height, this.fps);

        webCamTexture.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetWebcamTexture(DeviceIndex);

        //렌더 텍스쳐를 Texture2D로 변환해, 픽셀연산을 진행하기 위해 생성
       // frame01Tex2D = new Texture2D(frame01.width, frame01.height);
       // frame02Tex2D = new Texture2D(frame02.width, frame02.height);
        
       // res
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
