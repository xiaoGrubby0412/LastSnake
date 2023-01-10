using UnityEngine;
using System.Collections;

public class AI5collision : MonoBehaviour {


	AIRandom ai = new AIRandom ();
	AIControl add = new AIControl ();
	public void OnTriggerEnter(Collider collider){
		AIRoot5 (collider.name,4,4);
		
	}
	//public static string []str5 =new string[10]{"body","AIon","AIni","AIth","AIfo","AItw","AIsi","Aise","AIei","AIte"}; 
	public void AIRoot5(string str,int xiabiaozhi,int cou){//一个是碰撞到的名字，一个是他所处的下标，一个是判断碰撞到不能碰撞的东西
		string ss=str;
		Vector3 v= AIControl.pos[xiabiaozhi,0].SnakePos;
		float x,y;
		x=v.x;
		y=v.y;
		float n = 0;
		float m = 0;
		//如果碰撞到了墙体就让他产生其他的位移
		//下面的代码保证了蛇不会撞到墙体
		if (ss == "collide_Right") {
			//如果撞到了右边那么表示x肯定大于0
			//要么1  要么 4
			if(x>=0&&y>=0)//1
			{
				n = ai.AIXrandom(-1,0);//得到了随机的x
				m = ai.AIYrandom(0,1);//得到了随机的y
			}
			if(x>=0&&y<0){//4
				n = ai.AIXrandom(-1,0);//得到了随机的x
				m = ai.AIYrandom(-1,0);//得到了随机的y
			}
			Vector3 vv = new Vector3(n,m,0);
			add.AIAddTo(cou,0,0,vv,null);
		}
		if (ss == "collide_left") {  //2   3
			if(x<=0&&y>=0){
				//2
				n = ai.AIXrandom(0,1);//得到了随机的x
				m = ai.AIYrandom(0,1);//得到了随机的y
			}
			if(x<0&&y<0){
				//3
				n = ai.AIXrandom(0,1);//得到了随机的x
				m = ai.AIYrandom(-1,0);//得到了随机的y
			}
			Vector3 vv = new Vector3(n,m,0);
			add.AIAddTo(cou,0,0,vv,null);
		}
		if (ss == "collide_Bottom") {
			//y肯定小于0
			//yaome  3  yaome 4
			if(x<=0&&y<=0){
				//3
				n = ai.AIXrandom(-1,0);//得到了随机的x
				m = ai.AIYrandom(0,1);//得到了随机的y
			}
			if(x>=0&&y<0){
				//4
				n = ai.AIXrandom(0,1);//得到了随机的x
				m = ai.AIYrandom(0,1);//得到了随机的y
			}
			Vector3 vv = new Vector3(n,m,0);
			add.AIAddTo(cou,0,0,vv,null);
		}
		if (ss == "collide_Top") {
			//y肯定大于0
			if(x>=0&&y>0){
				//1
				n = ai.AIXrandom(0,1);//得到了随机的x
				m = ai.AIYrandom(-1,0);//得到了随机的y
			}
			if(x<0&&y>=0){
				//2
				n = ai.AIXrandom(-1,0);//得到了随机的x
				m = ai.AIYrandom(-1,0);//得到了随机的y
			}
			Vector3 vv = new Vector3(n,m,0);
			add.AIAddTo(cou,0,0,vv,null);
		}
		string sssss = "";
		sssss = ss.Substring(0,4);
		for(int i=0;i<One.str5.GetLength(0)-1;i++)
		if(sssss==One.str5[i]){
			 n =  ai.AIXrandom(-1,1);//得到了随机的x
			 m = ai.AIYrandom(-1,1);//得到了随机的y
			Vector3 vv = new Vector3(n,m,0);
			add.AIAddTo(cou,0,0,vv,null);
		}
	}
}
