using System;
using static System.Console;
using System.IO;

namespace PM_Vault_Console
{
    class Program
    {
       
        static void Main(string[] args)
        {
            VaultCommand c = new VaultCommand();
            VaultHelper h = new VaultHelper();
            VaultManagement m = new VaultManagement();
            HiddenPassword p = new HiddenPassword();
            string nL = Environment.NewLine;

            // title
            h.ShowTitle();

            LOGIN:
            Write(nL + "Username: ");
            string username = ReadLine();
            Write("Password: ");
            string password = p.Password();

            h.LoadingInfo();

            bool UserPermission = false;

            if (!h.ConfigFileExists(h.localFileName))
                UserPermission = h.UserControl(username, password, true);
            else UserPermission = h.UserControl(username, password);

            if (!UserPermission)
            {
                WriteLine("Wrong Credentials.");
                goto LOGIN;
            }
            else
            {
                START:
                Write(Environment.NewLine + "Enter comand: ");
                string cmd = ReadLine();
                if(cmd == c.AddAccount)
                {
                    WriteLine("$(Write in this order: title, username, password, comment)");
                    Write("> ");
                    string title = ReadLine();
                    m.AddAccount($"{h.programPath}\\{h.localFileName}", password, title);
                    goto START;
                }
                if (cmd == c.AddNote)
                {
                    WriteLine("$(Write in this order: title, comment)");
                    Write("> ");
                    string title = ReadLine();
                    m.AddNote($"{h.programPath}\\{h.localFileName}", password, title);
                    goto START;
                }
                else if(cmd == c.ReadAll)
                {
                    m.ReadAll($"{h.programPath}\\{h.localFileName}", password);
                }
                else if (cmd == c.ReadList)
                {
                    m.ReadList($"{h.programPath}\\{h.localFileName}", password);
                }
                else if(cmd.StartsWith(c.Remove))
                {
                    var name = cmd.Split(' ');
                    if (name.Length > 1)
                    {
                        string removeName = name[1];
                        m.Remove($"{h.programPath}\\{h.localFileName}", password, removeName);
                    }
                    else 
                    {
                        WriteLine("Write like: remove %NAME%");
                        goto START;
                    }
                }
                else if (cmd.StartsWith(c.Find))
                {
                    var name = cmd.Split(' ');
                    if (name.Length > 1)
                    {
                        string findName = name[1];
                        m.Find($"{h.programPath}\\{h.localFileName}", password, findName);
                    }
                    else
                    {
                        WriteLine("Write like: find %NAME%");
                        goto START;
                    }
                }
                else if (cmd.StartsWith(c.Update))
                {
                    var name = cmd.Split(' ');
                    if (name.Length > 1)
                    {
                        string updateName = name[1];
                        m.Update($"{h.programPath}\\{h.localFileName}", password, updateName);
                    }
                    else
                    {
                        WriteLine("Write like: update %NAME%");
                        goto START;
                    }
                }
                else if (cmd.StartsWith(c.Generate))
                {
                    var item = cmd.Split(' ');
                    try
                    {
                        int length = int.Parse(item[1]);
                        m.GeneratePwd(length);
                        goto START;
                    }
                    catch
                    {
                        WriteLine("Number length is not valid");
                    }
                }
                else if (cmd == c.Exit)
                {
                    Environment.Exit(0);
                }
                else if (cmd == c.Help)
                {
                    h.ShowHelp();
                }
                else WriteLine("Comand is not valid.");

                goto START;
            }
        }
    }
}
