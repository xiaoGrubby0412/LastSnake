using UnityEngine;
using System.Collections;

public class AI1Collision : MonoBehaviour {


	One yes = new One ();
	public void OnTriggerEnter(Collider collider){
		yes.AIRoot (collider.name,0,0);
	}
}
