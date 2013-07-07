using UnityEngine;
using System.Collections;

public class LookAtParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt( transform.parent.transform.position );
	
	}
}
