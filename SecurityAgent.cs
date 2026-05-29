using System;

using System.Collections.Generic; // Required for Dictionaries and Lists

namespace SecurityAgent

{
    public delegate string ResponseFormatter(string message);
    internal class SecurityAgent

    {
        
        public string ClientName { get; set; }

        public ResponseFormatter FormatOutput;
        public string FavoriteTopic { get; set; } = "";
        public string LastDiscussedTopic { get; set; } = "";

        // 1. New Data Structures for Code Optimisation

        private Dictionary<string, string> keywordResponses;

        private List<string> phishingTips;

        private Random randomGen;

        // 2. The Constructor: Sets up the bot's memory when it boots up

        public SecurityAgent()

        {

            randomGen = new Random();

            FormatOutput = (msg) => msg;
            // Rubric Task: Arrays or lists for random responses

            phishingTips = new List<string>

            {

                "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organisations.",

                "Always check the sender's actual email address, not just the display name.",

                "Never click suspicious links. Hover over them to see the real URL first."

            };

            // Rubric Task: Use dictionaries to organise keyword responses

            keywordResponses = new Dictionary<string, string>

            {

                { "password", "A robust password should be lengthy, unique, and include a mix of character types. Consider utilizing a secure password manager." },

                { "phishing", "Phishing involves fraudulent communications designed to steal data. Always verify the sender's address and avoid clicking unknown links." },

                { "safe browsing", "Stick to HTTPS encrypted sites and deploy a VPN on public networks to keep your data packets secure." },

                { "scam", "If an offer looks too good to be true, it likely is a scam. Verify the source before proceeding." },

                { "privacy", "Privacy is crucial. Review your security settings on social media and avoid oversharing personal details." }

            };

        }

        // 3. The New Brain: Replaces InitiateDialogue() and returns strings to the GUI

        public string GetBotResponse(string input)
        {
            input = input.ToLower();

            // ---------------------------------------------------------
            // TASK 6: SENTIMENT DETECTION (Empathy)
            // ---------------------------------------------------------
            string empathyPrefix = "";
            if (input.Contains("worried") || input.Contains("scared") || input.Contains("anxious"))
            {
                empathyPrefix = "It's completely understandable to feel that way. Scammers can be very convincing. Let me help. ";
            }
            else if (input.Contains("frustrated") || input.Contains("confused"))
            {
                empathyPrefix = "Don't worry if this feels overwhelming. Let's take it one step at a time. ";
            }

            // ---------------------------------------------------------
            // TASK 5: MEMORY AND RECALL (Saving the favorite topic)
            // ---------------------------------------------------------
            if (input.Contains("interested in "))
            {
                // Extract the topic they typed after "interested in "
                string[] words = input.Split(new string[] { "interested in " }, StringSplitOptions.None);
                if (words.Length > 1)
                {
                    FavoriteTopic = words[1].Trim(new char[] { '.', '!', '?', ' ' }); // Clean up punctuation
                  
                    return FormatOutput($"[Agent]: Great! I'll remember that you're interested in {FavoriteTopic}. It's a crucial part of staying safe online.");
                }
            }

            // ---------------------------------------------------------
            // TASK 4: CONVERSATION FLOW (Follow-up questions)
            // ---------------------------------------------------------
            if (input == "tell me more" || input == "another tip" || input == "explain more")
            {
                if (!string.IsNullOrEmpty(LastDiscussedTopic))
                {
                    // Trick the bot into thinking they asked about the last topic again
                    input = LastDiscussedTopic;
                }
                else
                {
                    
                    return FormatOutput("[Agent]: I'm not sure what you'd like more details on. What specific topic should we discuss?");
                }
            }

            // Check for Random Responses (Phishing)
            if (input.Contains("phishing tip") || input.Contains("phishing tips"))
            {
                LastDiscussedTopic = "phishing tip"; // Save to memory
                int index = randomGen.Next(phishingTips.Count);
                
                return FormatOutput($"[Agent]: {empathyPrefix}{phishingTips[index]}");
            }

            // Loop through the Dictionary to find matching keywords
            foreach (var keyword in keywordResponses.Keys)
            {
                if (input.Contains(keyword))
                {
                    LastDiscussedTopic = keyword; // Save to memory for follow-ups

                    // Task 5 Memory Recall: Check if this is their favorite topic!
                    string memoryBonus = "";
                    if (FavoriteTopic == keyword)
                    {
                        memoryBonus = $"As someone interested in {FavoriteTopic}, you should definitely know this: ";
                    }

                    // Combine Empathy, Memory, and the actual tip!
                    return FormatOutput($"[Agent]: {empathyPrefix}{memoryBonus}{keywordResponses[keyword]}"); 
                }
            }

            // Default fallback
           
            return FormatOutput("[Agent]: I'm not sure I understand. Can you try rephrasing?");
        }

    }

}    
 