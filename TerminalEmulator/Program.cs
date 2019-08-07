using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rebex.TerminalEmulation;

namespace TerminalEmulator
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                using (var ssh = new Rebex.Net.Ssh())
                {
                    ssh.Connect("10.210.16.4", 5023);
                    ssh.Login("uson", "Th33nd123");
                    Console.WriteLine("Connection Established");
                    while (true)
                    {
                        var userInput = Console.ReadLine();
                        Scripting script = ssh.StartScripting();
                        script.DetectPrompt();
                        script.Timeout = 3 * 70000;
                        script.Prompt = "> ";
                        if (userInput == "open")
                        {
                            script.SendCommand("amos ADAKGL");
                            Console.WriteLine("Reading response...");
                            string response = script.ReadUntilPrompt();
                            Console.WriteLine(response);
                            script.Prompt = response.Split('\n').Last()+script.Prompt;
                            Console.WriteLine(script.Prompt);
                        }
                        else if (userInput == "send1")
                        {
                            script.SendCommand("ue print -admitted");
                            Console.WriteLine("Sent command. Waiting for auth response");
                            ScriptMatch match = script.WaitFor("Username:");
                            string response = script.ReceivedData;
                            Console.WriteLine(response);
                            if (match.IsPrompt)
                            {
                                script.SendCommand("rbs");
                                Console.WriteLine("Username entered");
                            }
                            match = script.WaitFor("Password:");
                            response = script.ReceivedData;
                            Console.WriteLine(response);
                            if (match.IsPrompt)
                            {
                                script.SendCommand("rbs");
                                Console.WriteLine("Password entered");
                            }
                            response = script.ReadUntilPrompt();
                            Console.WriteLine();
                        }
                        else if (userInput == "send2")
                        {
                            script.SendCommand("mploadctrl short");
                            string response = script.ReadUntilPrompt();
                            Console.WriteLine(response);
                        }
                        else if (userInput == "send3")
                        {
                            script.Send("mploadctrl short");
                            script.Send(FunctionKey.Enter);
                            string response = script.ReadUntil("\n");
                            Console.WriteLine(response);
                            Console.WriteLine("Sent command. Waiting for auth response");
                            ScriptMatch match = script.WaitFor("\n");
                            response = script.ReceivedData;
                            Console.WriteLine(response);
                            match = script.WaitFor("\n");
                            response = script.ReceivedData;
                            Console.WriteLine(response);
                            match = script.WaitFor("\n");
                            response = script.ReceivedData;
                            Console.WriteLine(response);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
                                     
                    
            
            
            
        }

    }
}
