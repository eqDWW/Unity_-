using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[System.Serializable]
public struct introduce_
{
    [Header("Ѩλλ��")]
    public string acupoint_Poition;//Ѩλ����  Ѩλ����  Ѩλλ��  ȡѨ����  ��������  ���β�֢  ��Ĵ���
    [Header("ȡѨ����")]
    public string acupoint_Fanund;
    [Header("��������")]
    public string meridian;
    [Header("���β�֢")]
    public string disease;
    [Header("��Ĵ���")]
    public string method;
}


//����Ѩλ��Ϣ����
public class Information_Manager : MonoBehaviour
{
    
    [Header("Ѩλ����")]public string acupoint_Name;
    [Header("Ѩλ����")]public string acupoint_Index;
    //Ѩλ״̬(��ʾ/����)
    [HideInInspector]public bool isacupoint_state = true;

    //Ѩλ�����ı�
    private TMP_Text name_Tmp;
    private MeshRenderer sphereMeshrenderer;

    [SerializeField][Header("���Ѩλ��������")] private introduce_ introduce;
    [SerializeField][TextArea]private string introduce_str;//��ϸ���������ı�



    private void Start()
    {
        name_Tmp=transform.Find("Sphere/Text").GetComponent<TMP_Text>();
        name_Tmp.text= acupoint_Name;//ͬ��Ѩλ�ı�
        sphereMeshrenderer=GetComponentInChildren<MeshRenderer>();

        //Ѩλ��Ϣ
        introduce_str = string.Format("\nѨλ���ƣ�{0}\nѨλ���ţ�{1}\nѨλλ�ã�{2}\nȡѨ������{3}\n�������磻{4}\n���β�֢��{5}\n��Ĵ�����{6}\n",
            acupoint_Name, acupoint_Index, introduce.acupoint_Poition, introduce.acupoint_Fanund, introduce.meridian, introduce.disease, introduce.method);
    }
    //Ѩλ�����
    private void OnMouseDown()
    {
        if (!isacupoint_state) return;
        GameManager.Instance.introduce_Event(introduce_str);
    }


    private void Update()
    {
        if(isacupoint_state)
        {
            if (sphereMeshrenderer.enabled) return;
            sphereMeshrenderer.enabled = true;
            name_Tmp.enabled = true;
          
        }
        else
        {
            if (!sphereMeshrenderer.enabled) return;
            sphereMeshrenderer.enabled = false;
            name_Tmp.enabled = false;
          
        }
    }


}
