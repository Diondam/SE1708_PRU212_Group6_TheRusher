using System;
using _Main_Work.Dam.Scripts.Character.Enemy;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

namespace _Main_Work.Dam.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public UI_Controller uiController;
        public SoundController soundController;
        [Space]
        public Enemy enemy;
        public int level = 0;
        private string sceneNameToLoad = "level";
        public string arbitraryNameScene ;
        public Vector3 diePoint = new Vector3(0,0f,0);
        
        
        private void Awake()
        {
            uiController = FindObjectOfType<UI_Controller>();
            soundController = FindObjectOfType<SoundController>();
            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            uiController.OpenStartGame();
            soundController.BGSpeaker.PlayOneShot(soundController.introSound);
        }

      
     
        private void Update()
        {
            print($"Enemy Current State: {enemy?.currentState}");
        }
      
        public void JustLoadAScene()
        {
            SceneManager.LoadScene(arbitraryNameScene);
        }

        public void StartGame()
        {
            LoadScene(0);
            uiController.gameStart.SetActive(false);
            soundController.PlayBGSound(level);
        }
      
        public void Resume()
        {
           // LoadPlayerData();
            Time.timeScale = 1;
        }

        public void ReStart()
        {
            //TODO: tắt 2 cái trước rồi mới load
            uiController.DelayImage.gameObject.SetActive(true);
            uiController.gameEnd.SetActive(false);
            LoadPlayerData();
            LoadScene(level);
        }
        public void LoadLevel()
        {
            level++;
            LoadScene(level);
            soundController.PlayBGSound(level);
            SavePlayerData();
        }
        public void LoadScene(int level)
        {
            StartCoroutine(uiController.OpenDelayScene());
            SceneManager.LoadScene("level"+ level);
        }
        
        void SavePlayerData()
        {
            PlayerPrefs.SetInt("Level", level);
            
                string json = JsonUtility.ToJson(diePoint);
                PlayerPrefs.SetString("DiePoint", json);
            
            PlayerPrefs.Save(); 
        }

        void LoadPlayerData()
        {
            string json = PlayerPrefs.GetString("TransformData");
            if (!string.IsNullOrEmpty(json))
            // {
            //     diePoint = JsonUtility.FromJson<Vector3>(json);
            // }
                diePoint = JsonUtility.FromJson<Vector3>(json);
            print("load position");
            if (PlayerPrefs.HasKey("Level"))
            {
                level = PlayerPrefs.GetInt("Level");
            }
        }

        void OnDestroy()
        {
            SavePlayerData();
        }
        public void EndGame()
        {
            Time.timeScale = 0;
            SavePlayerData();
            uiController.OpenEndGame();
        }

        public void Pause()
        {
            Time.timeScale = 0;
            uiController.OpenPause();
        }

        
    }
}