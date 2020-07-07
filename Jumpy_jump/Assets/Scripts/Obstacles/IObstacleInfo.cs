using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacleInfo {

	Vector3 GetRightBotpSpritePos();
	Vector3 GetLeftTopSpritePos();
	Vector3 GetCentrSpritePos();
	PoolTag.Tag GetTag();

}
