using System;
using Model;

namespace View
{
    class MenuView
    {

        Memberview memberView = new Memberview();
        BoatView boatView = new BoatView();

        public void Start()
        {
            try
            {
                while (true)
                {
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Add Member");
                Console.WriteLine("2: Edit Member");
                Console.WriteLine("3: Remove Member");
                Console.WriteLine("4: Show Single User");
                Console.WriteLine("5: View Verbose List");
                Console.WriteLine("6: View Compact List");
                Console.WriteLine("7: Manage Boats");

                MenuOptions menuChoice = MenuOptions.Exit;
                string strInput = Console.ReadLine();
                    if(Enum.TryParse(strInput, out menuChoice)) 
                    {
                        switch(menuChoice)
                        {
                            case MenuOptions.Exit:
                                Environment.Exit(0);
                                break;
                            case MenuOptions.AddMember:
                                memberView.AddMember();
                                break;
                            case MenuOptions.EditMember:
                                memberView.EditMember();
                                break;
                            case MenuOptions.RemoveMember:
                                memberView.RemoveMember();
                                break;
                            case MenuOptions.ShowUser:
                                memberView.ShowMember();
                                break;
                            case MenuOptions.VerboseMemberList:
                                memberView.VerboseMemberList();
                                break;
                            case MenuOptions.CompactMemberList:
                                memberView.CompactMemberList();
                                break;
                            case MenuOptions.ManageBoats:
                                boatView.ManageBoats();
                                break;
                        }
                    }
                }
            }
            catch (Exception e)
            {               
                Console.WriteLine("ERROR: " + e);
                Start();
            }
            
        }
    }
}