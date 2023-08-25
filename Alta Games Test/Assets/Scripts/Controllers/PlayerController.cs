namespace Controllers
{
    public class PlayerController
    {
        private float playerScore;

        public float PlayerScore {
            get
            {
                return playerScore;
            }
        }

        public PlayerController(int score)
        {
            playerScore = score;
        }
        
        public void GetPowerForBullet(float power)
        {
            playerScore -= power;
        }
    }
}