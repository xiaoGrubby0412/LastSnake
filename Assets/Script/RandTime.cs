using UnityEngine;
using System.Collections;

public class RandTime : MonoBehaviour
{
    public static int minis = 5;
    public static int soncend = 1;
    UILabel lab;
    GameObject Snake;
    public UILabel lab1, lab2, lab3; //1 是蛇的长度，2是击杀的数量   3 是你打败了多少的对手
    UIWidget gameover;
    public static int wjhaishixs = 0; //无尽模式还是现实模式   //0表示无模式  1 无尽  2 新事
    public static bool timeMove = false;

    public static int ta = 0;

    //public static bool timeMove=false;
    // Use this for initialization
    void Start()
    {
        lab = GameObject.Find("timel").GetComponent<UILabel>();
        gameover = GameObject.Find("gameover").GetComponent<UIWidget>();
        lab1 = GameObject.Find("gameoverlength").GetComponent<UILabel>();
        lab2 = GameObject.Find("gameoverkill").GetComponent<UILabel>();
        lab3 = GameObject.Find("gameoverplayer").GetComponent<UILabel>();
    }

    // Update is called once per frame
    void Update()
    {
        //如果游戏还没有结束和在在现实模式
        if (timeMove == true && wjhaishixs == 2)
        {
            //如果现在是现实模式
            ta++;
            if (ta % 25 == 0)
            {
                soncend--;
                if (soncend == 0)
                {
                    minis--;
                    if (soncend == 0 && minis == -1)
                    {
                        //游戏结束
                        CollisionDetection.Isgameover = true;
                        Snake = GameObject.Find("SnakeHead");
                        float x, y;
                        x = Snake.transform.localPosition.x;
                        y = Snake.transform.localPosition.y;
                        gameover.transform.localPosition = new Vector3(x, y, 0);
                        lab1.text = SnakeControl.SnakeCout.ToString(); //蛇的长度
                        lab2.text = CollisionDetection.KillSnakeIs.ToString();
                        float p = SnakeControl.SnakeFenShu;
                        float player = p / 100f;
                        //print(SnakeControl.SnakeCout);
                        lab3.text = "你击败了全国" + player + "%的玩家";
                        GameObject map = GameObject.Find("SnakeMapYes"); //找到了这个对象
                        int a = map.transform.childCount;
                        float xxx, yyy;
                        int v = 0;
                        //删除这条蛇
                        //print("a="+a.ToString());
                        //return;
                        for (int i = 1; i < a; i++)
                        {
                            GameObject gg = GameObject.Find("body" + i.ToString());
                            xxx = gg.transform.localPosition.x;
                            yyy = gg.transform.localPosition.y;
                            //一个变量记录这条蛇

                            if (i % 3 == 0)
                            {
                                v++;
                                //如果剩余数为0
                                GameObject daHao = GameObject.Find("DAfood");
                                GameObject obj1 = (GameObject)Instantiate(Resources.Load(pifu.s)); //找到预设体
                                obj1.transform.parent = daHao.transform;
                                obj1.transform.localPosition = new Vector3(xxx, yyy, 0);
                                obj1.transform.localScale = new Vector3(1, 1, 1);
                                obj1.name = "mefood" + v.ToString();
                                UIWidget wid;
                                wid = obj1.transform.GetComponent<UIWidget>();
                                wid.height = 20;
                                wid.width = 20;
                            }

                            Destroy(gg);
                        }

                        return;
                    }

                    soncend = 60;
                }

                if (soncend < 10)
                    lab.text = "0" + minis + ":" + "0" + soncend;
                else
                    lab.text = "0" + minis + ":" + soncend;
            }
        }

        if (CollisionDetection.Isgameover == true) //如果游戏已经结束就让他暂停
        {
            lab.text = "00:00";
            //wjhaishixs=0;//不能进行时间走
            timeMove = false;
        }
    }
}