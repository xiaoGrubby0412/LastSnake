﻿using UnityEngine;
using System.Collections;

public class CO2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}//CollisionDetection Collis = new CollisionDetection();
	public void OnTriggerEnter(Collider collider){

		string ss = collider.name;
		string sssss = "";
		string nodeFod="";
		if (ss.Length > 6)
			nodeFod = ss.Substring (0, 6);
		else
			nodeFod = "";
		sssss = ss.Substring (0, 4);
		if (sssss == "node"||nodeFod == "AI1foo" || nodeFod == "AI2foo" || nodeFod == "AI3foo" || nodeFod == "AI4foo" || nodeFod == "AI5foo" || nodeFod == "AI6foo" || nodeFod == "AI7foo" || nodeFod == "AI8foo" || nodeFod == "AI9foo" || nodeFod == "AI10fo" || nodeFod == "mefood"||nodeFod=="AI11fo") {
			int aic = AIControl.pos[1,0].SnakeLength;
			if(aic>36){
				Destroy (collider.gameObject);//删除吃到的食物对象
				AIControl.pos [1, 0].AISnakeCount=0;//记录数变成6
				return;
			}
//			GameObject des = GameObject.Find (ss);
			GameObject ite;
			AIControl.pos [1, 0].AISnakeCount++;
			int bianliang = AIControl.pos [1, 0].AISnakeCount;
			if (bianliang % 6 == 0) {
				for(int inter=1;inter<=3;inter++)
				{
					AIControl.pos [1, 0].SnakeLength++;
					if(inter%3==0)
				 ite = (GameObject)Instantiate (Resources.Load ("body5"));
					else
					ite = (GameObject)Instantiate (Resources.Load ("body8_1"));
				GameObject father = GameObject.Find ("AI2");
				//UIWidget wid = ite.transform.GetComponent<UIWidget> ();
				ite.transform.parent = father.transform;
				ite.transform.localScale = new Vector3 (1, 1, 1);
				ite.name = "AItwo" + AIControl.pos [1, 0].SnakeLength.ToString();
				ite.transform.localPosition = new Vector3 (8888, 8888, 0);
				//mingci.SLength2 = AIControl.pos [1, 0].SnakeLength;
				mingci.St[1].length = AIControl.pos[1,0].SnakeLength;
			}
			}
			Destroy (collider.gameObject);//删除吃到的食物对象
		}
	}
}
