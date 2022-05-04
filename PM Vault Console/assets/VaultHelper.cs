using System;
using System.IO;
using static System.Console;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Configuration;

namespace PM_Vault_Console
{
    class VaultHelper
    {
        Cryptography crypto = new Cryptography();
        
        public string phraseKey { get; set; }
        public string localFileName { get; set; }
        public string programPath { get; set; }

        public void ShowTitle()
        {
            WriteLine(@" _______  _______             _______           _    _________");
            WriteLine(@"(  ____ )(       )  |\     /|(  ___  )|\     /|( \   \__   __/");
            WriteLine(@"| (    )|| () () |  | )   ( || (   ) || )   ( || (      ) (   ");
            WriteLine(@"| (____)|| || || |  | |   | || (___) || |   | || |      | |   ");
            WriteLine(@"|  _____)| |(_)| |  ( (   ) )|  ___  || |   | || |      | |  ");
            WriteLine(@"| (      | |   | |   \ \_/ / | (   ) || |   | || |      | |  ");
            WriteLine(@"| )      | )   ( |    \   /  | )   ( || (___) || (____/\| | ");
            WriteLine(@"|/       |/     \|     \_/   |/     \|(_______)(_______/)_(   ");

            WriteLine(Environment.NewLine + "Beta version - Password Manager Vault");
        }

        public void ShowHelp()
        {
            WriteLine(Environment.NewLine + "addnote : add new note");
            WriteLine("addaccount : add new account");
            WriteLine("readall : read all notes");
            WriteLine("readlist : read all notes title");
            WriteLine("remove %NAME% : remove an account");
            WriteLine("find %NAME% : find a specific account");
            WriteLine("update %NAME% : update a specific account");
            WriteLine("generate %LENGTH% : generate a random password with specific length");
            WriteLine("exit : close terminal");
        }

        public void LoadingInfo()
        {
            // direcotry and file name
            localFileName = ConfigurationManager.AppSettings["DatabaseName"];
            programPath = Directory.GetCurrentDirectory();
        }

        public void LogWriter(string message, string stackTrace)
        {
            WriteLine(Environment.NewLine + $"EXCEPTION - {message}");
            WriteLine($"STACKTRACE - {stackTrace}" + Environment.NewLine);
        }

        public bool CredentialControl(string user, string password)
        {
            try
            {
                // decrypt and read json file
                string jsonCrypted = JsonConvert.SerializeObject(user);
                jsonCrypted = File.ReadAllText($"{programPath}\\{localFileName}");
                string jsonContent = crypto.DecryptText(jsonCrypted, password);
                JObject resultJson = JObject.Parse(jsonContent); 

                // check credentials
                if (resultJson["Name"].ToString() == user)
                    return true;
                else WriteLine("Username is not correct.");
            }
            catch(Exception ex)
            {
                LogWriter(ex.Message, ex.StackTrace);
            }

            return false;
        }

        public bool UserControl(string username, string password, bool firstLogin = false)
        {
            if (firstLogin)
            {
                //create local file
                CreateLocalFile(localFileName);

                // json insert user
                User user = new User()
                {
                    Id = 1,
                    Name = username,
                    MasterPassword = password,
                    Vault = new List<Vault>()
                };

                // append json data into file
                string userJson = JsonConvert.SerializeObject(user);
                string cryptedJson = crypto.EncryptText(userJson, password);
                File.AppendAllText($"{programPath}\\{localFileName}", cryptedJson);
                WriteLine("Json file inizialized.");
                WriteLine(userJson);
                return true;
            }
            else
            {
                if(username.Length > 0 && password.Length > 0)
                {
                    bool IsMyUser = CredentialControl(username, password);
                    return IsMyUser;
                }
                else WriteLine("Username or Password is empty. Insert the credentials.");
            }

            return false;
        }


        internal void CreateLocalFile(string fileName)
        {
            try
            {
                File.AppendAllText($"{programPath}\\{fileName}", null);
            }
            catch (Exception ex)
            {
                LogWriter(ex.Message, ex.StackTrace);
            }
        }

        internal bool ConfigFileExists(string fileName)
        {
            // check file exists
            string _file = $"{programPath}\\{fileName}";
            if (File.Exists(_file))
            {
                return true;
            }
            return false;
        }
    }
}
