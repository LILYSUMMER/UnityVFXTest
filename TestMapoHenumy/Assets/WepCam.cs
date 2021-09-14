using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ķ���� ���� �ؽ��ĸ� �޾ƿ�, ���� �ؽ��Ŀ� �Ҵ��ϰ� 
// �̸� �÷��ο� �����غ���
public class WepCam : MonoBehaviour
{
    [Header("����� ī�޶��� ���° ī�޶� ����Ұ� �ΰ�(����Ʈ=0)")]
    public int DeviceIndex;

    [Header("����� ī�޶��� �ػ� �� ������")]
    public int width = 128;
    public int height = 128;
    public int fps = 30;

    [Header("��ķ���� ���� �ؽ��ĸ� �޾� ������ ���� �ؽ���")]
    public RenderTexture renderTexture;
    WebCamTexture webCamTexture;
    void SetWebCamTexture(int index)
    {
        //��ķ�ؽ��İ� ������̶��
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
