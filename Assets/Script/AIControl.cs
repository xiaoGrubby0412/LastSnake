using UnityEngine;
using System.Collections;
using System.Threading;

public class AIControl : MonoBehaviour
{
    public static Vector3 AIPositon = new Vector3(1, 0, 0); //给蛇产生位移的变量
    public static AIcontrols[,] pos = new AIcontrols[20, 20];

    public static string[] SnakeName = new string[]
    {
        "AI1Panduan", "AI2Panduan", "AI3Panduan", "AI4Panduan", "AI5Panduan", "AI6Panduan", "AI7Panduan", "AI8Panduan",
        "AI9Panduan", "AI10Panduan", "", "", "", "", "", "", "", "", "", "",
    };

    public GameObject AISnakeHead, obj;
    GameStartControl game = new GameStartControl();
    public static bool[] AISnakeCanMove = new bool[20];

    void Awake()
    {
        //给bool值进行赋值
        for (int i = 0; i < 20; i++)
        {
            AISnakeCanMove[i] = true;
        }

        KongJianControl(); //对控件的一些控制
        OWNSnake(); //默认的数组更新
        game.AIOneBody("body11", "AI1Panduan", 0, "AI1", "AIone"); //创建第一条蛇
        game.AIOneBody("body5", "AI2Panduan", 1, "AI2", "AItwo"); //创建第二条蛇
        game.AIOneBody("body6", "AI3Panduan", 2, "AI3", "AIthree"); //创建第3条蛇
        game.AIOneBody("body8", "AI4Panduan", 3, "AI4", "AIfour"); //创建第4条蛇
        game.AIOneBody("body9", "AI5Panduan", 4, "AI5", "AIfive"); //创建第5条蛇
        game.AIOneBody("body7", "AI6Panduan", 5, "AI6", "AIsix"); //创建第6条蛇
        game.AIOneBody("body18", "AI7Panduan", 6, "AI7", "AIseven"); //创建第7条蛇
        game.AIOneBody("body13", "AI8Panduan", 7, "AI8", "AIeight"); //创建第8条蛇
        game.AIOneBody("body1", "AI9Panduan", 8, "AI9", "AInine"); //创建第9条蛇
        game.AIOneBody("body4", "AI10Panduan", 9, "AI10", "AIten"); //创建第10条蛇
    }

    void Update()
    {
        //Fixed
        AIOne();
    }

    void KongJianControl()
    {
        obj = GameObject.Find("AI1Panduan");
        //obj = GameObject.Find ();
    }

    //此函数对AI的一些控制
    public void AIOne()
    {
        if (AISnakeCanMove[0] == false)
            return;
        Vector3 v = new Vector3(pos[0, 0].SnakePos.x, pos[0, 0].SnakePos.y, 0);
//		print (v.x + "," + v.y);
        int sp = pos[0, 0].SnakeSpeed;
        //	print ("速度是" + sp);
//		int length = pos [0, 0].SnakeLength;
        //print ("长度是" + length);
        //string name = pos [0, 0].whoSnake;
        //print ("名字是" + name);
        obj.transform.localPosition += sp * v.normalized; //给蛇产生位置
        //print("fff");
        GameObject dd = GameObject.Find("AISnakeHead1");
        AIXuaanzhuang(v.x, v.y, dd);
        //Vector3 yy = obj1.transform.localPosition;
        flootAIOneBody(obj.transform.localPosition); //此函智能在最下面   不然 他下面的函数不能执行
    }

    public GameObject SnakeHead;
    public Vector3 headF = Vector3.zero, headL, bodyF = new Vector3(0, 0, 0), v3 = Vector3.zero, v1 = Vector3.zero;

    public void flootAIOneBody(Vector3 V)
    {
        //v移动前坐标 c1 蛇头名字 s1 找到要添加的AI1
        Vector3 v = new Vector3(V.x, V.y, 0);
        //print (v.x + "," + v.y);
        SnakeHead = GameObject.Find("AI1Panduan");
        GameObject Map = GameObject.Find("AI1");
        headF = new Vector3(headL.x, headL.y, 0); //蛇头移动前的坐标
        headL = v; //蛇头移动后的坐标
        int c = Map.transform.childCount; //的到有多少个身体
        for (int i = 1; i < c; i++)
        {
            GameObject body = GameObject.Find("AIone" + i.ToString());
            bodyF = body.transform.localPosition; //记录没移动前的身体坐标
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

    //蛇头的旋转
    public void AIXuaanzhuang(float x, float y, GameObject AIo)
    {
        float m, j, i, q = 0;
        m = x * x + y * y;
        //		print (x + "," + y);
        j = Mathf.Sqrt(m);
        //print (j +"斜边");
        i = Mathf.Acos(x / j);
        //print (i +"弧度");
        if (i != 0)
        {
            q = (180 * i) / Mathf.PI;
            if (q >= 0 && q <= 90)
            {
                if (y > 0)
                {
                    AIo.transform.rotation = Quaternion.Euler(0, 0, q + 90);
                }
                else
                    AIo.transform.rotation = Quaternion.Euler(0, 0, -q + 90);
            }
            else if (q > 90 && q <= 180)
            {
                if (y > 0)
                {
                    AIo.transform.rotation = Quaternion.Euler(0, 0, q + 90);
                }
                else
                    AIo.transform.rotation = Quaternion.Euler(0, 0, -q + 90);
            }
        }
    }


    //结构类
    public struct AIcontrols
    {
        public string whoSnake; //标明是哪一条蛇
        public int SnakeLength; //标明是多少长度
        public int SnakeSpeed; //标明蛇的速度
        public Vector3 SnakePos; //标明蛇从哪个方向运动之
        public int AISnakeCount; //当蛇吃到了3个食物就给他的身体加一节
    }

    //每条i蛇的默认初始属性 在游戏开始的时候调用
    public void OWNSnake()
    {
        //	int j = 0;
        //for(int n=0;n<SnakeName.GetLength(0);n++)
        for (int i = 0; i < pos.GetLength(0); i++)
        {
            pos[i, 0].whoSnake = SnakeName[i];
            pos[i, 0].SnakeLength = 18; //默认长度
            pos[i, 0].SnakeSpeed = 5; //默认初始速度
            pos[i, 0].SnakePos = AIPositon; //默认运动方向
            pos[i, 0].AISnakeCount = 0;
        }

        pos[0, 0].SnakePos = new Vector3(-1, 0, 0);
    }

    //最重要的参数是count   记录了是哪一条蛇
    public void AIAddTo(int count, int length, int speed, Vector3 position, string name)
    {
        if (length > 0) //1
            pos[count, 0].SnakeLength = length; //如果传如的参数不为o
        if (speed > 0) //2
            pos[count, 0].SnakeSpeed = speed;
        if (position.x != 0 || position.y != 0) //3
            pos[count, 0].SnakePos = position;
        if (name != null) //4
            pos[count, 0].whoSnake = name;
    }
}