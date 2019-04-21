using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

// This script will manager the prompts that appear in each round.

public class PromptsManager : MonoBehaviour
{
    private TextMeshProUGUI promptText;
    private string chosenPrompt;

    public GameObject promptObjRefferenceContainer;
    public List<string> promptsList = new List<string>();

    private void Awake()
    {
        chosenPrompt = promptsList[Random.Range(0, promptsList.Count)];
        promptText = promptObjRefferenceContainer.GetComponent<TextMeshProUGUI>();
        promptText.text = chosenPrompt;
    }

    public void Update()
    {

    }
}
