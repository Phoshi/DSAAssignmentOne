using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace degreeCeremonyAssignment
{
    public class Node<LI>
    {
        private LI item;
        private Node<LI> next;

        public Node(LI item)
        {
            this.item = item;
            next = null;
        }

        public Node(LI item, Node<LI> next)
        {
            this.item = item;
            this.next = next;
        }

        /*
         * Compares the items in this Node with the given Node
         * item. Returns:
         * -1 if this Node item is less than the given one
         * 0 if the items are the same
         * 1 if this Node item is greater than the given one.
         */
        public int compareTo(LI item)
        {
            int returnVal = 999;
            String string1, string2;

            string1 = this.item.ToString();
            string2 = item.ToString();
            if (item is Int32)
            {
                returnVal = Int32.Parse(string1).CompareTo(Int32.Parse(string2));
            }
            else
            {
                returnVal = string1.CompareTo(string2);
            }
            return returnVal;
        }

        /**
         * Get the value of next
         *
         * @return the value of next
         */
        public Node<LI> getNext()
        {
            return next;
        }

        /**
         * Set the value of next
         *
         * @param next new value of next
         */
        public void setNext(Node<LI> next)
        {
            this.next = next;
        }

        /**
         * Get the value of item
         *
         * @return the value of item
         */
        public LI getItem()
        {
            return item;
        }

        /**
         * Set the value of item
         *
         * @param item new value of item
         */
        public void setItem(LI item)
        {
            this.item = item;
        }
    }
}
