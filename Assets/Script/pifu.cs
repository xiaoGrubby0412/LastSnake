using UnityEngine;
using System.Collections;

public class pifu : MonoBehaviour
{
    public GameObject obj;
    public UIWidget wid, wid1;
    public UIToggle tog1, tog2, tog3, tog4, tog5, tog6, tog7, tog8, tog9;

    public static string s = "body7";

    // Use this for initialization
    void Start()
    {
        valuetog();
    }

    // Update is called once per frame
    void Update()
    {
    }

    //皮肤走起
    public void Pifu()
    {
        wid.transform.localPosition = Vector3.zero;
        wid1.transform.localPosition = new Vector3(8888, 88888, 0);
    }

    //商城返回
    public void back()
    {
        wid.transform.localPosition = new Vector3(88888, 0, 0);
        wid1.transform.localPosition = Vector3.zero;
    }

    public void ToggleValue()
    {
        if (tog1.value == true)
            s = "body1";
        else if (tog3.value == true)
            s = "body14";
        else if (tog7.value == true)
            s = "body6";
        else if (tog8.value == true)
            s = "body17";
        else if (tog9.value == true)
            s = "body8";
        else
            s = "body7";
    }

    public void valuetog()
    {
        //找到商城
        obj = GameObject.Find("shop"); //找到了商城
        wid = GameObject.Find("shoppIng").GetComponent<UIWidget>();
        wid1 = GameObject.Find("wjms").GetComponent<UIWidget>();
        //给所有对象赋值
        tog1 = GameObject.Find("kuang").GetComponent<UIToggle>();
        tog2 = GameObject.Find("kuang1").GetComponent<UIToggle>();
        tog3 = GameObject.Find("kuang2").GetComponent<UIToggle>();
        tog4 = GameObject.Find("kuang3").GetComponent<UIToggle>();
        tog5 = GameObject.Find("kuang4").GetComponent<UIToggle>();
        tog6 = GameObject.Find("kuang5").GetComponent<UIToggle>();
        tog7 = GameObject.Find("kuang6").GetComponent<UIToggle>();
        tog8 = GameObject.Find("kuang7").GetComponent<UIToggle>();
        tog9 = GameObject.Find("kuang8").GetComponent<UIToggle>();
    }
}