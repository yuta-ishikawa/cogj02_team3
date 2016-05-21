using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeGaugeManager : MonoBehaviour {

	private Image timeGauge;
	private float timeLimit;
	private float remainTime;
	private bool isGaugeMoving;
	private StageManager stageManager;

	// Use this for initialization
	void Start () {
		timeGauge = this.GetComponent<Image> ();
		timeGauge.fillAmount = 0.0f;
		remainTime = 0.0f;
		isGaugeMoving = false;
		stageManager = GameObject.FindObjectOfType<StageManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isGaugeMoving) {
			remainTime -= Time.deltaTime;
			if (remainTime <= 0) {
				StopTimeGauge ();
				stageManager.TimeUp ();
			} else {
				timeGauge.fillAmount = remainTime / timeLimit;
			}
		}	
	}

	public void StartTimeGauge(float timeLimit) {
		timeGauge.fillAmount = 1.0f;
		this.timeLimit = timeLimit;
		remainTime = timeLimit;
		isGaugeMoving = true;
	}

	public void StopTimeGauge() {
		timeGauge.fillAmount = 0.0f;
		isGaugeMoving = false;
	}
}
