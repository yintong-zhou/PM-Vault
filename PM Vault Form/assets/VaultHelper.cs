using System;
using System.IO;
using static System.Console;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace PM_Vault_Form
{
    class VaultHelper
    {
        Cryptography crypto = new Cryptography();
        
        public string phraseKey { get; set; }
        public string localFileName { get; set; }
        public string programPath { get; set; }

        public void LoadingInfo()
        {
            // direcotry and file name
            localFileName = "pmvault.json";
            programPath = Directory.GetCurrentDirectory();
        }

        public void LogWriter(string message, string stackTrace)
        {
            WriteLine($"EXCEPTION - {message}");
            WriteLine($"STACKTRACE - {stackTrace}");
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
                {
                    if (resultJson["MasterPassword"].ToString() == password) return true;
                    else WriteLine("Password is not correct.");
                }
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
                else
                {
                    WriteLine("Username or Password is empty. Insert the credentials.");
                }
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
