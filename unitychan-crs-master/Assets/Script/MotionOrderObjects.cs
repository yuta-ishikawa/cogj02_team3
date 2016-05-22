using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// モーションの管理
[System.Serializable]
public class MotionOrderObjects : ScriptableObject {
	[System.Serializable]
	public class MotionOrder {
		public float startTimePoint;
		public MotionOrderObject motionOrderObject;
		public bool hasUsed { get; set; }
	}

	[SerializeField]
	private MotionOrder[] _motionOrders;
	public MotionOrder[] motionOrders {
		get {return _motionOrders;}
	}

	void OnEnable() {
		for (int i = 0; i < _motionOrders.Length; i++) {
			_motionOrders[i].hasUsed = false;
		}
	}
}