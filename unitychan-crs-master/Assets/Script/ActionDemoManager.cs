using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ActionDemoManager : MonoBehaviour {

	private StageManager stageManager;
	private GameObject hand;
	private Text handCount;
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
		this.handCount = this.hand.transform.FindChild ("HandCount").GetComponent<Text>();
		this.hand.SetActive (false);

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
		this.hand.SetActive (true);
		this.hand.transform.position = this.position_list[(int)order[0]];
		this.handCount.text = "1";

		for(int i = 0; i < order.Count; i++){
			if (i == 0) {
				SimpleAction ((int)order [i], (int)order [i], one_action_time, i);
			} else if (i < order.Count - 1) {
				SimpleAction ((int)order [i], (int)order [i - 1], one_action_time, i);
			} else {
				LastSimpleAction ((int)order [i], (int)order [i - 1], one_action_time, i);
			}
		}
	}

	private void SimpleAction(int current, int before, float time, int action_count){
		Vector3[] movepath = new Vector3[2];

		if (current == (int)ActionManager.Icon.POINTER_UP) {
			//タップ演出
			FadeOutHand(time/2, time * action_count + time);
			FadeInHand(time/2, time * action_count + time + time);
			Invoke("CountUpHandCount", time * action_count + time + time/2);

		} else if (isThroughCenter(current, before)) {
			if(current != (int)ActionManager.Icon.POINTER_UP) {
				movepath [0] = this.position_list[(int)ActionManager.Icon.MIDDLE_CENTER];
				movepath [1] = this.position_list[current];
			}
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

	private void CountUpHandCount() {
		int currentHandCount = 0;
		if (int.TryParse (this.handCount.text, out currentHandCount)) {
			this.handCount.text = (currentHandCount + 1).ToString ();
		}
	}

	private void FadeInHand(float time, float delay) {
		iTween.ValueTo(gameObject, iTween.Hash("from", 0f, "to", 1f, "time", 0.1f, "delay", delay, "onupdate", "SetHandAlpha"));
	}
	private void FadeOutHand(float time, float delay) {
		iTween.ValueTo(gameObject, iTween.Hash("from", 1f, "to", 0f, "time", 0f, "delay", delay, "onupdate", "SetHandAlpha"));
	}
	private void SetHandAlpha(float alpha) {
		// iTweenで呼ばれたら、受け取った値をImageのアルファ値にセット
		this.hand.GetComponent<RawImage> ().color = new Vector4 (255, 255, 255, alpha);

		Vector4 color = this.hand.transform.FindChild ("HandCountBack").GetComponent<Image> ().color;
		this.hand.transform.FindChild("HandCountBack").GetComponent<Image> ().color = new Vector4 (color.x, color.y, color.z, alpha);
		color = this.handCount.GetComponent<Text> ().color;
		this.handCount.GetComponent<Text> ().color = new Vector4 (color.x, color.y, color.z, alpha);
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
		this.hand.SetActive (false);
		Debug.Log ("FinishDemo");
		stageManager.FinishDemo();
	}
}
