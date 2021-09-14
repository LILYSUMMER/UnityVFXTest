using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Collections;

//�ؽ��� �ڿ����� ���Ͽ�
public class WepCam2 : MonoBehaviour
{
    [Header("����� ī�޶��� ���° ī�޶� ����Ұ� �ΰ�(����Ʈ=0)")]
    public int DeviceIndex;

    [Header("����� ī�޶��� �ػ� �� ������")]
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

        //���� �ؽ��ĸ� Texture2D�� ��ȯ��, �ȼ������� �����ϱ� ���� ����
       // frame01Tex2D = new Texture2D(frame01.width, frame01.height);
       // frame02Tex2D = new Texture2D(frame02.width, frame02.height);
        
       // res
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
