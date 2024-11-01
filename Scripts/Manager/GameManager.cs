using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //ΩÈ…‹ª≠≤º
    private GameObject introduce_Canvas;
    private Text introduce_Text;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }    
    }
    private void Start()
    {
        introduce_Canvas = GameObject.Find("Canvas");
        introduce_Text=introduce_Canvas.transform.Find("Panel/Scroll View/Viewport/Content").GetComponent<Text>();

        introduce_Canvas.SetActive(false);
    }

    #region ΩÈ…‹
    /// <summary>
    /// œÍœ∏ΩÈ…‹
    /// </summary>
    /// <param name="str">ΩÈ…‹ƒ⁄»›</param>
    public void introduce_Event(string str)
    {
        introduce_Canvas.SetActive(true);
        introduce_Text.text = str;
    }
    //πÿ±’ΩÈ…‹ª≠≤º
    public void quit_introduc()
    {
        introduce_Text.text = null;
        introduce_Canvas.SetActive(false);
    }

    #endregion

}
