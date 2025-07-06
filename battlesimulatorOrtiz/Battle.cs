using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battlesimulatorOrtiz
{
    public partial class Battle : Form 
    {
        // Declare animation and UI control timers and variables
        private Timer bounceTimerPlayer = new Timer(); // Used to animate bounce effect for player
        private int bounceStepPlayer = 0;

        private Timer bounceTimer = new Timer();      // Used to animate bounce effect for enemy
        private int bounceStep = 0;

        private int baseFontSize = 24;
        private Timer playerShakeTimer = new Timer();       // Used for player shake animation
        private Timer playerDamageTextTimer = new Timer(); // Used for moving damage text
        private int playerDamageTextStep = 0;
        private int playerShakeCount = 0;
        private int originalPlayerX;

        private Timer flashTimerPlayer; // Used to flash player after hit
        private int flashCountPlayer = 0;
        private bool isPlayerVisible = true;
        bool lastHitWasCritical = false;

        Timer enemyShakeTimer = new Timer(); // Enemy shake effect
        int shakeStep = 0;
        int originalEnemyX;
        int flashCount = 0;
        int charSelected;
        bool defending = false;
        bool battleEnded = false;   
        int targetPlayerHP;
        int targetEnemyHP;

        // Object-Oriented Design: Using class objects to represent characters
        character player;
        character enemy;

        // Defined character presets
        character bulbasaur = new character("Bulbasaur", "Grass", 1, 30, 30, "Vine Whip", "Razor Leaf");
        character ortiz = new character("Ortiz", "Lightning", 2, 35, 25, "Lightning Gun", "Lightning Pulse");
        character christian = new character("Christian", "Fire", 3, 20, 40, "Fire Spin", "Fireball");

        private void FlashTimer_Tick(object sender, EventArgs e)  // Flash timer to animate enemy when taking damage
        {
            flashCount++;

            // Move label upward to simulate damage effect
            lblDamageEffect.Top -= 5;   // Animate damage label upward

            if (flashCount >= 10)
            {
                flashTimer.Stop();
                lblDamageEffect.Visible = false;
                flashCount = 0;
            }
        }

        public Battle(int choice)   // Constructor receives player choice from SelectForm
        {
            InitializeComponent();

            // Setup timers and event handlers
            playerShakeTimer.Interval = 30;
            playerShakeTimer.Tick += PlayerShakeTimer_Tick;
            charSelected = choice;
            flashTimerPlayer = new Timer();
            flashTimerPlayer.Interval = 100;
            flashTimerPlayer.Tick += FlashTimerPlayer_Tick;
            playerDamageTextTimer.Interval = 50;
            playerDamageTextTimer.Tick += PlayerDamageTextTimer_Tick;          
            bounceTimer.Interval = 50;
            bounceTimerPlayer.Interval = 50;
            bounceTimer.Tick += BounceTimer_Tick;
            this.Load += Battle_Load;

            enemyShakeTimer.Interval = 30;
            enemyShakeTimer.Tick += EnemyShakeTimer_Tick;

        }

        // Load player and enemy depending on selected character
        private void Battle_Load(object sender, EventArgs e) 
        {

            if (charSelected == ortiz.charNum)
            {
                player = ortiz;
                enemy = christian;
                PBPlayer.Image = Properties.Resources.Ortiz;
                PBEnemy.Image = Properties.Resources.Christian;
            }
            else if (charSelected == christian.charNum)
            {
                player = christian;
                enemy = ortiz;
                PBPlayer.Image = Properties.Resources.Christian;
                PBEnemy.Image = Properties.Resources.Ortiz;
            }
            else if (charSelected == bulbasaur.charNum)
            {
                player = bulbasaur;
                enemy = ortiz;
                PBPlayer.Image = Properties.Resources.Bulbasaur;
                PBEnemy.Image = Properties.Resources.Ortiz;
            }

            // Display names and moves
            lblPlayerName.Text = "Player: " + player.name;
            lblEnemyName.Text = "Enemy: " + enemy.name;
            BtnAttack1.Text = player.move1;
            BtnAttack2.Text = player.move2;

            ProgBarPlayer.Value = Convert.ToInt32(player.hp);

            ProgBarEnemy.Value = Convert.ToInt32(enemy.hp);

        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void BtnAttack2_Click(object sender, EventArgs e) // Attack 2 logic
        {
            // Info and damage
            LblInfo.Text = player.name + " used " + player.move2;
            bool isCritical;
            string result = enemy.takeDamage(20, 11, player.atk, player.type, out isCritical);
            lastHitWasCritical = isCritical;
            LblInfo.Text += result;

            string[] lines = result.Split('\n');
            string lastLine = lines.Last().Trim();

            if (!lastLine.Contains("Miss"))
            {
                // Show damage animation
                lblDamageEffect.Text = result.Split('\n').Last();
                lblDamageEffect.Location = new Point(PBEnemy.Location.X + PBEnemy.Width / 2, PBEnemy.Location.Y);
                lblDamageEffect.Visible = true;
                bounceStep = 0;
                lblDamageEffect.Font = new Font("Arial", baseFontSize, FontStyle.Bold);
                bounceTimer.Start();
                lblDamageEffect.Font = new Font("Arial", 24, FontStyle.Bold);

                if (lastHitWasCritical)
                {
                    lblDamageEffect.ForeColor = Color.Gold;
                    lblDamageEffect.BackColor = Color.Black;
                    lblDamageEffect.Font = new Font("Arial", baseFontSize + 4, FontStyle.Bold);
                }
                else
                {
                    lblDamageEffect.ForeColor = Color.Red;
                    lblDamageEffect.BackColor = Color.Transparent;
                    lblDamageEffect.Font = new Font("Arial", baseFontSize, FontStyle.Bold);
                }

                originalEnemyX = PBEnemy.Left;
                enemyShakeTimer.Start();
                flashTimer.Start();
            }

            if (enemy.hp > 0)
            {
                targetEnemyHP = Convert.ToInt32(enemy.hp);
                TimerEnemyHP.Start();
            }
            else
            {
                if (battleEnded) return;
                battleEnded = true;

                enemy.hp = 0;
                ProgBarEnemy.Value = 0;
                VictoryForm victoryForm = new VictoryForm("Player Win!");
                this.Hide(); // hides current form (game/battle form)
                victoryForm.FormClosed += (s, args) => this.Close(); // closes game form after victory
                victoryForm.Show();
                this.Close();
            }
            // Disable buttons until enemy attack finishes
            TimerEnAtk.Enabled = true;
            BtnAttack1.Enabled = false;
            BtnAttack2.Enabled = false;
            BtnDefend.Enabled = false;
        }

        private void PBPlayer_Click(object sender, EventArgs e)
        {

        }

        // Attack 1 logic
        private void BtnAttack1_Click(object sender, EventArgs e)
        {
            LblInfo.Text = player.name + " used " + player.move1;
            bool isCritical;
            string result = enemy.takeDamage(10, 5, player.atk, player.type, out isCritical);
            lastHitWasCritical = isCritical;

            LblInfo.Text += result;

            string[] lines = result.Split('\n');
            string lastLine = lines.Last().Trim();

            if (!lastLine.Contains("Miss"))
            {
                lblDamageEffect.Text = lastLine;
                lblDamageEffect.Location = new Point(PBEnemy.Location.X + PBEnemy.Width / 2, PBEnemy.Location.Y);
                lblDamageEffect.Visible = true;
                bounceStep = 0;
                lblDamageEffect.Font = new Font("Arial", baseFontSize, FontStyle.Bold);
                bounceTimer.Start();
                originalEnemyX = PBEnemy.Left;
                shakeStep = 0;
                enemyShakeTimer.Start();
                lblDamageEffect.Font = new Font("Arial", 24, FontStyle.Bold);

                if (lastHitWasCritical)
                {
                    lblDamageEffect.ForeColor = Color.Gold;
                    lblDamageEffect.BackColor = Color.Black;
                    lblDamageEffect.Font = new Font("Arial", baseFontSize + 4, FontStyle.Bold);
                }
                else
                {
                    lblDamageEffect.ForeColor = Color.Red;
                    lblDamageEffect.BackColor = Color.Transparent;
                    lblDamageEffect.Font = new Font("Arial", baseFontSize, FontStyle.Bold);
                }

                flashTimer.Start(); //  flashTimerEnemy if that's what you use
            }

            if (enemy.hp > 0)
            {
                targetEnemyHP = Convert.ToInt32(enemy.hp);
                TimerEnemyHP.Start();

            }
            else
            {
                if (battleEnded) return;
                battleEnded = true;

                enemy.hp = 0;
                ProgBarEnemy.Value = 0;

                VictoryForm victoryForm = new VictoryForm("Player Win!");
                this.Hide(); // hides current form (game/battle form)
                victoryForm.FormClosed += (s, args) => this.Close(); // closes game form after victory
                victoryForm.Show();
            }
            TimerEnAtk.Enabled = true;
            BtnAttack1.Enabled = false;
            BtnAttack2.Enabled = false;
            BtnDefend.Enabled = false;
        }

        // Handles enemy's turn
        
        private void TimerEnAtk_Tick(object sender, EventArgs e)
        {
            TimerEnAtk.Enabled = false;   // Disable the timer to avoid multiple triggers

            Random rnd = new Random();  // Create a new random number generator
            int roll = rnd.Next(1, 3); // Randomly choose between 1 and 2

            // Enemy uses move 1
            if (roll == 1)
            {
                LblInfo.Text = enemy.name + " used " + enemy.move1;

                // Check for defend block
                if (defending == true)   // If the player is defending, block the attack
                {
                    LblInfo.Text += Environment.NewLine + " You Blocked It";
                    defending = false; // Reset defending flag
                }
                else
                {
                    // Calculate damage taken by the player
                    bool isCrit;
                    string result = player.takeDamage(10, 5, enemy.atk, enemy.type, out isCrit);                   
                    LblInfo.Text += result;

                    // Display damage text only if the attack didn't miss
                    string[] lines = result.Split('\n');
                    string lastLine = lines.Last().Trim();
                    if (!lastLine.Contains("Miss"))
                    {
                        // Position and format damage label
                        lblPlayerDamageEffect.Text = lastLine;
                        lblPlayerDamageEffect.Location = new Point(PBPlayer.Left + PBPlayer.Width / 2, PBPlayer.Top);
                        lblPlayerDamageEffect.Font = new Font("Arial", 24, FontStyle.Bold);

                        // Change color based on whether it's a critical hit
                        if (isCrit) 
                        {
                            lblPlayerDamageEffect.ForeColor = Color.Gold;
                            lblPlayerDamageEffect.BackColor = Color.Black;
                        }
                        else
                        {
                            lblPlayerDamageEffect.ForeColor = Color.Red;
                            lblPlayerDamageEffect.BackColor = Color.Transparent;
                        }

                        // Show the damage label and start animation
                        lblPlayerDamageEffect.Visible = true;
                        bounceStepPlayer = 0;
                        bounceTimerPlayer.Start();
                        playerDamageTextStep = 0;
                        playerDamageTextTimer.Start();

                        // Shake player sprite for effect
                        playerShakeTimer.Stop();
                        PBPlayer.Left = originalPlayerX;
                        playerShakeCount = 0;
                        originalPlayerX = PBPlayer.Left;
                        playerShakeTimer.Start();

                    }

                }
            }
            // Enemy uses move 2
            else if (roll == 2) 
            {
                LblInfo.Text = enemy.name + " used " + enemy.move2;
                // Block the attack if defending
                if (defending == true) 
                {
                    LblInfo.Text += Environment.NewLine + " You Blocked It";
                    defending = false;
                }
                else
                {
                    // Calculate damage to player
                    bool isCrit;
                    string result = player.takeDamage(10, 5, enemy.atk, enemy.type, out isCrit);
                    LblInfo.Text += result;

                    // Display damage text if not missed
                    string[] lines = result.Split('\n');
                    string lastLine = lines.Last().Trim();

                    if (!lastLine.Contains("Miss"))
                    {
                        lblPlayerDamageEffect.Text = lastLine;
                        lblPlayerDamageEffect.Location = new Point(PBPlayer.Left + PBPlayer.Width / 2, PBPlayer.Top);
                        lblPlayerDamageEffect.Font = new Font("Arial", 24, FontStyle.Bold);

                        // Apply styling based on critical hit
                        if (isCrit)
                        {
                            lblPlayerDamageEffect.ForeColor = Color.Gold;
                            lblPlayerDamageEffect.BackColor = Color.Black;
                        }
                        else
                        {
                            lblPlayerDamageEffect.ForeColor = Color.Red;
                            lblPlayerDamageEffect.BackColor = Color.Transparent;
                        }

                        // Show and animate damage label
                        lblPlayerDamageEffect.Visible = true;
                        playerDamageTextStep = 0;
                        playerDamageTextTimer.Start();

                        // Shake player sprite
                        playerShakeTimer.Stop();
                        PBPlayer.Left = originalPlayerX;
                        playerShakeCount = 0;
                        originalPlayerX = PBPlayer.Left;
                        playerShakeTimer.Start();
                    }
                }
            }
            else
            {

            }

            // Checks player HP and shows GameOver if defeated
            if (player.hp > 0)
            {
                targetPlayerHP = Convert.ToInt32(player.hp);
                TimerPlayerHP.Start();

            }
            else
            {
                enemy.hp = 0;
                ProgBarPlayer.Value = 0;
                GameOverForm gameOver = new GameOverForm("Enemy Win!\nYou Lost the Battle!");
                gameOver.ShowDialog();

                if (gameOver.PlayAgainClicked)
                {
                    StartForm startForm = new StartForm();
                    startForm.Show();
                    this.Hide();
                }
                this.Close();

            }

            BtnAttack1.Enabled = true;
            BtnAttack2.Enabled = true;
            BtnDefend.Enabled = true;
        }

        // Defend action
        private void BtnDefend_Click(object sender, EventArgs e)
        {
            defending = true;
            LblInfo.Text = player.name  + " Prepared To Defend ";
            TimerEnAtk.Enabled = true;
            BtnAttack1.Enabled = false;
            BtnAttack2.Enabled = false;
            BtnDefend.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // This method handles the event when the "Exit" button is clicked during the battle.
        private void BtnExit_Click(object sender, EventArgs e)
        {
            StartForm startForm = new StartForm(); // Create a new instance of the StartForm to return to the main menu
            startForm.Show();  // Show the StartForm
            this.Close();     // Close the current Battle form
        }

        // This method animates the player's HP bar by gradually decreasing it to the target value.
        private void TimerPlayerHP_Tick(object sender, EventArgs e)
        {
            // If the current HP bar value is greater than the target (after taking damage)
            if (ProgBarPlayer.Value > targetPlayerHP)
            {
                ProgBarPlayer.Value -= 1;  // Decrease the HP bar value by 1 unit to simulate smooth damage animation

                // Change the HP bar color based on remaining HP
                if (ProgBarPlayer.Value > 60)
                    ProgBarPlayer.ForeColor = Color.Green;   // High HP
                else if (ProgBarPlayer.Value > 30)
                    ProgBarPlayer.ForeColor = Color.Orange;  // Medium HP
                else
                    ProgBarPlayer.ForeColor = Color.Red;      // Low HP
            }
            else
            {
                TimerPlayerHP.Stop(); // Stop the timer once the bar has reached the intended target HP
            }
        }

        // This method gradually decreases the enemy's HP in the progress bar to create a smooth animation effect.
        private void TimerEnemyHP_Tick(object sender, EventArgs e)
        {
            // Check if the current displayed HP is still greater than the target HP (after taking damage)
            if (ProgBarEnemy.Value > targetEnemyHP)
            {
                ProgBarEnemy.Value -= 1;  // Decrease the HP by 1 unit to animate the health reduction

                // Change the progress bar color based on current HP level
                if (ProgBarEnemy.Value > 60)
                    ProgBarEnemy.ForeColor = Color.Green;  // High health
                else if (ProgBarEnemy.Value > 30)
                    ProgBarEnemy.ForeColor = Color.Orange; // Medium health
                else
                    ProgBarEnemy.ForeColor = Color.Red;    // Low health
            }
            else
            {
                TimerEnemyHP.Stop(); // Stop the timer once the progress bar has reached the target HP
            }
        }

        // This method is triggered by the flashTimerPlayer to simulate a flashing effect when the player takes damage
        private void FlashTimerPlayer_Tick(object sender, EventArgs e)
        {
            flashCountPlayer++;  // Increment the number of flashes that have occurred

            // Toggle the visibility of the player's image
            PBPlayer.Visible = !PBPlayer.Visible;

            // After flashing 6 times, stop the timer and make sure the player is visible again
            if (flashCountPlayer >= 6)
            {
                flashTimerPlayer.Stop();   // Stop the flash animation
                PBPlayer.Visible = true;  // Ensure the player sprite is visible
                flashCountPlayer = 0;    // Reset flash count for next time
            } 
        }

        // This timer method is triggered to simulate a shaking animation when the enemy gets hit
        private void EnemyShakeTimer_Tick(object sender, EventArgs e)
        {
            shakeStep++;  // Increment the shake step count

            // Alternate enemy's horizontal position left and right by 5 pixels
            if (shakeStep % 2 == 0)
                PBEnemy.Left = originalEnemyX + 5;
            else
                PBEnemy.Left = originalEnemyX - 5;

            // After 6 steps, stop shaking and reset enemy position and step counter
            if (shakeStep >= 6)
            {
                enemyShakeTimer.Stop();         // Stop the shake animation
                PBEnemy.Left = originalEnemyX; // Reset to original position
                shakeStep = 0;                // Reset step count for next use
            }
        }

        // This timer method is used to simulate a shaking animation when the player takes damage.
        private void PlayerShakeTimer_Tick(object sender, EventArgs e)
        {
            playerShakeCount++;  // Increment the shake count for the player

            // Alternate player’s position to simulate shaking
            if (playerShakeCount % 2 == 0)
                PBPlayer.Left += 5;
            else
                PBPlayer.Left -= 5;

            // After 6 shakes, stop the timer and reset player to original position
            if (playerShakeCount >= 6)
            {
                playerShakeTimer.Stop();           // Stop the shake animation
                PBPlayer.Left = originalPlayerX;  // Reset to original position
                playerShakeCount = 0;            // Reset shake count
            }
        }

        // This method is triggered every tick of bounceTimer to animate a "bouncing" effect
        private void BounceTimer_Tick(object sender, EventArgs e)
        {
            bounceStep++;  // Increment the step counter for the bounce animation

            // On the 1st tick, increase font size for a "pop" effect
            if (bounceStep == 1)
                lblDamageEffect.Font = new Font("Arial", baseFontSize + 6, FontStyle.Bold);

            // On the 2nd tick, reduce font size slightly to start settling down
            else if (bounceStep == 2)
                lblDamageEffect.Font = new Font("Arial", baseFontSize + 3, FontStyle.Bold);

            // On the 3rd tick, return to the base font size (normal)
            else if (bounceStep == 3)
                lblDamageEffect.Font = new Font("Arial", baseFontSize, FontStyle.Bold);

            // After the 3 steps, stop the timer and reset the bounce step counter
            else
            {
                bounceTimer.Stop();
                bounceStep = 0;
            }
        }


        // This method is triggered every tick of bounceTimerPlayer to animate a "bouncing" effect
        private void BounceTimerPlayer_Tick(object sender, EventArgs e)
        {
            bounceStepPlayer++; // Increment the step counter for the bounce animation

            // On the 1st tick, enlarge the font size for the bounce start
            if (bounceStepPlayer == 1)
                lblPlayerDamageEffect.Font = new Font("Arial", baseFontSize + 6, FontStyle.Bold);

            // On the 2nd tick, slightly reduce the font size
            else if (bounceStepPlayer == 2)
                lblPlayerDamageEffect.Font = new Font("Arial", baseFontSize + 3, FontStyle.Bold);

            // On the 3rd tick, reset font size to default
            else if (bounceStepPlayer == 3)
                lblPlayerDamageEffect.Font = new Font("Arial", baseFontSize, FontStyle.Bold);

            // After animation completes, stop the timer and reset counter
            else
            {
                bounceTimerPlayer.Stop();
                bounceStepPlayer = 0;
            }
        }


        // It creates a floating damage text effect by moving the label upwards step-by-step.
        private void PlayerDamageTextTimer_Tick(object sender, EventArgs e)
        {
            playerDamageTextStep++;   // Increment the step counter used to control how far the text should move

            lblPlayerDamageEffect.Top -= 2; // Move the damage label slightly upward each tick (2 pixels per tick)

            if (playerDamageTextStep >= 20) // Once the text has moved enough steps (20 ticks * 2 pixels = 40 pixels), stop the animation
            {
                playerDamageTextTimer.Stop();  // Stop the timer to end the animation
                lblPlayerDamageEffect.Visible = false; // Hide the damage label after animation is complete
                playerDamageTextStep = 0; // Reset the step counter for the next damage effect
            }
        }

        // Character class (OOP - Encapsulation and Abstraction)
        public class character
        {
            public string name;
            public string type;
            public int charNum;
            public double hp = 100;
            public double atk;
            public double def;
            public string move1;
            public string move2;

            //Constructors
            public character()
            {

            }


            public character(string n, string t, int cN, int a, int d, string m1, string m2)
            {
                name = n;
                type = t;
                charNum = cN;
                atk = a;
                def = d;
                move1 = m1;
                move2 = m2;

            }

            //Method
            public string takeDamage(int dam, int acc, double enAtk, string enType, out bool isCritical)
            {
                string result = "";
                Random rnd = new Random();
                int roll = rnd.Next(1, 21);
                double critMod = 1;
                double typeMod = 1;
                isCritical = false;

                if (roll >= acc)
                {
                    if (roll == 20)
                    {
                        critMod = 1.5;
                        isCritical = true;
                        result += Environment.NewLine + "Critical Hit!";
                    }

                    // Apply type effectiveness modifiers
                    if ((enType == "Fire" && type == "Water") || (enType == "Grass" && type == "Fire") || (enType == "Water" && type == "Grass"))
                    {
                        typeMod = 0.8;
                        result += Environment.NewLine + "It Wasn't Very Effective";
                    }
                    else if ((enType == "Water" && type == "Fire") || (enType == "Fire" && type == "Grass") || (enType == "Grass" && type == "Water"))
                    {
                        typeMod = 1.2;
                        result += Environment.NewLine + "It Was Super Effective";
                    }

                    // Final damage calculation
                    double randomMod = 0.85 + rnd.NextDouble() * 0.3;
                    double damageDealt = (enAtk / def) * dam * critMod * typeMod * randomMod;
                    hp -= damageDealt;

                    result += Environment.NewLine + $"-{Math.Round(damageDealt)}";
                }
                else
                {
                    result += Environment.NewLine + " Miss!";
                }

                return result;
            }

        }

    }
}
