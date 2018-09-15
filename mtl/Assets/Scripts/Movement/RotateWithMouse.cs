﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.forward = (CursorTargeting.mouseWorldPoint - gameObject.transform.position)+new Vector3(1,0,1);
		Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * 20f);
	}
}
