using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace degreeCeremonyAssignment
{
    public class DegreeCeremonyFrontEnd
    {
        CeremonyList thisCeremony = new CeremonyList();


        public DegreeCeremonyFrontEnd()
        {

            /**
             * Displays the main menu and responds to the input.
             * Processing loops, ignoring invalid input and responding to valid
             * choices. It exits on the input of the exit value. 
             */
            int choice = 0;
            while (choice != -1)
            {
                choice = displayMenu(); // Display the menu
                switch (choice)
                {
                    case 1:
                        {
                            addStudent();
                            break;
                        }
                    case 2:
                        {
                            addGuest();
                            break;
                        }
                    case 3:
                        {
                            displayGuestList();
                            break;
                        }
                    case 4:
                        {
                            thisCeremony.displayStudents();
                            break;
                        }
                    case 5:
                        {
                            thisCeremony.listAllGuests();
                            break;
                        }
                }
            }
        }

        /**
         * 
         * @return The value input as an integer
         * 
         */
        private int displayMenu()
        {
            int menuInput = 0;
            Console.Write("1. Add a student\n"
                    + "2. Add a guest for a student\n"
                    + "3. Display a student guest list\n"
                    + "4. Display students\n"
                    + "5. List all guests\n"
                    + "-1. Quit\n");

            //  open up standard input
            menuInput = getNumber("Enter choice: ");
            return menuInput;
        }

        /**
         * 
         * @param message Prompt to be displayed
         * @return The string that has been input.
         * 
         */
        private String getDetail(String message)
        {
            Console.Write(message);
            String input = Console.ReadLine();
            return input;
        }

        /**
         * This method prompts for a student number. It returns when a number has
         * been input.
         * @param message Prompt to be displayed
         * @return The integer that has been input
         * 
         */
        private int getNumber(String message)
        {
            int number = 0;
            Boolean success = false;
            while (!success)
            {
                success = true;
                Console.Write(message);
                String input = Console.ReadLine();
                if (!Int32.TryParse(input, out number))
                {
                    Console.WriteLine("Please enter digits");
                    success = false;
                }
            }
            return number;
        }

        /**
         * Creates a new student object and passes it to the "engine" to be added
         * to the list. Duplicates are not allowed.
         * 
         */
        private void addStudent()
        {
            int studentNumber = getNumber("Enter student number: ");
            String name = getDetail("Enter student's name: ");
            Student aStudent = new Student(studentNumber, name);
            if (thisCeremony.addStudent(aStudent) == true)
            {
                Console.WriteLine(" Student " + name + " successfully added");
            }
            else
            {
                Console.WriteLine(" Student " + name + " not added");
            }
        }

        /** This method gets the name of the student to whom the guest should be added
         *  and the guest detail. It then attempts to add the guest to that student.
         */
        private void addGuest()
        {
            int result;
            // Get input details
            int num = getNumber("Enter student's number: ");
            String guestName = getDetail("Enter guest's name: ");
            String guestEmail = getDetail("Enter guest's email address: ");
            Guest newGuest = new Guest(guestName, guestEmail);

            // Now try to add the guest  to the student
            result = thisCeremony.addGuest(num, guestName, guestEmail);


            if (result > 0)
            {
                Console.WriteLine("Guest added to student" + num);
            }
            else
            {
                Console.WriteLine("ERROR: Guest not added to student " + num);
                if (result == 0)
                {
                    Console.WriteLine("The guest list for " + num + " is full");

                }
                else
                {
                    Console.WriteLine("Student " + num + " not found");
                }
            }
        }

        private void displayGuestList()
        {
            // Get input details
            int num = getNumber("Enter student's number: ");
            thisCeremony.displayGuestList(num);

        }

        /**
         * Runs the degree ceremony front end.
         * @param args
         * 
         */
        public static void Main(String[] args)
        {
            DegreeCeremonyFrontEnd myDegreeCeremony = new DegreeCeremonyFrontEnd();

        }
    }
}
