using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;
    public DialogManager Box;

    public void StartDialog()
    {
        Box.OpenDialogue(messages, actors);
    }

    public void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Box.OpenDialogue(messages, actors);
        }
    }
}

[System.Serializable]
public class Message {
    public int actorId;
    public string message;
}

[System.Serializable]
public class Actor {
    public string name;
    public Sprite sprite;
}
