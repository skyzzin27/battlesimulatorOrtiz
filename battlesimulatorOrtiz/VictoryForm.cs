using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battlesimulatorOrtiz
{
    public partial class VictoryForm : Form   // This form is shown when the player wins the battle
    {
        public VictoryForm(string message)  // Constructor: accepts a string message to display ("You Win!")
        {
            InitializeComponent();
            lblVictoryMessage.Text = message;   // Set the victory label to show the win message
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)   // Event handler for the "Play Again" button
        {
            btnPlayAgain.Enabled = false;  // Prevent multiple clicks by disabling the button
            this.Hide();  // Hide the victory form
            SelectForm selectForm = new SelectForm(); // Open the SelectForm so the player can pick a character again
            selectForm.FormClosed += (s, args) => this.Close(); // When SelectForm is closed, also close this form to clean up
            selectForm.Show(); // Show the SelectForm
        }

        private void btnExit_Click(object sender, EventArgs e) // Event handler for the "Exit" button
        {
            Application.Exit(); // Exit the entire application
        }

        private void lblVictoryMessage_Click(object sender, EventArgs e)  // This method exists for potential label click interaction (not currently used)
        {

        }
    }
}
