using System;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

public class Vertex : MonoBehaviour
{
	[SerializeField] private Color selectedColor;
	[SerializeField] private Color deselectedColor;
	[SerializeField] private TextMeshPro text;
	
	[NonSerialized] public bool isSelected;
	public int value;
	private Renderer thisRenderer;
	
	public void Init(Vector3 position, int _value)
	{
		transform.position = position;
		text.text = _value.ToString();
		thisRenderer = GetComponent<Renderer>();
		value = _value;
	}

	public void Select()
	{
		thisRenderer.material.color = selectedColor;
		isSelected = true;
	}

	public void Deselect()
	{
		thisRenderer.material.color = deselectedColor;
		isSelected = false;
	}

	public void Destroy()
	{
		Object.Destroy(gameObject);
	}
}
