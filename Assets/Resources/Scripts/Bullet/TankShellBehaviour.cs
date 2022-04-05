using UnityEngine;
using System.Collections;
using GlobalScripts;
public class TankShellBehaviour : MonoBehaviour {
	public GameObject tankShellExplosion;
	public GameObject destroytank;
	public GameObject DestroyBuildingpar;
	public GameObject mytankPar;
	public GameObject jeepcardestroypar;
	public GameObject death;
	private GameObject maincamera;
	private float vibrationTime= 0f;
	private bool tankvibration = false;
	private Vector3 oldpos;
	private bool bFlag = false;
	private Vector3 initialVelocity;
	private Vector3 initialPosition;
	private float DetectorLength;
	private bool targetdetected = false;
	private float numSteps;
	private float timeDelta;
	private Vector3 velocity, lastpos,position;
	private Vector3 gravity = Vector3.zero;
//	public UISlider healthbar;
//	private GameObject targetTank;
//	private GetTargetFunc gettarget;
	// Use this for initialization
	void Start () {
		StartCoroutine (FinalizeParticle ());
		maincamera = GameObject.Find ("Main Camera");
		this.GetComponent<Rigidbody>().velocity = transform.forward * 300f;
		initialVelocity = transform.forward * 300f;
		initialPosition = transform.position;
		DetectorLength = 300f; 
		numSteps = DetectorLength;
		 timeDelta = 1.0f / initialVelocity.magnitude;
		 position = initialPosition;
		 velocity = initialVelocity;
		 lastpos = initialPosition;
		if (GetComponent<Rigidbody>().useGravity) {
			gravity = Physics.gravity;
		}
//		targetTank = GameObject.Find ("MouseClickController");
//		gettarget = targetTank.GetComponent<GetTargetFunc> ();
	}
	
	// Update is called once per frame
 
