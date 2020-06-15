using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	[SerializeField] private new Rigidbody2D rigidbody;
	[SerializeField] private int HitPoint;
	[SerializeField] private SpriteRenderer PlayerSprite;

	private bool IsLife;

	private Color red;
	private Color blue;

	private void Awake()
	{
		red = Color.red;
		blue = Color.blue;
		PlayerSprite.color = red;
		IsLife = HitPoint > 0;
		rigidbody = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if(IsLife == false)
		{
			Destroy(gameObject);
		}

		if(Input.GetMouseButtonDown(0))
		{
			PlayerSprite.color = SpriteColor();
			rigidbody.gravityScale = -rigidbody.gravityScale;
		}
	}

	private Color SpriteColor()
	{
		if(PlayerSprite.color == red)
		{
			return blue;
		}
		else
			return red;
	}

}
