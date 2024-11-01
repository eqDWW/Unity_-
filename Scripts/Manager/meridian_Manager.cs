using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//经络管理（多个穴位）
public class meridian_Manager : MonoBehaviour
{
    //显示路径管理器
    private NavPathArrow nacpatharrow;

    private void Start()
    {
        nacpatharrow = GetComponent<NavPathArrow>();
       // hide_event();
    }
    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.F))
       {
            Full_event();
       }

        /*if (Input.GetKeyDown(KeyCode.H))
        {
            hide_event();
        }*/
    }

    //显示经络
    public void Full_event()
    {
        //nacpatharrow.display_();
       /* for (int i = 0; i < transform.childCount; i++)
        {
            try
            {
                transform.GetChild(i).GetComponent<Information_Manager>().isacupoint_state = true;
            }
            catch
            {
                return;
            }
        }*/
    }
    //隐藏经络
    /*public void hide_event()
    {
        nacpatharrow.hide();
        for (int i = 0; i < transform.childCount; i++)
        {
            try
            {
                transform.GetChild(i).GetComponent<Information_Manager>().isacupoint_state = false;
            }
            catch { break; }
        }
    }*/


  /*  //搜索该经络下的穴位名字信息以及代号
    public Vector3 SearchEvent(string acupoint_Name)
    {
        Vector3 linTrna = Vector3.zero;
        for (int i = 0; i < transform.childCount; i++)
        {
            var lin = transform.GetChild(i).GetComponent<Information_Manager>();

            if (lin.acupoint_Name == acupoint_Name || lin.acupoint_Index == acupoint_Name)
            {
                //搜索成功
                linTrna = lin.transform.position;
            }
            else
            {
                linTrna = Vector3.zero;

            }
        }
        return linTrna;
    }*/
}
