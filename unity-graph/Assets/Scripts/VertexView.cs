using System;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

public class VertexView : MonoBehaviour
{
	[SerializeField] private Color selectedColor;
	[SerializeField] private Color deselectedColor;
	
	[SerializeField] private TextMeshPro text;
	
	[NonSerialized] public EdgeView EdgeView;

	[NonSerialized] public bool isSelected;
	public int value;
	private Renderer renderer;
	
	public void Init(Vector3 position, int _value)
	{
		transform.position = position;
		text.text = _value.ToString();
		renderer = GetComponent<Renderer>();
		value = _value;
	}

	public void Select()
	{
		renderer.material.color = selectedColor;
		isSelected = true;
		Debug.Log("SELECTD");
	}

	public void Deselect()
	{
		renderer.material.color = deselectedColor;
		isSelected = false;
		Debug.Log("DESLE");
	}

	public void Destroy()
	{
		if(EdgeView != null)
			Object.Destroy(EdgeView.gameObject);
		
		Object.Destroy(gameObject);
	}
}
