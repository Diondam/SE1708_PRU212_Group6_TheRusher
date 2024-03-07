using System;
using UnityEngine;

namespace _Main_Work.Dam.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public bool isEndGame;
        public float timeDelay = 1f;

        private void Update()
        {
            if (isEndGame == true)
            {
                EndGame();
            }
        }

        public void EndGame()
        {
            Invoke("Pause", timeDelay);
        }

        public void Pause()
        {
            print("pause game");
            Time.timeScale = 0;
        }

        public void Resume()
        {
            
        }
    }
}