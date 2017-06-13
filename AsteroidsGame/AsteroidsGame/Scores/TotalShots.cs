namespace AsteroidsGame.Scores
{
    public class TotalShots
    {
        /// <summary>
        /// total score variable to show missing shot on our apllication form.
        /// CAN'T AND MUSTN'T BE ACCESSED OUTSIDE THIS CLASS DIRECTLY!
        /// </summary>
        private int totalShot;

        /// <summary>
        /// Sets total score variable to the value you want.
        /// </summary>
        public TotalShots(int shot)
        {
            this.totalShot = shot;
        }

        /// <summary>
        /// Property which allows you to get and set the total score variable outside of this class.
        /// </summary>
        public int Total
        {
            get { return this.totalShot; }
            set { this.totalShot = value; }
        }
    }
}
