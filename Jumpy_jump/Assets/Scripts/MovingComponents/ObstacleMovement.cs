using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : ObjectInfo {
	
	[SerializeField] private float MovSpeed;

	private void FixedUpdate()
	{
		MovPlatform();
	}

	private void MovPlatform()
	{
		transform.position += (Vector3.left * MovSpeed * Time.deltaTime);
	}
}
