using UnityEngine;
using System.Collections;
using System.Threading;
public class CollisionDetection : MonoBehaviour {
	public static int againFood=0;//这个变量重新生成了食物
	public GameObject gamemap;//找到预设体的父亲
	public BoxCollider box ;
	public static NodeFool[] nodeFood = new NodeFool[500];//存储蛇吃到的食物200  如果蛇吃了200个的话  就重新生成食物
	public static int nodefood=1;//用来看看食物的下标是否越界了，如果是越界了就让他能归零后重新运行，如果不是就让他继续++
	public GameObject des;//删除得到的食物
	public static int SnakeCC=0;//用这个变量记录蛇的长度
	//GameStartControl con = new GameStartControl();//实例化这个类 用来创建删除的食物
	public UIWidget gameover, snakewid;//游戏结束出来的窗口
	public GameObject Snake;//把gameover的坐标等于蛇头的坐标
	public static bool Isgameover=false;//判断游戏是否结束
	public static bool IsSizeone=true,IsSizeTwo=true;
	public UILabel lab1,lab2,lab3;//1 是蛇的长度，2是击杀的数量   3 是你打败了多少的对手
	public static int Maxfood=0;
	public static int KillSnakeIs=0;//这个变量记录snake击杀了多少条蛇
	void Start () {
		gamemap = GameObject.Find("Gamemap");//添加食物的父物体
		gameover = GameObject.Find ("gameover").GetComponent<UIWidget> ();
		Snake = GameObject.Find("SnakeHead");
		lab1 = GameObject.Find ("gameoverlength").GetComponent<UILabel> ();
		lab2 = GameObject.Find ("gameoverkill").GetComponent<UILabel> ();
		lab3 = GameObject.Find ("gameoverplayer").GetComponent<UILabel> ();
		snakewid = GameObject.Find ("SnakeHead").GetComponent<UIWidget> ();//得到蛇头的wid 方便变化他的大小
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
//	AIBB aibb = new AIBB();
	UIWidget wid;
	public static int inter=0;
	public void OnTriggerEnter(Collider collider){
		if (Isgameover == true)
			return;
		//如果蛇吃了30个食物就给地图中生成30个食物
		if (nodefood % 30==0) {
		//地图生成食物出来
			NoodAgain();//在地图中在添加食物出来
		}
		string nodeFod = "";
		string ss = collider.name;//吃到的食物名字
		if (ss.Length >= 7)
			nodeFod = ss.Substring (0, 6);
		else
			nodeFod = "";
		//print (ss.Length);

		string sssss = "";
		des = GameObject.Find (ss);

		if (ss == "collide_Top" || ss == "collide_Bottom" || ss == "collide_left" || ss == "collide_Right") {
			//游戏结束
			Isgameover = true;
			//得到蛇头的坐标
			float x, y;
			x = Snake.transform.localPosition.x;
			y = Snake.transform.localPosition.y;
			//把游戏结束的坐标等于蛇头的坐标
			gameover.transform.localPosition = new Vector3 (x, y, 0);
			lab1.text = SnakeControl.SnakeCout.ToString ();//蛇的长度
			lab2.text = KillSnakeIs.ToString();
			float p = SnakeControl.SnakeFenShu;
			float player = p / 100f;
			//print(SnakeControl.SnakeCout);
			lab3.text = "你击败了全国" + player + "%的玩家";
			GameObject map = GameObject.Find ("SnakeMapYes");//找到了这个对象
			int a = map.transform.childCount;
			float xxx, yyy;
			int v = 0;
			//删除这条蛇
			for (int i=1; i<a; i++) {
				GameObject gg = GameObject.Find ("body" + i.ToString ());
				xxx = gg.transform.localPosition.x;
				yyy = gg.transform.localPosition.y;
				//一个变量记录这条蛇
			
				if (i % 3 == 0) {
					v++;
					//如果剩余数为0
					GameObject daHao = GameObject.Find ("DAfood");
					GameObject obj1 = (GameObject)Instantiate (Resources.Load (pifu.s));//找到预设体
					obj1.transform.parent = daHao.transform;
					obj1.transform.localPosition = new Vector3 (xxx, yyy, 0);
					obj1.transform.localScale = new Vector3 (1, 1, 1);
					obj1.name = "mefood" + v.ToString ();
					wid = obj1.transform.GetComponent<UIWidget> ();
					wid.height = 20;
					wid.width = 20;
				}
				Destroy (gg);
			}
			//print (a);
		} else {
			sssss = ss.Substring (0, 4);
			if (sssss == "node") {
				//如果是食物
				SnakeCC++;//吃到了食物  记录++  如果吃到4个 长度就增加
				if (SnakeCC % 3 == 0) {
					for(int inter=1;inter<=3;inter++)
					{
					//lab.text = strX [XinxiB];
					SnakeControl.SnakeCout++;//长度增加一个单位
					GameObject ite;
					if(inter%3==0)
					 ite = (GameObject)Instantiate (Resources.Load (pifu.s));
					else
					ite = (GameObject)Instantiate (Resources.Load ("body8_1"));
					GameObject father = GameObject.Find ("SnakeMapYes");
					UIWidget wid = ite.transform.GetComponent<UIWidget> ();
					if (SnakeControl.SnakeCout >= 100 && SnakeControl.SnakeCout < 200) {//如果蛇吃到了一定长度的食物就让他的大小增加一定的范围
						//如果长度》100小于150的画 就让他的宽度和高度都+3
						//先改变蛇头的大小
						//SnakeControl.SnakeCout=5;
						snakewid.width = 22;
						snakewid.height = 22;
						if (IsSizeone == true) {
							IsSizeone = false;
							for (int i=1; i<SnakeControl.SnakeCout; i++) {
								GameObject obj = GameObject.Find ("body" + i.ToString ());
								UIWidget uiwid = obj.transform.GetComponent<UIWidget> ();
								uiwid.width = 21;
								uiwid.height = 21;
							}
						}
						wid.width = 17;
						wid.height = 17;
					} else if (SnakeControl.SnakeCout >= 200) {//如果长度大于了200
						//SnakeControl.SnakeCout=7;
						snakewid.width = 21;
						snakewid.width = 21;
						//蛇头大小改变了之后判断
						if (IsSizeTwo == true) {//需要主要的是在单机返回和重新开始的时候需要把这两个bool变成false
							//蛇头也要初始化为默认的大小
							IsSizeTwo = false;
							for (int i=1; i<SnakeControl.SnakeCout; i++) {
								GameObject obj = GameObject.Find ("body" + i.ToString ());
								UIWidget uiwid = obj.transform.GetComponent<UIWidget> ();
								uiwid.width = 23;
								uiwid.height = 23;
							}
						}
						wid.width = 22;
						wid.height = 22;
					}
					ite.transform.parent = father.transform;
					ite.transform.localScale = new Vector3 (1, 1, 1);
					ite.name = "body" + SnakeControl.SnakeCout;
					ite.transform.localPosition = new Vector3 (8888, 8888, 0);
					mingci.St[10].length =SnakeControl.SnakeCout;
				}
				}
				sssss = ss.Substring (5, 6);//预设体名字
				nodeFood [nodefood].itemname = sssss;//把预设体名字保存下来
				nodeFood [nodefood].delname = ss;//被删除的名字也保存下来
				nodeFood [nodefood].v = des.transform.localPosition;//记录下标
				nodefood++;//下标++
				SnakeControl.SnakeFenShu += 10;//分数++
				Destroy (collider.gameObject);//删除吃到的食物对象

			}
			if(nodeFod=="AI1foo"||nodeFod=="AI2foo"||nodeFod=="AI3foo"||nodeFod=="AI4foo"||nodeFod=="AI5foo"||nodeFod=="AI6foo"||nodeFod=="AI7foo"||nodeFod=="AI8foo"||nodeFod=="AI9foo"||nodeFod=="AI10fo"||nodeFod=="mefood"||nodeFod=="AI11fo")
			{GameObject ite;
				againFood++;
				Maxfood++;
				for(int i=1;i<=3;i++){
				if(Maxfood%2==0){
					SnakeControl.SnakeCout++;//长度增加一个单位
						if(i%3==0)
					 ite = (GameObject)Instantiate (Resources.Load (pifu.s));
						else
						ite = (GameObject)Instantiate (Resources.Load ("body8_1"));
					GameObject father = GameObject.Find ("SnakeMapYes");
					ite.transform.parent = father.transform;
					ite.transform.localScale = new Vector3 (1, 1, 1);
					ite.name = "body" + SnakeControl.SnakeCout;
					ite.transform.localPosition = new Vector3 (8888, 8888, 0);
					SnakeControl.SnakeFenShu += 20;//分数++
					mingci.St[10].length =SnakeControl.SnakeCout ;
				}
			}
				Destroy (collider.gameObject);//删除吃到的食物对象
			}
		}
	}
	public void SnakeGanK(){
		box = GameObject.Find ("SnakeHead").GetComponent<BoxCollider> ();

	}
	public struct NodeFool{
		public string itemname;//预设体名字
		public string delname;//被删除的名字
		public Vector3 v;//记录原来食物的坐标
	}
	//如果吃了30个食物的话 地图中就在次生成30个食物出来
	public void NoodAgain(){
		for (int i=1; i<nodefood; i++) {
			//print(nodeFood[i].itemname);
			GameObject obj = (GameObject)Instantiate(Resources.Load(nodeFood[i].itemname));//找到预设体
			obj.transform.parent = gamemap.transform;
			obj.name = nodeFood[i].delname;//给他个名字
			obj.transform.localPosition = nodeFood[i].v;
			obj.transform.localScale = new Vector3(1,1,1);
		}
		SnakeCC = 0;
		nodeFood = new NodeFool[500];
		nodefood = 0;//清空下标

	}

}
