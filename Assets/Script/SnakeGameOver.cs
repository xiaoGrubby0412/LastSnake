using UnityEngine;
using System.Collections;

public class SnakeGameOver : MonoBehaviour {
	public GameObject obj;
	public UIWidget wid;
	//返回的一些处理
	AIBB aibb = new AIBB();
	AIBB2 aibb2 = new AIBB2();
	AIBB3 aibb3 = new AIBB3();
	AIBB4 aibb4 = new AIBB4();
	AIBB5 aibb5 = new AIBB5();
	AIBB6 aibb6 = new AIBB6();
	AIBB7 aibb7 = new AIBB7();
	AIBB8 aibb8 = new AIBB8();
	AIBB9 aibb9 = new AIBB9();
	AIBB10 aibb10 = new AIBB10();
	public void ShancSnake(){
		BoxCollider yesnake = GameObject.Find("collide_left").GetComponent<BoxCollider>();
		//GameObject yesnake = GameObject.Find("body1");
		aibb.OnTriggerEnter (yesnake);
		aibb2.OnTriggerEnter (yesnake);
		aibb3.OnTriggerEnter (yesnake);
		aibb4.OnTriggerEnter (yesnake);
		aibb5.OnTriggerEnter (yesnake);
		aibb6.OnTriggerEnter (yesnake);
		aibb7.OnTriggerEnter (yesnake);
		aibb8.OnTriggerEnter (yesnake);
		aibb9.OnTriggerEnter (yesnake);
		aibb10.OnTriggerEnter (yesnake);
	//	print("删除创建成功");
		
	}
	//如果游戏结束点击了返回按钮
	public void IsGameOver(){
		ShancSnake ();
		RandTime.wjhaishixs = 0;//放回变0
		RandTime.ta = 0;
		RandTime.timeMove = false;
		SuiJiFood.suiji = false;
		CollisionDetection.KillSnakeIs = 0;//返回游戏击杀为0
		//print("asdf");
		//某些东西变成 false
		AIBB.startPanel = false;//开始做Ai的碰撞检测
		AIBB2.startPanel2 = false;
		AIBB3.startPanel3 = false;//开始做Ai的碰撞检测
		AIBB4.startPanel4 = false;//开始做Ai的碰撞检测
		AIBB5.startPanel5 = false;//开始做Ai的碰撞检测
		AIBB6.startPanel6 = false;//开始做Ai的碰撞检测
		AIBB7.startPanel7 = false;//开始做Ai的碰撞检测
		AIBB8.startPanel8 = false;//开始做Ai的碰撞检测
		AIBB9.startPanel9 = false;//开始做Ai的碰撞检测
		AIBB10.startPanel10 = false;//开始做Ai的碰撞检测
		CollisionOtherSnake.AIaaa = false;//xianzai zai nage yemina 
		//返回是的时候删除地图中所有的食物
		GameObject food = GameObject.Find ("DAfood");
		int cc = food.transform.childCount;
		if(cc>0)
		foreach (Transform transform in food.transform) {
			Destroy(transform.gameObject);
		}
		CollisionDetection.IsSizeone = true;
		CollisionDetection.IsSizeTwo = true;
		UIWidget snakeheadd = GameObject.Find ("SnakeHead").GetComponent<UIWidget>();//找到了蛇头
		//把蛇头的大小改成原来的大小
		snakeheadd.width = 21;
		snakeheadd.height = 21;
		jiasuduButtonClick.v = 1;
		SnakeControl.SnakeSpeed = 5;
		//CollisionDetection co = new CollisionDetection ();
		if (CollisionDetection.nodefood > 10)
			IsNoodAgain ();
		IsGameAgain ();
		CollisionDetection.nodeFood = new CollisionDetection.NodeFool[50];//重新初始化数组下标
		CollisionDetection.nodefood = 1;//重新初始化数组的下标
		SnakeControl.SnakeCout = 18;//初始化长度
		SnakeControl.SnakeFenShu = 0;//初始化游戏分数
		YINCanGobject (-3);//隐藏不需要的对象
		obj = GameObject.Find("gameover");
		obj.transform.localPosition = new Vector3 (-88888, 88888, 0);//此窗口弹出
		//相机的坐标设置为0.0
		Camera came = GameObject.Find ("Camera").GetComponent<Camera> ();
		came.transform.localPosition = Vector3.zero;
		obj = GameObject.Find ("GameStart");
		obj.transform.localPosition = new Vector3 (88888, 88888, 0);
		obj = GameObject.Find("wjms");
		obj.transform.localPosition = Vector3.zero;
	}
	private static string[]str = new string[14]{"yaogangfather","yanggangsun","lenthandkill","lengthshare","killCount","snakeTiShi","panhang","jinrizuijia","yongdao","jiasudu","timel","dierming","disangming","disiming"};
	//游戏模式跳转到无尽模式需要隐藏的对象
	public void YINCanGobject(int dep){//一个参数depth
//		print (dep);
		//把摇杆先隐藏起来
		for (int i=0; i<str.GetLength(0); i++) {
			wid = GameObject.Find (str [i]).GetComponent<UIWidget> ();
			wid.depth = dep;
		}
	
	}


	//把吃到的东西全部返回
	public void IsNoodAgain(){
		GameObject gamemap = GameObject.Find ("Gamemap");
		//print("进入"+"   nodefood下标=="+nodefood);
		for (int i=1; i<CollisionDetection.nodefood; i++) {
			 obj = (GameObject)Instantiate(Resources.Load(CollisionDetection.nodeFood[i].itemname));//找到预设体
			obj.transform.parent = gamemap.transform;
			obj.name = CollisionDetection.nodeFood[i].delname;//给他个名字
			obj.transform.localPosition = CollisionDetection.nodeFood[i].v;
			obj.transform.localScale = new Vector3(1,1,1);
		}
	}

