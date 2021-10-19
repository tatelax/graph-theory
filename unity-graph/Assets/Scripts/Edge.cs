using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Edge : MonoBehaviour
{
	[SerializeField] private LineRenderer lineRenderer;

	private Graph graph;
	private Vertex start;
	private Vertex end;
	
	private Vector3 vertex0Prev;
	private Vector3 vertex1Prev;
	
	public void Init(Graph _graph, Vertex _start, Vertex _end)
	{
		graph = _graph;
		start = _start;
		end = _end;

		lineRenderer.alignment = LineAlignment.View;
		lineRenderer.positionCount = 2;
		lineRenderer.SetPosition(0, start.transform.position);
		lineRenderer.SetPosition(1, end.transform.position);
	}

	public void Update()
	{
		Vector3 vertex0Pos = start.transform.position;
		Vector3 vertex1Pos = end.transform.position;
		
		if (vertex0Pos != vertex0Prev)
		{
			lineRenderer.SetPosition(0, vertex0Pos);
		}

		if (vertex1Pos != vertex1Prev)
		{
			lineRenderer.SetPosition(1, vertex1Pos);
		}

		vertex0Prev = vertex0Pos;
		vertex1Prev = vertex1Pos;
	}
}
