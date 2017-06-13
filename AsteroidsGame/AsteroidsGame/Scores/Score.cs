namespace AsteroidsGame.Scores
{
    public class Score
    {
        /// <summary>
        /// score variable to show missing shot on our apllication form.
        /// CAN'T AND MUSTN'T BE ACCESSED OUTSIDE THIS CLASS DIRECTLY!
        /// </summary>
        private int score;

        /// <summary>
        /// Sets score variable to the value you want.
        /// </summary>
        public Score(int shot)
        {
            this.score = shot;
        }

        /// <summary>
        /// Property which allows you to get and set the score variable outside of this class.
        /// </summary>
        public int ScoreDeeclareton
        {
            get { return this.score; }
            set { this.score = value; }
        }
    }
}
