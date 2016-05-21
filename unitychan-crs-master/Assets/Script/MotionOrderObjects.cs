using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// モーションの管理
[System.Serializable]
public class MotionOrderObjects : ScriptableObject {

	[SerializeField]
	private MotionOrderObject[] _motionOrders;
	public MotionOrderObject[] motionOrders {
		get {return _motionOrders;}
	}
}