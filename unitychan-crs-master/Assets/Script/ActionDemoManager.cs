using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ActionDemoManager : MonoBehaviour {

	private StageManager stageManager;
	private GameObject hand;
	private List<Vector3> position_list = new List<Vector3>();
	private Vector3 top_left;
	private Vector3 top_center;
	private Vector3 top_right;
	private Vector3 bottom_left;
	private Vector3 bottom_center;
	private Vector3 bottom_right;
	private Vector3 middle_center;

	// Use this for initialization
	void Start () {
		stageManager = GameObject.FindObjectOfType<StageManager> ();
		this.hand = GameObject.Find ("hand");

		this.position_list.Add(GameObject.Find("top_left").transform.position);
		this.position_list.Add(GameObject.Find("top_center").transform.position);
		this.position_list.Add(GameObject.Find("top_right").transform.position);
		this.position_list.Add(GameObject.Find("bottom_left").transform.position);
		this.position_list.Add(GameObject.Find("bottom_center").transform.position);
		this.position_list.Add(GameObject.Find("bottom_right").transform.position);
		this.position_list.Add(GameObject.Find("middle_center").transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Next(List<ActionManager.Icon> order, string motionName, float time) {
		switch (motionName) {
		case "dummy":
			break;
		default:
			SimpleActionDemo(order, time/order.Count);  // orderに基づいた簡易アニメーション 
			break;
		}
	}


	private void SimpleActionDemo(List<ActionManager.Icon> order, float one_action_time) {
		this.hand.transform.position = this.position_list[(int)order[0]];
		for(int i =0; i<order.Count; i++){
			if (i == 0) {
				SimpleAction ((int)order [i], (int)order [i], one_action_time, i);
			} else if (order.Count - 1 > i) {
				SimpleAction ((int)order [i], (int)order [i - 1], one_action_time, i);
			} else
				LastSimpleAction((int)order [i], (int)order [i - 1], one_action_time, i);
		}
	}


	private void SimpleAction(int current, int before, float time, int action_count){
		Vector3[] movepath = new Vector3[2];
		if(current != (int)ActionManager.Icon.POINTER_UP) {
			movepath [0] = this.position_list[(int)ActionManager.Icon.MIDDLE_CENTER];
			movepath [1] = this.position_list[current];
		}
		// Vector3[] movepath = new Vector3[4];
		// if(current != (int)ActionManager.Icon.POINTER_UP) {
		// 	movepath [0] = new Vector3(this.position_list[current].x - this.position_list[current].x,
		// 	                           this.position_list[current].y - this.position_list[current].y,
		// 	                           this.position_list[current].z) - this.position_list[current].z;
		// 	movepath [1] = this.position_list[(int)ActionManager.Icon.MIDDLE_CENTER];
		// 	movepath [2] = new Vector3(this.position_list[current].x - this.position_list[current].x,
		// 	                           this.position_list[current].y - this.position_list[current].y,
		// 	                           this.position_list[current].z - this.position_list[current].z);
		// 	movepath [3] = this.position_list[current];
		// }
			
		if (current == (int)ActionManager.Icon.POINTER_UP) {
			//タップ演出
			FadeOutHand(time/2, time * action_count + time);
			FadeInHand(time/2, time * action_count + time + time);
		} else if (isThroughCenter(current, before)) {
			iTween.MoveTo (this.hand, iTween.Hash ("path", movepath,
				                                   "time", time,
				                                   "delay", time * action_count,
				                                   "easeType",iTween.EaseType.linear));
		} else {
			iTween.MoveTo (this.hand, iTween.Hash ("position", this.position_list [current],
				                                   "time", time,
				                                   "delay", time * action_count,
				                                   "easeType",iTween.EaseType.linear));
		}
	}

	private void FadeInHand(float time, float delay) {
		// SetValue()を毎フレーム呼び出して、１秒間に０から１までの値の中間値を渡す
		iTween.ValueTo(gameObject, iTween.Hash("from", 0f, "to", 1f, "time", 0.1f, "delay", delay, "onupdate", "SetValue"));
	}
	private void FadeOutHand(float time, float delay) {
		// SetValue()を毎フレーム呼び出して、１秒間に１から０までの値の中間値を渡す
		iTween.ValueTo(gameObject, iTween.Hash("from", 1f, "to", 0f, "time", 0f, "delay", delay, "onupdate", "SetValue"));
	}
	private void SetValue(float alpha) {
		// iTweenで呼ばれたら、受け取った値をImageのアルファ値にセット
		this.hand.GetComponent<RawImage>().color = new Vector4(255, 255, 255, alpha);
	}


	private void LastSimpleAction(int current, int before, float time, int action_count){
		iTween.MoveTo(this.hand, iTween.Hash("position", this.position_list[current],
			                                 "time", time,
			                                 "delay", time * action_count,
			                                 "oncomplete", "FinishDemo",
			                                 "oncompletetarget", gameObject,
			                                 "easeType",iTween.EaseType.linear));
	}

	private bool isThroughCenter(int current, int before) {
		if ( (before == (int)ActionManager.Icon.TOP_LEFT && current == (int)ActionManager.Icon.TOP_RIGHT) ||
			 (before == (int)ActionManager.Icon.TOP_RIGHT && current == (int)ActionManager.Icon.TOP_LEFT) ||
			 (before == (int)ActionManager.Icon.BOTTOM_LEFT && current == (int)ActionManager.Icon.BOTTOM_RIGHT) ||
			 (before == (int)ActionManager.Icon.BOTTOM_RIGHT && current == (int)ActionManager.Icon.BOTTOM_LEFT)){
			return true;
			}
		return false;
	}

	private void FinishDemo(){
		this.hand.transform.position = new Vector3(0, 3000, 0);
		Debug.Log ("FinishDemo");
		stageManager.FinishDemo();
	}
}
