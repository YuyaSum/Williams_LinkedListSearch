using System;
using System.Collections.Generic;
using System.Text;

namespace Williams_LinkedListSearch
{
    class LinkedList
    {
        private Node head;
        private Node tail;

        public Node Add(MetaData data)
        {
            // check for empty list. If empty add to head
            if (head == null)
            {
                head = new Node(data);
                tail = head;
                return head;
            }

            Node current = head;

            // if not empty, search the list for insert point
            while (current != null)
            {
                Node next = current.Next;
                // handle null tail
                if (next == null)
                {
                    if (current.Data.Name.CompareTo(data.Name) > 0)
                    {
                        Node temp = new Node(data);
                        temp.Next = head;
                        head = temp;
                        return temp;
                    }
                    else
                    {
                        tail.Next = new Node(data);
                        tail.Next.Previous = tail;
                        tail = tail.Next;
                        return tail;
                    }
                }

                // handle new head
                if (current.Data.Name.CompareTo(data.Name) > 0)
                {
                    Node temp = new Node(data);
                    temp.Next = head;
                    head = temp;
                    return temp;
                }

                // insert in middle
                if (current.Data.Name.CompareTo(data.Name) < 0 && next.Data.Name.CompareTo(data.Name) >= 0)
                {
                    current.Next = new Node(data);
                    current.Next.Previous = current;
                    current.Next.Next = next;
                    next.Previous = current.Next;
                    return current.Next;
                }
                current = current.Next;
            }
            return null;

        }

        public string Print()
        {
            // Remove later for encapsulation
            Node current = head;
            //string result = "";
            StringBuilder sb = new StringBuilder();
            while (current != null)
            {
                sb.Append(current.Data.Name + "\n");

                //result += current.Data + "\n";
                current = current.Next;
            }

            return sb.ToString();
        }

        public Node SameTimeSearch(string data) {
            Node forward = head;
            Node backwards = tail;

            // if not empty, search the list for insert point
            while (backwards != null)
            {
                if (backwards == null)
                {
                    return null;
                }

                if (forward.Data.Name.ToLower().CompareTo(data) == 0)
                {
                    return forward;
                }

                if (backwards.Data.Name.ToLower().CompareTo(data) == 0)
                {
                    return backwards;
                }

                backwards = backwards.Previous;
                forward = forward.Next;
            }

            return null;
        }

        public Node Head {
            get { return head; }
        }

        public Node[] Popular() {

            Node current = head;
            Node popularMale = head;
            Node popularFemale = head;
            char gender = 'M';
            Node[] nodes = new Node[2];

            while (current.Data.Gender == gender || current.Data.Gender != gender) {

                if (current.Data.Gender == gender)
                {
                    popularMale = current;
                }
                else {
                    popularFemale = current;
                }
                
                if (current.Next == null) {
                    break;
                }
                current = current.Next;
            }
            current = head;

            while (current != null)
            {
                if (current == null)
                {
                    return null;
                }

                if (popularMale.Data.Rank <= current.Data.Rank && current.Data.Gender == gender)
                {
                    popularMale = current;
                }

                if (popularFemale.Data.Rank <= current.Data.Rank && current.Data.Gender != gender)
                {
                    popularFemale = current;
                }

                if(current.Next == null)
                {
                    nodes[0] = popularFemale;
                    nodes[1] = popularMale;
                    return nodes;
                }
                current = current.Next;
            }

            return null;

        }
    }
}