	bool RayPrediction (Vector3 lastpos, Vector3 currentpos, Vector3 initialPosition)
	{
		RaycastHit hitInfo;
		Vector3 dir = (currentpos - lastpos);
		dir.Normalize ();
		 
//		 if (Physics.Raycast (lastpos, dir, out hitInfo, 5f)) {
//			if(hitInfo.collider.tag=="enemy")
//			{
////				Debug.Log("Target Detected!");
//								GameObject gb = (GameObject)Instantiate(tankShellExplosion,hitInfo.point,Quaternion.identity);
//								hitInfo.collider.gameObject.GetComponent<TankBehaviour>().pd -= 41f;
//								hitInfo.collider.gameObject.SendMessage("Smoke",SendMessageOptions.DontRequireReceiver);
//								if(hitInfo.collider.gameObject.GetComponent<TankBehaviour>().pd <0f)
//								{
//									hitInfo.collider.gameObject.GetComponent<TankBehaviour>().pd=0f;
//									hitInfo.collider.gameObject.SetActive(false);
//									GameObject gb1 = (GameObject)Instantiate(destroytank,hitInfo.collider.gameObject.transform.position,Quaternion.identity);
//									GameManager.childcount--;
//
//								} 
//								return true;			
//			}
//			else if(hitInfo.collider.tag =="strongenemy")
//			{
//							//				hitInfo.collider.gameObject.SetActive(false);
//							//				int number = hitInfo.collider.gameObject.GetComponent<Enemy>().index;
//							//				hitInfo.collider.gameObject.GetComponent<Enemy>().flag[number]=true;
//							
//							GameObject gb = (GameObject)Instantiate(tankShellExplosion,hitInfo.point,Quaternion.identity);
//							//				Destroy(hitInfo.collider.gameObject);
//							
//							hitInfo.collider.gameObject.GetComponent<TankBehaviour>().pd -= 21f;
//							hitInfo.collider.gameObject.SendMessage("Smoke",SendMessageOptions.DontRequireReceiver);
//							if(hitInfo.collider.gameObject.GetComponent<TankBehaviour>().pd <=0f)
//							{
//								hitInfo.collider.gameObject.GetComponent<TankBehaviour>().pd=0f;
//								//					Destroy(hitInfo.collider.gameObject);
//								hitInfo.collider.gameObject.SetActive(false);
//								GameObject gb1 = (GameObject)Instantiate(destroytank,hitInfo.collider.gameObject.transform.position,Quaternion.identity);
//								GameManager.childcount--;
//							}
//							return true;	
//							//				GameObject gb1 = (GameObject)Instantiate(destroytank,hitInfo.collider.gameObject.transform.position,Quaternion.identity);
//			}
//			else if(hitInfo.collider.tag == "mytank")
//			{
//				GameObject gb = (GameObject)Instantiate(mytankPar,hitInfo.point,Quaternion.identity);
////				hitInfo.collider.gameObject.SendMessage("decraseHealth",SendMessageOptions.DontRequireReceiver);
//				GameManager.instance.mytankHealth();
//				vibrationTime = 2f;
////				if(!bFlag){
////					oldpos = maincamera.transform.position;
////					bFlag = true;
////				}
////				StartCoroutine(mytankVibration());
////				Destroy (this.gameObject);
//				return true;
//			}
//			else if(hitInfo.collider.tag == "bounstarget")
//			{
//				GameObject gb = (GameObject)Instantiate(jeepcardestroypar,hitInfo.point,Quaternion.identity);
//				hitInfo.collider.gameObject.SendMessage("ccc",SendMessageOptions.DontRequireReceiver);
//				return true;	
//			}
//			else
//			{
//				GameObject gb= (GameObject)Instantiate(DestroyBuildingpar,hitInfo.point,Quaternion.identity);
//							return true;
//			}
//
//		}

			return false;
	}
	void Update () {
		numSteps-=1/DetectorLength;

			

		if (numSteps == 0)
		{ 
			Destroy(gameObject);
			return;
		}
		if (targetdetected) 
		{
			Destroy (gameObject);
			return;
		}
		position += velocity * Time.deltaTime + 0.5f * gravity * Time.deltaTime*Time.deltaTime;
		velocity += gravity * Time.deltaTime;
		targetdetected = RayPrediction(lastpos, position, initialPosition);

		lastpos = position;
//		transform.Translate (Time.deltaTime * 200f * transform.forward, Space.World);
//		rigidbody.velocity += transform.forward * Time.deltaTime * 800f;
//		transform.RotateAroundLocal (transform.right, Time.deltaTime*0.2f);
//		rigidbody.velocity += -transform.up * Time.deltaTime * 20f;
//		transform.Translate (Time.deltaTime * 5.5f * -transform.up, Space.World);
//		RaycastHit hitInfo;
//		if (Time.timeScale == 0) {
//			return;
//		}
//
//
//		if (Physics.Raycast (transform.position, transform.forward, out hitInfo, 5f)) {
//			if(hitInfo.collider.CompareTag("enemy")){
////				hitInfo.collider.gameObject.SetActive(false);
////				int number = hitInfo.collider.gameObject.GetComponent<Enemy>().index;
////				hitInfo.collider.gameObject.GetComponent<Enemy>().flag[number]=true;
//
//				GameObject gb = (GameObject)Instantiate(tankShellExplosion,hitInfo.point,Quaternion.identity);
////				Destroy(hitInfo.collider.gameObject);
//
//				hitInfo.collider.gameObject.GetComponent<TankBehaviour>().pd -= 41f;
//				hitInfo.collider.gameObject.SendMessage("Smoke",SendMessageOptions.DontRequireReceiver);
//				if(hitInfo.collider.gameObject.GetComponent<TankBehaviour>().pd <0f)
//				{
//					hitInfo.collider.gameObject.GetComponent<TankBehaviour>().pd=0f;
////					Destroy(hitInfo.collider.gameObject);
//					hitInfo.collider.gameObject.SetActive(false);
//					GameObject gb1 = (GameObject)Instantiate(destroytank,hitInfo.collider.gameObject.transform.position,Quaternion.identity);
//					GameManager.childcount--;
//					Debug.Log(GameManager.childcount);
//				}
//				Destroy (this.gameObject);
////				GameObject gb1 = (GameObject)Instantiate(destroytank,hitInfo.collider.gameObject.transform.position,Quaternion.identity);
//			}
//			if(hitInfo.collider.CompareTag("strongenemy")){
//				//				hitInfo.collider.gameObject.SetActive(false);
//				//				int number = hitInfo.collider.gameObject.GetComponent<Enemy>().index;
//				//				hitInfo.collider.gameObject.GetComponent<Enemy>().flag[number]=true;
//				
//				GameObject gb = (GameObject)Instantiate(tankShellExplosion,hitInfo.point,Quaternion.identity);
//				//				Destroy(hitInfo.collider.gameObject);
//				
//				hitInfo.collider.gameObject.GetComponent<TankBehaviour>().pd -= 21f;
//				hitInfo.collider.gameObject.SendMessage("Smoke",SendMessageOptions.DontRequireReceiver);
//				if(hitInfo.collider.gameObject.GetComponent<TankBehaviour>().pd <=0f)
//				{
//					hitInfo.collider.gameObject.GetComponent<TankBehaviour>().pd=0f;
//					//					Destroy(hitInfo.collider.gameObject);
//					hitInfo.collider.gameObject.SetActive(false);
//					GameObject gb1 = (GameObject)Instantiate(destroytank,hitInfo.collider.gameObject.transform.position,Quaternion.identity);
//					GameManager.childcount--;
//				}
//				Destroy (this.gameObject);
//				//				GameObject gb1 = (GameObject)Instantiate(destroytank,hitInfo.collider.gameObject.transform.position,Quaternion.identity);
//			}
//			else if(hitInfo.collider.CompareTag("mytank"))
//			{
//				GameObject gb = (GameObject)Instantiate(mytankPar,hitInfo.point,Quaternion.identity);
//				hitInfo.collider.gameObject.SendMessage("decraseHealth",SendMessageOptions.DontRequireReceiver);
//				vibrationTime = 2f;
//				Destroy(this.gameObject);
////				if(!bFlag){
////					oldpos = maincamera.transform.position;
////					bFlag = true;
////				}
////				StartCoroutine(mytankVibration());
////				Destroy (this.gameObject);
//			}
//			else if(hitInfo.collider.CompareTag("bounstarget"))
//			{
//				GameObject gb = (GameObject)Instantiate(jeepcardestroypar,hitInfo.point,Quaternion.identity);
//				hitInfo.collider.gameObject.SendMessage("ccc",SendMessageOptions.DontRequireReceiver);
//			}
//			else
//			{
//				GameObject gb= (GameObject)Instantiate(DestroyBuildingpar,hitInfo.point,Quaternion.identity);
////				Destroy(hitInfo.collider.gameObject,0.3f);
//				Destroy (this.gameObject);
//			}
//		}
//		if(vibrationTime >0f)
//		{
//			Camera.main.transform.position = new Vector3(maincamera.transform.position.x,maincamera.transform.position.y+Random.Range(-1f,1f),maincamera.transform.position.z);
//			vibrationTime -= Time.deltaTime*3f;
//			if(!GlobalInfo.cameraFlag)
//			{
//				maincamera.camera.fieldOfView = Random.Range(56f,64f);
//			}
//		}
//		else
//		{
//			if(!GlobalInfo.cameraFlag)
//			{
//				maincamera.camera.fieldOfView = 60f;
//			}
//		}
	}

