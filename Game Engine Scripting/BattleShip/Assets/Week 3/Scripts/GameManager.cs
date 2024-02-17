using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Battleship

{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private int[,] grid = new int[,]
        {
        //Top left is (0,0)
        { 1, 1, 0, 0, 1 },
        { 0, 0, 0, 0, 0 },
        { 0, 0, 1, 0, 1 },
        { 1, 0, 1, 0, 0 },
        { 1, 0, 1, 0, 1 }
            //Bottom right is 4,4

        };

        //Represents where the player has fired
        private bool[,] hits;

        //Total rows and columns we have
        private int nRows;
        private int nCols;
        //Current row/column we are on
        private int row;
        private int col;
        //Correctly hit ships
        private int score;
        //Total time game has been running
        private int time;

        //Parent of all cells
        [SerializeField] Transform gridRoot;
        //Template used to populate the grid
        [SerializeField] GameObject cellPrefab;
        [SerializeField] GameObject winLabel;
        [SerializeField] GameObject timeLabel;
        [SerializeField] GameObject scoreLabel;

        private void Awake()
        {
            //Initialize rows/cols to help us with our operations
            nRows = grid.GetLength(0);
            nCols = grid.GetLength(1);
            //Create identical 2D array to grid that is of the type bool instead of int
            hits = new bool[nRows, nCols];

            //Populate the grid using a loop
            //Needs to execute as many times to fill up the grid
            //Can figure that out by calculating rows * cols
            for (int i = 0; i < nRows * nCols; i++)
            {
                //Create an instance of the prefab and child it to the gridRoot
                Instantiate(cellPrefab, gridRoot);

            }

            SelectCurrentCall();
            InvokeRepeating("IncrementTime", 1f, 1f);

        }

        Transform GetCurrentCall()
        {
            //You can figure out the child index
            //of the cell that is a part of the grid
            //by calculating (row*col) + col
            int index = (row * nCols) + col;
            //Return the child by index
            return gridRoot.GetChild(index);

        }

        void SelectCurrentCall()
        {
            //Get the current call
            Transform cell = GetCurrentCall();
            //Set the "Cursor" image on
            Transform cursor = cell.Find("Cursor");
            cursor.gameObject.SetActive(true);
        }

        void UnselectCurrentCall()
        {
            //Get the current call
            Transform cell = GetCurrentCall();
            //Set the "Cursor" image off
            Transform cursor = cell.Find("Cursor");
            cursor.gameObject.SetActive(false);

        }

        public void MoveHorizontal(int amt)
        {
            UnselectCurrentCall();

            col += amt;
            col = Mathf.Clamp(col, 0, nCols - 1);

            SelectCurrentCall();

        }

        public void MoveVerticle(int amt)
        {
            UnselectCurrentCall();

            row += amt;
            row = Mathf.Clamp(row, 0, nRows - 1);

            SelectCurrentCall();
        }

        void ShowHit()
        {
            Transform cell = GetCurrentCall();
            Transform hit = cell.Find("Hit");
            hit.gameObject.SetActive(true);
        }

        void ShowMiss()
        {
            Transform cell = GetCurrentCall();
            Transform miss = cell.Find("Miss");
            miss.gameObject.SetActive(true);
        }

        void IncrementScore()
        {
            score++;
            scoreLabel.text = string.Format("Score: {0}", score);

        }

        public void Fire()
        {
            if (hits[row, col]) return;
            hits[row, col] = true;

            if (grid[row, col] == 1)
            {
                ShowHit();
                IncrementScore();
            }
        
            else
            {
                ShowMiss();
            }
        
        
        }

        void TryEndGame()
        {
            for (int row = 0; row < nRows; row++)
            {
                for (int col = 0; col < nCols; col++)
                {
                    if (grid[row, col] == 0) continue;
                    if (hits[row, col] == false) return;
                }
            }

            winLabel.SetActive(true);
            CancelInvoke("IncrementTime");
        }
       
        void IncrementTime()
        {
            time++;
            timeLabel.text = string.Format("{0}:{1}", time / 60, (time % 60).ToString("00"));
        }
 
    
    
    }



}

