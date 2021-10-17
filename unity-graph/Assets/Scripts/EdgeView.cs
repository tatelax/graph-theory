using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class EdgeView : MonoBehaviour
{
	[SerializeField] private LineRenderer lineRenderer;

	private Graph graph;
	private int start;
	private int end;
	
	private Vector3 vertex0Prev;
	private Vector3 vertex1Prev;
	
	public void Init(Graph _graph, int _start, int _end)
	{
		graph = _graph;
		start = _start;
		end = _end;

		lineRenderer.alignment = LineAlignment.View;
		lineRenderer.positionCount = 2;
		lineRenderer.SetPosition(0, graph.vertexViews[start].transform.position);
		lineRenderer.SetPosition(1, graph.vertexViews[end].transform.position);
	}

	public void Update()
	{
		Vector3 vertex0Pos = graph.vertexViews[start].transform.position;
		Vector3 vertex1Pos = graph.vertexViews[end].transform.position;
		
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
