using UnityEngine;
using System.Collections;

public class yemiantiaozhuang : MonoBehaviour {
	public UIWidget wid;
	public UILabel uilab;
	// Use this for initialization
	void Start () {
		uilab = GameObject.Find ("timel").GetComponent<UILabel> ();
	}

	public TweenPosition startPanelTween;
	public TweenPosition optionPanelTween;
	public TweenPosition StartGameTween;
	GameStartControl ga = new GameStartControl ();
	joystick jc = new joystick ();
	public void OnOptionButtonClick(){
		UIWidget wid = GameObject.Find ("PlayGame").GetComponent<UIWidget> ();
		wid.transform.localPosition =new Vector3 (8888, 8888, 0);
		wid = GameObject.Find ("wjms").GetComponent<UIWidget> ();
		wid.transform.localPosition = Vector3.zero;
	}
	public void OnCompleteSettingButtonClick(){//无尽模式到game视图
		//optionPanelTween.PlayReverse ();
		//StartGameTween.PlayForward ();
		RandTime.wjhaishixs = 1;//现在是无尽模式
		RandTime.timeMove = false;
		SuiJiFood.suiji = true;//生成食物
		AIBB.startPanel = true;//开始做Ai的碰撞检测
		AIBB2.startPanel2 = true;
		AIBB3.startPanel3 = true;//开始做Ai的碰撞检测
		AIBB4.startPanel4 = true;//开始做Ai的碰撞检测
		AIBB5.startPanel5 = true;//开始做Ai的碰撞检测
		AIBB6.startPanel6 = true;//开始做Ai的碰撞检测
		AIBB7.startPanel7 = true;//开始做Ai的碰撞检测
		AIBB8.startPanel8 = true;//开始做Ai的碰撞检测
		AIBB9.startPanel9 = true;//开始做Ai的碰撞检测
		AIBB10.startPanel10 = true;//开始做Ai的碰撞检测
		CollisionOtherSnake.AIaaa = true;//xianzai zai nage yemina 

		UIWidget widtiao = GameObject.Find ("GameStart").GetComponent<UIWidget> ();
		widtiao.transform.localPosition = Vector3.zero;
		widtiao = GameObject.Find ("wjms").GetComponent<UIWidget> ();
		widtiao.transform.localPosition = new Vector3(8888,8888,0);
		UIWidget wid = GameObject.Find ("yaogangfather").GetComponent<UIWidget> ();
		wid.depth = 20;
		wid = GameObject.Find ("timel").GetComponent<UIWidget> ();
		wid.depth = -8;//把时间隐藏
		UIWidget widd;
		widd = GameObject.Find ("yanggangsun").GetComponent<UIWidget> ();
		widd.depth = 21;
		widd = GameObject.Find ("jiasudu").GetComponent<UIWidget> ();
		widd.depth = 20;

		ga.SnakeBody (pifu.s);//实例化蛇的身体出来
		ZXFSnake (pifu.s);
		CollisionDetection.Isgameover = false;//游戏还没有结束
		//shetou蛇头坐标清0
		GameObject shetou = GameObject.Find ("SnakeHead");
		shetou.transform.localPosition = Vector3.zero;
		//给摇杆类中的ector 3 重新赋值

		jc.Moren = new Vector3 (30,0,0);
		  
	}
	//现实模式
	public void xsmscomputer(){
		RandTime.wjhaishixs = 2;//现在是无尽模式
		RandTime.timeMove = true;
		RandTime.ta = 0;
		//初始化时间
		RandTime.soncend = 1;
		RandTime.minis = 5;
		SuiJiFood.suiji = true;//生成食物
		AIBB.startPanel = true;//开始做Ai的碰撞检测
		AIBB2.startPanel2 = true;
		AIBB3.startPanel3 = true;//开始做Ai的碰撞检测
		AIBB4.startPanel4 = true;//开始做Ai的碰撞检测
		AIBB5.startPanel5 = true;//开始做Ai的碰撞检测
		AIBB6.startPanel6 = true;//开始做Ai的碰撞检测
		AIBB7.startPanel7 = true;//开始做Ai的碰撞检测
		AIBB8.startPanel8 = true;//开始做Ai的碰撞检测
		AIBB9.startPanel9 = true;//开始做Ai的碰撞检测
		AIBB10.startPanel10 = true;//开始做Ai的碰撞检测
		CollisionOtherSnake.AIaaa = true;//xianzai zai nage yemina 
		
		UIWidget widtiao = GameObject.Find ("GameStart").GetComponent<UIWidget> ();
		widtiao.transform.localPosition = Vector3.zero;
		widtiao = GameObject.Find ("wjms").GetComponent<UIWidget> ();
		widtiao.transform.localPosition = new Vector3(8888,8888,0);
		UIWidget wid = GameObject.Find ("yaogangfather").GetComponent<UIWidget> ();
		wid.depth = 20;
		UIWidget widd;
		widd = GameObject.Find ("yanggangsun").GetComponent<UIWidget> ();
		widd.depth = 21;
		widd = GameObject.Find ("jiasudu").GetComponent<UIWidget> ();
		widd.depth = 20;
		widd = GameObject.Find ("timel").GetComponent<UIWidget> ();
		widd.depth = 4;
		GameStartControl ga = new GameStartControl ();
		ga.SnakeBody (pifu.s);//实例化蛇的身体出来
		ZXFSnake (pifu.s);
		CollisionDetection.Isgameover = false;//游戏还没有结束
		//shetou蛇头坐标清0
		GameObject shetou = GameObject.Find ("SnakeHead");
		shetou.transform.localPosition = Vector3.zero;
		//给摇杆类中的ector 3 重新赋值
		//joystick jc = new joystick ();
		jc.Moren = new Vector3 (30,0,0);
	}
	public void ZXFSnake(string sss){
		UISprite head = GameObject.Find("SnakeHead").GetComponent<UISprite>();
		//print (head.spriteName);
		//判断当前蛇头需要什么颜色
		if (sss == "body1")
			head.spriteName = "skin_14_head";
			if(sss=="body6")
			head.spriteName = "skin_10_head";
				if(sss=="body7")
			head.spriteName = "skin_6_head";
					if(sss=="body8")
			head.spriteName = "skin_7_head";
						if(sss=="body14")
			head.spriteName = "skin_12_head";
							if(sss=="body17")
			head.spriteName = "skin_17_head";
		wid = GameObject.Find ("lengthshare").GetComponent<UIWidget> ();
		wid.depth = 3;
		wid = GameObject.Find ("killCount").GetComponent<UIWidget> ();
		wid.depth = 3;
		wid = GameObject.Find ("panhang").GetComponent<UIWidget> ();
		wid.depth = 3;

		wid = GameObject.Find ("jinrizuijia").GetComponent<UIWidget> ();
		wid.depth = 3;
		wid = GameObject.Find ("yongdao").GetComponent<UIWidget> ();
		wid.depth = 3;
		wid = GameObject.Find ("dierming").GetComponent<UIWidget> ();
		wid.depth = 3;
		wid = GameObject.Find ("disangming").GetComponent<UIWidget> ();
		wid.depth = 3;
		wid = GameObject.Find ("disiming").GetComponent<UIWidget> ();
		wid.depth = 3;
	
	}

}
