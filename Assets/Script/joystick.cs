using UnityEngine;
using System.Collections;
using System.Threading;
public class joystick : MonoBehaviour {
	public Vector3 Moren;//不拉摇杆的时候让蛇的移动方向
	private GameObject obj,obj1,objf;
	public UILabel lab; //lab1;
	public UIWidget wid;
	private Camera camera;
	public Vector3 ve3;
	// Use this for initialization
	void Start () {
		obj = GameObject.Find("yanggangsun");
		obj1 = GameObject.Find("SnakeHead");
		objf = GameObject.Find ("snakefloot");
		 camera = GameObject.Find ("Camera").GetComponent<Camera> ();
		Moren = new Vector3 (30, 0, 0);//给摇杆的默认值是平移状态
		wid = obj.GetComponent<UIWidget> ();
		lab = GameObject.Find ("lengthshare").GetComponent<UILabel>();
		//lab1 = GameObject.Find ("yongdao").GetComponent<UILabel> ();
	}
	SnakeControl sn = new SnakeControl();
	// Update is called once per frame
	void Update () {//FixedUpdate
		if (CollisionDetection.Isgameover == false) {//如果游戏还没有结束
			if (wid.depth == 21&&SnakeControl.SnakeSpeed==5)
				JiaoDu (SnakeControl.SnakeSpeed);
			//每次更新蛇的长度
			lab.text = "长度" + SnakeControl.SnakeCout;
			if(SnakeControl.SnakeSpeed==10){
				JiaoDu (5);
				JiaoDu (5);
			}
			//lab1.text = "mySnake     :" + SnakeControl.SnakeFenShu;
		}
	}

	public int SnakeCountMove =0;
	public Vector3 vvvvvv;
	//得到摇杆偏移的角度
	public void JiaoDu(int sudu){
		SnakeCountMove++;//每次自增
		//记录蛇头的开始位置
		float x, y;
		x = obj.transform.localPosition.x;
		y = obj.transform.localPosition.y;
		Xuaanzhuang (x,y);
		if (obj.transform.localPosition.x != 0 && obj.transform.localPosition.y != 0) //如果移动了摇杆
			Moren = obj.transform.localPosition;//记录摇杆的当前状态
		vvvvvv =  Moren;
			obj1.transform.localPosition += sudu * Moren.normalized;//给蛇产生位置
		//obj1.transform.Translate += sudu * Moren.normalized;
		if (SnakeCountMove % 20 == 0)
				SnakeCountMove = 1;
		sn.SnakebodyMove(obj1.transform.localPosition,vvvvvv);
		UILabel la = GameObject.Find ("snakenameis").GetComponent<UILabel> ();
		la.transform.localPosition = new Vector3 (obj1.transform.localPosition.x, obj1.transform.localPosition.y + 30, 0);
		objf.transform.localPosition = obj1.transform.localPosition;
		camera.transform.localPosition = obj1.transform.localPosition;//摄像机跟随蛇头位置走
	}
	public void Xuaanzhuang(float x, float y){
		float m ,j,i,q=0;
		m = x * x + y * y;
		//		print (x + "," + y);
		j = Mathf.Sqrt (m);
		//print (j +"斜边");
		i = Mathf.Acos (x / j);
		//print (i +"弧度");
		if (i != 0) {
			q = (180 * i) / Mathf.PI;
			if (q >= 0 && q <= 90) {
				if (y > 0) {
					obj1.transform.rotation = Quaternion.Euler (0, 0, q + 90);
				} else
					obj1.transform.rotation = Quaternion.Euler (0, 0, -q + 90);
			} else if(q>90&&q<=180) {
				if (y > 0) {
					obj1.transform.rotation = Quaternion.Euler (0, 0, q + 90);
				} else
					obj1.transform.rotation = Quaternion.Euler (0, 0, -q + 90);
			}
		}
		
	}

}
