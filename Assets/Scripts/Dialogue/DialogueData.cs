using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue/Dialogue Data")]
public class DialogueData : ScriptableObject
{
    [SerializeField] private string characterName;
    [SerializeField][TextArea(3, 10)] private string[] dialogue;

    public string CharacterName
    {
        get { return characterName; }
        set { characterName = value; }
    }

    public string[] Dialogue
    {
        get { return dialogue; }
        set { dialogue = value; }
    }
}