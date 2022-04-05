using UnityEngine;
using System.Collections;
using GlobalScripts;
public class AiTankBehaviour : MonoBehaviour {

	// Use this for initialization
	private bool shootFlag = false;
	
	private Transform playerPos;
	public Transform turret;
	public Transform cannon;
	public Transform cannonSp;
	public GameObject explode;
	public GameObject shoot_Flame;
	public Transform centerOfMass;
	public GameObject tankShell;

	private Vector3 currentWaypoint;
	private int currentIndex = 0;
	private float shoottime=0f;
	public Texture2D hpLine;
	public float pd=100f;
	public GameObject tanksmoke;
	public GameObject defaultrot;
	public WheelCollider[] Wheel;
	public Material damagedAitankMat;
	private RaycastHit aitankhit;
	public Transform maincamera;
	public GameObject Health;
//	private bool flag;
	public LayerMask filterLayer;
	void Start () {
		GameObject gb = GameObject.FindGameObjectWithTag ("mytank");
		playerPos = gb.transform;
		GetComponent<Rigidbody>().centerOfMass = centerOfMass.localPosition;
		foreach (WheelCollider a in Wheel)
		{
			a.brakeTorque = Mathf.Infinity;
		}
	}
	
	// Update is called once per frame
	void Update () {
/*		Physics.Linecast (transform.position, maincamera.position, out aitankhit, filterLayer);
		//		Debug.DrawLine (transform.position, maincamera.position, Color.blue);
		if(aitankhit.collider == null)
		{
			flag = true;
		}
		else
		{
			flag = false;
		}*/
		if (GlobalInfo.isPause) {
						Health.SetActive (false);
				} else
						Health.SetActive (true);
		shoottime += Time.deltaTime;
		if(Vector3.Distance(transform.position,playerPos.position)<200f)
		{
			//				nMA.Stop();
			Vector3 lookPos = new Vector3(playerPos.position.x,turret.position.y,playerPos.position.z);
			float turret_Ang = Vector3.Angle(turret.forward,(lookPos - turret.position).normalized);
			if(turret_Ang > 1f){
				if(Vector3.Angle(turret.right,(lookPos - turret.position).normalized) < 90f){
					turret.RotateAround(turret.position,turret.up,Time.deltaTime * 40f);
				}else{
					turret.RotateAround(turret.position,turret.up,-Time.deltaTime * 40f);
				}
			}
			//			shootFlag= true;
			//			StartCoroutine(ShootingBehaviour());
			Invoke("shooting",5f);
		}
		else
		{
			//				transform.Translate (transform.forward * Time.deltaTime * 10f,Space.World);
			//				nMA.Resume();
			turret.rotation = Quaternion.Slerp (turret.rotation, defaultrot.transform.rotation, Time.deltaTime);
		}
	}
	void shooting()
	{
		if(shoottime>4f)
		{
//			this.rigidbody.AddForceAtPosition(transform.up * 200000f,transform.position);
			GameObject flame = (GameObject)Instantiate (shoot_Flame, transform.position, Quaternion.identity);
			flame.transform.parent = turret.transform;
			flame.transform.localRotation = Quaternion.identity;
			flame.transform.localPosition = Vector3.zero;
			
			GameObject gb = (GameObject)Instantiate (tankShell, cannonSp.position, turret.rotation);
			
			shoottime=0f;
		}
	}
	public void Smoke()
	{
		if(pd<50f)
		{
			tanksmoke.SetActive(true);
			GameObject gb = GameObject.Find (this.gameObject.name + "/Body");
			GameObject gb1 = GameObject.Find (this.gameObject.name + "/Turret");
			GameObject gb2 = GameObject.Find (this.gameObject.name + "/Turret/Cannon");
			gb.GetComponent<Renderer>().material = damagedAitankMat;
			gb1.GetComponent<Renderer>().material = damagedAitankMat;
			gb2.GetComponent<Renderer>().material = damagedAitankMat;
		}
	}
}
