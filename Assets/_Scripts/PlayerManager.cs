using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;


/* This script will take care of multiple things
 * 1. Taking track of how many players are playing [Less than 3 players should will result in a block]
 * 2. Managing the player's turnorder
 * 3. Managing the who's the judge for each round.
 */

public class PlayerManager : MonoBehaviour
{
    private bool check1, check2, check3, check4 = false;
    private bool endTurn;
    public bool player1, player2, player3, player4;
    private int basePlayersRefference; // refference of how many players are in-game

    [Header("Game States")]
    public bool playerSelectScreen;
    public bool finalizeToGameplay;

    [Header("Debug info *Please set as private later*")]
    public int playersPresent;
    public int judgeSelect;
    public int[] turn;



    private void Update()
    {
        if (playerSelectScreen == true)
        {
            if (finalizeToGameplay == true)
            {
                JankyPlayerCounter(playersPresent);
                basePlayersRefference = playersPresent;
                judgeSelect = turn[Random.Range(0, turn.Length)];
                print("End Total: " + playersPresent + ". Player " + judgeSelect + " is now the judge!");
                playerSelectScreen = false;
            }
        }
    }
    public void ChooseOrder()
    {
        turn[3] = judgeSelect;
        turn[0] = turn[Random.Range(0,2)];
        turn[0] = turn[Random.Range(0,1)];
        if (turn[1] == turn[0]) { }
    }
    public int JankyPlayerCounter(int players) //Look into when doing the player select.
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
        print("We counted: " + players);
        playersPresent = players;
        return players;
    }
}
