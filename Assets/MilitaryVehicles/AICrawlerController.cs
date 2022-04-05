using UnityEngine;
using System.Collections;

public class AICrawlerController : MonoBehaviour {

	// Use this for initialization
	public Transform wheelParent;
	public Transform wheelColliderParent;

	private int wheelCount = 0;
	private Transform[] leftWheel;
	private Transform[] rightWheel;
	private WheelCollider[] leftWheelCollider;
	private WheelCollider[] rightWheelCollider;
	void Start () {
		wheelCount = wheelParent.childCount / 2;
		leftWheel = new Transform[wheelCount];
		rightWheel = new Transform[wheelCount];
		leftWheelCollider = new WheelCollider[wheelCount];
		rightWheelCollider = new WheelCollider[wheelCount];
		
		foreach(Transform obj in wheelParent) {
			string n = obj.name;
			n = n.Substring(5);
			if(n.Substring(0,1) == "L"){
				leftWheel[System.Int32.Parse(n.Substring(1)) - 1] = obj;
				
			}else{
				rightWheel[System.Int32.Parse(n.Substring(1)) - 1] = obj;
			}
		}
		for(int i = 0;i < wheelCount;i++) {
			GameObject a = new GameObject("WheelCollider");
			a.transform.parent = wheelColliderParent;
			a.transform.localRotation = Quaternion.identity;
			a.transform.localPosition = leftWheel[i].localPosition;
			leftWheelCollider[i] = a.AddComponent<WheelCollider>();
			leftWheelCollider[i].mass = 1;
			leftWheelCollider[i].radius = 0.9f;
			leftWheelCollider[i].suspensionDistance = 0.4f;
			JointSpring js = new JointSpring();
			js.spring = 5000;
			js.damper = 45;
			js.targetPosition = 0.5f;
			leftWheelCollider[i].suspensionSpring = js;
			leftWheelCollider[i].brakeTorque = Mathf.Infinity;
			a = new GameObject("WheelCollider");
			a.transform.parent = wheelColliderParent;
			a.transform.localRotation = Quaternion.identity;
			a.transform.localPosition = rightWheel[i].localPosition;
			rightWheelCollider[i] = a.AddComponent<WheelCollider>();
			rightWheelCollider[i].mass = 1;
			rightWheelCollider[i].radius = 0.9f;
			rightWheelCollider[i].suspensionDistance = 0.4f;
			js = new JointSpring();
			js.spring = 5000;
			js.damper = 45;
			js.targetPosition = 0.5f;
			rightWheelCollider[i].suspensionSpring = js;
			rightWheelCollider[i].brakeTorque = Mathf.Infinity;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
