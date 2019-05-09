using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/* This script will take care of multiple things:
 * 1. Saving the player's inputed line.
 * 2. The last few characters of the line as well as projecting it to the next player.
 * 3. Clear the Text Area for the next player.
 * 4. Accumulating the lines for the judgement phase.
 * 5. Restart [Next Round].
 */

public class LinesManager : MonoBehaviour
{
    private PlayerManager playersReff;
    private string empty = "";

    public bool roundRestart;

    [Header("Containers")]
    public GameObject playerLinesObjRefferenceContainer;
    public GameObject previousPlayerLinesObjRefferenceContainer;

    [Header("Lines Section")]
    public int charactersToBeShowned;
    public string player1Line, player2Line, player3Line, player4Line;
    public string player1LastCharacters, player2LastCharacters, player3LastCharacters, player4LastCharacters;


    private void Awake()
    {
        playersReff = GameObject.FindGameObjectWithTag("GManagerTag").GetComponent<PlayerManager>();
    }

    private void Update()
    {
        // Start of a new round
        if (roundRestart == true)
        {
            player1Line = player2Line = player3Line = player4Line = empty;
            player1LastCharacters = player2LastCharacters = player3LastCharacters = player4LastCharacters = empty;
            playerLinesObjRefferenceContainer.GetComponent<TMP_Text>().text = empty;
            playersReff.judgeSelect = Random.Range(1, playersReff.numberOfPlayers);         
            roundRestart = false;
        }
    }

    public void SaveLine ()
    {
        if (playersReff.player1Turn == true)
        {
            if (playersReff.player1IsJudge != true)
            {
                player1Line = playerLinesObjRefferenceContainer.GetComponent<TMP_Text>().text;
                player1LastCharacters = player1Line.Substring(player1Line.Length - charactersToBeShowned);
                playersReff.player1Turn = false;
            }   
        }

        if (playersReff.player2Turn == true)
        {
            if (playersReff.player2IsJudge != true)
            {
                player2Line = playerLinesObjRefferenceContainer.GetComponent<TMP_Text>().text;
                player2LastCharacters = player2Line.Substring(player2Line.Length - charactersToBeShowned);
                playersReff.player2Turn = false;
            }
        }

        if (playersReff.player3Turn == true)
        {
            if (playersReff.player3IsJudge != true)
            {
                player3Line = playerLinesObjRefferenceContainer.GetComponent<TMP_Text>().text;
                player3LastCharacters = player3Line.Substring(player3Line.Length - charactersToBeShowned);
                playersReff.player3Turn = false;
            }
        }

        if (playersReff.player4Turn == true)
        {
            if (playersReff.player4IsJudge != true)
            {
                player4Line = playerLinesObjRefferenceContainer.GetComponent<TMP_Text>().text;
                player4LastCharacters = player4Line.Substring(player4Line.Length - charactersToBeShowned);
                playersReff.player4Turn = false;
            }
        }

        playerLinesObjRefferenceContainer.GetComponent<TMP_Text>().text = empty;
    }
}
