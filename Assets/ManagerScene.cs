using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ManagerScene : MonoBehaviour
{
    public Animator trans;

    public void BackToMenu() => StartCoroutine(LoadLevelNext(0));
    public void GoToGame() => StartCoroutine(LoadLevelNext(2));
    public void GoToGame1() => StartCoroutine(LoadLevelNext(1));
    public void ExitToGame() => Application.Quit();

    IEnumerator LoadLevelNext(int levelIndex)
    {
        trans.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
}
