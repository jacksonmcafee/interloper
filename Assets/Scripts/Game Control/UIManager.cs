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

    public TMP_Text stageText;
    public string stageTextString;
    public float fadeDuration = 5f;

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

      StartCoroutine(ShowStageText(stageTextString, 0.5f));
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

    IEnumerator ShowStageText(string text, float delay)
    {
        yield return new WaitForSeconds(delay);

        stageText.text = text;

        float currentTime = 0;
        Color initialColor = stageText.color;

        while (currentTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, currentTime / fadeDuration);
            stageText.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }

        // Disable the Text object after fading out
        stageText.gameObject.SetActive(false);
    }
}
