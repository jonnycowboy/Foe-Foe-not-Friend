﻿using UnityEngine;
using System.Collections;

public class colorme : MonoBehaviour {
	private Color startcolor;
	void OnMouseEnter()
		
	{
		startcolor = GetComponent<Renderer>().material.color;
		GetComponent<Renderer>().material.color = Color.red;
	}
	void OnMouseExit()
	{
		GetComponent<Renderer>().material.color = startcolor;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
