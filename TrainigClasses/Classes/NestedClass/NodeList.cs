using System;

namespace NestedClass
{
    public class NodeList<T>
    {
        /// <summary>
        /// Neasted class for working with Node in linked list.
        /// We could write Node instead of Node<T>, because neasted class can see members(even private)
        /// of outer class.
        /// </summary>
        /// <typeparam name="T">Parameter of generalized type.</typeparam>
        public class Node
        {
            public Node(T data)
            {
                Data = data;
            }
            // Value of this node.
            public T Data { get; set; }
            // Reference to next node.
            public Node Next { get; set; }
        }

        Node head; // Head element of list.
        Node tail; // Tail element of list.
        int count;  // Count of elements in list.

        /// <summary>
        /// Adding new element to list.
        /// </summary>
        /// <param name="data">Value for adding to current list.</param>
        public void Add(T data)
        {
            Node node = new Node(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;

            count++;
        }
        /// <summary>
        /// Removing element from list.
        /// </summary>
        /// <param name="data">Value to remove.</param>
        /// <returns></returns>
        public bool Remove(T data)
        {
            Node current = head;
            Node previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // If node in head of tail
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.Next;

                        // If list is empty, tail is null
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }
    }
}
