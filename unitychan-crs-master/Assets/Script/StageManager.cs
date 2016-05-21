using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageManager : MonoBehaviour {

	[SerializeField]
	private MotionOrderObject[] motionOrders;

	private ActionDemoManager actionDemoManager;
	private ActionManager actionManager;
	private Reaction reaction;
	private TimeGaugeManager timeManager;

	private List<int> currentOrder;

	void Start () {
		actionDemoManager = GameObject.FindObjectOfType<ActionDemoManager> ();
		actionManager = GameObject.FindObjectOfType<ActionManager> ();
		reaction = GameObject.FindObjectOfType <Reaction>();
		timeManager = GameObject.FindObjectOfType <TimeGaugeManager> ();
		currentOrder = new List<int> ();
	}

	private bool startDemo = true;
	// Update is called once per frame
	void Update () {
		// 出現条件に応じて、お手本開始
		//DEBUG
		if (startDemo) {
			StartNextDemo ();
			startDemo = false;
		}
	}

	void StartNextDemo() {
		// 名前に合わせてorderの作成、時間のセットとかとか
		currentOrder.Add (0);
		currentOrder.Add (1);
		currentOrder.Add (2);
		currentOrder.Add (5);
		currentOrder.Add (4);
		currentOrder.Add (3);

		float demoTime = 0.0f;
		actionDemoManager.Next (currentOrder, "MotionName", demoTime);
	}

	public void FinishDemo() {
		// お手本が終わったらアクション開始
		StartNextAction();
	}

	void StartNextAction() {
		float actionTime = 0.0f;

		timeManager.StartTimeGauge ();
		actionManager.Next (currentOrder);
	}

	public void FailAction() {
		reaction.CreateReaction (GameManager.JudgementState.MISS, Vector3.zero);
		timeManager.StartTimeGauge ();
	}

	public void SuccessAction() {
		// TODO 残り時間に応じた評価
		reaction.CreateReaction (GameManager.JudgementState.PERFECT, Vector3.zero);
		timeManager.StartTimeGauge ();
	}
}
