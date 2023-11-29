using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text targetText;
    public TMP_Text currentText;
    public TMP_Text xy_coordinates;
    public Transform targetTransform;
    
    public GameObject scoringObject;
    public Scoring scoringScript;
  
    int x_coordinate; 
    int y_coordinate;

    void Start()
    {
      if (scoringObject != null) {
        scoringScript = scoringObject.GetComponent<Scoring>();

        targetText.text = "target score: " + scoringScript.targetScore.ToString();
        currentText.text = "current score: " + scoringScript.currentScore.ToString();
        UpdateCoordinates();
      }
      else 
      {
        Debug.Log("Scoring object (singularity) not linked in Inspector.");
      }
    }

    void Update()
    {
        targetText.text = "target score: " + scoringScript.targetScore.ToString();
        currentText.text = "current score: " + scoringScript.currentScore.ToString();
        UpdateCoordinates();
    }

    void UpdateCoordinates()
    {
        // Check if the targetTransform is assigned
        if (targetTransform != null)
        {
            // Extract x and y coordinates from the Transform
            x_coordinate = Mathf.RoundToInt(targetTransform.position.x);
            y_coordinate = Mathf.RoundToInt(targetTransform.position.y);

            // Update the UI text for coordinates
            xy_coordinates.text = "x: " + x_coordinate.ToString() + ", y: " + y_coordinate.ToString();
        }
        else
        {
            Debug.LogError("Target Transform not assigned in the inspector!");
        }
    }


}
