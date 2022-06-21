using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Universal")]
    [SerializeField] private float duration;
    [SerializeField] private GameObject anim;
    [SerializeField] private bool isGame;
    private Animator animator;
    

    [Header("Private For Game Scene")]
    [SerializeField] private GameObject panelEndGame;
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelStart;
    [SerializeField] private TMPro.TMP_Text playerWinningText;


    private void Awake()
    {
        animator = anim.GetComponent<Animator>();    
    }

    private void Update()
    {
        if (!Data.isEndForPlayer1 && !Data.isEndForPlayer2 && !Data.isEndForPlayer3 && isGame) {
            playerWinningText.text = "Player 4, Won \n Tapi jangan bangga!!";
            StartCoroutine(EndGame());
        } else if (!Data.isEndForPlayer1 && !Data.isEndForPlayer2 && !Data.isEndForPlayer4 && isGame) {
            playerWinningText.text = "Player 3, Won \n Tapi jangan bangga!!";
            StartCoroutine(EndGame());
        } else if (!Data.isEndForPlayer1 && !Data.isEndForPlayer3 && !Data.isEndForPlayer4 && isGame) {
            playerWinningText.text = "Player 2, Won \n Tapi jangan bangga!!";
            StartCoroutine(EndGame());
        } else if (!Data.isEndForPlayer2 && !Data.isEndForPlayer3 && !Data.isEndForPlayer4 && isGame) {
            playerWinningText.text = "Player 1, Won \n Tapi jangan bangga!!";
            StartCoroutine(EndGame());
        }

        PauseGame();
    }

    IEnumerator EndGame()
    {
        Data.isWin = true;
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        Destroy(ball);

        yield return new WaitForSeconds(1.5f);

        panelEndGame.SetActive(true);
    }

    public void PauseGame()
    {
        if(Input.GetKey(KeyCode.P) && isGame && !Data.isWin)
        {
            Time.timeScale = 0;
            panelPause.SetActive(true);
        }
    }

    public void ClosePausePanel()
    {
        panelPause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Game()
    {
        StartCoroutine(Transition("Game"));

        Data.scorePlayer1 = 0;
        Data.scorePlayer2 = 0;
        Data.scorePlayer3 = 0;
        Data.scorePlayer4 = 0;

        Data.isEndForPlayer1 = true;
        Data.isEndForPlayer2 = true;
        Data.isEndForPlayer3 = true;
        Data.isEndForPlayer4 = true;

        Data.isWin = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    { 
        Data.scorePlayer1 = 0;
        Data.scorePlayer2 = 0;
        Data.scorePlayer3 = 0;
        Data.scorePlayer4 = 0;

        Data.isEndForPlayer1 = true;
        Data.isEndForPlayer2 = true;
        Data.isEndForPlayer3 = true;
        Data.isEndForPlayer4 = true;

        Data.isWin = false;

        panelStart.SetActive(false);
    }

    public void nextScene(string sceneName)
    {
        StartCoroutine(Transition(sceneName));
        Time.timeScale = 1;
    }

    IEnumerator Transition(string sceneName)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(duration);

        SceneManager.LoadScene(sceneName);
    }
}
