# SecureSphere Support Agent

## Overview

SecureSphere Support Agent is a Windows Forms cybersecurity chatbot application developed in C#.
The application assists users with basic digital security awareness by providing information about passwords, phishing, scams, privacy, and safe browsing practices.

The chatbot includes:

* Interactive chat interface
* Timestamped responses
* Personalized user experience
* Memory for favorite topics
* Random phishing safety tips
* Emotional response handling
* Audio greeting on startup

---

# Features

## 1. User Registration

When the application starts, the user is prompted to enter their preferred name.

Example:
System ready. Please type your preferred name below and click Send.

After entering a name:
System: Name registered as John.
[Agent]: How can I assist your digital security today?

---

## 2. Cybersecurity Assistance

The chatbot responds to cybersecurity-related keywords such as:

* password
* phishing
* scam
* privacy
* safe browsing

Example:
User: Tell me about phishing

Bot:
[Agent]: Phishing involves fraudulent communications designed to steal data. Always verify the sender's address and avoid clicking unknown links.

---

## 3. Emotional Awareness

The chatbot detects emotional words such as:

* worried
* scared
* anxious
* frustrated
* confused

It then responds empathetically before providing assistance.

Example:
User: I'm worried about phishing emails

Bot:
[Agent]: It's completely understandable to feel that way. Scammers can be very convincing. Let me help.

---

## 4. Favorite Topic Memory

The chatbot remembers topics the user is interested in.

Example:
User: interested in phishing

Bot:
[Agent]: Great! I'll remember that you're interested in phishing.

Later responses about phishing will include personalized information.

---

## 5. Conversation Memory

The chatbot remembers the last topic discussed.

Commands supported:

* tell me more
* another tip
* explain more

Example:
User: tell me more

The chatbot continues discussing the previous topic.

---

## 6. Random Phishing Tips

The chatbot can provide random phishing safety tips.

Example:
User: phishing tips

Bot:
[Agent]: Always check the sender's actual email address, not just the display name.

---

## 7. Timestamped Messages

All bot responses include timestamps using the format:
[HH:mm]

Example:
[14:35] [Agent]: Privacy is crucial.

---

## 8. Audio Greeting

The application plays a greeting sound on startup using:
greeting.wav

If the audio file is missing, the application displays an error message.

---

# Technologies Used

* C#
* .NET Windows Forms
* Visual Studio
* RichTextBox UI Component
* Dictionary Collections
* Lists
* Delegates
* Random Class

---

# Project Structure

## Form1.cs

Handles:

* User interface
* User input
* Chat display
* Audio greeting
* Timestamp formatting

## SecurityAgent.cs

Handles:

* Chatbot logic
* Keyword detection
* Responses
* Conversation memory
* Favorite topics
* Emotional intelligence

## Form1.Designer.cs

Handles:

* User interface design
* Buttons
* Labels
* Textboxes
* Layout configuration

---

# How to Run the Application

## Requirements

* Visual Studio 2022 or later
* .NET Framework / .NET Windows Forms support

---

## Steps

1. Open the project in Visual Studio.
2. Build the solution.
3. Ensure the file:
   greeting.wav
   is placed in the project directory.
4. Run the application.

---

# User Interface Components

| Component   | Purpose                            |
| ----------- | ---------------------------------- |
| RichTextBox | Displays conversation history      |
| TextBox     | Allows user input                  |
| Button      | Sends messages                     |
| Label       | Displays ASCII cyber-themed design |

---

# Example Conversation

User:
John

Bot:
System: Name registered as John.
[Agent]: How can I assist your digital security today?

User:
Tell me about passwords

Bot:
[14:32] [Agent]: A robust password should be lengthy, unique, and include a mix of character types.

User:
another tip

Bot:
[14:33] [Agent]: Consider utilizing a secure password manager.

---

# Error Handling

The application includes exception handling for:

* Missing audio files
* Empty user input
* Invalid conversation flow

Example:
System Error: Audio file missing.

---

# Future Improvements

Possible enhancements include:

* Database integration
* AI-powered responses
* Voice recognition
* User login system
* Dark/light themes
* More cybersecurity topics
* Typing animation
* Save chat history feature

---

# Author

Developed as a cybersecurity awareness chatbot project using C# Windows Forms.

---

# License

This project is for educational purposes only.
# SecurityAgent
