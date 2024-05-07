using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class PauseMenu : MonoBehaviour
{
   [SerializeField] GameObject pauseMenu;
   [SerializeField] Button resumeButton;
   [SerializeField] Button muteButton;
   [SerializeField] Button chessButton;
   [SerializeField] Button startButton;
   [SerializeField] GameObject gameUI; // Reference to the Game UI
   [SerializeField] GameObject chessUIWhite; // Reference to the Game UI
   [SerializeField] GameObject chessUIBlack; // Reference to the Game UI
   [SerializeField] GameObject chessLight; // Reference to the Game UI
   [SerializeField] GameObject startLight; // Reference to the Game UI
   [SerializeField] GameObject theme; // Reference to the Game UI
    private bool isPaused = false;
   private bool isMuted = false;

   void Start()
   {
      resumeButton.onClick.AddListener(ResumeGame);
      muteButton.onClick.AddListener(ToggleMute);
      chessButton.onClick.AddListener(ResumeChess);
      startButton.onClick.AddListener(ResumeStart);
      pauseMenu.SetActive(false); // Start hidden
   }

   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
         pauseMenu.SetActive(!pauseMenu.activeSelf);
         isPaused = !isPaused;
         if (isPaused)
         {
           UnlockCursor();
         }
         else
         {
           if (gameUI.activeSelf)
           {
             LockCursor();
           }
         }
      }
   }

   void ResumeGame()
   {
      Time.timeScale = 1;
      pauseMenu.SetActive(false);
      LockCursor(); // Hide the cursor when resuming
      isPaused = false;
   }

    void ResumeStart()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        gameUI.SetActive(true); // Re-enable the game UI
        theme.SetActive(true);
        startLight.SetActive(true);
        chessLight.SetActive(false);
        LockCursor(); // Hide the cursor when resuming
        isPaused = false;
    }

    void ResumeChess()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        startLight.SetActive(false);
        chessLight.SetActive(true);
        if (chessUIWhite.activeSelf || !chessUIBlack.activeSelf)
        {
            chessUIWhite.SetActive(false);
            chessUIWhite.SetActive(true);
        }
        else
        {
            chessUIBlack.SetActive(false);
            chessUIBlack.SetActive(true);
        }
        gameUI.SetActive(false); // Re-enable the game UI
        theme.SetActive(false);
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
