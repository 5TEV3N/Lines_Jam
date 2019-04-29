using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script will take care of multiple things
 * 1. Taking track of how many players are playing [Less than 3 players should will result in a block]
 * 2. Managing the player's turnorder
 * 3. Managing the who's the judge for each round.
 */

public class PlayerManager : MonoBehaviour
{
    private bool check1, check2, check3, check4 = false;

    public bool playerSelectScreen;
    public bool player1, player2, player3, player4;
    public int playersPresent;

    private bool endTurn;
    public int turnOrder;


    private void Update()
    {
        if (playerSelectScreen == true)
        {
            JankyPlayerCounter(playersPresent);
            print("End Total: " + playersPresent);
            playerSelectScreen = false;

            //if (playersPresent < 3) { print("Sorry you need 3 or more players to continue playing."); }
            //if (playersPresent == 3) { turnOrder = 3; }
            //if (playersPresent == 4) { turnOrder = 4; } // Expand on later
        }
        else
        {
            //playerSelectScreen = false;
            // Move into gameplay.
        }
    }

    // return two types

    public int JankyPlayerCounter(int players)
    {
        for (int i = 0; i < 4; i++)
        {
            if (check1 == false)
            {
                if (player1 == true)
                {
                    players++;
                    i++;
                    check1 = true;
                }
            }

            if (check2 == false)
            {
                if (player2 == true)
                {
                    players++;
                    i++;
                    check2 = true;
                }
            }

            if (check3 == false)
            {
                if (player3 == true)
                {
                    players++;
                    i++;
                    check3 = true;
                }
            }

            if (check4 == false)
            {
                if (player4 == true)
                {
                    players++;
                    i++;
                    check4 = true;
                }
            }
        }
        print("We counted: " + players + " players in the jank");
        playersPresent = players;
        return players;
    }



}