	public void IsGameAgain(){
		//找到蛇头把他的坐标改变成00
		obj = GameObject.Find ("SnakeHead");
		obj.transform.localPosition = Vector3.zero;
		//判断他的身体是否超过了长度的限制
		obj = GameObject.Find ("SnakeMapYes");
		int Length = obj.transform.childCount;
			for(int i=1;i<=Length-1;i++){
				obj = GameObject.Find("body"+i.ToString());
				Destroy(obj);//删除超过的部分
			}
	}
	//重新开始游戏
	yemiantiaozhuang ye = new yemiantiaozhuang();
	public void ChongXinKaiShi(){
		//print (RandTime.wjhaishixs);
		if (RandTime.wjhaishixs == 1) {//现在是无尽模式下
			RandTime.timeMove = false;
			RandTime.ta = 0;
			CollisionDetection.KillSnakeIs = 0;//重新开始击杀为0
			GameObject food = GameObject.Find ("DAfood");
			int cc = food.transform.childCount;
			if (cc > 0)
				foreach (Transform transform in food.transform) {
					Destroy (transform.gameObject);
				}
			CollisionDetection.IsSizeone = true;//把蛇的身体大小改一下
			CollisionDetection.IsSizeTwo = true;
			//找到蛇头的坐标
			UIWidget snakeheadd = GameObject.Find ("SnakeHead").GetComponent<UIWidget> ();//找到了蛇头
			//把蛇头的大小改成原来的大小
			snakeheadd.width = 21;
			snakeheadd.height = 21;
			jiasuduButtonClick.v = 1;
			SnakeControl.SnakeSpeed = 5;
			if (CollisionDetection.nodefood > 10)
				IsNoodAgain ();
			IsGameAgain ();
			CollisionDetection.nodeFood = new CollisionDetection.NodeFool[50];//重新初始化数组下标
			CollisionDetection.nodefood = 1;//重新初始化数组的下标
			SnakeControl.SnakeCout = 18;//初始化长度
			SnakeControl.SnakeFenShu = 0;//初始化游戏分数
			//YINCanGobject (-3);//隐藏不需要的对象
			obj = GameObject.Find ("gameover");
			obj.transform.localPosition = new Vector3 (8888, 8888, 0);//此窗口弹出
			//相机的坐标设置为0.0
			Camera came = GameObject.Find ("Camera").GetComponent<Camera> ();
			came.transform.localPosition = Vector3.zero;
			//obj = GameObject.Find ("GameStart");
			//obj.transform.localPosition = new Vector3 (8888, 8888, 0);
			//obj = GameObject.Find("wjms");
			//obj.transform.localPosition = Vector3.zero;
			GameStartControl ga = new GameStartControl ();
			ga.SnakeBody (pifu.s);//实例化蛇的身体出来
			ye.ZXFSnake (pifu.s);
			CollisionDetection.Isgameover = false;//游戏还没有结束
			//shetou蛇头坐标清0
			GameObject shetou = GameObject.Find ("SnakeHead");
			shetou.transform.localPosition = Vector3.zero;
			//给摇杆类中的ector 3 重新赋值
			joystick jc = new joystick ();
			jc.Moren = new Vector3 (30, 0, 0);
		}
		else if(RandTime.wjhaishixs==2){//现在是现实模式下
			//初始化时间
			RandTime.timeMove = true;
			RandTime.minis=5;
			RandTime.soncend = 1;
			CollisionDetection.KillSnakeIs = 0;//重新开始击杀为0
			GameObject food = GameObject.Find ("DAfood");
			int cc = food.transform.childCount;
			if (cc > 0)
			foreach (Transform transform in food.transform) {
				Destroy (transform.gameObject);
			}
			CollisionDetection.IsSizeone = true;//把蛇的身体大小改一下
			CollisionDetection.IsSizeTwo = true;
			//找到蛇头的坐标
			UIWidget snakeheadd = GameObject.Find ("SnakeHead").GetComponent<UIWidget> ();//找到了蛇头
			//把蛇头的大小改成原来的大小
			snakeheadd.width = 21;
			snakeheadd.height = 21;
			jiasuduButtonClick.v = 1;
			SnakeControl.SnakeSpeed = 5;
			if (CollisionDetection.nodefood > 10)
				IsNoodAgain ();
			IsGameAgain ();
			CollisionDetection.nodeFood = new CollisionDetection.NodeFool[50];//重新初始化数组下标
			CollisionDetection.nodefood = 1;//重新初始化数组的下标
			SnakeControl.SnakeCout = 18;//初始化长度
			SnakeControl.SnakeFenShu = 0;//初始化游戏分数
			//YINCanGobject (-3);//隐藏不需要的对象
			obj = GameObject.Find ("gameover");
			obj.transform.localPosition = new Vector3 (8888, 8888, 0);//此窗口弹出
			//相机的坐标设置为0.0
			Camera came = GameObject.Find ("Camera").GetComponent<Camera> ();
			came.transform.localPosition = Vector3.zero;
			GameStartControl ga = new GameStartControl ();
			ga.SnakeBody (pifu.s);//实例化蛇的身体出来
			ye.ZXFSnake (pifu.s);
			CollisionDetection.Isgameover = false;//游戏还没有结束
			//shetou蛇头坐标清0
			GameObject shetou = GameObject.Find ("SnakeHead");
			shetou.transform.localPosition = Vector3.zero;
			//给摇杆类中的ector 3 重新赋值
			joystick jc = new joystick ();
			jc.Moren = new Vector3 (30, 0, 0);
		}
	}
	public void TuiChuGame(){
		Application.Quit ();
	}
}
