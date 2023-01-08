namespace UI
{
    public class TimeScore
    {
        private float time_score;

        public TimeScore(float timeScore)
        {
            time_score = timeScore;
        }

        public float GetTimeScore()
        {
            return time_score;
        }
        
        public void SetTimeScore(float newTime)
        {
            time_score= newTime;
        }

        public string GetString()
        {
            int hrs = 00 ;
            int min = (int)time_score / 60;
            float sec = time_score % 60;

            if (min >= 60)
            {
                hrs = min / 60; 
                min %= 60;
            }

            return hrs + ":" + min + ":" + sec.ToString("f2");
        }
    }
}