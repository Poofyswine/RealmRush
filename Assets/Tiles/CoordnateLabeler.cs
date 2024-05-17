using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordnateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.red;
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    void Awake() {
        label = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
        label.enabled = false;
        
    }

    void Update()
    {
        if(!Application.isPlaying){
            DisplayCoordinates();
            UpdateObjectName();
        }
        ToggleLables();
        ColorCoords();
    }

    void ToggleLables(){
        
        if(Input.GetKeyDown(KeyCode.C)){
            label.enabled = !label.IsActive();
        }
    }

    void ColorCoords()
    {
        if(waypoint.Isplaceable){
            label.color = defaultColor;
        }
        else{
            label.color = blockedColor;
        }
    }

    void DisplayCoordinates(){
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x/UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z/UnityEditor.EditorSnapSettings.move.z);
        label.text = $"{coordinates.x},{coordinates.y}";
    }

    void UpdateObjectName(){
        transform.parent.name = coordinates.ToString();
    }
}
