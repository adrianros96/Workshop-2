using System;
using View;
using Model;
namespace BoatClub
{
    // This is a starting point of the application.
    class Program
    {
        static void Main(string[] args)
        {
            MenuView mainMenu = new MenuView();
            mainMenu.Start();
        }
    }
}
