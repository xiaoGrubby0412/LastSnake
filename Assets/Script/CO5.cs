using UnityEngine;
using System.Collections;

public class CO5 : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    } //CollisionDetection Collis = new CollisionDetection();

    public void OnTriggerEnter(Collider collider)
    {
        string ss = collider.name;
        string sssss = "";
        string nodeFod = "";
        if (ss.Length > 6)
            nodeFod = ss.Substring(0, 6);
        sssss = ss.Substring(0, 4);
        if (sssss == "node" || nodeFod == "AI1foo" || nodeFod == "AI2foo" || nodeFod == "AI3foo" ||
            nodeFod == "AI4foo" || nodeFod == "AI5foo" || nodeFod == "AI6foo" || nodeFod == "AI7foo" ||
            nodeFod == "AI8foo" || nodeFod == "AI9foo" || nodeFod == "AI10fo" || nodeFod == "mefood" ||
            nodeFod == "AI11fo")
        {
            //	print (ss);
            //如果是食物
            //SnakeCC++;//吃到了食物  记录++  如果吃到4个 长度就增加
            int aic = AIControl.pos[4, 0].SnakeLength;
            if (aic > 36)
            {
                Destroy(collider.gameObject); //删除吃到的食物对象
                AIControl.pos[4, 0].AISnakeCount = 0; //记录数变成6
                return;
            }

            GameObject ite;
            //GameObject des = GameObject.Find (ss);
            CollisionDetection.againFood++;
            AIControl.pos[4, 0].AISnakeCount++;
            int bianliang = AIControl.pos[4, 0].AISnakeCount;
            if (bianliang % 6 == 0)
            {
                for (int inter = 1; inter <= 3; inter++)
                {
                    AIControl.pos[4, 0].SnakeLength++;
                    if (inter % 3 == 0)
                        ite = (GameObject)Instantiate(Resources.Load("body9"));
                    else
                        ite = (GameObject)Instantiate(Resources.Load("body8_1"));
                    GameObject father = GameObject.Find("AI5");
                    //UIWidget wid = ite.transform.GetComponent<UIWidget> ();
                    ite.transform.parent = father.transform;
                    ite.transform.localScale = new Vector3(1, 1, 1);
                    ite.name = "AIfive" + AIControl.pos[4, 0].SnakeLength.ToString();
                    ite.transform.localPosition = new Vector3(8888, 8888, 0);
                    //mingci.SLength5 = AIControl.pos [4, 0].SnakeLength;
                    mingci.St[4].length = AIControl.pos[4, 0].SnakeLength;
                }
            }

            Destroy(collider.gameObject); //删除吃到的食物对象
        }
    }
}