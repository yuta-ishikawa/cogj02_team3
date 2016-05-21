using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StageManager : MonoBehaviour {

	[SerializeField]
	private MotionOrderObjects motionOrderObjects;
	private MotionOrderObject[] motionOrders;

	private ActionDemoManager actionDemoManager;
	private ActionManager actionManager;
	private Reaction reaction;
	private TimeGaugeManager timeManager;

	private MotionOrderObject currentMotionOrder;
	private AudioSource music;
	private bool actionCheck;

	void Start () {
		motionOrders = motionOrderObjects.motionOrders;

		actionDemoManager = GameObject.FindObjectOfType<ActionDemoManager> ();
		actionManager = GameObject.FindObjectOfType<ActionManager> ();
		reaction = GameObject.FindObjectOfType <Reaction>();
		timeManager = GameObject.FindObjectOfType <TimeGaugeManager> ();

		GameObject musicPlayer = GameObject.FindObjectOfType<StageDirector> ().GetMusicPlayer (); 
		music = musicPlayer.transform.FindChild ("Main").GetComponent<AudioSource>();
		actionCheck = false;
	}

	private bool startDemo = false;
	// Update is called once per frame
	void Update () {
		// 出現条件に応じて、お手本開始
		//DEBUG
		if (startDemo) {
			StartNextDemo ();
			startDemo = false;
		}
			
		float musicTime = music.time;
		foreach (var motionOrder in motionOrders) {
			if (! motionOrder.hasUsed) {
				if (motionOrder.startTimePoint <= musicTime) {
					// DEBUG
					Debug.Log ("<color=green>" + motionOrder.name + "</color> : " + musicTime);
					string str = "";
					for (int i = 0; i< motionOrder.order.Count; i++){
						str = str + motionOrder.order[i] + ", ";
					}
					Debug.Log(str);

					motionOrder.hasUsed = true;
					currentMotionOrder = motionOrder;
					StartNextDemo ();
				}
			}
		}
	}

	void StartNextDemo() {
		actionDemoManager.Next (currentMotionOrder.order, currentMotionOrder.name, currentMotionOrder.demoTime);
	}

	public void FinishDemo() {
		// お手本が終わったらアクション開始
		StartNextAction();
	}

	void StartNextAction() {
		timeManager.StartTimeGauge (currentMotionOrder.actionTimeLimit);
		actionManager.Next (currentMotionOrder.order);
		actionCheck = true;
	}

	public void FailAction() {
		FinishAction(GameManager.JudgementState.MISS);
	}

	public void SuccessAction() {
		// TODO 残り時間に応じた評価
		FinishAction(GameManager.JudgementState.PERFECT);
	}

	void FinishAction(GameManager.JudgementState judge) {
		currentMotionOrder.judge = judge;
		reaction.CreateReaction (judge, Vector3.zero);
		timeManager.StopTimeGauge ();
		actionCheck = true;
	}

	public void TimeUp() {
		if (actionCheck) {
			actionManager.TimeUp ();
			FailAction ();
		}
	}
}
