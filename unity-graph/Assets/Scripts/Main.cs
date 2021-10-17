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
	
	private Graph graph;
	
	private void Start()
	{
		graph = new Graph(edgePrefab, vertexPrefab);

		for (int i = 0; i < startingVertices; i++)
		{
			graph.AddVertex(i, Random.insideUnitSphere * radius);
		}

		for (int i = 0; i < startingVertices - 1; i++)
		{
			graph.AddEdge(i, i + 1);
		}
		
		graph.Print();
	}

	private void OnGUI()
	{
		if (GUILayout.Button("Destroy"))
		{
			graph.RemoveVertex(0);
		}
	}
}
