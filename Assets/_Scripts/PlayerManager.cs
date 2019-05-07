using UnityEngine;

using Random = UnityEngine.Random;


/* This script will take care of multiple things
 * 1. Taking track of how many players are playing [Less than 3 players should will result in a block]
 * 2. Managing the player's turnorder
 * 3. Managing the who's the judge for each round.
 */

public class PlayerManager : MonoBehaviour
{
    private int basePlayersRefference; // refference of how many players are in-game
    private bool check1, check2, check3, check4 = false;
    private bool checkTurn1, checkTurn2, checkTurn3 = false;
    private bool endTurn;

    //public bool player1IsPlaying, player2IsPlaying, player3IsPlaying, player4IsPlaying;
    public bool player1Turn, player2Turn, player3Turn, player4Turn;
    public bool player1IsJudge, player2IsJudge, player3IsJudge, player4IsJudge;

    [Header("Game States")]
    public bool playerSelectScreen;
    public bool finalizeToGameplay;
    
    [Header("Debug info *Please set as private later")]
    public int playersPresent;
    public int judgeSelect;
    
    
    
    /*
    private void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            turn[0] = turn[Random.Range(0, 3)];
            print(turn[0]);
            //SceneManager.LoadScene(0);
        }
    }
     
        if (playerSelectScreen == true)
        {
            if (finalizeToGameplay == true)
            {
                JankyPlayerCounter(playersPresent);
                basePlayersRefference = playersPresent;
                //
                judgeSelect = turn[Random.Range(0, turn.Length)];
                turn[3] = judgeSelect;
                print("Judge = " + judgeSelect);
                //print("End Total: " + playersPresent + ". Player " + judgeSelect + " is now the judge!");
                ChooseOrder();
                playerSelectScreen = false;
            }
        }
    }


    public void ChooseOrder()
    {
        if (checkTurn1 == false)
        {
            turn[0] = turn[Random.Range(0, 3)];
            if (turn[0] != judgeSelect)
            {
                checkTurn1 = true;
                print("Player 1 = " + turn[0]);
            }
        }
       
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
        //print("We counted: " + players);
        playersPresent = players;
        return players;
    }
    */
}
