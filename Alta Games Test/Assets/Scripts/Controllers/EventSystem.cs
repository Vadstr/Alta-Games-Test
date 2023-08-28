namespace Controllers
{
    public class EventSystem
    {
        public delegate void Anigilation();
        public delegate void LoseGame();
        public delegate void StartGame();
        public delegate void WinGame();
        public delegate void CheckTrees();
        
        public static event Anigilation AnigilateEvent;
        public static event StartGame StartGameEvent;
        public static event LoseGame LoseGameEvent;
        public static event WinGame WinGameEvent;
        public static event CheckTrees CheckTreesEvent;

        
        
        public static void InvokeAnigilate()
        {
            AnigilateEvent.Invoke();
        }
        public static void InvokeLoseGame()
        {
            LoseGameEvent.Invoke();
        }
        public static void InvokeWinGame()
        {
            WinGameEvent.Invoke();
        }
        public static void InvokeCheckTree()
        {
            CheckTreesEvent.Invoke();
        }
        public static void InvokeStartGame()
        {
            StartGameEvent.Invoke();
        }
    }
}