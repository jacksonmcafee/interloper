using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
  public GameObject scoringObject;
  public Scoring scoringScript;

  void Start()
  {
    scoringScript = scoringObject.GetComponent<Scoring>();
  }

  public void OnClickAddScore()
  {
    scoringScript.currentScore += 5;
  }
}
