using UnityEngine;
using System.Collections;

public class rules : MonoBehaviour
{
    public GameObject obj;

    public UIWidget wid;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static int Ga = 0;

    public void Rules()
    {
        UIWidget wid1, wid2, wid3, wid4;
        wid1 = GameObject.Find("wjms").GetComponent<UIWidget>();
        wid2 = GameObject.Find("s1").GetComponent<UIWidget>();
        wid3 = GameObject.Find("s2").GetComponent<UIWidget>();
        wid4 = GameObject.Find("s3").GetComponent<UIWidget>();
        Ga++;
        if (Ga == 1)
        {
            //页面跳转
            wid1.transform.localPosition = new Vector3(8888, 8888, 0);
            obj = GameObject.Find("guize");
            obj.transform.localPosition = Vector3.zero;
        }
        else if (Ga == 2)
        {
            wid2.depth = 5;
            wid3.depth = 4;
            wid4.depth = 3;
        }
        else if (Ga == 3)
        {
            wid2.depth = 3;
            wid3.depth = 5;
            wid4.depth = 3;
        }
        else if (Ga == 4)
        {
            wid2.depth = 3;
            wid3.depth = 3;
            wid4.depth = 5;
        }
        else if (Ga == 5)
        {
            obj = GameObject.Find("guize");
            obj.transform.localPosition = new Vector3(8888, 8888, 0);
            wid1.transform.localPosition = Vector3.zero;
            Ga = 0;
        }
    }
}