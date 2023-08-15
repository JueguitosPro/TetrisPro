using UnityEngine;
using UnityEngine.UI;

namespace JueguitosPro.Views
{
    public class LoginView : MonoBehaviour
    {
        [SerializeField] private Button googleLogin;

        private void Start()
        {
            googleLogin.onClick.AddListener(OnClickGoogleLogin);
        }

        private void OnClickGoogleLogin()
        {
            
        }
    }
}

