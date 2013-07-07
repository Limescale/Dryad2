using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour {
	
	Transform target;
	
	void lookAtParent()
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
