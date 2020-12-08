using System;
using Microsoft.VisualBasic;

static class Program
{

    public static string WriteError(string type, string s)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("[Error] ");
        Console.ResetColor();
        if (type == "invalid")
        {
            Console.Write("Invalid command. ");
        }
        else if (type == "input")
        {
            Console.Write("Invalid input. ");
        }
        Console.WriteLine(s);
        return s;
    }
    public static string WriteInfo(string s)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("[Info] ");
        Console.ResetColor();
        Console.WriteLine(s);
        return s;
    }
    public static string WriteHelp(string s)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("[Help] ");
        Console.ResetColor();
        Console.WriteLine(s);
        return s;
    }
    public static string WriteWarn(string s)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("[Warn] ");
        Console.ResetColor();
        Console.WriteLine(s);
        return s;
    }
    public static void Main()
    {
        Console.Title = "MiniConsole 1.0 by Kat21";
        bool trueValue = true;
        bool promptTime = false;
        string prompt = "(" + Environment.CurrentDirectory + ")>";
        string prompt2 = "";
        Console.WriteLine("MiniConsole 1.0 by Kat21. Coded in C#");
        Console.WriteLine("Currently running on a " + Environment.OSVersion.VersionString);
        Console.ResetColor();
        while (trueValue == true)
        {
            string UInput;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(prompt);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("");
            Console.ResetColor();
            UInput = Console.ReadLine();
            if (promptTime == true)
            {
                prompt = prompt2.Replace("$prompt", prompt).Replace("$time", DateTime.Now.ToString("h:mm:ss tt")).Replace("$hi", "Hello!").Replace("$path", Environment.CurrentDirectory);
            }
            if (UInput == "hi")
                Console.WriteLine("Hello!");
            else if (UInput == "")
            {
                WriteError("input","No input recieved");
            }
            else if (UInput.Contains("help"))
            {
                if (UInput == "help")
                {
                    WriteInfo("Help usage: \"help (command)\" where \"(command)\" is the command ex. \"help draw\"");
                    WriteHelp("Help menu:");
                    Console.WriteLine("clear         Clear the screen (remove all the text)");
                    Console.WriteLine("draw [arg]    Draw to the screen (help draw)");
                    Console.WriteLine("help          Show help menu");
                    Console.WriteLine("hi            Say hi");
                    Console.WriteLine("time          Displays the time");
                    Console.WriteLine("path          Displays the current path of the executable");
                    Console.WriteLine("prompt [arg]  Change prompt (help prompt)");
                }
                else if (UInput == "help prompt")
                {
                    Console.WriteLine("Usage: prompt [time/path/default]");
                    Console.WriteLine("Supports command output (ex. prompt $path, prompt $time, prompt $hi)");
                    Console.WriteLine("Also supports strings (prompt Hello World, it's $time)");
                    Console.WriteLine("Examples: (prompt $time) returns the time ex. (12:05:00 PM)>");
                }
                else if (UInput == "help draw")
                {
                    Console.WriteLine("Usage: draw [string]");
                    Console.WriteLine("Supports command output (ex. draw $path, draw $time, draw $hi)");
                    Console.WriteLine("Also supports strings (draw Hello World, it's $time)");
                    Console.WriteLine("Examples: (draw $time) returns the time ex. 12:05:00 PM");
                }
                else if (UInput.StartsWith("help "))
                {
                    WriteHelp("No help was found for " + UInput.Substring(5) + ".");
                }
                else
                {
                    WriteError("invalid","Did you mean 'help'?");
                }
            }
            else if (UInput.Contains("draw"))
            {
                if (UInput.StartsWith("draw "))
                {
                    UInput = UInput.Replace("$prompt", prompt).Replace("$time", DateTime.Now.ToString("h:mm:ss tt")).Replace("$hi", "Hello!").Replace("$path", Environment.CurrentDirectory);
                    Console.WriteLine(UInput.Substring(5));
                }
                else
                {
                    WriteError("invalid", "Did you mean 'draw'?");
                }
            }
            else if (UInput == "time")
            {
                Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
            }
            else if (UInput == "path")
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Path: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(Environment.CurrentDirectory);
                Console.ResetColor();
                WriteInfo("You can use \"help path\" to get more information about the path command.");
                promptTime = false;
            }
            else if (UInput.StartsWith("prompt"))
            {
                if (UInput == "prompt")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Prompt: ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(prompt);
                    Console.ResetColor();
                    WriteInfo("You can use \"help prompt\" to get more information about the prompt command.");
                    if (promptTime == true)
                    {
                        WriteInfo("Time prompt is activated. Use any other prompt to stop. (ex. prompt $path)");
                    }
                    else
                    {
                        promptTime = false;
                    }
                }
                else
                {
                    if (UInput.Contains("$time"))
                    {
                        promptTime = true;
                        prompt2 = UInput.Substring(7);
                    }
                    else
                    {
                        promptTime = false;
                    }
                    UInput = UInput.Replace("$prompt", prompt).Replace("$time", DateTime.Now.ToString("h:mm:ss tt")).Replace("$hi", "Hello!").Replace("$path", Environment.CurrentDirectory);
                    prompt = UInput[7..];
                    
                }
            }
            else if (UInput == "exit")
                System.Environment.Exit(0);
            else
            {
                WriteError("invalid", "try help?");
            }
        }
        WriteWarn("Sequence Ended");
    }
}