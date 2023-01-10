using UnityEngine;
using System.Collections;

public class AIBB9 : MonoBehaviour {
	
	public static bool startPanel9=false;
	public static bool IsOR9=false;
	GameStartControl gamestart = new GameStartControl();
	// Update is called once per frame
	void Update () {
		if (IsOR9 == true) {
			IsOR9=false;

			gamestart.AIOneBody ("body1", "AI9Panduan", 8, "AI9", "AInine");//创建第9条蛇
			AIControl.AISnakeCanMove[8] = true;
			startPanel9=true;
		}
	}

	public void OnTriggerEnter(Collider collider){
		if (startPanel9 == false)
			return;//还不能开始计算
		string ss = collider.name;
		string sssss = "";
		sssss = ss.Substring(0,4);
		for(int io=0;io<One.str9.GetLength(0);io++)
		if (sssss == One.str9[io]) {
			AIControl.AISnakeCanMove[8]=false;
			IsOR9=true;//是否要被创建
			startPanel9 = false;//是否还要发生碰撞
			IsOR9=true;//是否要被创建
			//print("撞到了身体");
			//int a=AIControl.pos[8,0].SnakeLength;
			AIO9();
			GameObject game  = GameObject.Find("AI9Panduan");
			GameObject suiji = GameObject.Find("suijisnake9");
			game.transform.localPosition = suiji.transform.localPosition;
			AIControl.pos[8,0].SnakeLength =18;//初始化长度
			if(sssss=="body"){
				CollisionDetection.KillSnakeIs++;
				return;
			}
		}
	}
	IEnumerator Robot(){
		yield return new WaitForSeconds (0.2f);
	}
	UIWidget wid;
	private void AIO9(){
		//GameObject map = GameObject.Find("AI9");//找到了这个对象
		int a=AIControl.pos [8, 0].SnakeLength;
		float xxx,yyy;
		int v=a;
		//删除这条蛇
		for(int i=1;i<=a;i++){
			GameObject gg = GameObject.Find("AInine"+i.ToString());
			xxx=gg.transform.localPosition.x;
			yyy=gg.transform.localPosition.y;
			//一个变量记录这条蛇
			Destroy(gg);
			if(i%3==0)
			{
				v++;
				//如果剩余数为0
				GameObject daHao = GameObject.Find("DAfood");
				GameObject obj1 = (GameObject)Instantiate(Resources.Load("body1"));//找到预设体
				obj1.transform.parent = daHao.transform;
				obj1.transform.localPosition =new Vector3(xxx,yyy,0);
				obj1.transform.localScale = new Vector3(1,1,1);
				obj1.name = "AI9food"+v.ToString();
				wid = obj1.transform.GetComponent<UIWidget>();
				wid.height = 17;
				wid.width =17;
			}
			
		}
	}
}
