using UnityEngine;
using System.Collections;

public class SnakeControl : MonoBehaviour
{
    public static int SnakeCout = 18; //记录蛇身体的总长度  也可以在此处设置蛇身体的总长度
    public static int SnakeSpeed = 5; //记录蛇的速度

    public static int SnakeFenShu = 0; //记录蛇的分数

    //public static bool CanMove=false;//判断现在蛇是否处于移动状态，如果是就让他移动，如果不是就不让他移动
    // Use this for initialization
    public Vector3 headF, headL, bodyF, bodyL, v1, v2, v3;

    //定义一个数组存储mysnake的预设体坐标
    public GameObject SnakeHead;

    UILabel killc;

    //插入数组的所在层级
    void Start()
    {
        killc = GameObject.Find("killCount").GetComponent<UILabel>();
    }

    // Update is called once per frame
    void Update()
    {
        killc.text = "击杀:" + CollisionDetection.KillSnakeIs.ToString();
    }

    //让蛇的身体随蛇头移动
    public void SnakebodyMove(Vector3 v, Vector3 aiv)
    {
        //传进一个参数，蛇头移动前的坐标
        //	print (v.x + "," + v.y);
        SnakeHead = GameObject.Find("SnakeHead");
        GameObject Map = GameObject.Find("SnakeMapYes");
        headF = new Vector3(headL.x, headL.y, 0); //蛇头移动前的坐标
        headL = v; //蛇头移动后的坐标
        int c = Map.transform.childCount; //的到有多少个身体
        for (int i = 1; i < c; i++)
        {
            GameObject body = GameObject.Find("body" + i.ToString());
            bodyF = body.transform.localPosition; //记录没移动前的身体坐标
            if (i == 1)
            {
                bodyF = body.transform.localPosition; //记录第一个身体移动前的坐标
                v3 = new Vector3(bodyF.x, bodyF.y, 0);
                if (SnakeControl.SnakeSpeed > 4)
                    body.transform.localPosition = headF + aiv;
                body.transform.localPosition = headF; //得到移动后的坐标并且移动
            }
            else
            {
                if (i % 2 == 0) //偶数情况下
                {
                    v1 = body.transform.localPosition; //记录移动前的坐标
                    if (SnakeControl.SnakeSpeed > 4)
                        body.transform.localPosition = v3 + aiv;
                    body.transform.localPosition = v3; //得到移动后的坐标
                }
                else
                {
                    v3 = body.transform.localPosition; //记录移动前的坐标
                    if (SnakeControl.SnakeSpeed > 4)
                        body.transform.localPosition = v1 + aiv;
                    body.transform.localPosition = v1; //得到移动后的坐标并且进行移动
                }
            }
        }
    }
}