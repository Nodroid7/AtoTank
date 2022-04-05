using UnityEngine;
using System.Collections;

public class tankhouseScripts : MonoBehaviour {

	// Use this for initialization
	public GameObject env;
	public GameObject Tank;
	public GameObject Tank1;
	public GameObject Tank2;
	public GameObject tanklabel;
	public GameObject tank1label;
	public GameObject tank2label;
	public TouchController controller;
	private int TankNumber;
	void Start () {
		TankNumber = 1;

	}
	
	// Update is called once per frame
	void Update () {
		env.transform.Rotate (0f, -Time.deltaTime * 25f*controller.GetAxis("Mouse X"), 0f);
		if(TankNumber == 1)
		{
			Tank.SetActive(true);
			tanklabel.SetActive(true);
			Tank1.SetActive(false);
			tank1label.SetActive(false);
			Tank2.SetActive(false);
			tank2label.SetActive(false);
		}else if(TankNumber ==2)
		{
			Tank.SetActive(false);
			tanklabel.SetActive(false);
			Tank1.SetActive(true);
			tank1label.SetActive(true);
			Tank2.SetActive(false);
			tank2label.SetActive(false);
		}else if(TankNumber ==3)
		{
			Tank.SetActive(false);
			tanklabel.SetActive(false);
			Tank1.SetActive(false);
			tank1label.SetActive(false);
			Tank2.SetActive(true);
			tank2label.SetActive(true);
		}
		PlayerPrefs.SetInt ("SelectedTankNumber", TankNumber);
	}
	public void playstart()
	{
		Application.LoadLevel ("Loading");

	}
	public void nextTank()
	{
		TankNumber++;
		if(TankNumber > 3)
		{
			TankNumber =1;
		}
	}
	public void backTank()
	{
		TankNumber--;
		if(TankNumber < 1)
		{
			TankNumber = 3;
		}
	}

}
