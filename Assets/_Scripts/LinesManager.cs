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
    public GameObject playerTextObjRefferenceContainer;
    public GameObject playerLines1ObjRefferenceContainer;
    
    public bool roundRestart;

    private PlayerManager playersReff;
   
    public string player1Line;
    public string player2Line;
    public string player3Line;
    public string player4Line;
    
    private void Awake()
    {
        playersReff = GameObject.FindGameObjectWithTag("GManagerTag").GetComponent<PlayerManager>();
    }

    private void Update()
    {
        // Start of a new round
        if (roundRestart == true)
        {
            string empty = "";
            player1Line = player2Line = player3Line = player4Line = empty;
            playerLines1ObjRefferenceContainer.GetComponent<TMP_Text>().text = empty;
            roundRestart = false;
        }

        // Debug
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player1Line = playerTextObjRefferenceContainer.GetComponent<TMP_Text>().text;
            playerLines1ObjRefferenceContainer.GetComponent<TMP_Text>().text = player1Line;
        }
    }
    /*
    private bool isPlayerPlaying(bool playerStatus)
    {

        return false;
    }
    */
}
