using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_rotate : MonoBehaviour
{


    public  Transform target;//获取旋转目标
    public  Transform player_trans;

    public bool isrotate = true;


    private void Start()
    {
        player_trans = GameObject.Find("Player").transform;
        target = player_trans;
    }
    private void Update()
    {
        //当点击到画布上返回
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) return;
        camerazoom();
        if (!isrotate) return;
        camerarotate();
    }


    private void camerarotate() //摄像机围绕目标旋转操作
    {
        //transform.RotateAround(target.position, Vector3.up, 1 * Time.deltaTime); //摄像机围绕目标旋转
        var mouse_x = Input.GetAxis("Mouse X");//获取鼠标X轴移动
        var mouse_y = -Input.GetAxis("Mouse Y");//获取鼠标Y轴移动
        if (Input.GetKey(KeyCode.Mouse1))
        {
            
            transform.Translate(Vector3.left * (mouse_x * 15f) * Time.deltaTime);
            transform.Translate(Vector3.up * (mouse_y * 15f) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {         
            transform.RotateAround(target.transform.position, Vector3.up, mouse_x * 5);
            transform.RotateAround(target.transform.position, transform.right, mouse_y * 5);
        }
    }

    private void camerazoom() //摄像机滚轮缩放
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            transform.Translate(Vector3.forward * 0.1f);


        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            transform.Translate(Vector3.forward * -0.1f);
    }

}
