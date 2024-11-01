using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_rotate : MonoBehaviour
{


    public  Transform target;//��ȡ��תĿ��
    public  Transform player_trans;

    public bool isrotate = true;


    private void Start()
    {
        player_trans = GameObject.Find("Player").transform;
        target = player_trans;
    }
    private void Update()
    {
        //������������Ϸ���
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) return;
        camerazoom();
        if (!isrotate) return;
        camerarotate();
    }


    private void camerarotate() //�����Χ��Ŀ����ת����
    {
        //transform.RotateAround(target.position, Vector3.up, 1 * Time.deltaTime); //�����Χ��Ŀ����ת
        var mouse_x = Input.GetAxis("Mouse X");//��ȡ���X���ƶ�
        var mouse_y = -Input.GetAxis("Mouse Y");//��ȡ���Y���ƶ�
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

    private void camerazoom() //�������������
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            transform.Translate(Vector3.forward * 0.1f);


        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            transform.Translate(Vector3.forward * -0.1f);
    }

}
