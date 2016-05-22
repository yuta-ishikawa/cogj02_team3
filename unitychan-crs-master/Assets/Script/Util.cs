using UnityEngine;
using System.Collections;

public static class Util {

	public static bool CompareTags(this Component _component, params string[] _tags) {
		foreach (var tag in _tags) {
			if (_component.CompareTag(tag)) return true;
		}
		return false;
	}

	public static T Choose<T>(int index, params T[] args)
	{
		if (index < 1 || index > args.Length)
		{
			return default(T);
		}
		else
		{
			return args[--index];
		}
	}
}
