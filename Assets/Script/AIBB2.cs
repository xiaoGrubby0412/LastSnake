using UnityEngine;
using System.Collections;

public class AIBB2 : MonoBehaviour {


	public static bool startPanel2=false;
	public static bool IsOR2=false;
	GameStartControl gamestart = new GameStartControl();
	// Update is called once per frame
	void Update () {
		if (IsOR2 == true) {
			IsOR2=false;

			gamestart.AIOneBody ("body5", "AI2Panduan", 1, "AI2", "AItwo");//创建第二条蛇
			AIControl.AISnakeCanMove[1] = true;
			startPanel2=true;
		}
	}
	/*IEnumerator Robot(){
		yield return new WaitForSeconds (0.2f);
	}*/
	UIWidget wid;
	private void AIO2(){
	//	GameObject map = GameObject.Find("AI2");//找到了这个对象
		//int a=map.transform.childCount;
		int b = AIControl.pos [1, 0].SnakeLength;
		float xxx,yyy;
		int v=b;
		//删除这条蛇
		//print ("a= :"+b.ToString()+" v= :"+v.ToString());
		for(int i=1;i<=b;i++){
			GameObject gg = GameObject.Find("AItwo"+i.ToString());
			//print("aitwo："+gg.name+"  --");
			xxx=gg.transform.localPosition.x;
			yyy=gg.transform.localPosition.y;

			//一个变量记录这条蛇
			Destroy(gg);
			if(i%3==0)
			{
				v++;
				//如果剩余数为0
				GameObject daHao = GameObject.Find("DAfood");
				GameObject obj1 = (GameObject)Instantiate(Resources.Load("body5"));//找到预设体
				obj1.transform.parent = daHao.transform;
				obj1.transform.localPosition =new Vector3(xxx,yyy,0);
				obj1.transform.localScale = new Vector3(1,1,1);
				obj1.name = "AI2food"+v.ToString();
				wid = obj1.transform.GetComponent<UIWidget>();
				wid.height = 17;
				wid.width =17;
			}
			
		}
	}


	public void OnTriggerEnter(Collider collider){
		if (startPanel2 == false)
			return;//还不能开始计算
		string ss = collider.name;
		string sssss = "";
		sssss = ss.Substring(0,4);
		for(int io=0;io<One.str2.GetLength(0);io++)
		if (sssss == One.str2[io]) {
			AIControl.AISnakeCanMove[1]=false;
			IsOR2=true;//是否要被创建
			startPanel2 = false;//是否还要发生碰撞
			IsOR2=true;//是否要被创建
//			print("撞到了身体");
			//int a=AIControl.pos[1,0].SnakeLength;
			AIO2();
			GameObject game  = GameObject.Find("AI2Panduan");
			GameObject suiji = GameObject.Find("suijisnake2");
			game.transform.localPosition = suiji.transform.localPosition;
			AIControl.pos[1,0].SnakeLength =18;//初始化长度
			if(sssss=="body"){
				CollisionDetection.KillSnakeIs++;
				return;
			}
		}
	}
}
