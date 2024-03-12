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
        public int level = 1;
        private string sceneNameToLoad = "level";
        public string arbitraryNameScene ;
        public Transform diePoint  ;
        
        
        private void Awake()
        {
            uiController = FindObjectOfType<UI_Controller>();
            soundController = FindObjectOfType<SoundController>();
            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            
            uiController.OpenStartGame();
            soundController.PlayBGSound();

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
            LoadScene(1);
            Invoke("DelayHideStart",0.3f);
        }

        void DelayHideStart()
        {
           uiController.gameStart.SetActive(false);
        }
        
        public void Resume()
        {
           // LoadPlayerData();
            Time.timeScale = 1;
        }

        public void ReStart()
        {
            LoadPlayerData();
            LoadScene(level);
        }
        public void LoadLevel()
        {
            LoadScene(level);
            SavePlayerData();
            level++;
        }
        public void LoadScene(int level)
        {
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
            {
                diePoint = JsonUtility.FromJson<Transform>(json);
            }
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