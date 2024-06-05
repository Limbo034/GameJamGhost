using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backGroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;

    public GameObject buttonBack;

    public AudioSource door;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        DisplayMessage();
        backGroundBox.LeanScale(new Vector3(1f, 1f, 1f), 0.5f).setEaseInOutExpo();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
            if (activeMessage == currentMessages.Length - 1)
            {
                door = GetComponent<AudioSource>();
                door.Play();
            }
        }

        else
        {
            backGroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            buttonBack.SetActive(true);
        }
    }

    void Start()
    {
        backGroundBox.transform.localScale = Vector3.zero;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextMessage();
        }
    }
}
