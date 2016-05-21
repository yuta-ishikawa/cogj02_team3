using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;


public class ActionManager : MonoBehaviour {
	[HideInInspector]public GameObject top_left;
	[HideInInspector]public GameObject top_center;
	[HideInInspector]public GameObject top_right;
	[HideInInspector]public GameObject bottom_left;
	[HideInInspector]public GameObject bottom_center;
	[HideInInspector]public GameObject bottom_right;
	[HideInInspector]public List<int> action_order_list;
	[HideInInspector]public List<int> input_order_list;


	public enum Icon{
		POINTER_UP = -1,
		TOP_LEFT,
		TOP_CENTER,
		TOP_RIGHT,
		BOTTOM_LEFT,
		BOTTOM_CENTER,
		BOTTOM_RIGHT,
	}

	private StageManager stageManager;

	// Use this for initialization
	void Start () {
		stageManager = GameObject.FindObjectOfType<StageManager> ();

		action_order_list.Add (0);
		action_order_list.Add (1);
		action_order_list.Add (2);
		action_order_list.Add (5);
		action_order_list.Add (4);
		action_order_list.Add (3);

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
	}


	// Update is called once per frame
	void Update () {

	}

	void StartInput()
	{
		input_order_list.Clear();
	}

	void RegisterEvent(GameObject icon, Icon icon_enum) {
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback.AddListener( (x) => { Event(icon_enum);} );

		EventTrigger.Entry pointer_down = new EventTrigger.Entry();
		pointer_down.eventID = EventTriggerType.PointerDown;
		pointer_down.callback.AddListener( (x) => { Event(icon_enum);} );

		EventTrigger.Entry pointer_up = new EventTrigger.Entry();
		pointer_up.eventID = EventTriggerType.PointerUp;
		pointer_up.callback.AddListener( (x) => { Event(Icon.POINTER_UP);} );

		EventTrigger trigger = icon.GetComponent<EventTrigger>();
		trigger.triggers.Add(entry);
		trigger.triggers.Add(pointer_down);
		trigger.triggers.Add(pointer_up);
	}

//	void 
	void Event(Icon icon_enum)
	{
		input_order_list.Add((int)icon_enum);
		DebugInput();

		int result = Compare();
		if (result == 1) {
			Debug.Log ("Success");
			input_order_list.Clear ();
			stageManager.SuccessAction ();
		} else if (result == -1) {
			Debug.Log ("Miss");
			input_order_list.Clear ();
			stageManager.FailAction ();
		}
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

	public void Next(List<int> order) {
		// 操作開始
		// 終了はStageManager.FailAction または StageManager.SuccessAction
		// もしくは時間切れが通知されるので停止
	}

	public void TimeUp() {
		// 失敗処理はStageManager側でします
	}
}
