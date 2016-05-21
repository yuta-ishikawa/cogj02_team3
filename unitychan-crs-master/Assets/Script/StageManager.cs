using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour {

	private ActionManager actionManaer;
	private Reaction reaction;
	private TimeGaugeManager timeManager;

	void Start () {
		actionManaer = GameObject.FindObjectOfType<ActionManager> ();
		reaction = GameObject.FindObjectOfType <Reaction>();
		timeManager = GameObject.FindObjectOfType <TimeGaugeManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void StartNextNote() {
		timeManager.StartTimeGauge ();
		actionManager.Next ();
	}
}
