using UnityEngine;
using System.Collections;

public class AI7control : MonoBehaviour
{
    GameObject obj;

    // Use this for initialization
    void Start()
    {
        obj = GameObject.Find("AI7Panduan");
    }

    // Update is called once per frame
    void Update()
    {
        AIseven();
    }

    AIControl ai7 = new AIControl();

    public void AIseven()
    {
        //得到他的位移方向，
        //得到他的速度
        //得到他的长度
        //print (bleed);
        //if (bleed == false)
        //return;
        if (AIControl.AISnakeCanMove[6] == false) //第二条蛇是否死亡
            return;
        Vector3 v = new Vector3(AIControl.pos[6, 0].SnakePos.x, AIControl.pos[6, 0].SnakePos.y, 0);
        //print (v.x + "," + v.y);
        int sp = AIControl.pos[6, 0].SnakeSpeed;
        //	print ("速度是" + sp);
        //int length = AIControl.pos [6, 0].SnakeLength;
        //print ("长度是" + length);
        //string name = AIControl.pos [6, 0].whoSnake;
        //print ("名字是" + name);
        //GameObject obj = GameObject.Find (name);
        //print("线程进了这个方法");
        obj.transform.localPosition += sp * v.normalized; //给蛇产生位置
        //print("fff");
        GameObject dd = GameObject.Find("AISnakeHead7");
        ai7.AIXuaanzhuang(v.x, v.y, dd);
        //Vector3 yy = obj1.transform.localPosition;
        flootAIOneBody7(obj.transform.localPosition); //此函智能在最下面   不然 他下面的函数不能执行
    }

    //private GameObject SnakeHead;
    private Vector3 headF = Vector3.zero, headL, bodyF = new Vector3(0, 0, 0), v3 = Vector3.zero, v1 = Vector3.zero;

    public void flootAIOneBody7(Vector3 V)
    {
        //v移动前坐标 c1 蛇头名字 s1 找到要添加的AI1
        //print (v.x + "," + v.y);
        Vector3 v = new Vector3(V.x, V.y, 0);
        //SnakeHead=GameObject.Find("AI7Panduan");
        GameObject Map = GameObject.Find("AI7");
        headF = new Vector3(headL.x, headL.y, 0); //蛇头移动前的坐标
        headL = v; //蛇头移动后的坐标
        int c = Map.transform.childCount; //的到有多少个身体
        //		print (c);
        //print ("程序执行到这里"+(c - 2));
        for (int i = 1; i < c; i++)
        {
            GameObject body = GameObject.Find("AIseven" + i.ToString());
            bodyF = body.transform.localPosition; //记录没移动前的身体坐标
            //if(i==c-2)
            //print(bodyF.x+","+bodyF.y);
            if (i == 1)
            {
                bodyF = body.transform.localPosition; //记录第一个身体移动前的坐标
                v3 = new Vector3(bodyF.x, bodyF.y, 0);
                body.transform.localPosition = headF; //得到移动后的坐标并且移动
                //bodyL = new Vector3(headF.x,headF.y,0);//记录移动后的坐标
            }
            else
            {
                if (i % 2 == 0) //偶数情况下
                {
                    v1 = body.transform.localPosition; //记录移动前的坐标
                    body.transform.localPosition = v3; //得到移动后的坐标
                }
                else
                {
                    v3 = body.transform.localPosition; //记录移动前的坐标
                    body.transform.localPosition = v1; //得到移动后的坐标并且进行移动
                }
            }
        }
    }
}