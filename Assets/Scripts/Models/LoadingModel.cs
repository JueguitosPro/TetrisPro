using System;

namespace JueguitosPro.Models
{
    public class LoadingModel : ModelBase
    {
        public event Action onSuccess;
        public event Action<string> onFailure;
        public void LoginWithGoogle()
        {
            PlayfabWrapper.LoginWithGoogle(result =>
            {
                onSuccess?.Invoke();
            }, error =>
            {
                onFailure?.Invoke(error);
            });
        }
    }
}
