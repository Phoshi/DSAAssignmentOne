using System;
using System.Linq;
using System.Text;
using LinkedList;

/*
 * YOU HAVE TO COMPLETE THIS CLASS
 */
namespace degreeCeremonyAssignment
{
    public class CeremonyList
    {
        private LinkedList<Student> myList = new LinkedList<Student>();


        public Boolean addStudent(Student aStudent)
        {
            Boolean success = false;
            if (!myList.Contains(aStudent))
            {
                myList.Prepend(aStudent);
                success = true;
            }
            return success;
        }

        /**
         * YOU HAVE TO COMPLETE THIS METHOD.
         * Adds a guest to a student. Returns:
         * -1 if the student's name was not in the list
         * 0 if guest list is full
         * 1 if guest successfully added
         */
        public int addGuest(int number, String guestName, String email)
        {
            int result = -1;
            Guest newGuest = new Guest(guestName, email);
            Student temp = new Student(number, " ");
            if (myList.Contains(temp)){
            Student tmpStudent = (from student in myList where student.Equals(temp) select student).First();
                if (tmpStudent.addGuest(newGuest))
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }

            }
            return result;
        }

        /**
         * YOU HAVE TO COMPLETE THIS METHOD.
         * Displays a student's guest list
         * @param studentNum
         */
        public void displayGuestList(int studentNum)
        {
            Student aStudent = new Student(studentNum, " ");
            if (myList.Contains(aStudent))
            {
                myList.First(student => student.getStudentNum()==studentNum).displayGuestList();
            }
            else{
                Console.WriteLine("This student does not exist!");
            }


        }

        /**
         * YOU HAVE TO COMPLETE THIS METHOD.
         * Displays all students and their guests
         */
        public void displayStudents()
        {
            foreach (var student in myList){
                student.display();
            }
        }

        /**
         * YOU HAVE TO COMPLETE THIS METHOD.
         * Displays all guests. There should be no duplicates
         */
        public void listAllGuests()
        {
            LinkedList<Guest> guests = new LinkedList<Guest>();
            foreach (var student in myList){
                LinkedList<Guest> guestList = student.getGuestList();
                foreach (var guest in guestList){
                    if (!guests.Contains(guest)){
                        guests.Add(guest);
                    }
                }
            }
            foreach (var guest in guests){
                Console.WriteLine(guest);
            }
        }
    }
}
