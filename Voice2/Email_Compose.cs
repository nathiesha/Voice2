﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;//speech output
using System.Speech.Recognition;//for speech recognition



namespace Voice2
{
    //email composing window 1 of 2
    public partial class Email_Compose : Form
    {
        SpeechSynthesizer synth = new SpeechSynthesizer();
        SemanticResultValue[] userNames = new SemanticResultValue[10];//conact names semantic values

        string[] lines2;//to store contact names
        string[] lines3;
        String next;
        int position;//temp variables
        String contactEmail;//recipients email
        String email;//user email address
        String password;//pasword of email
        String user; //user name 
        int number;
        
      

        public Email_Compose(String email, String password,String username,int num)
        {
            InitializeComponent();
            this.email = email;
            this.password = password;
            user = username;
            number = num;

        }


       
        //when the window is shown
        private void Email_Compose_Shown(object sender, EventArgs e)
        {
            //initialize speech enine
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();

             
            synth.SetOutputToDefaultAudioDevice();
            synth.Speak("Select a contact name to send the email");

            //fetch contact names from file
            lines2 = System.IO.File.ReadAllLines(@"G:\c users\Desktop\sem 5\SEP\ContactNames.txt");         
            

            //adding the contact names to the dictionary
            Dictionary<string, int> names = new Dictionary<string, int>();

            
            int i=0;

            //read out each contact name
            foreach (string line in lines2)
            {
                synth.Speak(line);
                userNames[i]=new SemanticResultValue(line,line);   //add the names to semantic values
                textBox1.Text=line;//set text in the text box
                i++;
            }
            textBox1.Text = "";

            synth.Speak("Speak now");

            Choices services2 = new Choices();
            GrammarBuilder[] gb=new GrammarBuilder[i];//new grammar builder array

            //add the user names to the grammar builder array
            for (int j = 0; j < i; j++)
            {
                gb[j] = userNames[j];
            }


            services2.Add(new Choices(gb));

            // Build the phrase and add SemanticResultKeys.
            GrammarBuilder chooseService2 = new GrammarBuilder();

            chooseService2.Append(new SemanticResultKey("origin", services2));

            // Build a Grammar object from the GrammarBuilder.
            Grammar ser = new Grammar(chooseService2);
            ser.Name = "Services";

            // Add a handler for the LoadGrammarCompleted event.
            recognizer.LoadGrammarCompleted +=
              new EventHandler<LoadGrammarCompletedEventArgs>(recognizer_LoadGrammarCompleted);

            // Add a handler for the SpeechRecognized event.
            recognizer.SpeechRecognized +=
              new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

            // Load the grammar object to the recognizer.
            recognizer.LoadGrammarAsync(ser);

            // Set the input to the recognizer.
            recognizer.SetInputToDefaultAudioDevice();

            // Start recognition.
            recognizer.RecognizeAsync();

            

        
        }

          // Handle the LoadGrammarCompleted event.
        static void recognizer_LoadGrammarCompleted(object sender, LoadGrammarCompletedEventArgs e)
        {
        }


        // Handle the SpeechRecognized event.
        void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result != null )
            {
                textBox1.Text = e.Result.Text + "\r\n";//set the name on text box

                //identify which contact name is told by user
                for (int i = 0; i < userNames.Length; i++)
                {
                    if (e.Result.Text == lines2[i])
                    {
                        next = lines2[i];
                        position = i;
                        break;
                    }
              
                }

                //fetch all the contact emails from file
                lines3 = System.IO.File.ReadAllLines(@"G:\c users\Desktop\sem 5\SEP\ContactPassword.txt"); 
                contactEmail=lines3[position];//get the relavant email
                
                textBox3.Text = contactEmail;//set it on text box
                synth.Speak("Detected " + e.Result.Text);
                synth.Speak("Click to proceed");
                synth.Speak("Or press any key to try again");
                
            }
        }

        //when button clicked
        private void button1_Click(object sender, EventArgs e)
        {
            //message should be recorded]
            //directs to the message recording window
            System.Media.SystemSounds.Beep.Play();
            Email_comRecord form8 = new Email_comRecord(email, password, contactEmail, next);//passing the recipients email and user email and password
            this.Hide();//hide this
            form8.Closed += (s, args) => this.Close();
            form8.Show();//show next window
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //message should be recorded
            //directs to the message recording window
            System.Media.SystemSounds.Beep.Play();
            Email_comRecord form8 = new Email_comRecord(email, password, contactEmail, next);//passing the recipients email and user email and password
            this.Hide();//hide this
            form8.Closed += (s, args) => this.Close();
            form8.Show();//show next window
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //message should be recorded
            //directs to the message recording window
            System.Media.SystemSounds.Beep.Play();
            Email_comRecord form8 = new Email_comRecord(email, password, contactEmail, next);//passing the recipients email and user email and password
            this.Hide();//hide this
            form8.Closed += (s, args) => this.Close();
            form8.Show();//show next window
        }


        private void label4_Click(object sender, EventArgs e)
        {
            //message should be recorded
            //directs to the message recording window
            System.Media.SystemSounds.Beep.Play();
            Email_comRecord form8 = new Email_comRecord(email, password, contactEmail, next);//passing the recipients email and user email and password
            this.Hide();//hide this
            form8.Closed += (s, args) => this.Close();
            form8.Show();//show next window
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //message should be recorded
            //directs to the message recording window
            System.Media.SystemSounds.Beep.Play();
            Email_comRecord form8 = new Email_comRecord(email, password, contactEmail, next);//passing the recipients email and user email and password
            this.Hide();//hide this
            form8.Closed += (s, args) => this.Close();
            form8.Show();//show next window
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            //message should be recorded
            //directs to the message recording window
            System.Media.SystemSounds.Beep.Play();
            Email_comRecord form8 = new Email_comRecord(email, password, contactEmail, next);//passing the recipients email and user email and password
            this.Hide();//hide this
            form8.Closed += (s, args) => this.Close();
            form8.Show();//show next window
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            //message should be recorded
            //directs to the message recording window
            System.Media.SystemSounds.Beep.Play();
            Email_comRecord form8 = new Email_comRecord(email, password, contactEmail, next);//passing the recipients email and user email and password
            this.Hide();//hide this
            form8.Closed += (s, args) => this.Close();
            form8.Show();//show next window
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            //message should be recorded
            //directs to the message recording window
            System.Media.SystemSounds.Beep.Play();
            Email_comRecord form8 = new Email_comRecord(email, password, contactEmail, next);//passing the recipients email and user email and password
            this.Hide();//hide this
            form8.Closed += (s, args) => this.Close();
            form8.Show();//show next window
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //user wants to try again
            //directs to the same window
            System.Media.SystemSounds.Beep.Play();
            Email_Compose form8 = new Email_Compose(email, password, user, number);//passing the recipients email and user email and password
            this.Hide();//hide this
            form8.Closed += (s, args) => this.Close();
            form8.Show();//show next window
        }



        }
    }


