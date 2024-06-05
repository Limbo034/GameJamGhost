using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{ 
    public class DialogHolder : MonoBehaviour
    {
        public ManagerScene LevelNext;
        private void Awake()
        {
            Deactivate();
            Invoke(nameof(Starting), 2f);
        }

        void Starting()
        {
            StartCoroutine(dialogSeq());
        }

        protected IEnumerator dialogSeq()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Deactivate();
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finish);
            }

            yield return new WaitForSeconds(0.1f);
            LevelNext.GoToGame1();
        }

        private void Deactivate()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
