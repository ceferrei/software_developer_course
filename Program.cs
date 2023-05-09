/*
- Room Rental System:
This is a console-based application that allows users to rent rooms and stores the rented rooms' occupants' information.

- How to Use:
To use this application, simply run the executable file and follow the prompts. You will be asked how many rooms you want to rent, and for each room,
you will be asked to provide the renter's name, email, and room number. If the requested room is already occupied, you will be prompted to choose another room.

Once you have rented all the desired rooms, the application will display a list of the occupied rooms, along with the renters' names and emails.*/


using System;

class Program
{
    static void Main(string[] args)
    {
        // Creates an array of strings to store room occupations
        string[] rooms = new string[10];

        Console.Write("How many rooms will be rented? ");
        int n = int.Parse(Console.ReadLine());

        // Loop to request rental information
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine("Rent #" + i + ":");

            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();

            int room;
            // Creates the variable outside the loop for memory and efficiency reasons
            while (true)
            {
                Console.Write("Room (0 to 9): ");
                room = int.Parse(Console.ReadLine());

                // Checks if the room is already occupied. If it is, requests another room number
                if (rooms[room] == null)
                    break;
                Console.WriteLine("Room already occupied. Choose another.");
            }

            // Stores the student's name and email in the rooms array at the corresponding position
            rooms[room] = name + ", " + email;
        }

        Console.WriteLine("Occupied rooms:");
        for (int i = 0; i < 10; i++)
        {
            if (rooms[i] != null)
                Console.WriteLine(i + ": " + rooms[i]);
        }
    }
}

// Defines a student class with properties Name and Email
class Student
{
    public string Name { get; set; }
    public string Email { get; set; }

    // Constructor for the Student class that receives name and email
    public Student(string name, string email)
    {
        Name = name;
        Email = email;
    }
}
