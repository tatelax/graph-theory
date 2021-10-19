using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

public class Vertex : MonoBehaviour
{
	[SerializeField] private Color selectedColor;
	[SerializeField] private Color deselectedColor;
	[SerializeField] private TextMeshPro text;
	
	[NonSerialized] public bool isSelected;

	public HashSet<Edge> connectedEdges;

	public int value;
	private Renderer thisRenderer;
	
	public void Init(Vector3 position, int _value)
	{
		connectedEdges = new HashSet<Edge>();
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

	public void ConnectEdge(Edge edge)
	{
		connectedEdges.Add(edge);
	}

	public void DisconnectEdge(Edge edge)
	{
		if (!connectedEdges.Contains(edge))
		{
			Debug.LogError("Tried to remove an edge that wasn't connected!");
			return;
		}

		connectedEdges.Remove(edge);
	}

	public void Destroy()
	{
		foreach (Edge connectedEdge in connectedEdges)
		{
			connectedEdge.Destroy();
		}

		Object.Destroy(gameObject);
	}
}
