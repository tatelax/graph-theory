using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeView : MonoBehaviour
{
	[SerializeField] private LineRenderer renderer;
	
	public void Init(Vector3 start, Vector3 end)
	{
		renderer.alignment = LineAlignment.View;
		renderer.positionCount = 2;
		renderer.SetPosition(0, start);
		renderer.SetPosition(1, end);
	}
}
