using UnityEngine;
using System.Collections;

public class ScaleUp : MonoBehaviour {

	private enum StateType { Stay, Up, Success };

	[SerializeField]
	private float addScale = 0.01f;
	[SerializeField]
	private StateType stateType = StateType.Stay;

	Vector3 nowScale = new Vector3(0.01f, 0.01f, 0.01f);

	void Awake()
	{
		gameObject.transform.localScale = nowScale;
	}

	public void StartScaleUp()
	{
		//stateType
	}

	// Update is called once per frame
	void Update () {
		if (stateType != StateType.Up) return;


		nowScale += new Vector3(addScale, addScale, addScale);

	}
}
