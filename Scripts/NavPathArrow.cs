using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ������ͷ������
/// </summary>
public class NavPathArrow : MonoBehaviour
{

    private meridian_Manager meridian_manager;
    private List<Transform> points = new List<Transform>();//·����


    private LineRenderer LineRenderer;
    [SerializeField][Header("�������")] private float line_width = 0.01f;
    [Header("��������")]public Material line_Mat;


    void Start()
    {
        initialize();    

       //��ȡ·����
        var vertex_trans = transform.Find("����vertex_s����");
        for (int i = 0; i < vertex_trans.childCount; i++)
        {
            points.Add(vertex_trans.GetChild(i));
        }
        //����������Ⱦ��
        foreach (Transform tran in points)
        {
            setliner(LineRenderer, tran.position);
        }
        //meridian_manager.hide_event();
    }
    //��ʼ��
    void initialize()
    {
        meridian_manager = GetComponent<meridian_Manager>();
        LineRenderer =this.AddComponent<LineRenderer>();
        LineRenderer.startWidth = line_width;
        LineRenderer.endWidth = line_width;
        LineRenderer.material = line_Mat;
        LineRenderer.positionCount = 0;     
    }

    #region ����·��״̬
    //��ʾ·��
    public void display_()
    {
        LineRenderer.enabled = true;
    }
    //����·��
    public void hide()
    {
        LineRenderer.enabled = false;
    }
    #endregion
    //����������Ⱦ��
    void setliner(LineRenderer linerenderer,Vector3 target)
    {    
        linerenderer.positionCount++;
        linerenderer.SetPosition(linerenderer.positionCount-1, target);
    }
  
}

