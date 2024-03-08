using System;
using _Main_Work.Dam.Scripts.Character.Enemy;
using UnityEngine;

namespace _Main_Work.Dam.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public bool isEndGame;
        public float timeDelay = 1f;
        public Enemy enemy;
        private void Update()
        {
            print($"Enemy Current State: {enemy.currentState}");
            if (isEndGame == true)
            {
                EndGame();
            }
        }

        public void EndGame()
        {
            Time.timeScale = 0;
        }

        public void Pause()
        {
            Time.timeScale = 0;
        }

        public void Resume()
        {
            
        }
    }
}