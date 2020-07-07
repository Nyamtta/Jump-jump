using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraengleSpavn : MonoBehaviour
{

	[SerializeField] private SpriteRenderer ThisSprite;
	
	private void OnEnable()
	{
		ObjectPool.Instans.GetObgectOfTag(PoolTag.Tag.SmallTriangle, transform.position, transform.parent, Quaternion.identity);
	}


}
