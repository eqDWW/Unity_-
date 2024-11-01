using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//搜索管理器
public class Search_Manager : MonoBehaviour
{
    public static Search_Manager searchmanagerl;




    //所有经络
    private List<Transform> meridian_manager = new List<Transform>();
    //目标经络缓存
    private Transform meriaian_lin = null;
    //返回注视画布对象
    private GameObject returnObject;
    //返回注视按钮
    private Button rturnButton;
    //相机行为
    private Input_rotate inputrotae;
    //需要关闭的对象(经络选择对象)
    private GameObject meridian_toggleobject;
    //经络选择勾选框父对象
    private Transform toggle_Parent;
    //全部勾选框
    private List<Toggle> toggles = new List<Toggle>();

    private int meridian_index;
    private void Awake()
    {
        if (searchmanagerl == null)
        {
            searchmanagerl = this;
        }
    }
    private void Start()
    {
        initialize();
    }
    //初始化
    void initialize()
    {
        returnObject = GameObject.Find("Return_Canvas");
        rturnButton = returnObject.transform.Find("ReturnButton").GetComponent<Button>();
        rturnButton.onClick.AddListener(returnbutton_Event);
        returnObject.SetActive(false);
        inputrotae = Camera.main.GetComponent<Input_rotate>();
        
        //获取经络选择对象
        meridian_toggleobject = GameObject.Find("function_Canvas").transform.Find("meridianz_ButtonS").gameObject;
        //获取Toggle父对象
        toggle_Parent = meridian_toggleobject.transform.Find("Scroll View/Viewport/Content_ButtonS");

        for (int i = 0; i < transform.childCount; i++)
        {
            meridian_manager.Add(transform.GetChild(i));
        }

        for (int i = 0; i < toggle_Parent.childCount; i++)
        {
            toggles.Add(toggle_Parent.GetChild(i).GetComponent<Toggle>());
        }
    }
    //搜索
    public void Search_(string acupointName)
    {
        if (acupointName == "") return;
        for (int i = 0; i < meridian_manager.Count; i++)
        {
            //遍历每条经络
            for (int j = 0; j < meridian_manager[i].childCount; j++)
            {
                //穴位点
                try
                {
                    var mana = meridian_manager[i].GetChild(j).GetComponent<Information_Manager>();
                    if (mana.acupoint_Name == acupointName || mana.acupoint_Index == acupointName)
                    {
                        Camera_Gimbal.cameragimbal.set_gimbal(mana.transform.position); //设置相机移动注视点
                        meriaian_lin = meridian_manager[i];//目标经络
                        meridian_index = i;
                        print(i);
                        meriaian_lin.gameObject.SetActive(true);//打开经络目标
                        inputrotae.isrotate = false;//禁止相机旋转
                        returnObject.SetActive(true);//打开返回画布
                        meridian_toggleobject.SetActive(false);

                    }
                }
                catch
                {
                    break;
                }

            }
        }

    }




    //关闭注视模式事件
    private void returnbutton_Event()
    {
       
        inputrotae.isrotate = true;//可旋转相机
        returnObject.SetActive(false);//关闭画布
        meridian_toggleobject.SetActive(true);//打开经络选择对象

        if (toggles[meridian_index].isOn)
        {
            meriaian_lin = null;//缓存对象设空
            meridian_index = 0;//清空
            return;
        }     
        else
        {
            meriaian_lin.gameObject.SetActive(false);//关闭当前经络
            meriaian_lin = null;//缓存对象设空
            meridian_index = 0;//清空
        }


    }


}
