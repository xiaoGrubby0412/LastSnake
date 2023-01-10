using UnityEngine;
using System.Collections;

public class mingci : MonoBehaviour
{
    public struct Snake
    {
        public string name;
        public int length;
    }

    public UILabel lab1, lab2, lab3, lab4;
    public static Snake[] St = new Snake[11];
    int i = 0;
    int j = 0;
    Snake st;

    // Use this for initialization
    void Start()
    {
        for (i = 0; i < St.Length; i++)
        {
            St[i].name = str[i];
        }

//		print (St [10].length+","+St[10].name);
        lab1 = GameObject.Find("yongdao").GetComponent<UILabel>();
        lab2 = GameObject.Find("dierming").GetComponent<UILabel>();
        lab3 = GameObject.Find("disangming").GetComponent<UILabel>();
        lab4 = GameObject.Find("disiming").GetComponent<UILabel>();
    }

    // Update is called once per frame
    //public static string PaiMing1="AIone",PaiMing2="",PaiMing3="",PaiMing4="",PaiMing5="",PaiMing6="",PaiMing7="",PaiMing8="",PaiMing9="",PaiMing10="",PaiMing11="";
    public static string[] str = new string[11]
    {
        "AIone", "AItwo", "AIthree", "AIfour", "AIfive", "AIsix", "AIseven", "AIeight", "AInine", "AIten", "MySnake"
    };

    //public static int SLength1 = 0,SLength2 = 0,SLength3 = 0,SLength4 = 0,SLength5 = 0,SLength6 = 0,SLength7 = 0,SLength8 = 0,SLength9 = 0,SLength10 = 0,SLength11 = 0;
    void Update()
    {
    }

    void FixedUpdate()
    {
        for (i = 0; i < St.Length - 1; i++)
        {
            for (j = i; j < St.Length - 1; j++)
            {
                if (St[j].length < St[j + 1].length)
                {
                    st = St[j];
                    St[j] = St[j + 1];
                    St[j + 1] = st;
                }
            }
        }

        //print (St [0].name + "," + St [0].length + "--" + St [1].name + "," + St [1].length + "--"+St [2].name + "," + St [2].length + "--");
        lab1.text = St[0].name + ":" + St[0].length * 30;
        lab2.text = St[1].name + ":" + St[1].length * 30;
        lab3.text = St[2].name + ":" + St[2].length * 30;
        lab4.text = St[3].name + ":" + St[3].length * 30;
    }
}