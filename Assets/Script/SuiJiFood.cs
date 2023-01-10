using UnityEngine;
using System.Collections;

public class SuiJiFood : MonoBehaviour {
	
	public static int mapfood=1;
	public static string[] stra =new string[13]{"node01","node02","node03","node04","node05","node06","node07","node08","node09","node10","node11","node12","node13"};
	// Use this for initialization
	void Start () {
		obj1 = GameObject.Find ("Gamemap");
	}
	public static bool suiji=false;
	GameObject obj1;
	public static int sdf=1;
	// Update is called once per frame
	//AIRandom air = new AIRandom();
	void Update () {
		if (suiji == true) {
			mapfood++;
			if (mapfood % 100 == 0) {
				sdf++;
				//mapfood=0;
				for (int i=0; i<13; i++) {
					GameObject obj = (GameObject)Instantiate (Resources.Load (stra [i]));//找到预设体
					obj.transform.parent = obj1.transform;
					obj.name = "node(" + stra [i].ToString () + ")a"+sdf.ToString();//给他个名字
					float x = Random.Range (-1360, 1360);
					float y = Random.Range (-760, 760);
					obj.transform.localPosition = new Vector3 (x, y, 0);
					obj.transform.localScale = new Vector3 (1, 1, 1);
					if (mapfood >= 1000)
						mapfood = 0;
				}
			}
		}
	}
}
