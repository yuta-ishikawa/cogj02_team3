using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// ステージで音楽の再生時間に応じて出現させるノーツ（モーション）
[System.Serializable]
public class MotionOrderObject : ScriptableObject {
	[SerializeField, Tooltip("モーション名指定")]
	private string _name;
	public new string name {
		get { return _name; }
	}
	[SerializeField, Tooltip("モーション開始時刻")]
	private float _startTimePoint;
	public float startTimePoint {
		get { return _startTimePoint; }
	}
	[SerializeField, Tooltip("お手本再生時間")]
	private float _demoTime;
	public float demoTime {
		get { return _demoTime; }
	}
	[SerializeField, Tooltip("入力制限時間")]
	private float _actionTimeLimit;
	public float  actionTimeLimit {
		get { return _actionTimeLimit; }
	}
	[SerializeField, Tooltip("順序指定")]
	private List<ActionManager.Icon> _order;
	public List<ActionManager.Icon> order {
		get { return _order; }
	}

	public bool hasUsed { get; set; }
	public GameManager.JudgementState judge { get; set; }

	void OnEnable() {
		hasUsed = false;
	}
}

