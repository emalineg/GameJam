using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
// just adding something to commmit lol
public class DarkSceneDialogue : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.04f;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private List<string> dialogueLines = new List<string>();
    private int currentLine = 0;
    private bool isTyping = false;

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private Inventory inventory;

    private void Start()
    {
        dialogueBox.SetActive(false);

        dialogueLines.Add("This is the first line of dialogue.");
        dialogueLines.Add("This is the second line of dialogue.");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Inventory.memories == 1)
        {
            dialogueBox.SetActive(true);
            StartCoroutine(TypeText(dialogueLines[currentLine]));
        }
    }

    private IEnumerator TypeText(string text)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    public void NextLine()
    {
        if (!isTyping)
        {
            currentLine++;
            if (currentLine < dialogueLines.Count)
            {
                StartCoroutine(TypeText(dialogueLines[currentLine]));
            }
            else
            {
                dialogueBox.SetActive(false);
            }
        }
    }
}
