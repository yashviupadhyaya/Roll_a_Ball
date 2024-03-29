﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	private int count;
	public float speed;
	public Text countText;
	public Text winText;

	/*// Use this for initialization

	// Update is called once per frame
	void Update () {
		
	}*/

	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		winText.text = " ";
		SetCountText ();
	}


	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("PickUp")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}	
	}
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) 
		{
			winText.text="YOU WIN!!!";
		}
	}
}