using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Edge : MonoBehaviour
{
	[SerializeField] private LineRenderer lineRenderer;

	private Vertex start;
	private Vertex end;
	
	private Vector3 vertex0Prev;
	private Vector3 vertex1Prev;
	
	public void Init(Vertex _start, Vertex _end)
	{
		start = _start;
		end = _end;

		lineRenderer.alignment = LineAlignment.View;
		lineRenderer.positionCount = 2;
		lineRenderer.SetPosition(0, start.transform.position);
		lineRenderer.SetPosition(1, end.transform.position);
	}

	public void Update()
	{
		// Prob not the best way to check if we need to delete an edge
		// but this is just an example project
		if (!start || !end)
		{
			Destroy();
			return;
		}
		
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

	public void Destroy()
	{
		Object.Destroy(gameObject);
	}
}
