namespace Singleton
{
    using System;

    public sealed class Authenticator
    {
        private static Authenticator? _instance;
        private static object _lock = new object();
        private string? _currentLogin;
        private bool _isAuthenticated;

        public bool IsAuthenticated => _isAuthenticated;
        public string? Login => _currentLogin;

        private Authenticator()
        {
            Console.WriteLine("Initialize Authenticator");
        }

        public static Authenticator GetInstance()
        {
            if (_instance is null)
            {
                lock (_lock)
                {
                    if (_instance is null)
                    {
                        _instance = new Authenticator();
                    }
                }
            }
            return _instance;
        }

        public bool Authenticate(string login, string password)
        {
            // hardcoded authentication check example
            if (login != "admin" || password != "password")
            {
                return false;
            }
            _currentLogin = login;
            _isAuthenticated = true;
            return true;
        }

        public bool Logout()
        {
            _currentLogin = null;
            _isAuthenticated = false;
            return true;
        }
    }

}
