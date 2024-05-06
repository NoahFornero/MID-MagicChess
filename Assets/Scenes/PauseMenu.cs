using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class PauseMenu : MonoBehaviour
{
   [SerializeField] GameObject pauseMenu;
   [SerializeField] Button resumeButton;
   [SerializeField] Button muteButton;
   [SerializeField] GameObject gameUI; // Reference to the Game UI

   private bool isPaused = false;
   private bool isMuted = false;

   void Start()
   {
      resumeButton.onClick.AddListener(ResumeGame);
      muteButton.onClick.AddListener(ToggleMute);
      pauseMenu.SetActive(false); // Start hidden
      UnlockCursor(); // Unlock cursor at the start
   }

   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
         if (isPaused)
         {
            ResumeGame();
         }
         else
         {
            PauseGame();
         }
      }
   }

   void PauseGame()
   {
      Time.timeScale = 0;
      pauseMenu.SetActive(true);
      gameUI.SetActive(false); // Disable the game UI
      UnlockCursor(); // Show the cursor when paused
      isPaused = true;
   }

   void ResumeGame()
   {
      Time.timeScale = 1;
      pauseMenu.SetActive(false);
      gameUI.SetActive(true); // Re-enable the game UI
      LockCursor(); // Hide the cursor when resuming
      isPaused = false;
   }

   void LockCursor()
   {
      Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
      Cursor.visible = false; // Hide the cursor
   }

   void UnlockCursor()
   {
      Cursor.lockState = CursorLockMode.None; // Unlock the cursor
      Cursor.visible = true; // Show the cursor
   }

   void ToggleMute()
   {
      isMuted = !isMuted; // Toggle mute state
      AudioListener.volume = isMuted ? 0 : 1; // Mute or unmute audio
      muteButton.GetComponentInChildren<UnityEngine.UI.Text>().text = isMuted ? "Unmute" : "Mute";

   }
}
