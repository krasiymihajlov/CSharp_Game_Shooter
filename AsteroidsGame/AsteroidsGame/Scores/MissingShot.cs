using System.Windows.Forms;

namespace AsteroidsGame.Scores
{
    public class MissingShot : AsteroidsForm
    {
        /// <summary>
        /// Missing shot variable to show missing shot on our apllication form.
        /// </summary>
        public static int missingShots = 0;
        
        /// <summary>
        /// Property which allows you to get and set the missing shot variable outside of this class.
        /// </summary>
        public static int MissingShots1
        {
            get => missingShots;
            set => missingShots = value;
        }

        public MissingShot()
        {
            
        }

        //public void MissShot()
        //{
        //    missingShots++;
        //    label2.Text = "Missing Shots = " + missingShots;
        //    totalShots++;
        //    label1.Text = "Total Shots = " + totalShots;
        //}
    }
}
