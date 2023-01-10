using UnityEngine;
using System.Collections;

public class CollisionOtherSnake : MonoBehaviour
{
    GameObject Snake;
    public UIWidget gameover, lab4, wid;

    public UILabel lab1, lab2, lab3; //1 是蛇的长度，2是击杀的数量   3 是你打败了多少的对手

    // Use this for initialization
    void Start()
    {
        Snake = GameObject.Find("SnakeHead");
        gameover = GameObject.Find("gameover").GetComponent<UIWidget>();
        lab1 = GameObject.Find("gameoverlength").GetComponent<UILabel>();
        lab2 = GameObject.Find("gameoverkill").GetComponent<UILabel>();
        lab3 = GameObject.Find("gameoverplayer").GetComponent<UILabel>();
        lab4 = GameObject.Find("lengthshare").GetComponent<UIWidget>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    //看看现在是否处于无尽模式  如果是在无尽模式的话就让他为false  如果已经进入了游戏 就让他为true
    public static bool AIaaa = false;
    public GameObject des; //删除得到的食物

    private string[] sd = new string[10]
        { "AIone", "AItwo", "AIthr", "AIfou", "AIfiv", "AIsix", "AIsev", "AIeig", "AInin", "AIten" };

    public void OnTriggerEnter(Collider collider)
    {
        if (AIaaa == false)
            return;
        //print (collider.name);
        string ss = collider.name;
        string sssss = ss.Substring(0, 5);
        for (int i = 0; i < sd.GetLength(0); i++)
            if (sssss == sd[i])
            {
                acessKillSnake();
                return;
            }
    }

    public void acessKillSnake()
    {
        //游戏结束
        CollisionDetection.Isgameover = true;
        //得到蛇头的坐标
        float x, y;
        x = Snake.transform.localPosition.x;
        y = Snake.transform.localPosition.y;
        //把游戏结束的坐标等于蛇头的坐标
        gameover.transform.localPosition = new Vector3(x, y, 0);
        lab1.text = SnakeControl.SnakeCout.ToString(); //蛇的长度
        lab2.text = CollisionDetection.KillSnakeIs.ToString();
        float p = SnakeControl.SnakeFenShu;
        float player = p / 100f;
        lab3.text = "你击败了全国" + player + "%的玩家";
        GameObject map = GameObject.Find("SnakeMapYes"); //找到了这个对象
        int a = map.transform.childCount;
        float xxx, yyy;
        int v = 0;
        //删除这条蛇
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
                wid = obj1.transform.GetComponent<UIWidget>();
                wid.height = 17;
                wid.width = 17;
            }

            Destroy(gg);
        }
    }
}