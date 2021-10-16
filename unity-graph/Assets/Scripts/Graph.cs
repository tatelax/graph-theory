using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Graph
{
	private class Node
	{
		public readonly GameObject nodeView;

		public Node(Vector3 position)
		{
			nodeView = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			nodeView.transform.position = position;
		}

		~Node()
		{
			Object.Destroy(nodeView);
		}
	}

	private Dictionary<int, Node> nodeViews;
	private Dictionary<int, LinkedList<int>> vertices; // key = value of the vertex, value = connected vertices

	private GameObject edgePrefab;
	
	public Graph(GameObject _edgePrefab)
	{
		edgePrefab = _edgePrefab;
		vertices = new Dictionary<int, LinkedList<int>>();
		nodeViews = new Dictionary<int, Node>();
	}

	public void AddVertex(int value, Vector3 position = new Vector3())
	{
		if (vertices.ContainsKey(value))
		{
			Debug.Log($"Vertex {value} already exists.");
			return;
		}
		
		vertices.Add(value, new LinkedList<int>());
		nodeViews.Add(value, new Node(position));
	}

	public void AddEdge(int u, int v)
	{
		vertices[u].AddLast(v);
		CreateEdgeView(u, v);
	}

	private void CreateEdgeView(int start, int end)
	{
		EdgeView newEdge = Object.Instantiate(edgePrefab).GetComponent<EdgeView>();

		Vector3 startVertexPos = nodeViews[start].nodeView.transform.position;
		Vector3 endVertexPos = nodeViews[end].nodeView.transform.position;

		newEdge.Init(startVertexPos, endVertexPos);
	}

	public void Print()
	{
		foreach (KeyValuePair<int,LinkedList<int>> vertex in vertices)
		{
			StringBuilder output = new StringBuilder();

			output.Append($"[{vertex.Key}]: ");
			
			foreach (int i in vertex.Value)
			{
				output.Append($"-> {i} ");
			}

			Debug.Log(output);
		}
	}
}
