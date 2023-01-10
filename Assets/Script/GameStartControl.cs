using UnityEngine;
using System.Collections;

public class GameStartControl : MonoBehaviour {
	public GameObject obj,obj1;
	public UISprite spr,spr1;
	public UIWidget wid;
	// Use this for initialization
	void Start () {
		StartGameTime ();//控件随窗体大小改变而改变
		SnakeFood ();//蛇的食物
		//SnakeBody ();//蛇的身体
		//print("dd");
		//AIOneBody("body3");
	}

	void Update () {
	
	}
	//这个文件是让游戏开始的时候要实例化出来的很多东西
	public void StartGameTime(){
		//把游戏的提示信息隐藏了

		//游戏开始实例话所有对象
		//得到屏幕的大小
		int Contk, posy;
		spr = GameObject.Find ("backGroundduibi").GetComponent<UISprite> ();//得到背景大小
//		print (spr.width + ",." + spr.height);
		spr1 = GameObject.Find ("tcsdzzbj").GetComponent<UISprite> ();
		spr1.width = spr.width;
		spr1.height = spr.height;
		spr1 = GameObject.Find ("startGameY").GetComponent<UISprite> ();
		spr1.width = spr.width;
		spr1.height = spr.height;
		spr1 = GameObject.Find ("tcsdzz").GetComponent<UISprite> ();
		spr1.width = spr.width;
		Contk = spr.height;
		spr1.height = Contk/4;
		//贪吃蛇位置
		posy = Contk * 146 / 730;
		spr1.transform.localPosition = new Vector3 (0,posy,0);
		//开始游戏按钮的大小
		//spr1 = GameObject.Find ("play").GetComponent<UISprite> ();
		//spr1.width = spr.width / 3;
		//spr1.height = spr.height / 10;
		//spr1.transform.localPosition = 
		//上面的是playgame已经弄完成
		//下面的是无尽模式窗口
		//背景
		spr1 = GameObject.Find ("wujingmoshibj").GetComponent<UISprite> ();
		spr1.width = spr.width;
		spr1.height = spr.height;
		spr1.transform.localPosition = Vector3.zero;
		//商城的页面
		spr1 = GameObject.Find ("shop").GetComponent<UISprite> ();
		spr1.height = spr.height;
		spr1.width = spr.width;
		spr1.transform.localPosition = Vector3.zero;
		//无尽模式排行版
		//spr1 = GameObject.Find ("zuocechuangkou").GetComponent<UISprite> ();
		//spr1.width = spr.width /8;
		//spr1.height = spr.height /2;
		//spr1.transform.localPosition = new Vector3 (-(spr.width/2),0,0);
		//无尽模式小按钮
		spr1 = GameObject.Find ("wujingmoshi").GetComponent<UISprite> ();
		spr1.width = spr.width / 4;
		spr1.height = spr.height / 3;
		spr1.transform.localPosition = new Vector3 (-(spr.width/2/3),0,0);
		//现实模式
		spr1 = GameObject.Find ("xianshimoshi").GetComponent<UISprite> ();
		spr1.width = spr.width / 4;
		spr1.height = spr.height / 3;
		spr1.transform.localPosition = new Vector3 ((spr.width / 2 / 3), 0, 0);

		//三个页面的初始位置
		wid = GameObject.Find ("wjms").GetComponent<UIWidget> ();
		wid.transform.localPosition = new Vector3 (spr.width + 30, 0, 0);
		wid = GameObject.Find ("GameStart").GetComponent<UIWidget> ();
		wid.transform.localPosition = new Vector3 (spr.width*5 + 30, 0, 0);
		spr1 = GameObject.Find ("startGameY").GetComponent<UISprite> ();
		spr1.width = 2732;
		spr1.height = 1532;
		//启动的时候让他的depth  为-3
		wid = GameObject.Find ("yaogangfather").GetComponent<UIWidget> ();
		wid.depth = -3;
		wid = GameObject.Find ("yanggangsun").GetComponent<UIWidget>();
		wid.depth = -3;
		//加速度
		wid = GameObject.Find ("jiasudu").GetComponent<UIWidget> ();
		wid.depth = -3;
		//长度
		wid = GameObject.Find ("lengthshare").GetComponent<UIWidget>();
		wid.depth = -3;
		//击杀
		wid = GameObject.Find ("killCount").GetComponent<UIWidget> ();
		wid.depth = -3;
		wid = GameObject.Find ("panhang").GetComponent<UIWidget> ();
		wid.depth = -3;
		wid = GameObject.Find ("jinrizuijia").GetComponent<UIWidget> ();
		wid.depth = -3;
		wid = GameObject.Find ("yongdao").GetComponent<UIWidget> ();
		wid.depth = -3;
		wid = GameObject.Find ("dierming").GetComponent<UIWidget> ();
		wid.depth = -3;
		wid = GameObject.Find ("disangming").GetComponent<UIWidget> ();
		wid.depth = -3;
		wid = GameObject.Find ("disiming").GetComponent<UIWidget> ();
		wid.depth = -3;
		//gameover 窗口
		wid = GameObject.Find ("gameover").GetComponent<UIWidget> ();
		wid.transform.localPosition = new Vector3 (88888, 88888, 0);
		//规则
	/*	spr1 = GameObject.Find ("rule").GetComponent<UISprite> ();
		spr1.width = spr.width / 7;
		spr1.height = spr.height / 6;
		spr1.transform.localPosition = new Vector3 (-(spr.width/2/3),-(spr.height/2/3),0);
		print ("spr"+spr.transform.localPosition.x + "," + spr.transform.localPosition.y);
		//皮肤
		spr1 = GameObject.Find ("skin").GetComponent<UISprite> ();
		spr1.width = spr.width / 7;
		spr1.height = spr.height / 6;
		print ("大小是：" + spr1.width + ",高度是" + spr1.height);
		spr1.transform.localPosition = new Vector3 (0,-(spr.height/2/3),0);
		//退出
		spr1 = GameObject.Find ("RankingList").GetComponent<UISprite> ();
		spr1.width = spr.width / 6;
		spr1.height = spr.height / 7;
		spr1.transform.localPosition = new Vector3 (spr.width/2/3,-(spr.height/2/3),0);
		//spr1 = GameObject.Find ("SnakeHead").GetComponent<UISprite> ();
		//Camera ca = GameObject.Find ("Camera").GetComponent<Camera> ();*/
		SnakePifuSize ();
	}
	//所有颜色的食物
	public static string []Food = new string[14]{"zxf","node01","node02","node03","node04","node05","node06","node07","node08","node09","node10","node11","node12","node13"};
	public int name=0;
	//实例化出食物出来
	public void SnakeFood(){
		//定义一个变量记录food名字下标
		obj = GameObject.Find ("Gamemap");//添加食物的父物体
		for (int f=1; f<14; f++) {//总共有13个食物
			for (int i=0; i<=40; i++) {
				obj1 = (GameObject)Instantiate (Resources.Load (Food [f]));//找到了食物
				name++;
				obj1.transform.parent = obj.transform;
				obj1.transform.localPosition = new Vector3 (FoodX (), FoodY(), 0);
				obj1.transform.localScale = new Vector3(1,1,1);
				obj1.name = "node"+"("+Food[f]+")"+name.ToString();
			
			}
		}
	}
	//得到随机的x坐标
	public int FoodX(){
		//得到gamemap的宽 2732 取值在  -1366  ~  1366
		int x = Random.Range (-1350,1350);
		return x;
	}
	//得到随机的y坐标
	public int FoodY(){
		//gamemap的高 1532  取值在 -766 ~ 766
		int y = Random.Range (-760, 760);
		return y;
	}
	//实例化蛇出来
	public int smallbody=0;
	public void SnakeBody(string s){//蛇的身体
		GameObject locapos = GameObject.Find("SnakeHead");
		float oneX, oneY;
		oneX = locapos.transform.localPosition.x;
		oneY = locapos.transform.localPosition.y;
		for (int i=1; i<=SnakeControl.SnakeCout; i++) {
			obj = GameObject.Find ("SnakeMapYes");
			//int a = obj.transform.childCount;
			//for (int smalbody=1; smalbody<=3; smalbody++) {
			smallbody++;
				if (smallbody % 3 == 0)
					obj1 = (GameObject)Instantiate (Resources.Load (s));
				else 
					obj1 = (GameObject)Instantiate (Resources.Load ("body8_1"));
				obj1.transform.parent = obj.transform;
				obj1.name = "body" + i.ToString ();
				if (i == 1)
					obj1.transform.localPosition = new Vector3 (oneX - 5, oneY, 0);
				else {
					GameObject game = GameObject.Find ("body" + (i - 1).ToString ());
					float x, y;
					x = game.transform.localPosition.x;
					y = game.transform.localPosition.y;
					obj1.transform.localPosition = new Vector3 (x - 5, y, 0);
				}
				obj1.transform.localScale = new Vector3 (1, 1, 1);
		//	}
		}

	}
	//s是预设名字，sname是判断框的名字，bi是 数组查找身体的下标,fd是  蛇头的名字，bodyname是身体名字
	//AI1Panduan  
	//0
	//AI1
	//AIone
	public void AIOneBody(string s,string sname,int bi,string fd,string bodyname){//创建AI蛇的身体
		GameObject locapos = GameObject.Find (sname);//找到ai小蛇的蛇头
		float oneX, oneY;
		oneX = locapos.transform.localPosition.x;
		oneY = locapos.transform.localPosition.y;
		//得到他的长度
		int c = AIControl.pos [bi, 0].SnakeLength;
		//print ("蛇的身体有"+c+"g");
		for (int i=1; i<=c; i++) {
			obj = GameObject.Find (fd);
//			int a = obj.transform.childCount;
			//			print(a);
				if(i%3==0)
				obj1 = (GameObject)Instantiate (Resources.Load (s));
				else
					obj1 = (GameObject)Instantiate (Resources.Load ("body8_1"));
			obj1.transform.parent = obj.transform;
			obj1.name = bodyname + i.ToString ();
			if (i == 1)
				obj1.transform.localPosition = new Vector3 (oneX - 20, oneY, 0);
			else {
				GameObject game = GameObject.Find (bodyname + (i).ToString ());
				float x, y;
				x = game.transform.localPosition.x;
				y = game.transform.localPosition.y;
				obj1.transform.localPosition = new Vector3 (x - 20, y, 0);
			}
			//obj1.transform.localPosition = new Vector3(-8888,0,0);
			obj1.transform.localScale = new Vector3 (1, 1, 1);
		
	}
	}
	//商城所有能买的虫的图片大小
	public static string []sizeSD = new string[9]{"zhongguo","zhongguoxianggang","qingse","jianada","agengting","dahong","xiaolan","xiaolv","xiaohuang"};
	public void SnakePifuSize(){
		for(int i=0;i<9;i++){
			spr1 = GameObject.Find(sizeSD[i]).GetComponent<UISprite>();
			spr1.width = spr.width/4;
			spr1.height = spr.height/3;
			if(i==0)
				spr1.transform.localPosition = new Vector3(-(spr.width/2.826f),spr.height/2.908f,0);
			else if(i==1){
				spr1.transform.localPosition = new Vector3(-(spr.width/16.285f),spr.height/2.908f,0);
			}
			else if(i==2){
				spr1.transform.localPosition = new Vector3(spr.width/4.32911f,spr.height/2.908f,0);
			}
			else if(i==3){
				spr1.transform.localPosition = new Vector3(-(spr.width/2.826f),spr.height/31.739f,0);
			}
			else if(i==4){
				spr1.transform.localPosition = new Vector3(-(spr.width/16.285f),spr.height/31.739f,0);
			}
			else if(i==5){
				spr1.transform.localPosition = new Vector3(spr.width/4.32911f,spr.height/31.739f,0);
			}
			else if(i==6){
				spr1.transform.localPosition = new Vector3(-(spr.width/2.826f),-(spr.height/3.5609f),0);
			}
			else if(i==7){
				spr1.transform.localPosition = new Vector3(-(spr.width/16.285f),-(spr.height/3.5609f),0);
			}
			else if(i==8){
				spr1.transform.localPosition = new Vector3(spr.width/4.32911f,-(spr.height/3.5609f),0);
			}
		}
	}

}
