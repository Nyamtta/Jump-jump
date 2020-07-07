using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Player : MonoBehaviour
{

	[SerializeField] private SpriteRenderer MySprite;
	[SerializeField] private int HitPoint;
	[SerializeField] private float JumpFors;
	private new Rigidbody2D rigidbody;

	private bool IsLife;
	private bool IsActivJump;

	private Color red;
	private Color blue;

	private void Awake()
	{
		IsActivJump = true;
		rigidbody = GetComponent<Rigidbody2D>();
		red = Color.red;
		blue = Color.blue;
		MySprite.color = red;
		IsLife = HitPoint > 0;
	}

	private void Update()
	{
		if(IsLife == false)
		{
			Destroy(gameObject);
		}

		if(Input.GetMouseButtonDown(0))
		{
			rigidbody.velocity = Vector3.zero;
			rigidbody.AddForce(Vector3.down * JumpFors, ForceMode2D.Impulse);
		}

		if(rigidbody.velocity.y < 0)
		{
			rigidbody.gravityScale = 1.5f;
		}

	}	

	private void Jump()
	{
		rigidbody.AddForce(Vector3.up * JumpFors, ForceMode2D.Impulse);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(IsActivJump == true)
		{
			rigidbody.gravityScale = 1;
			IsActivJump = false;
			Jump();
		}

		StartCoroutine(ActivJump());
	}

	private Color SpriteColor()
	{
		if(MySprite.color == red)
		{
			return blue;
		}
		else
			return red;
	}

	IEnumerator ActivJump()
	{
		yield return new WaitForSeconds(0.1f);
		IsActivJump = true;
	}

}
