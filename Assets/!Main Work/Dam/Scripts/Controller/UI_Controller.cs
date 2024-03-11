using UnityEngine;
using UnityEngine.UI;

namespace _Main_Work.Dam.Scripts
{
    public class UI_Controller:MonoBehaviour
    {
        public GameObject gameStart;
        public GameObject gameSettings;
        public GameObject gameEnd;

        public Button pauseGame;
        public Button startButton;



        public void UIOnUpdate()
        {
            
        }
        public void OpenStartGame()
        {
            gameStart.SetActive(true);
        }

        public void OpenSetting()
        {
            gameSettings.SetActive(true);
        }

        public void OpenPause()
        {
            pauseGame.gameObject.SetActive(true);
        }

        public void OpenEndGame()
        {
            gameEnd.SetActive(true);
        }
    }
}