using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//����������Ѩλ��
public class meridian_Manager : MonoBehaviour
{
    //��ʾ·��������
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

    //��ʾ����
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
    //���ؾ���
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


  /*  //�����þ����µ�Ѩλ������Ϣ�Լ�����
    public Vector3 SearchEvent(string acupoint_Name)
    {
        Vector3 linTrna = Vector3.zero;
        for (int i = 0; i < transform.childCount; i++)
        {
            var lin = transform.GetChild(i).GetComponent<Information_Manager>();

            if (lin.acupoint_Name == acupoint_Name || lin.acupoint_Index == acupoint_Name)
            {
                //�����ɹ�
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
