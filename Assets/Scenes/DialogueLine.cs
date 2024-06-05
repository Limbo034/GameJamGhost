using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DialogSystem
{
    public class DialogueLine : TextType
    {
        public TextMeshProUGUI textHolder;
        [SerializeField] private string line;

        [SerializeField] private float delay;

        [SerializeField] private float delayBetweenLines;

        public GameObject Mouse;

        private void Start()
        {
            StartCoroutine(DisplayLine(line, textHolder, delay, delayBetweenLines, Mouse));
        }
    }   
}
