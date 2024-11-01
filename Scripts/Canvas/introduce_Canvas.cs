using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ΩÈ…‹ª≠≤º
public class introduce_Canvas : MonoBehaviour
{

    //∑µªÿ∞¥≈•
    private Button returnbutton;

    private void Start()
    {
        returnbutton=transform.Find("return_Button").GetComponent<Button>();
        returnbutton.onClick.AddListener(() => { GameManager.Instance.quit_introduc(); });
    }

    

}
