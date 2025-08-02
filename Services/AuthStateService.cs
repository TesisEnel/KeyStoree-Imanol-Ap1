namespace KeyStore.Services
{
    public class AuthStateService
    {
        public event Action? OnAuthStateChanged;

        public void NotifyAuthStateChanged()
        {
            OnAuthStateChanged?.Invoke();
        }
    }
}