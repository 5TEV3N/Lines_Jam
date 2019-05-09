using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This script will take care of multiple things
 * 1. Taking track of how many players are playing [Less than 3 players should will result in a block] <TBD
 * 2. Pick the judge
 * 3. Managing the player's turnorder [Last player is always judge]
 */

public class PlayerManager : MonoBehaviour
{
    private bool turn1Established, turn2Established, turn3Established;

    public int numberOfPlayers;
    public int judgeSelect;

    public int turnNumber;
    public int[] playerTurn;
     
    public bool player1Turn, player2Turn, player3Turn, player4Turn;
    public bool player1IsJudge, player2IsJudge, player3IsJudge, player4IsJudge;
    
    public void EstablishTurnOrder()
    {
        turn1Established = turn2Established = turn3Established = false;
        judgeSelect = Random.Range(1, 5);
        playerTurn[3] = judgeSelect;

        for (int i = 0; i <= 3; i++)
        {
            if (turn1Established == false)
            {
                playerTurn[0] = Random.Range(1, 5);
                if (playerTurn[0] != judgeSelect)
                {
                    turn1Established = true;
                    i++;
                }
            }

            if (turn2Established == false)
            {
                if (playerTurn[1] != judgeSelect)
                {
                    playerTurn[1] = Random.Range(1, 5);
                    if (playerTurn[1] != playerTurn[0])
                    {
                        turn2Established = true;
                        i++;
                    }
                }
            }

            if (turn3Established == false)
            {
                if (playerTurn[2] != judgeSelect)
                {
                    playerTurn[2] = Random.Range(1, 5);
                    if (playerTurn[2] != playerTurn[0] && playerTurn[2] != playerTurn[1])
                    {
                        turn3Established = true;
                        i++;
                    }
                }
            }

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EstablishTurnOrder();
        }
    }
    public void EndTurn()
    {
        if (turnNumber < numberOfPlayers)
        {
            turnNumber++;
        }
        else
        {
            // go to judging stage;
        }
    }
}
