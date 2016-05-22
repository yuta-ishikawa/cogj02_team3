using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	[SerializeField]
	private float destroyTime = 1.5f;
	private float nowTime = 0.0f;

	// Update is called once per frame
	void Update () {
		nowTime += Time.deltaTime;
		if (nowTime < destroyTime) return;

		Destroy(this.gameObject);
	}
}
