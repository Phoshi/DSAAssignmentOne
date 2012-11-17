using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * This class holds guest details. In addition to accessor methods,
 * methods to display the guest details and compare for equality are included.
 *
 */
namespace degreeCeremonyAssignment
{
    public class Guest
    {
        String name;
        String emailAddress = null;

        /**
         *
         * @param name Guest name
         * @param emailAddress Guest email address
         */
        public Guest(String name, String emailAddress)
        {
            this.name = name;
            this.emailAddress = emailAddress;
        }

        public String getEmailAddress()
        {
            return emailAddress;
        }

        public void setEmailAddress(String emailAddress)
        {
            this.emailAddress = emailAddress;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }


        public override bool Equals(Object anItem)
        {
            bool equal = false;
            if (anItem is Guest)
            {
                Guest aGuest = (Guest)anItem;
                if (this.name.Equals(aGuest.getName())
                        && this.emailAddress.Equals(aGuest.getEmailAddress()))
                {
                    equal = true;
                }
            }
            return equal;

        }


        public override int GetHashCode()
        {
            int hash = 7;
            hash = 67 * hash + (this.name != null ? this.name.GetHashCode() : 0);
            hash = 67 * hash + (this.emailAddress != null ? this.emailAddress.GetHashCode() : 0);
            return hash;
        }


        public override String ToString(){
            return string.Format("{0} ({1})", getName(), getEmailAddress());
        }

        /**
         * Displays guest details
         */
        public void display()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
