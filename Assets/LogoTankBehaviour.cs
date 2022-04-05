using UnityEngine;
using System.Collections;
using GlobalScripts;
public class LogoTankBehaviour : MonoBehaviour {

	// Use this for initialization
	public Transform[] wayPoints;
	private Vector3 currentWaypoint;
	public Transform tankpos;
	public Transform []wheel;
	private int index = 0;
	void Start () {
		StartCoroutine ("TankSound");
		currentWaypoint = wayPoints [index].position;
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Transform a in wheel)
		{
			a.Rotate(200f*Time.deltaTime,0f,0f);
		}
		transform.Translate (transform.forward * Time.deltaTime * 10f,Space.World);
		Vector3 lookAtVector = new Vector3 (currentWaypoint.x, transform.position.y, currentWaypoint.z);
		float angle = Vector3.Angle (transform.forward, (lookAtVector - transform.position).normalized);
		if (angle > Time.deltaTime * 30f) {
			if(Vector3.Angle(transform.right,(lookAtVector - transform.position).normalized) < 90f){
				transform.RotateAround(transform.position,transform.up,Time.deltaTime * 30f);
			}else{
				transform.RotateAround(transform.position,transform.up,-Time.deltaTime * 30f);
			}
		}
		if (Vector3.Distance (transform.position, currentWaypoint) < 5f){
			index ++;
			if(index >= wayPoints.Length){

				index = 0;
				transform.position = tankpos.position;
				transform.rotation = tankpos.rotation;
			}
			currentWaypoint = wayPoints[index].position;
		}
	}
	IEnumerator TankSound()
	{
		yield return new WaitForSeconds (1f);
		transform.GetComponent<AudioSource> ().enabled = true;
	}
}
