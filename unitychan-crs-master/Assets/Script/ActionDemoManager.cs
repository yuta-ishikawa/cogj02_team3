using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionDemoManager : MonoBehaviour {

	private StageManager stageManager;

	// Use this for initialization
	void Start () {
		stageManager = GameObject.FindObjectOfType<StageManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Next(List<int> order, string motionName, float time) {
		//簡易実装：orderに基づいたあにめーしょん
		//本番実装：名前に基づき事前に作っておいたアニメーションを再生
		//time秒が経過しデモが終了したらstageManager.FinishDemo();

		switch (motionName) {	//TODO 頑張る
		default:
			break;
		}

		stageManager.FinishDemo();
	}
}
