using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace DialogSystem
{
    public class CutSceneTirgger : MonoBehaviour
    {
        public bool finish {get; private set; }

        public PlayableDirector timeline;

        void Start()
        {
            Invoke(nameof(Plays), 0.2f);
        }

        void Plays()
        {
            finish = true;
            timeline.gameObject.SetActive(true);
            timeline.Play();
        }
    }   
}
