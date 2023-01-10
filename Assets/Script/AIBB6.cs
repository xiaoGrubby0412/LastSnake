using UnityEngine;
using System.Collections;

public class AIBB6 : MonoBehaviour
{
    public static bool startPanel6 = false;
    public static bool IsOR6 = false;

    GameStartControl gamestart = new GameStartControl();

    // Update is called once per frame
    void Update()
    {
        if (IsOR6 == true)
        {
            IsOR6 = false;

            gamestart.AIOneBody("body7", "AI6Panduan", 5, "AI6", "AIsix"); //创建第6条蛇
            AIControl.AISnakeCanMove[5] = true;
            startPanel6 = true;
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (startPanel6 == false)
            return; //还不能开始计算
        string ss = collider.name;
        string sssss = "";
        sssss = ss.Substring(0, 4);
        for (int io = 0; io < One.str6.GetLength(0); io++)
            if (sssss == One.str6[io])
            {
                AIControl.AISnakeCanMove[5] = false;
                IsOR6 = true; //是否要被创建
                startPanel6 = false; //是否还要发生碰撞
                IsOR6 = true; //是否要被创建
                //print("撞到了身体");

                AIO6();
                GameObject game = GameObject.Find("AI6Panduan");
                GameObject suiji = GameObject.Find("suijisnake6");
                game.transform.localPosition = suiji.transform.localPosition;
                AIControl.pos[5, 0].SnakeLength = 18; //初始化长度
                if (sssss == "body")
                {
                    CollisionDetection.KillSnakeIs++;
                    return;
                }
            }
    }

    IEnumerator Robot()
    {
        yield return new WaitForSeconds(0.2f);
    }

    UIWidget wid;

    private void AIO6()
    {
        int a = AIControl.pos[5, 0].SnakeLength;
        float xxx, yyy;
        int v = a;
        //删除这条蛇
        for (int i = 1; i <= a; i++)
        {
            GameObject gg = GameObject.Find("AIsix" + i.ToString());
            xxx = gg.transform.localPosition.x;
            yyy = gg.transform.localPosition.y;
            //一个变量记录这条蛇
            Destroy(gg);
            if (i % 3 == 0)
            {
                v++;
                //如果剩余数为0
                GameObject daHao = GameObject.Find("DAfood");
                GameObject obj1 = (GameObject)Instantiate(Resources.Load("body7")); //找到预设体
                obj1.transform.parent = daHao.transform;
                obj1.transform.localPosition = new Vector3(xxx, yyy, 0);
                obj1.transform.localScale = new Vector3(1, 1, 1);
                obj1.name = "AI6food" + v.ToString();
                wid = obj1.transform.GetComponent<UIWidget>();
                wid.height = 17;
                wid.width = 17;
            }
        }
    } /*
	public void OnTriggerEnter(Collider collider){
		string ss = collider.name;
		//		print (ss);
		if (ss == "collide_Top" || ss == "collide_Bottom" || ss == "collide_left" || ss == "collide_Right") {
			//AIControl.bleed=false;//此条蛇不能运动
			
			AIControl.AISnakeCanMove[5]=false;
			//AIKillFod("AI1","AIone","body11");
			AIO();
			StartCoroutine("Robot");
			//si le 之后 看看他的长度是否是大于20如果是那么进行删除然后地图中重新生成一条小蛇
			//生成之后让他能走
			GameObject game  = GameObject.Find("AI6Panduan");
			GameObject game1 = GameObject.Find("suijisnake6");
			game.transform.localPosition = game1.transform.localPosition;
			//把数组下标变成20
			//让后重新生成蛇
			AIControl.pos[5,0].SnakeLength=20;//初始化蛇的长度
			GameStartControl gamestart = new GameStartControl();
			gamestart.AIOneBody ("body7", "AI6Panduan", 5, "AI6", "AIsix");//创建第6条蛇
			AIControl.AISnakeCanMove[5]=true;
		}
		string sssss = "";
		sssss = ss.Substring(0,4);
		for(int io=0;io<One.str6.GetLength(0);io++)
		if (sssss == One.str6[io]) {
			AIControl.AISnakeCanMove[5]=false;
			AIO();
			StartCoroutine("Robot");
			GameObject game  = GameObject.Find("AI6Panduan");
			GameObject game1 = GameObject.Find("suijisnake6");
			game.transform.localPosition = game1.transform.localPosition;
			//把数组下标变成20
			//让后重新生成蛇
			AIControl.pos[5,0].SnakeLength=20;//初始化蛇的长度
			GameStartControl gamestart = new GameStartControl();
			gamestart.AIOneBody ("body7", "AI6Panduan", 5, "AI6", "AIsix");//创建第6条蛇
			AIControl.AISnakeCanMove[5]=true;
			
		}
	}*/
}