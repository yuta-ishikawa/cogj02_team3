using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ActionManager : MonoBehaviour {
	private GameObject top_left;
	private  GameObject top_center;
	private  GameObject top_right;
	private GameObject bottom_left;
	private GameObject bottom_center;
	private GameObject bottom_right;
	private List<Icon> action_order_list;
	private List<Icon> input_order_list;
	private GameObject tap_object;

	public enum Icon{
		POINTER_UP = -1,
		TOP_LEFT,
		TOP_CENTER,
		TOP_RIGHT,
		BOTTOM_LEFT,
		BOTTOM_CENTER,
		BOTTOM_RIGHT,
		MIDDLE_CENTER,
	}

	private StageManager stageManager;
	private bool actionCheck;
	private bool hasDowned;

	// Use this for initialization
	void Start () {
		// 速攻でフェード終了
		// メインに遷移後すぐにFadeOutを完了させる
		ScreenFadeManager.Instance.FadeOut(0.01f, new Color(1.0f, 1.0f, 1.0f), delegate { Debug.Log("OK"); });

		stageManager = GameObject.FindObjectOfType<StageManager> ();

		top_left = GameObject.Find("top_left");
		top_center = GameObject.Find("top_center");
		top_right = GameObject.Find("top_right");
		bottom_left = GameObject.Find("bottom_left");
		bottom_center = GameObject.Find("bottom_center");
		bottom_right = GameObject.Find("bottom_right");

		RegisterEvent(top_left, Icon.TOP_LEFT);
		RegisterEvent(top_center, Icon.TOP_CENTER);
		RegisterEvent(top_right, Icon.TOP_RIGHT);
		RegisterEvent(bottom_left, Icon.BOTTOM_LEFT);
		RegisterEvent(bottom_center, Icon.BOTTOM_CENTER);
		RegisterEvent(bottom_right, Icon.BOTTOM_RIGHT);

		actionCheck = false;
		input_order_list = new List<Icon> ();
	}


	// Update is called once per frame
	void Update () {

	}

	void ResetInput()
	{
		input_order_list.Clear();
	}

	void RegisterEvent(GameObject icon, Icon icon_enum) {
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback.AddListener( (x) => { Event(icon_enum, EventTriggerType.PointerEnter, icon);} );

		EventTrigger.Entry pointer_down = new EventTrigger.Entry();
		pointer_down.eventID = EventTriggerType.PointerDown;
		pointer_down.callback.AddListener( (x) => { Event(icon_enum, EventTriggerType.PointerDown, icon);} );

		EventTrigger.Entry pointer_up = new EventTrigger.Entry();
		pointer_up.eventID = EventTriggerType.PointerUp;
		pointer_up.callback.AddListener( (x) => { Event(Icon.POINTER_UP, EventTriggerType.PointerUp, icon);} );

		EventTrigger trigger = icon.GetComponent<EventTrigger>();
		trigger.triggers.Add(entry);
		trigger.triggers.Add(pointer_down);
		trigger.triggers.Add(pointer_up);
	}

	void Event(Icon icon_enum, EventTriggerType eventType, GameObject icon)
	{
		switch (eventType) {
		case EventTriggerType.PointerEnter:
			if (!hasDowned) {
				return;
			}
			break;
		case EventTriggerType.PointerDown:
			hasDowned = true;
			break;
		case EventTriggerType.PointerUp:
			hasDowned = false;
			break;
		default:
			Debug.LogAssertion ("Event Error. Type:" + eventType);
			break;
		}

		if (actionCheck) {
			input_order_list.Add (icon_enum);
			tap_object = icon;
			FadeInHand();
			DebugInput ();

			int result = Compare ();
			if (result == 1) {
				Debug.Log ("Success");
				stageManager.SuccessAction ();
				actionCheck = false;
				ResetInput ();
			} else if (result == -1) {
				Debug.Log ("Miss");
				stageManager.FailAction ();
				actionCheck = false;
				ResetInput ();
			}
		}
	}

	private void FadeInHand() {
		// SetValue()を毎フレーム呼び出して、１秒間に０から１までの値の中間値を渡す
		iTween.ValueTo(gameObject, iTween.Hash("from", 0f, "to", 1f, "time", 1.0f, "delay", 0, "loopType", "none", "onupdate", "SetValue"));
	}
	private void FadeOutHand() {
		// SetValue()を毎フレーム呼び出して、１秒間に１から０までの値の中間値を渡す
		iTween.ValueTo(gameObject, iTween.Hash("from", 1f, "to", 0f, "time", 1.0f, "delay", 0, "loopType", "none", "onupdate", "SetValue"));
	}
	private void SetValue(float alpha) {
		// iTweenで呼ばれたら、受け取った値をImageのアルファ値にセット
		this.tap_object.GetComponent<RawImage>().color = new Vector4(255, 255, 255, alpha);
	}

	int Compare(){
		if (input_order_list.Count < action_order_list.Count) {
			if (action_order_list [input_order_list.Count - 1] != input_order_list [input_order_list.Count - 1]) {
				return -1;
			} else {
				return 0;
			}
		} else if (input_order_list.Count > action_order_list.Count) {
			return -1;
		}

		for (int i = input_order_list.Count - 1; i >= 0; i--)
		{
			if (action_order_list [i] != input_order_list [i]) {
				return -1;
			}
		}
		return 1;
	}

	void DebugInput() {
		string str = "";
		for (int i = input_order_list.Count - 1; i >= 0; i--)
		{
			str = str + input_order_list[i] + ", ";
		}
		Debug.Log(str);
	}

	public void Next(List<Icon> order) {
		action_order_list = order;
		actionCheck = true;
		ResetInput ();
	}

	public void TimeUp() {
		actionCheck = false;
		ResetInput();
	}
}
