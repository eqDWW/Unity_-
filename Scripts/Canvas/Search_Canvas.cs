using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//搜索画布对象(选择穴位)
public class Search_Canvas : MonoBehaviour
{
    private InputField tmpInputfield;

    private Button Search_Button;

    [SerializeField]
    [Header("经络父对象")] private Transform meridian_Parent;

    private List<GameObject>mers = new List<GameObject>();



    private void Start()
    {
        tmpInputfield = transform.Find("Search/InputField").GetComponent<InputField>();
        Search_Button = transform.Find("Search/Search_Button").GetComponent<Button>();
        Search_Button.onClick.AddListener(search_Event);

        //获取每条经络
        for (int i = 0; i < meridian_Parent.childCount; i++)
        {
            mers.Add(meridian_Parent.GetChild(i).gameObject);
        }
    }

    void search_Event()
    {
        if(tmpInputfield.text!=null)
        {
            Search_Manager.searchmanagerl.Search_(tmpInputfield.text);
        }
    }



    //Toggle 事件
    public void set_meridian(bool ison,int index)
    {
        if(ison)
        {
            //打开目标经络
            mers[index].SetActive(true);
        }
        else
        {

            mers[index].SetActive(false);

        }
    }


}
