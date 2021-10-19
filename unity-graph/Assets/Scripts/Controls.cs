using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Controls : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Main main;
    [SerializeField] private TextMeshProUGUI totalDegrees;
    [SerializeField] private Button addButton;
    [SerializeField] private Button deleteButton;
    [SerializeField] private Button connectButton;
    
    private List<Vertex> selectedVertices;
    private Vertex prevSelected;
    private bool selectingMultiple;
    private float radius;
    
    private void Start()
    {
        selectedVertices = new List<Vertex>();
        radius = main.Radius;
        
        addButton.onClick.AddListener(Add);
        deleteButton.onClick.AddListener(Delete);
        connectButton.onClick.AddListener(Connect);
    }

    private void Update()
    {
        selectingMultiple = Input.GetKey(KeyCode.LeftShift);

        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.gameObject.CompareTag("Vertex"))
                {
                    Vertex vertex = hit.transform.gameObject.GetComponent<Vertex>();

                    if (prevSelected != null && prevSelected != vertex && !selectingMultiple)
                    {
                        prevSelected.Deselect();
                    }

                    if (!selectingMultiple && prevSelected != vertex)
                    {
                        DeselectAll();
                    }

                    if (vertex.isSelected)
                    {
                        selectedVertices.Remove(vertex);
                        vertex.Deselect();
                    }
                    else
                    {
                        selectedVertices.Add(vertex);
                        vertex.Select();
                        prevSelected = vertex;
                    }
                }
            }
            else if(!selectingMultiple)
            {
                DeselectAll();
            }
        }
        
        DoThings();
        UpdateUI();
    }

    private void UpdateUI()
    {
        totalDegrees.text = "Total Degrees: " + main.graph.GetTotalDegrees();

        connectButton.interactable = selectedVertices.Count == 2;
        deleteButton.interactable = selectedVertices.Count > 0;
    }

    public void DoThings()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Connect();
        }
        
        if(Input.GetKeyDown(KeyCode.Delete))
        {
            Delete();
        }
        
        if(Input.GetKeyDown(KeyCode.Insert))
        {
            Add();
        }
    }

    private void Connect()
    {
        main.graph.Connect(selectedVertices[0], selectedVertices[1]);
    }

    private void Delete()
    {
        for (int i = 0; i < selectedVertices.Count; i++)
        {
            main.graph.RemoveVertex(selectedVertices[i]);
            selectedVertices.RemoveAt(i);
        }
    }

    private void Add()
    {
        int value = (int)Math.Pow(Random.value * 100, 2);
        Vector3 position = Random.insideUnitSphere * radius;
        main.graph.AddVertex(value, position);
    }
    
    private void DeselectAll()
    {
        for (var i = 0; i < selectedVertices.Count; i++)
        {
            selectedVertices[i].Deselect();
        }

        selectedVertices.Clear();
        prevSelected = null;
    }
}
