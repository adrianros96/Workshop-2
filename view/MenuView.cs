using System;

namespace View
{
    class MenuView
    {
        public void Start()
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
                        Console.WriteLine("Mail motherfocker");
                        break;
                    case MenuOptions.EditMember:
                        break;
                    case MenuOptions.RemoveMember:
                        break;
                    case MenuOptions.ShowUser:
                        Console.WriteLine("Mail motherfocker");
                        break;
                    case MenuOptions.VerboseMemberList:
                        break;
                    case MenuOptions.CompactMemberList:
                        break;
                    case MenuOptions.ManageBoats:
                        break;
                }
            }
        }

        //  private int MainMenu()
        // {
            
        // }
    }
}