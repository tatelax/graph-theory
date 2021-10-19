using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Main : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] private int startingVertices;
	[SerializeField] private float radius = 10f;
	
	[Header("References")]
	[SerializeField] private GameObject edgePrefab;
	[SerializeField] private GameObject vertexPrefab;

	public Graph graph { get; private set; }

	public float Radius
	{
		get => radius;
	}
	
	private void Start()
	{
		graph = new Graph(edgePrefab, vertexPrefab);
		
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
	}
}
