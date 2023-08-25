using UnityEditor.Timeline.Actions;

namespace Controllers
{
    public class EventSystem
    {
        public delegate void Anigilation();
        public static event Anigilation Anigilate;

        public static void InvokeAnigilate()
        {
            Anigilate.Invoke();
        }
    }
}