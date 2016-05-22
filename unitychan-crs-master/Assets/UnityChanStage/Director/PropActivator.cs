using UnityEngine;
using System.Collections;

public class PropActivator : MonoBehaviour
{
    void ActivateProps()
    {
		foreach (Transform c in transform)
		{
			if (!c.gameObject.activeSelf) continue;
			Debug.Log("SetActiveProps : " + c.gameObject.name);
			c.gameObject.SetActive(true);
		}
    }
}