	void OnCollisionEnter(Collision col)
	{
			if(col.collider.CompareTag("enemy")){
//				hitInfo.collider.gameObject.SetActive(false);
//				int number = hitInfo.collider.gameObject.GetComponent<Enemy>().index;
//				hitInfo.collider.gameObject.GetComponent<Enemy>().flag[number]=true;

			GameObject gb = (GameObject)Instantiate(tankShellExplosion,transform.position,Quaternion.identity);
//				Destroy(hitInfo.collider.gameObject);

			col.collider.gameObject.GetComponent<TankBehaviour>().pd -= 41f;
			col.collider.gameObject.SendMessage("Smoke",SendMessageOptions.DontRequireReceiver);
			if(col.collider.gameObject.GetComponent<TankBehaviour>().pd <0f)
				{
				col.collider.gameObject.GetComponent<TankBehaviour>().pd=0f;
//					Destroy(hitInfo.collider.gameObject);
				col.collider.gameObject.SetActive(false);
				GameObject gb1 = (GameObject)Instantiate(destroytank,col.collider.gameObject.transform.position,Quaternion.identity);
				gb1.transform.rotation = col.collider.gameObject.transform.rotation;
					GameManager.childcount--;
					GameManager.instance.tankCount--;
					GameManager.instance.EnemyHealth();
//					Debug.Log(GameManager.childcount);
				}
				Destroy (this.gameObject);
//				GameObject gb1 = (GameObject)Instantiate(destroytank,hitInfo.collider.gameObject.transform.position,Quaternion.identity);
			}
			else if(col.collider.CompareTag("stopenemy"))
		{
			GameObject gb = (GameObject)Instantiate(tankShellExplosion,transform.position,Quaternion.identity);
			//				Destroy(hitInfo.collider.gameObject);
			
			col.collider.gameObject.GetComponent<AiTankBehaviour>().pd -= 31f;
			col.collider.gameObject.SendMessage("Smoke",SendMessageOptions.DontRequireReceiver);
			if(col.collider.gameObject.GetComponent<AiTankBehaviour>().pd <0f)
			{
				col.collider.gameObject.GetComponent<AiTankBehaviour>().pd=0f;
				//					Destroy(hitInfo.collider.gameObject);
				col.collider.gameObject.SetActive(false);
				GameObject gb1 = (GameObject)Instantiate(destroytank,col.collider.gameObject.transform.position,Quaternion.identity);
				gb1.transform.rotation = col.collider.gameObject.transform.rotation;
				GameManager.childcount--;
				GameManager.instance.tankCount--;
				GameManager.instance.EnemyHealth();
			}
			Destroy (this.gameObject);
		}
		if(col.collider.CompareTag("strongenemy")){
				//				hitInfo.collider.gameObject.SetActive(false);
				//				int number = hitInfo.collider.gameObject.GetComponent<Enemy>().index;
				//				hitInfo.collider.gameObject.GetComponent<Enemy>().flag[number]=true;
				
			GameObject gb = (GameObject)Instantiate(tankShellExplosion,transform.position,Quaternion.identity);
				//				Destroy(hitInfo.collider.gameObject);
				
			col.collider.gameObject.GetComponent<TankBehaviour>().pd -= 21f;
			col.collider.gameObject.SendMessage("Smoke",SendMessageOptions.DontRequireReceiver);
			if(col.collider.gameObject.GetComponent<TankBehaviour>().pd <0f)
				{
				col.collider.gameObject.GetComponent<TankBehaviour>().pd=0f;
					//					Destroy(hitInfo.collider.gameObject);
				col.collider.gameObject.SetActive(false);
				GameObject gb1 = (GameObject)Instantiate(destroytank,col.collider.gameObject.transform.position,Quaternion.identity);
				gb1.transform.rotation = col.collider.gameObject.transform.rotation;
					GameManager.childcount--;
				GameManager.instance.tankCount--;
				GameManager.instance.EnemyHealth();
				}
				Destroy (this.gameObject);
				//				GameObject gb1 = (GameObject)Instantiate(destroytank,hitInfo.collider.gameObject.transform.position,Quaternion.identity);
			}
		else if(col.collider.CompareTag("mytank"))
			{
			GameObject gb = (GameObject)Instantiate(mytankPar,transform.position,Quaternion.identity);
			GameManager.instance.mytankHealth();
			if(GameManager.instance.healthbar.value <=0f)
			{
//				col.collider.gameObject.transform.position = new Vector3(-1000f,-1000f,-1000f);
				Camera.main.transform.parent = null;
				Camera.main.transform.GetComponent<SmoothFollow>().enabled = true;
				col.collider.gameObject.SetActive(false);
				GameManager.instance.tankdamgedflag  = false;
				GameObject gb1 = (GameObject)Instantiate(destroytank,col.collider.gameObject.transform.position,Quaternion.identity);
				gb1.transform.rotation = col.collider.gameObject.transform.rotation;
			}

			vibrationTime = 2f;
			Destroy(this.gameObject);
//				if(!bFlag){
//					oldpos = maincamera.transform.position;
//					bFlag = true;
//				}
//				StartCoroutine(mytankVibration());
//				Destroy (this.gameObject);
			}
		else if(col.collider.CompareTag("bounstarget"))
			{
			GameObject gb = (GameObject)Instantiate(jeepcardestroypar,transform.position,Quaternion.identity);
			col.collider.gameObject.SendMessage("ccc",SendMessageOptions.DontRequireReceiver);
			}
/*		else if(col.collider.CompareTag("RPG"))
		{
			GameObject gb= (GameObject)Instantiate(DestroyBuildingpar,transform.position,Quaternion.identity);
			col.collider.gameObject.SetActive(false);
			GameManager.childcount--;
			GameManager.instance.EnemyHealth();
			GameObject gb1 = (GameObject)Instantiate(death,col.collider.gameObject.transform.position,Quaternion.identity);
			Destroy(this.gameObject);
		}*/
			else
			{
			GameObject gb= (GameObject)Instantiate(DestroyBuildingpar,col.contacts [0].point,Quaternion.identity);
//			GameObject gb= (GameObject)Instantiate(DestroyBuildingpar,transform.position,Quaternion.identity);
//				Destroy(hitInfo.collider.gameObject,0.3f);
				Destroy (this.gameObject);
			}

	}
//	IEnumerator mytankVibration()
//	{
//		maincamera.transform.position = new Vector3(maincamera.transform.position.x,maincamera.transform.position.y+Random.Range(-5f,5f),maincamera.transform.position.z);
//		yield return new WaitForSeconds (3f);
//	}
	IEnumerator FinalizeParticle(){
		yield return new WaitForSeconds(5f);
		Destroy (this.gameObject);
	}
}
