using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// リザルトで表示するテキストをまとめたオブジェクト
[System.Serializable]
public class MotionOrderObject : ScriptableObject {
	[SerializeField, Tooltip("モーション名指定")]
	private string _name;
	private string name {
		get { return _name; }
	}
	[SerializeField, Tooltip("モーション開始時刻")]
	private string _startTimePoint;
	private string startTimePoint {
		get { return _startTimePoint; }
	}
	[SerializeField, Tooltip("お手本再生時間")]
	private string _demoTime;
	private string demoTime {
		get { return _demoTime; }
	}
	[SerializeField, Tooltip("入力制限時間")]
	private string _actionTimeLimit;
	private string actionTimeLimit {
		get { return _actionTimeLimit; }
	}
	[SerializeField, Tooltip("順序指定")]
	private List<ActionManager.Icon> _order;
	private List<ActionManager.Icon> order {
		get { return _order; }
	}
}

