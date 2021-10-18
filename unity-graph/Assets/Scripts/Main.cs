using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Main : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] private int startingVertices;
	[SerializeField] private float radius = 10f;
	
	[Header("References")]
	[SerializeField] private GameObject edgePrefab;
	[SerializeField] private GameObject vertexPrefab;
	[SerializeField] private Camera camera;
	
	private Graph graph;

	private List<VertexView> selectedVertices;
	private VertexView prevSelected;
	private bool selectingMultiple;
	
	private void Start()
	{
		graph = new Graph(edgePrefab, vertexPrefab);
		selectedVertices = new List<VertexView>();
		
		int prevValue = 0;
		
		for (int i = 0; i < startingVertices; i++)
		{
			int value = (int)Math.Pow(Random.value * 100, 2);
			Vector3 position = Random.insideUnitSphere * radius;
			
			graph.AddVertex(value, position);
			
			if(i > 0)
				graph.AddEdge(prevValue, value);
			
			prevValue = value;
		}

		graph.Print();
	}

	private void OnGUI()
	{
		if (prevSelected == null) return;
		
		GUILayout.BeginHorizontal();

		if (GUILayout.Button("Destroy") || Input.GetKeyDown(KeyCode.Delete))
		{
			for (var i = 0; i < selectedVertices.Count; i++)
			{
				graph.RemoveVertex(selectedVertices[i].value);
				selectedVertices.RemoveAt(i);
			}
		}
		
		GUILayout.EndHorizontal();

		if (GUILayout.Button("Add") || Input.GetKeyDown(KeyCode.Insert))
		{
			int value = (int)Math.Pow(Random.value * 100, 2);
			Vector3 position = Random.insideUnitSphere * radius;
			
			graph.AddVertex(value, position);
		}
	}

	private void Update()
	{
		selectingMultiple = Input.GetKey(KeyCode.LeftShift);

		RaycastHit hit;
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);

		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(ray, out hit)) {
				if (hit.transform.gameObject.CompareTag("Vertex"))
				{
					VertexView vertexView = hit.transform.gameObject.GetComponent<VertexView>();

					if (prevSelected != null && prevSelected != vertexView && !selectingMultiple)
					{
						prevSelected.Deselect();
					}

					if (!selectingMultiple && prevSelected != vertexView)
					{
						DeselectAll();
					}

					Debug.Log(vertexView.isSelected);
					
					if (vertexView.isSelected)
					{
						selectedVertices.Remove(vertexView);
						vertexView.Deselect();
					}
					else
					{
						selectedVertices.Add(vertexView);
						vertexView.Select();
						prevSelected = vertexView;
					}
				}
			}
			else if(!selectingMultiple)
			{
				DeselectAll();
			}
		}
	}

	private void DeselectAll()
	{
		for (var i = 0; i < selectedVertices.Count; i++)
		{
			selectedVertices[i].Deselect();
		}

		selectedVertices.Clear();
		prevSelected = null;
	}
}
