using UnityEngine;
using System.Collections;

public static class Util {

	public static bool CompareTags(this Component _component, params string[] _tags) {
		foreach (var tag in _tags) {
			if (_component.CompareTag(tag)) return true;
		}
		return false;
	}

}
