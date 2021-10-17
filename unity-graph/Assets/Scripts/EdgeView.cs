using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class EdgeView : MonoBehaviour
{
	[SerializeField] private LineRenderer lineRenderer;

	private Graph graph;
	private int start;
	private int end;
	
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
		lineRenderer.SetPosition(0, graph.vertexViews[start].transform.position);
		lineRenderer.SetPosition(1, graph.vertexViews[end].transform.position);
	}
}
