using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

	[SerializeField] private float MovSpeed;


	private void Update()
	{
		transform.position += Vector3.left * MovSpeed * Time.deltaTime;
	}

}
