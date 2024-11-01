using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 导航箭头管理器
/// </summary>
public class NavPathArrow : MonoBehaviour
{

    private meridian_Manager meridian_manager;
    private List<Transform> points = new List<Transform>();//路径点


    private LineRenderer LineRenderer;
    [SerializeField][Header("线条宽度")] private float line_width = 0.01f;
    [Header("线条材质")]public Material line_Mat;


    void Start()
    {
        initialize();    

       //获取路径点
        var vertex_trans = transform.Find("——vertex_s——");
        for (int i = 0; i < vertex_trans.childCount; i++)
        {
            points.Add(vertex_trans.GetChild(i));
        }
        //设置线条渲染器
        foreach (Transform tran in points)
        {
            setliner(LineRenderer, tran.position);
        }
        //meridian_manager.hide_event();
    }
    //初始化
    void initialize()
    {
        meridian_manager = GetComponent<meridian_Manager>();
        LineRenderer =this.AddComponent<LineRenderer>();
        LineRenderer.startWidth = line_width;
        LineRenderer.endWidth = line_width;
        LineRenderer.material = line_Mat;
        LineRenderer.positionCount = 0;     
    }

    #region 设置路径状态
    //显示路径
    public void display_()
    {
        LineRenderer.enabled = true;
    }
    //隐藏路径
    public void hide()
    {
        LineRenderer.enabled = false;
    }
    #endregion
    //设置线条渲染器
    void setliner(LineRenderer linerenderer,Vector3 target)
    {    
        linerenderer.positionCount++;
        linerenderer.SetPosition(linerenderer.positionCount-1, target);
    }
  
}

