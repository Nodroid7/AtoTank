using UnityEngine;
using System.Collections;
using GlobalScripts;
public class LoadLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(GlobalInfo.levelnumber<9)
		{
			Application.LoadLevel ("Battlefield");
		}
		else if(GlobalInfo.levelnumber>=9 && GlobalInfo.levelnumber <17)
		{
			Application.LoadLevel ("desertCity");
		}
		else 
		{
			Application.LoadLevel ("Snow");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
