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
	[SerializeField] private Camera mainCamera;
	
	private Graph graph;

	private List<Vertex> selectedVertices;
	private Vertex prevSelected;
	private bool selectingMultiple;
	
	private void Start()
	{
		graph = new Graph(edgePrefab, vertexPrefab);
		selectedVertices = new List<Vertex>();
		
		Vertex prevVertex = null;
		
		for (int i = 0; i < startingVertices; i++)
		{
			int value = (int)Math.Pow(Random.value * 100, 2);
			Vector3 position = Random.insideUnitSphere * radius;
			
			Vertex newVertex = graph.AddVertex(value, position);
			
			if(i > 0)
				graph.Connect(prevVertex, newVertex);
			
			prevVertex = newVertex;
		}

		graph.Print();
	}

	private void OnGUI()
	{
		GUILayout.BeginVertical();
		GUILayout.Label(graph.GetTotalDegrees().ToString());
		GUILayout.EndVertical();
		
		if (GUILayout.Button("Add") || Input.GetKeyDown(KeyCode.Insert))
		{
			int value = (int)Math.Pow(Random.value * 100, 2);
			Vector3 position = Random.insideUnitSphere * radius;
			
			graph.AddVertex(value, position);
		}
		
		if (prevSelected != null && GUILayout.Button("Destroy") || Input.GetKeyDown(KeyCode.Delete))
		{
			for (int i = 0; i < selectedVertices.Count; i++)
			{
				graph.RemoveVertex(selectedVertices[i]);
				selectedVertices.RemoveAt(i);
			}
		}

		if (selectedVertices.Count == 2 && GUILayout.Button("Connect") || selectedVertices.Count == 2 && Input.GetKeyDown(KeyCode.C))
		{
			graph.Connect(selectedVertices[0], selectedVertices[1]);
		}
	}

	private void Update()
	{
		selectingMultiple = Input.GetKey(KeyCode.LeftShift);

		RaycastHit hit;
		Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(ray, out hit)) {
				if (hit.transform.gameObject.CompareTag("Vertex"))
				{
					Vertex vertex = hit.transform.gameObject.GetComponent<Vertex>();

					if (prevSelected != null && prevSelected != vertex && !selectingMultiple)
					{
						prevSelected.Deselect();
					}

					if (!selectingMultiple && prevSelected != vertex)
					{
						DeselectAll();
					}

					Debug.Log(vertex.isSelected);
					
					if (vertex.isSelected)
					{
						selectedVertices.Remove(vertex);
						vertex.Deselect();
					}
					else
					{
						selectedVertices.Add(vertex);
						vertex.Select();
						prevSelected = vertex;
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
