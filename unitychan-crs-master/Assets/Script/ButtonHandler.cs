using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerExitHandler {

	[SerializeField]
	private Sprite[] sprites;

	public void OnPointerDown (PointerEventData eventData)
	{
		GetComponent<Image> ().sprite = sprites[1];
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		GetComponent<Image> ().sprite = sprites[0];
	}
}
