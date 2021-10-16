using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class EdgeView : MonoBehaviour
{
	[SerializeField] private LineRenderer lineRenderer;
	
	public void Init(Vector3 start, Vector3 end)
	{
		lineRenderer.alignment = LineAlignment.View;
		lineRenderer.positionCount = 2;
		lineRenderer.SetPosition(0, start);
		lineRenderer.SetPosition(1, end);
	}
}
