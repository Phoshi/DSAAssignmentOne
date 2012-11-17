using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace degreeCeremonyAssignment
{
    public class LList<LI>
    {
        private Node<LI> firstNode;
        private int currLength;

        public LList()
        {
            clear();
        }

        public void clear()
        {
            firstNode = null;
            currLength = 0;
        }

        /* inserts an item at the start of the list
         */
        public void insert(LI anItem)
        {
            Node<LI> newLink = new Node<LI>(anItem);
            if (!isEmpty())
            {
                newLink.setNext(getFirstNode());
            }
            setFirstNode(newLink);
            setCurrLength(getCurrLength() + 1);
        }

        /*
         * Inserts an item at a given position in the list
         * Returns true if the node was inserted
         * Returns false if the given position was invalid and therefore the item
         * could not be inserted
         */
        public bool insert(LI anItem, int position)
        {
            Node<LI> newLink;
            Node<LI> insertionPoint;
            bool success = true;

            if ((position >= 1) && (position <= getCurrLength() + 1))
            {
                newLink = new Node<LI>(anItem);
                if (isEmpty() || position == 1)
                {
                    insert(anItem);
                }
                else
                {
                    // Get the insertion point
                    // Link the new node to the chain at the insertion point
                    // Link the insertionpoint to the new node
                    // Increment current length
                    insertionPoint = getNodeAt(position - 1);
                    newLink.setNext(insertionPoint.getNext());
                    insertionPoint.setNext(newLink);
                    setCurrLength(getCurrLength() + 1);
                }
            }
            else
            {
                success = false;
            }
            return success;
        }

        /*
         * Checks that a given position is valid
         * i.e. that pos >0 AND <= currLength
         */
        private bool validPosition(int pos)
        {
            return (pos > 0) && (pos <= getCurrLength());
        }
        /*
         * Inserts an item at a position from a list dependent on the contents
         * of anItem
         */
        public bool sortedInsert(LI anItem)
        {
            Node<LI> insertionPoint;
            bool success = true;


            Node<LI> newLink = new Node<LI>(anItem);
            insertionPoint = getInsertionPoint(anItem);
            if (isEmpty() || insertionPoint == null)
            {
                insert(anItem);
            }
            else
            {
                newLink.setNext(insertionPoint.getNext());
                insertionPoint.setNext(newLink);
                setCurrLength(getCurrLength() + 1);
            }
            return success;
        }

        /*
         * Insertion point has been found when the item in the
         * currentNode is less than the given item
         */
        private Node<LI> getInsertionPoint(LI anItem)
        {
            Node<LI> insertionPoint = null;
            Node<LI> currentNode = getFirstNode();

            while ((currentNode != null) &&
                    (currentNode.compareTo(anItem) < 0))
            {
                insertionPoint = currentNode;
                currentNode = currentNode.getNext();
            }

            return insertionPoint;
        }


        /*
         * Looks for a given entry and removes it. Returns:
         *     true if the entry is removed
         *     false if the entry was not found
         */
        public bool remove(LI value)
        {
            bool success = false;
            int pos = 0;

            pos = find(value);
            if (pos > 0)
            {
                success = true;
                success = remove(pos);
            }
            return success;
        }
        /*
         * Removes an item at a particular position from a list
         */
        public bool remove(int position)
        {
            bool success = false;
            if (validPosition(position))
            {
                Node<LI> beforeNode = getFirstNode();
                if (position == 1)
                {
                    //remove head node
                    setFirstNode(beforeNode.getNext());
                }
                else
                {
                    for (int i = 1; i < position - 1; i++)
                    {
                        // Get the node before the one to be removed
                        beforeNode = beforeNode.getNext();
                    }
                    Node<LI> newLink = beforeNode.getNext();
                    beforeNode.setNext(newLink.getNext());
                }
                success = true;
                setCurrLength(getCurrLength() - 1);
            }
            return success;
        }

        public bool isEmpty()
        {
            return (getFirstNode() == null);
        }

        /*
        * Finds the position of an item in the list or -1 if the item
        * is not found
        */
        public int find(LI anItem)
        {

            if (isEmpty()) return -1;
            Node<LI> currentNode = getFirstNode();
            for (int i = 1; i <= getCurrLength(); i++)
            {
                if (currentNode.compareTo(anItem) == 0) return i;
                currentNode = currentNode.getNext();
            }
            return -1;
        }
        /*
         * Finds the node containing the given item
         * Returns the node or null if the item is not found
         */
        public Node<LI> findNode(LI anItem)
        {

            Node<LI> currentNode = getFirstNode();
            for (int i = 2; i <= getCurrLength(); i++)
            {
                currentNode = currentNode.getNext();
                if (currentNode.compareTo(anItem) == 0) return currentNode;
            }
            return null;

        }
        /*
         * Returns the item at a given position
         * If there was no item at the given pos, null is returned
         */
        public LI getItem(int pos)
        {
            LI item = default(LI);
            if (validPosition(pos))
            {
                Node<LI> currentNode = getNodeAt(pos);
                item = currentNode.getItem();
            }
            return item;
        }
        /*
         * Returns the Node at a given position
         * Returns null if the position doesn't exist
         */
        private Node<LI> getNodeAt(int pos)
        {
            Node<LI> currentNode = null;
            if (validPosition(pos))
            {
                currentNode = getFirstNode();
                for (int i = 2; i <= pos; i++)
                {
                    currentNode = currentNode.getNext();
                }
            }
            return currentNode;
        }

        /*
         * Get the value of currLength
         *
         * @return the value of currLength
         */
        public int getCurrLength()
        {
            return currLength;
        }

        /**
         * Set the value of currLength
         *
         * @param currLength new value of currLength
         */
        public void setCurrLength(int currLength)
        {
            this.currLength = currLength;
        }

        /**
         * Get the value of firstNode
         *
         * @return the value of firstNode
         */
        private Node<LI> getFirstNode()
        {
            return firstNode;
        }

        /**
         * Set the value of firstNode
         *
         * @param firstNode new value of firstNode
         */
        private void setFirstNode(Node<LI> firstNode)
        {
            this.firstNode = firstNode;
        }

        public void printList()
        {
            object item;
            Console.WriteLine("List length = " + getCurrLength());
            for (int i = 0; i < getCurrLength(); i++)
            {
                item = (object)getItem(i);
                Console.WriteLine(item.ToString());
            }
        }
    }
}
