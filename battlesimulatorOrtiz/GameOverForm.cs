using System;
using System.Windows.Forms;

namespace battlesimulatorOrtiz
{
    // This form is shown when the game ends (either win or lose)
    public partial class GameOverForm : Form
    {
        // Property used to track whether the "Play Again" button was clicked
        public bool PlayAgainClicked { get; private set; }

       // Constructor for GameOverForm - accepts a message to display( "You Win!" or "Game Over")
        public GameOverForm(string message)
        {
            InitializeComponent();
            lblMessage.Text = message;   // Set the message label to display the game result

            // Attach event handlers to buttons
            btnPlayAgain.Click += btnPlayAgain_Click;
            btnExit.Click += btnExit_Click;
        }

        // Sets PlayAgainClicked to true and closes the form
        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            PlayAgainClicked = true;
            this.Close();
        }

        // Closes the entire application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

