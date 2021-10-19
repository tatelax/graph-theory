using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Graph
{
	private readonly Dictionary<Vertex, LinkedList<Vertex>> vertices; // key = value of the vertex, value = connected vertices

	private readonly GameObject vertexPrefab;
	private readonly GameObject edgePrefab;
	
	public Graph(GameObject _edgePrefab, GameObject _vertexPrefab)
	{
		edgePrefab = _edgePrefab;
		vertexPrefab = _vertexPrefab;
		vertices = new Dictionary<Vertex, LinkedList<Vertex>>();
	}

	public Vertex AddVertex(int value, Vector3 position = new Vector3())
	{
		Vertex newVertex = Object.Instantiate(vertexPrefab).GetComponent<Vertex>();
		newVertex.Init(position, value);
		
		vertices.Add(newVertex, new LinkedList<Vertex>());
		
		Debug.Log($"Added vertex {value}");

		return newVertex;
	}

	public void Connect(Vertex u, Vertex v)
	{
		if (!vertices.ContainsKey(u) || !vertices.ContainsKey(v))
		{
			Debug.LogWarning($"Tried to connect vertex {u} to {v} but one of them didn't exist!");
			return;
		}
		
		vertices[u].AddLast(v);
		vertices[v].AddLast(u);
		
		Debug.Log($"Connected vertex {u.value} to {v.value}");
		
		CreateEdgeView(u, v);
	}

	public void RemoveVertex(Vertex vertex)
	{
		if (!vertices.ContainsKey(vertex))
		{
			Debug.LogWarning($"Tried to remove {vertex}, but it doesn't exist.");
			return;
		}
		
		// Remove vertex from all of the things that vertex is connected to
		foreach (Vertex i in vertices[vertex])
		{
			vertices[i].Remove(vertex);
		}
		
		vertex.Destroy();
		vertices.Remove(vertex);
		
		Print();
	}

	private void CreateEdgeView(Vertex start, Vertex end)
	{
		Edge newEdge = Object.Instantiate(edgePrefab).GetComponent<Edge>();
		
		// Sets the start and end vertices of the line renderer so we can see it
		newEdge.Init(this, start, end);
		
		Print();
	}

	public int GetTotalDegrees()
	{
		int value = 0;

		foreach (KeyValuePair<Vertex,LinkedList<Vertex>> vertex in vertices)
		{
			value += vertex.Value.Count;
		}

		return value;
	}

	public int GetVertexDegree(Vertex vertex)
	{
		if (!vertices.ContainsKey(vertex))
		{
			Debug.LogError("Vertex not found!");
			return -1;
		}

		return vertices[vertex].Count;
	}

	public int GetVerticesDegrees(List<Vertex> vertices)
	{
		int sum = 0;

		for (int i = 0; i < vertices.Count; i++)
		{
			sum += GetVertexDegree(vertices[i]);
		}
		
		return sum;
	}
	
	public void Print()
	{
		Debug.Log("========== START OUTPUT ==========");

		foreach (KeyValuePair<Vertex,LinkedList<Vertex>> vertex in vertices)
		{
			StringBuilder output = new StringBuilder();

			output.Append($"[{vertex.Key.value}]: ");
			
			foreach (Vertex i in vertex.Value)
			{
				output.Append($"-> {i.value} ");
			}

			Debug.Log(output);
		}
		
		Debug.Log($"Total Degrees: {GetTotalDegrees().ToString()}");
		
		Debug.Log("========== END OUTPUT ==========");
	}
}
