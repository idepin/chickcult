using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] private DialogueData testDialogues;
    [SerializeField] private GameObject pressToInteract;

    private void Start()
    {
        //StartDialogue(testDialogues);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pressToInteract.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pressToInteract.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && pressToInteract.activeSelf)
        {
            StartDialogue(testDialogues);
            pressToInteract.SetActive(false);
        }
    }

    public void StartDialogue(DialogueData dialogueData)
    {
        if (dialogueUI != null)
        {
            dialogueUI.StartDialogue(dialogueData);
        }
    }
}
