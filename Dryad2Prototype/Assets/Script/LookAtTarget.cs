using UnityEngine;
using System.Collections;

public class lookAtTarget : MonoBehaviour {
	
	Transform target;
	
	void LookAtParent()
	{
		transform.LookAt( target );
	}

	// Use this for initialization
	void Start () {
		target = transform.parent.transform;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
