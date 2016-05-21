using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageManager : MonoBehaviour {

	private ActionDemoManager actionDemoManager;
	private ActionManager actionManager;
	private Reaction reaction;
	private TimeGaugeManager timeManager;


	void Start () {
		actionDemoManager = GameObject.FindObjectOfType<ActionDemoManager> ();
		actionManager = GameObject.FindObjectOfType<ActionManager> ();
		reaction = GameObject.FindObjectOfType <Reaction>();
		timeManager = GameObject.FindObjectOfType <TimeGaugeManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		// ノーツの出現条件に応じて
		StartNextNote();
	}

	void StartNextNote() {
		List<int> action_order_list = new List<int> ();		//TODO
		action_order_list.Add (0);
		action_order_list.Add (1);
		action_order_list.Add (2);
		action_order_list.Add (5);
		action_order_list.Add (4);
		action_order_list.Add (3);

		timeManager.StartTimeGauge ();
		actionManager.Next (action_order_list);
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
