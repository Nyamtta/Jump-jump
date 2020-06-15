using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMov : MonoBehaviour
{
	[SerializeField] private string Tag;
	[SerializeField] private float MovSpeed;

	private void FixedUpdate()
	{
		MovPlatform();
	}

	public string GetTag()
	{
		return Tag;
	}

	private void MovPlatform()
	{
		transform.position += (Vector3.left * MovSpeed * Time.deltaTime);
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if(collision.gameObject.GetComponent<DestroyWall>() == true)
		{
			ObjectPool.Instans.ReturnToPool(Tag, gameObject);
		}
	}


}
