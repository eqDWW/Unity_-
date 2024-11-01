using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toogle_Event : MonoBehaviour
{

    [SerializeField][Header("¾­ÂçË÷Òý£¨0_£©")] private int meriaian_index;

    [SerializeField]private Search_Canvas search_canvas;

    private Toggle toggle;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener((bool isvolue) =>
        {

                toggle_event();
          

        });
    }

    void toggle_event()
    {
        search_canvas.set_meridian(toggle.isOn, meriaian_index);
    }





}
