using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace FiroozehGameServiceAndroid.Helpers
{
    [RequireComponent (typeof(CanvasGroup))]
    public class DialogUtil : MonoBehaviour
    {
        private static DialogUtil instance;

        private Text title;
        private Text message;
        private Text accept, decline;
        private Button acceptButton, declineButton;

        CanvasGroup _cg;
       

        void Awake(){
      
            _cg = GetComponent<CanvasGroup>();
        }

        public DialogUtil OnAccept(string text, UnityAction action){
            accept.text = text;
            acceptButton.onClick.RemoveAllListeners();
            acceptButton.onClick.AddListener(action);
            return this;
        }



        public DialogUtil OnDecline(string text, UnityAction action){
            decline.text = text;
            declineButton.onClick.RemoveAllListeners();
            declineButton.onClick.AddListener(action);
            return this;
        }

        public DialogUtil Title(string title){
            this.title.text = title;
            return this;
        }

        public DialogUtil Message(string message){
            this.message.text = message;
            return this;
        }

        // show the dialog, set it's canvasGroup.alpha to 1f or tween like here
        public void Show()
        {
            _cg.alpha = 1;
            _cg.blocksRaycasts = true;
            _cg.interactable = true;
        }

        public void Hide(){
            _cg.alpha = 0;
            _cg.blocksRaycasts = false;
            _cg.interactable = false;
        }

        
        public static DialogUtil Instance() {
            if (instance) return instance;
            instance = FindObjectOfType(typeof (DialogUtil)) as DialogUtil;
            if(!instance)
                Debug.Log("There need to be at least one active DialogUtil on the scene");

            return instance;
        }

        
    }
}
