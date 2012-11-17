using System;
using System.Linq;
using System.Text;
using LinkedList;

namespace degreeCeremonyAssignment
{
    /**
    *
    * @author Jane
    * This class stores details about a student.
    * Each student has a number, a name and a list of Guests.
    * You have to complete the addGuest method
    */
    public class Student
    {
        private int studentNum;
        private String name;
        private LinkedList<Guest> guestList;

        /**
         * Get the value of guestList
         *
         * @return the value of guestList
         */
        public LinkedList<Guest> getGuestList()
        {
            return guestList;
        }

        /**
         * Set the value of guestList
         *
         * @param guestList new value of guestList
         */
        public void setGuestList(LinkedList<Guest> guestList)
        {
            this.guestList = guestList;
        }


        /**
         * Get the value of name
         *
         * @return the value of name
         */
        public String getName()
        {
            return name;
        }

        /**
         * Set the value of name
         *
         * @param name new value of name
         */
        public void setName(String name)
        {
            this.name = name;
        }


        /**
         * Get the value of studentNum
         *
         * @return the value of studentNum
         */
        public int getStudentNum()
        {
            return studentNum;
        }

        /**
         * Set the value of studentNum
         *
         * @param studentNum new value of studentNum
         */
        public void setStudentNum(int studentNum)
        {
            this.studentNum = studentNum;
        }

        public Student(int number, String name)
        {
            this.studentNum = number;
            this.name = name;
            guestList = new LinkedList<Guest>(length: 4);
        }



        /**
         * This method displays the guest list on the console
         */
        public void displayGuestList()
        {
            foreach (var guest in guestList){
                Console.WriteLine("\t" + guest);
            }
        }



        public override int GetHashCode()
        {
            int hash = 5;
            hash = 67 * hash + this.studentNum;
            return hash;
        }


        public override bool Equals(Object anItem)
        {
            bool equal = false;
            if (anItem is Student)
            {
                Student aStudent = (Student)anItem;
                if (this.studentNum == aStudent.getStudentNum())
                {
                    equal = true;
                }
            }
            return equal;

        }

        /**
         * YOU HAVE TO COMPLETE THIS METHOD.
         * Adds a new guest to a guest list. Duplicate guests are not allowed
         * @param newGuest
         * @return true if guest is added
         *         false if the list is full or the guest is already on the list
         */
        public bool addGuest(Guest newGuest)
        {
            if (!this.getGuestList().Contains(newGuest))
            {
                try{
                    this.getGuestList().Add(newGuest);
                }
                catch(ArgumentOutOfRangeException){
                    return false;
                }
                return true;
            }
            return false;
        }

        /**
         * this method displays the student details, together with the guest list
         */
        public void display()
        {
            Console.WriteLine(this.ToString());
            this.displayGuestList();
        }


        public override String ToString(){
            return string.Format("{0}: {1}", getStudentNum(), getName());
        }
    }
}
