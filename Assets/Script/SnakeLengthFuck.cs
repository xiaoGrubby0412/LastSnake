using UnityEngine;
using System.Collections;

public class SnakeLengthFuck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void BianCu(){
		//长度到了一定时候把蛇变粗
		//获取长度
		int a = SnakeControl.SnakeCout;//长度
		string sss = pifu.s;//找到他使用的是哪个预设体
		if (a == 8) {//如果长度大于10
			GameObject gg = (GameObject)Instantiate(Resources.Load(sss));
			UIWidget wid = gg.transform.GetComponent<UIWidget>();
			wid.width = 20;
			wid.height = 20;
		}
	}
}
