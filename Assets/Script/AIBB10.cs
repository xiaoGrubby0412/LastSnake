using UnityEngine;
using System.Collections;

public class AIBB10 : MonoBehaviour
{
    public static bool startPanel10 = false;
    public static bool IsOR10 = false;

    IEnumerator Robot()
    {
        yield return new WaitForSeconds(0.2f);
    }

    UIWidget wid;

    private void AIO10()
    {
        //GameObject map = GameObject.Find("AI10");//找到了这个对象
        int a = AIControl.pos[9, 0].SnakeLength;
        float xxx, yyy;
        int v = a;
        //删除这条蛇
        for (int i = 1; i <= a; i++)
        {
            GameObject gg = GameObject.Find("AIten" + i.ToString());
            xxx = gg.transform.localPosition.x;
            yyy = gg.transform.localPosition.y;
            //一个变量记录这条蛇
            Destroy(gg);
            if (i % 3 == 0)
            {
                v++;
                //如果剩余数为0
                GameObject daHao = GameObject.Find("DAfood");
                GameObject obj1 = (GameObject)Instantiate(Resources.Load("body4")); //找到预设体
                obj1.transform.parent = daHao.transform;
                obj1.transform.localPosition = new Vector3(xxx, yyy, 0);
                obj1.transform.localScale = new Vector3(1, 1, 1);
                obj1.name = "AI10food" + v.ToString();
                wid = obj1.transform.GetComponent<UIWidget>();
                wid.height = 17;
                wid.width = 17;
            }
        }
    }

    GameStartControl gamestart = new GameStartControl();

    // Update is called once per frame
    void Update()
    {
        if (IsOR10 == true)
        {
            IsOR10 = false;

            gamestart.AIOneBody("body4", "AI10Panduan", 9, "AI10", "AIten"); //创建第10条蛇
            AIControl.AISnakeCanMove[9] = true;
            startPanel10 = true;
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (startPanel10 == false)
            return; //还不能开始计算
        string ss = collider.name;
        string sssss = "";
        sssss = ss.Substring(0, 4);
        for (int io = 0; io < One.str10.GetLength(0); io++)
            if (sssss == One.str10[io])
            {
                AIControl.AISnakeCanMove[9] = false;
                IsOR10 = true; //是否要被创建
                startPanel10 = false; //是否还要发生碰撞
                IsOR10 = true; //是否要被创建
                //print("撞到了身体");
                //int a=AIControl.pos[9,0].SnakeLength;
                AIO10();
                GameObject game = GameObject.Find("AI10Panduan");
                GameObject suiji = GameObject.Find("suijisnake10");
                game.transform.localPosition = suiji.transform.localPosition;
                AIControl.pos[9, 0].SnakeLength = 18; //初始化长度
                //return;
                if (sssss == "body")
                {
                    CollisionDetection.KillSnakeIs++;
                    return;
                }
            }
    }
}