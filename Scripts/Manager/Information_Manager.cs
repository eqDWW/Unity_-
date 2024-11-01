using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[System.Serializable]
public struct introduce_
{
    [Header("穴位位置")]
    public string acupoint_Poition;//穴位名称  穴位代号  穴位位置  取穴方法  所属经络  主治病症  针灸处方
    [Header("取穴方法")]
    public string acupoint_Fanund;
    [Header("所属经络")]
    public string meridian;
    [Header("主治病症")]
    public string disease;
    [Header("针灸处方")]
    public string method;
}


//单个穴位信息管理
public class Information_Manager : MonoBehaviour
{
    
    [Header("穴位名称")]public string acupoint_Name;
    [Header("穴位代号")]public string acupoint_Index;
    //穴位状态(显示/隐藏)
    [HideInInspector]public bool isacupoint_state = true;

    //穴位名称文本
    private TMP_Text name_Tmp;
    private MeshRenderer sphereMeshrenderer;

    [SerializeField][Header("点击穴位介绍内容")] private introduce_ introduce;
    [SerializeField][TextArea]private string introduce_str;//详细介绍内容文本



    private void Start()
    {
        name_Tmp=transform.Find("Sphere/Text").GetComponent<TMP_Text>();
        name_Tmp.text= acupoint_Name;//同步穴位文本
        sphereMeshrenderer=GetComponentInChildren<MeshRenderer>();

        //穴位信息
        introduce_str = string.Format("\n穴位名称；{0}\n穴位代号；{1}\n穴位位置：{2}\n取穴方法：{3}\n所属经络；{4}\n主治病症；{5}\n针灸处方；{6}\n",
            acupoint_Name, acupoint_Index, introduce.acupoint_Poition, introduce.acupoint_Fanund, introduce.meridian, introduce.disease, introduce.method);
    }
    //穴位被点击
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
