using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static battlesimulatorOrtiz.Battle;

namespace battlesimulatorOrtiz
{

    // This form lets the player select a character before starting the battle
    public partial class SelectForm : Form
    {
        int charSelected = 0;
        public SelectForm()
        {
            InitializeComponent();
        }

        private void PBOrtiz_Click(object sender, EventArgs e)   // Event triggered when the player clicks on the Ortiz picture
        {
            charSelected = 2;   // 2 represents Ortiz
            CharChanged(); // Update UI to reflect the selected character
        }

        private void PBChristian_Click(object sender, EventArgs e)   // Event triggered when the player clicks on the Christian picture
        {
            charSelected = 3; // 3 represents Christian
            CharChanged(); // Update UI reflect the selected character
        }

        private void PBBulbasaur_Click(object sender, EventArgs e)   // Event triggered when the player clicks on the Bulbasaur picture
        {
            charSelected = 1; // 1 represents Bulbasaur
            CharChanged(); // Update UI to reflect the selected character
        }

        void CharChanged()  // Method to update the appearance of character selections
        {
            if (charSelected == 1)   // If Bulbasaur is selected
            {
                // Highlight Bulbasaur
                PBOrtiz.BackColor = Color.LightBlue;
                PBChristian.BackColor = Color.White;
                PBBulbasaur.BackColor = Color.White;
                PBOrtiz.BorderStyle = BorderStyle.Fixed3D;
                PBChristian.BorderStyle = BorderStyle.FixedSingle;
                PBBulbasaur.BorderStyle = BorderStyle.FixedSingle;
            } 
            else if (charSelected == 2) // If Ortiz is selected
            {
                // Highlight Ortiz
                PBChristian.BackColor = Color.LightBlue;
                PBOrtiz.BackColor = Color.White;
                PBBulbasaur.BackColor = Color.White;
                PBChristian.BorderStyle = BorderStyle.Fixed3D;
                PBOrtiz.BorderStyle = BorderStyle.FixedSingle;
                PBBulbasaur.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (charSelected == 3) // If Christian is selected
            {
                // Highlight Christian
                PBBulbasaur.BackColor = Color.LightBlue;
                PBOrtiz.BackColor = Color.White;
                PBChristian.BackColor = Color.White;
                PBBulbasaur.BorderStyle = BorderStyle.Fixed3D;
                PBOrtiz.BorderStyle = BorderStyle.FixedSingle;
                PBChristian.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void btnStartBattle_Click(object sender, EventArgs e)  // Called when the "Start Battle" button is clicked
        {
            if (charSelected == 0)   // If no character has been selected
            {
                MessageBox.Show("Please Choose Your Character Before Starting The Battle", "Choose A Character");
            } else
            {
                Battle battle = new Battle(charSelected); // Start the battle by opening the Battle form and passing the selected character
                this.Hide();    // Hide the selection form
                battle.Show(); // Show the battle form
            }
        }

        private void SelectForm_Load(object sender, EventArgs e)   // Form load event (not used in this version but can be used for setup)
        {

        }
    }
}
