using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RingEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		iTween.ValueTo (this.gameObject, 
			iTween.Hash ("from", 1f, "to", 0f, "time", 0.5f, "delay", 0, "loopType", "none", "onupdate", "SetRingEffectAlpha", "oncomplete", "Destroy"));
		iTween.ScaleTo (this.gameObject, new Vector3 (3.0f, 3.0f, 1.0f), 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private void Destroy() {
		Destroy (this.gameObject);
	}

	private void SetRingEffectAlpha(float alpha) {
		Debug.Log ("SetRingEffectAlpha:" + alpha);
		this.GetComponent<Image> ().color = new Vector4 (255, 255, 255, alpha);
	}
}
