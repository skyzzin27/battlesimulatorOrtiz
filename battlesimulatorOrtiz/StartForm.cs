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
    public partial class StartForm : Form    // This form is the entry point of the game (Main Menu)
    {
        public StartForm()  // Constructor, Initializes the StartForm UI components
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)   // Event handler for the "Start" button
        {
            SelectForm select = new SelectForm();  // When clicked, it opens the character selection form
            this.Hide();    // Hide the current StartForm
            select.Show(); // Show the SelectForm
        }

        private void BtnExit_Click(object sender, EventArgs e)   // Event handler for the "Exit" button
        {
            this.Close(); // Closes the current form (exits the application if no other forms are open)
        }
    }
}
