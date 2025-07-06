using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI characterNameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private float typingSpeed = 0.05f;

    private bool isTyping = false;
    private bool skipTyping = false;
    private int currentDialogueIndex = 0;
    private DialogueData currentDialogueData;
    private Coroutine typingCoroutine;

    void Start()
    {
        gameObject.SetActive(false); // Hide dialogue UI initially
    }

    public void StartDialogue(DialogueData dialogueData)
    {
        if (dialogueData == null || dialogueData.Dialogue.Length == 0)
        {
            Debug.LogWarning("Dialogue data is empty or null.");
            return;
        }

        PlayerController.Instance.AllowMovement = false; // Disable player movement during dialogue

        gameObject.SetActive(true);
        characterNameText.text = dialogueData.CharacterName;
        currentDialogueData = dialogueData;
        currentDialogueIndex = 0;

        StartTyping();
    }

    private void Update()
    {
        // Check for space key or any input to skip/continue dialogue
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            HandleDialogueInput();
        }
    }

    public void HandleDialogueInput()
    {
        if (isTyping)
        {
            // Skip typing animation and show full text immediately
            skipTyping = true;
        }
        else
        {
            // Move to next dialogue or close dialogue
            NextDialogue();
        }
    }

    private void StartTyping()
    {
        if (currentDialogueIndex < currentDialogueData.Dialogue.Length)
        {
            string currentText = currentDialogueData.Dialogue[currentDialogueIndex];
            typingCoroutine = StartCoroutine(TypingEffect(currentText));
        }
        else
        {
            EndDialogue();
        }
    }

    private void NextDialogue()
    {
        currentDialogueIndex++;
        if (currentDialogueIndex < currentDialogueData.Dialogue.Length)
        {
            StartTyping();
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        gameObject.SetActive(false);
        currentDialogueData = null;
        currentDialogueIndex = 0;
        PlayerController.Instance.AllowMovement = true; // Allow player movement again
    }

    IEnumerator TypingEffect(string text)
    {
        isTyping = true;
        skipTyping = false;
        dialogueText.text = "";

        for (int i = 0; i < text.Length; i++)
        {
            if (skipTyping)
            {
                // Show full text immediately when skipping
                dialogueText.text = text;
                break;
            }

            dialogueText.text += text[i];
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        skipTyping = false;
    }

    // Public method that can be called from buttons or other scripts
    public void SkipOrContinue()
    {
        HandleDialogueInput();
    }
}
