using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DialogSystem
{
    public class TextType : MonoBehaviour
    {
        public bool finish {get; private set; }
        public IEnumerator DisplayLine(string line, TextMeshProUGUI dialogueText, float delay, float delayBetweenLines, GameObject Mouse)
        {
            foreach (char letter in line.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(delay);
            }
            Mouse.SetActive(true);
            yield return new WaitUntil(() => Input.GetMouseButton(0));
            Mouse.SetActive(false);
            finish = true;
        }
    }   
}
