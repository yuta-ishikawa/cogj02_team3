using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeGaugeManager : MonoBehaviour {

	private Image timeGauge;
	private const float timeLimit = 8;
	private float remainTime;
	private bool isGaugeMoving;

	// Use this for initialization
	void Start () {
		timeGauge = this.GetComponent<Image> ();
		remainTime = 0.0f;
		isGaugeMoving = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isGaugeMoving) {
			remainTime -= Time.deltaTime;
			if (remainTime <= 0) {
				StopTimeGauge ();
			} else {
				timeGauge.fillAmount = remainTime / timeLimit;
			}
		}	
	}

	public void StartTimeGauge() {
		timeGauge.fillAmount = 1.0f;
		remainTime = timeLimit;
		isGaugeMoving = true;
	}

	void StopTimeGauge() {
		timeGauge.fillAmount = 0.0f;
		isGaugeMoving = false;
	}
			
}
