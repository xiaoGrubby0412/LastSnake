using UnityEngine;
using System.Collections;
using System.Threading;

public class AIBB : MonoBehaviour
{
    public static bool startPanel = false;
    public static bool IsOR = false;

    GameStartControl gamestart = new GameStartControl();

    // Update is called once per frame
    void Update()
    {
        if (IsOR == true)
        {
            IsOR = false;

            gamestart.AIOneBody("body11", "AI1Panduan", 0, "AI1", "AIone"); //创建第一条蛇
            AIControl.AISnakeCanMove[0] = true;
            startPanel = true;
        }
    }

    UIWidget wid;

    public void AIO()
    {
        //GameObject map = GameObject.Find("AI1");//找到了这个对象
        //int a=map.transform.childCount;
        int a = AIControl.pos[0, 0].SnakeLength;
        float xxx, yyy;
        int v = a;
        //删除这条蛇
        for (int i = 1; i <= a; i++)
        {
            GameObject gg = GameObject.Find("AIone" + i.ToString());
            xxx = gg.transform.localPosition.x;
            yyy = gg.transform.localPosition.y;
            //一个变量记录这条蛇
            Destroy(gg);
            if (i % 3 == 0)
            {
                v++;
                //如果剩余数为0
                GameObject daHao = GameObject.Find("DAfood");
                GameObject obj1 = (GameObject)Instantiate(Resources.Load("body11")); //找到预设体
                obj1.transform.parent = daHao.transform;
                obj1.transform.localPosition = new Vector3(xxx, yyy, 0);
                obj1.transform.localScale = new Vector3(1, 1, 1);
                obj1.name = "AI1food" + v.ToString();
                wid = obj1.transform.GetComponent<UIWidget>();
                wid.height = 17;
                wid.width = 17;
            }
        }
    }

    /*IEnumerator Robot(){
        yield return new WaitForSeconds (0.2f);
    }*/
    public void OnTriggerEnter(Collider collider)
    {
        if (startPanel == false)
            return; //还不能开始计算
        string ss = collider.name;
        string sssss = "";
        sssss = ss.Substring(0, 4);
        for (int io = 0; io < One.str1.GetLength(0); io++)
            if (sssss == One.str1[io])
            {
                AIControl.AISnakeCanMove[0] = false;
                IsOR = true; //是否要被创建
                startPanel = false; //是否还要发生碰撞
                IsOR = true; //是否要被创建
//			print("撞到了身体");
                //int a=AIControl.pos[0,0].SnakeLength;
                AIO();
                GameObject game = GameObject.Find("AI1Panduan");
                GameObject suiji = GameObject.Find("suijisnake1");
                game.transform.localPosition = suiji.transform.localPosition;
                AIControl.pos[0, 0].SnakeLength = 18; //初始化长度
                if (sssss == "body")
                {
                    CollisionDetection.KillSnakeIs++;
                    return;
                }
            }
    }
}