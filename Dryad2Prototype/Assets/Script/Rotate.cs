using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	
	public float _rotateSpeed = 3.0f;
	
	void RotateObject()
	{
		transform.Rotate( Vector3.up*_rotateSpeed );
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RotateObject();
	
	}
}
