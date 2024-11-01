using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//����������
public class Search_Manager : MonoBehaviour
{
    public static Search_Manager searchmanagerl;




    //���о���
    private List<Transform> meridian_manager = new List<Transform>();
    //Ŀ�꾭�绺��
    private Transform meriaian_lin = null;
    //����ע�ӻ�������
    private GameObject returnObject;
    //����ע�Ӱ�ť
    private Button rturnButton;
    //�����Ϊ
    private Input_rotate inputrotae;
    //��Ҫ�رյĶ���(����ѡ�����)
    private GameObject meridian_toggleobject;
    //����ѡ��ѡ�򸸶���
    private Transform toggle_Parent;
    //ȫ����ѡ��
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
    //��ʼ��
    void initialize()
    {
        returnObject = GameObject.Find("Return_Canvas");
        rturnButton = returnObject.transform.Find("ReturnButton").GetComponent<Button>();
        rturnButton.onClick.AddListener(returnbutton_Event);
        returnObject.SetActive(false);
        inputrotae = Camera.main.GetComponent<Input_rotate>();
        
        //��ȡ����ѡ�����
        meridian_toggleobject = GameObject.Find("function_Canvas").transform.Find("meridianz_ButtonS").gameObject;
        //��ȡToggle������
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
    //����
    public void Search_(string acupointName)
    {
        if (acupointName == "") return;
        for (int i = 0; i < meridian_manager.Count; i++)
        {
            //����ÿ������
            for (int j = 0; j < meridian_manager[i].childCount; j++)
            {
                //Ѩλ��
                try
                {
                    var mana = meridian_manager[i].GetChild(j).GetComponent<Information_Manager>();
                    if (mana.acupoint_Name == acupointName || mana.acupoint_Index == acupointName)
                    {
                        Camera_Gimbal.cameragimbal.set_gimbal(mana.transform.position); //��������ƶ�ע�ӵ�
                        meriaian_lin = meridian_manager[i];//Ŀ�꾭��
                        meridian_index = i;
                        print(i);
                        meriaian_lin.gameObject.SetActive(true);//�򿪾���Ŀ��
                        inputrotae.isrotate = false;//��ֹ�����ת
                        returnObject.SetActive(true);//�򿪷��ػ���
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




    //�ر�ע��ģʽ�¼�
    private void returnbutton_Event()
    {
       
        inputrotae.isrotate = true;//����ת���
        returnObject.SetActive(false);//�رջ���
        meridian_toggleobject.SetActive(true);//�򿪾���ѡ�����

        if (toggles[meridian_index].isOn)
        {
            meriaian_lin = null;//����������
            meridian_index = 0;//���
            return;
        }     
        else
        {
            meriaian_lin.gameObject.SetActive(false);//�رյ�ǰ����
            meriaian_lin = null;//����������
            meridian_index = 0;//���
        }


    }


}
