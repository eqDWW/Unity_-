using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���ܻ���
public class introduce_Canvas : MonoBehaviour
{

    //���ذ�ť
    private Button returnbutton;

    private void Start()
    {
        returnbutton=transform.Find("return_Button").GetComponent<Button>();
        returnbutton.onClick.AddListener(() => { GameManager.Instance.quit_introduc(); });
    }

    

}
