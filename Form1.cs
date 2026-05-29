using System;

using System.Windows.Forms;

namespace SecurityAgent

{

    public partial class Form1 : Form

    {

        // 1. Create the bot object here so the whole form can see it

        SecurityAgent agent = new SecurityAgent();

        public Form1()

        {

            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Just leave this empty!
        }
        private void Form1_Load(object sender, EventArgs e)
         
        {

            try

            {
                agent.FormatOutput = AddTimestamp;

                System.Media.SoundPlayer player = new System.Media.SoundPlayer("C:\\Users\\Dell\\source\\repos\\SecurityAgent\\greeting.wav");

                player.Play();

                // Make the terminal look official when it starts

                rtbChatArea.AppendText("**************************************************\n");

                rtbChatArea.AppendText("    Initializing SecureSphere Support Agent...    \n");

                rtbChatArea.AppendText("**************************************************\n\n");

                rtbChatArea.AppendText("System ready. Please type your preferred name below and click Send.\n");

            }

            catch (Exception ex)

            {

                rtbChatArea.AppendText("System Error: Audio file missing. " + ex.Message + "\n");

            }

        }

        private void btnSend_Click_1(object sender, EventArgs e)

        {

            // Grab the text from the input box

            string userInput = txtUserInput.Text;

           
            // Prevent empty blank messages from doing anything

            if (string.IsNullOrWhiteSpace(userInput)) return;

            // 2. Name Registration (Check if the name is blank)

            if (string.IsNullOrEmpty(agent.ClientName))

            {

                agent.ClientName = userInput;

                rtbChatArea.AppendText($"\nSystem: Name registered as {agent.ClientName}.\n");

                rtbChatArea.AppendText("[Agent]: How can I assist your digital security today?\n");

                txtUserInput.Clear(); // Clear the text box

                return; // Stop here so it doesn't process their name as a cybersecurity question

            }

            // 3. Normal Chat Flow

            // Show what the user typed

            rtbChatArea.AppendText($"\n{agent.ClientName}: {userInput}\n");

            // Ask the agent for the answer!

            string botResponse = agent.GetBotResponse(userInput);

            // Show the bot's response

            rtbChatArea.AppendText($"{botResponse}\n");

            // Clear the input box so it is ready for the next question

            txtUserInput.Clear();

        }
        
        private string AddTimestamp(string message)
        {
            // Grabs the current time (e.g., "14:30") and sticks it in front of the message
            string time = DateTime.Now.ToString("HH:mm");
            return $"[{time}] {message}";
        }

    }

}
 