using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo :MonoBehaviour, IObstacleInfo {

	[SerializeField] private SpriteRenderer MySprite;
	[SerializeField] private PoolTag.Tag MyTag;

	public Vector3 GetCentrSpritePos()
	{
		return MySprite.bounds.center;
	}

	public Vector3 GetLeftTopSpritePos()
	{
		return MySprite.bounds.max;
	}

	public Vector3 GetRightBotpSpritePos()
	{
		return MySprite.bounds.min;
	}

	public PoolTag.Tag GetTag()
	{
		return MyTag;
	}
}
