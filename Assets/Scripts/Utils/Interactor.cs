using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}
public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    public GameObject player;
    [SerializeField] GameObject chessUIWhite; // Reference to the Game UI
    [SerializeField] GameObject chessUIBlack; // Reference to the Game UI
    public GameObject Light1;
    public GameObject Light2;
    public GameObject Theme;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            player.SetActive(false);
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
            Light1.SetActive(false);
            Light2.SetActive(true);
            Theme.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
   }
}
