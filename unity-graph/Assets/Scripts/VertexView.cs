using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class VertexView : MonoBehaviour
{
	[NonSerialized] public EdgeView EdgeView;

	public void Init(Vector3 position)
	{
		transform.position = position;
	}

	public void Destroy()
	{
		Object.Destroy(EdgeView.gameObject);
		Object.Destroy(gameObject);
	}
}
